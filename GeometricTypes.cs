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

        public List<Edge>[] ET
        {
            get
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

        public Color GetColor(int x, int y)
        {
            Vector2 p = new(x,y);
            Vector2 v1 = new(vertices[0].P.X, vertices[0].P.Y);
            Vector2 v2 = new(vertices[1].P.X, vertices[1].P.Y);
            Vector2 v3 = new(vertices[2].P.X, vertices[2].P.Y);

            Vector3 barCoords = new();
            float denom = (v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y);
            barCoords.X = ((v2.Y - v3.Y) * (p.X - v3.X) + (v3.X - v2.X) * (p.Y - v3.Y)) / denom;
            barCoords.Y = ((v3.Y - v1.Y) * (p.X - v3.X) + (v1.X - v3.X) * (p.Y - v3.Y)) / denom;
            barCoords.Z = 1 - barCoords.X - barCoords.Y;

            Vector3 normal = new(
                vertices[0].N.X * barCoords.X + vertices[1].N.X * barCoords.Y + vertices[2].N.X * barCoords.Z,
                vertices[0].N.Y * barCoords.X + vertices[1].N.Y * barCoords.Y + vertices[2].N.Y * barCoords.Z,
                vertices[0].N.Z * barCoords.X + vertices[1].N.Z * barCoords.Y + vertices[2].N.Z * barCoords.Z
                );
            normal = Vector3.Normalize(normal);
            float z = vertices[0].P.Z * barCoords.X + vertices[1].P.Z * barCoords.Y + vertices[2].P.Z * barCoords.Z;

            Vector3 lightSource = new(0, 0, 100);
            Vector3 lightVector = Vector3.Normalize(lightSource - new Vector3(x, y, z));
            Vector3 lightColor = new(1, 1, 1);

            float kd = 1f;
            float ks = 0.5f;
            float m = 10;

            Vector3 objColor = new(1, 0, 0);

            Vector3 V = new(0, 0, 1);
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(lightVector, normal) * normal - lightVector);

            float cosNL = Math.Max(Vector3.Dot(normal, lightVector), 0);
            float cosVR = Math.Max(Vector3.Dot(V, R), 0);

            Vector3 color = lightColor * objColor * (kd * cosNL + ks * (float)Math.Pow(cosVR, m));
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
