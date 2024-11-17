using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BezierSurface
{
    public class Triangle
    {
        public Vertex[] vertices;
        public Edge[] edges;

        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            vertices = new Vertex[3];
            vertices[0] = v1;
            vertices[1] = v2;
            vertices[2] = v3;

            edges = new Edge[3];
            edges[0] = new Edge(v1, v2);
            edges[1] = new Edge(v2, v3);
            edges[2] = new Edge(v3, v1);
        }

        public List<Edge>[] GetET()
        {
            List<Edge>[] et = new List<Edge>[ySize + 1];
            foreach (var edge in edges)
            {
                int index = edge.yMin - yMin;
                if(et[index] == null)
                {
                    et[index] = new List<Edge> { edge };
                    continue;
                }

                et[index].Add(edge);
            }
            return et;
        }

        public int ySize
        {
            get
            {
                float min = float.MaxValue;
                float max = float.MinValue;
                foreach (var v in vertices)
                {
                    if (v.P_rotated.Y < min) min = v.P_rotated.Y;
                    if (v.P_rotated.Y > max) max = v.P_rotated.Y;
                }
                return (int)Math.Ceiling(Math.Abs(max - min));
            }
        }

        public int yMin => (int)Math.Round(vertices.Min(v => v.P_rotated.Y));

        public void Fill(Bitmap bmp, int centerX, int centerY)
        {
            List<Edge>[] ET = GetET();
            List<Edge> AET = new List<Edge>();

            foreach (var e in edges)
            {
                e.xMin = e.v1.P_rotated.Y < e.v2.P_rotated.Y ? e.v1.P_rotated.X : e.v2.P_rotated.X;
            }

            for (int i = 0; i < ySize + 1; i++)
            {
                if (ET[i] != null)
                {
                    AET.AddRange(ET[i]);
                }

                AET = AET.OrderBy(e => e.xMin).ToList();

                if (AET.Count != 0)
                {
                    int x2, x1 = (int)Math.Round(AET[0].xMin);
                    if (AET.Count > 1)
                        x2 = (int)Math.Round(AET[1].xMin);
                    else
                        x2 = AET[0].xMax;

                    for (int k = x1; k <= x2; k++)
                    {
                        int adjX = k + centerX;
                        int adjY = i + yMin + centerY;
                        if (adjX >= bmp.Width || adjX < 0 || adjY >= bmp.Height || adjY < 0) continue;

                        bmp.SetPixel(
                            k + centerX,
                            i + yMin + centerY,
                            GetColor(k, i + yMin)
                            );
                    }
                }

                List<Edge> toRemove = new();
                foreach (var e in AET)
                {
                    if (e.yMax <= i + 1 + yMin)
                    {
                        toRemove.Add(e);
                        continue;
                    }
                    e.xMin += e.slope;
                }

                foreach (var e in toRemove)
                {
                    AET.Remove(e);
                }
            }
        }

        public Color GetColor(int x, int y)
        {
            Vector2 v1 = new(vertices[0].P_rotated.X, vertices[0].P_rotated.Y);
            Vector2 v2 = new(vertices[1].P_rotated.X, vertices[1].P_rotated.Y);
            Vector2 v3 = new(vertices[2].P_rotated.X, vertices[2].P_rotated.Y);

            Vector3 barCoords = GeometryHelpers.GetBaricentricCoords(x, y, v1, v2, v3);

            Vector3 normal = GeometryHelpers.InterpolatePoint(barCoords, vertices[0].N_rotated, vertices[1].N_rotated, vertices[2].N_rotated);
            normal = Vector3.Normalize(normal);

            float z = (float)GeometryHelpers.InterpolatePoint(barCoords, vertices[0].P_rotated.Z, vertices[1].P_rotated.Z, vertices[2].P_rotated.Z);
            double u = (double)GeometryHelpers.InterpolatePoint(barCoords, vertices[0].u, vertices[1].u, vertices[2].u);
            double v = (double)GeometryHelpers.InterpolatePoint(barCoords, vertices[0].v, vertices[1].v, vertices[2].v);
            u = Math.Clamp(u, 0, 1);
            v = Math.Clamp(v, 0, 1);

            if (Config.useNormalMap) 
            {
                Vector3 Pu = Vector3.Normalize(
                    vertices[0].Pu_rotated * barCoords.X + vertices[1].Pu_rotated * barCoords.Y + vertices[2].Pu_rotated * barCoords.Z);
                Vector3 Pv = Vector3.Normalize(
                    vertices[0].Pv_rotated * barCoords.X + vertices[1].Pv_rotated * barCoords.Y + vertices[2].Pv_rotated * barCoords.Z);

                Color mapColor = Config.normalMap!.GetPixel(
                    (int)((1-v) * (Config.normalMap.Width - 1)),
                    (int)((1-u) * (Config.normalMap.Height - 1))
                    );
                Vector3 normalFromMap = new((float)mapColor.R / 127.5f - 1, (float)mapColor.G / 127.5f - 1, (float)mapColor.B / 127.5f - 1);
                Matrix4x4 rotMatrix = new Matrix4x4(
                    Pu.X, Pu.Y, Pu.Z, 0,
                    Pv.X, Pv.Y, Pv.Z, 0,
                    normal.X, normal.Y, normal.Z, 0,
                    0, 0, 0, 0
                    );
                normal = Vector3.Normalize(Vector3.Transform(normalFromMap, rotMatrix));
            }

            Vector3 lightVector = Vector3.Normalize(GeometryHelpers.Rotate(LightSource.source) - new Vector3(x, y, z));
            Vector3 lightColor = new(Config.lightColor.R, Config.lightColor.G, Config.lightColor.B);
            lightColor /= 255.0f;

            Vector3 objColor;
            if (Config.texture == null)
            {
                objColor = new(Config.surfaceColor.R, Config.surfaceColor.G, Config.surfaceColor.B);
            }
            else
            {
                Color pixelColor = Config.texture.GetPixel(
                    (int)((1-v) * (Config.texture.Width - 1)),
                    (int)((1-u) * (Config.texture.Height - 1))
                    );
                objColor = new(pixelColor.R, pixelColor.G, pixelColor.B);
            }
            objColor /= 255.0f;

            Vector3 V = new(0, 0, 1);
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(lightVector, normal) * normal - lightVector);

            float cosNL = Math.Max(Vector3.Dot(normal, lightVector), 0);
            float cosVR = Math.Max(Vector3.Dot(V, R), 0);

            Vector3 color = lightColor * objColor * (Config.kd * cosNL + Config.ks * (float)Math.Pow(cosVR, Config.m));
            return Color.FromArgb(255,
                (int)(Math.Clamp(color.X, 0, 1) * 255),
                (int)(Math.Clamp(color.Y, 0, 1) * 255),
                (int)(Math.Clamp(color.Z, 0, 1) * 255)
                );
        }
    }

    public class Vertex
    {
        public Vector3 P;
        public Vector3 Pu;
        public Vector3 Pv;
        public Vector3 N;

        public Vector3 P_rotated;
        public Vector3 Pu_rotated;
        public Vector3 Pv_rotated;
        public Vector3 N_rotated;

        public double u;
        public double v;

        public void Rotate(Matrix4x4 rotMatrixZ, Matrix4x4 rotMatrixX)
        {
            P_rotated = GeometryHelpers.Rotate(P, rotMatrixZ, rotMatrixX);
            Pu_rotated = GeometryHelpers.Rotate(Pu, rotMatrixZ, rotMatrixX);
            Pv_rotated = GeometryHelpers.Rotate(Pv, rotMatrixZ, rotMatrixX);
            N_rotated = GeometryHelpers.Rotate(N, rotMatrixZ, rotMatrixX);
        }
    }

    public class Edge
    {
        public Vertex v1;
        public Vertex v2;
        public Edge? next;

        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int yMax => (int)Math.Round(v1.P_rotated.Y > v2.P_rotated.Y ? v1.P_rotated.Y : v2.P_rotated.Y);
        public int yMin => (int)Math.Round(v1.P_rotated.Y < v2.P_rotated.Y ? v1.P_rotated.Y : v2.P_rotated.Y);
        public int xMax => (int)Math.Round(v1.P_rotated.X > v2.P_rotated.X ? v1.P_rotated.X : v2.P_rotated.X);

        public float xMin;
        public float slope => (v2.P_rotated.X - v1.P_rotated.X) / (v2.P_rotated.Y - v1.P_rotated.Y);
    }
}
