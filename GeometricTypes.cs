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
