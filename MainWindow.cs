using System.Drawing;
using System.Net;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Windows.Forms;

namespace BezierSurface
{
    public partial class MainWindow : Form
    {
        private List<Triangle> _mesh = new();
        private Bitmap? _bmp;
        private List<Vector3> controlPoints = new();

        private double alpha = 45 / Math.PI * .5;
        private double beta = 7 / Math.PI * .5;

        private int precision = 10;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            GenerateVerticies();
            DrawBitmap();
        }

        private void LoadData()
        {
            controlPoints = new List<Vector3>
            {
                new Vector3(-120, 120, -20),
                new Vector3(-40, 120, 0),
                new Vector3(40, 120, 0),
                new Vector3(120, 120, -20),
                new Vector3(-120, 40, 0),
                new Vector3(-40, 40, 20),
                new Vector3(40, 40, 20),
                new Vector3(120, 40, 0),
                new Vector3(-120, -40, 0),
                new Vector3(-40, -40, 20),
                new Vector3(40, -40, 20),
                new Vector3(120, -40, 0),
                new Vector3(-120, -120, -20),
                new Vector3(-40, -120, 0),
                new Vector3(40, -120, 0),
                new Vector3(120, -120, -20)
            };
        }

        private void GenerateVerticies()
        {
            List<Vector3> tempControlPoints = new();
            List<Vector3> surfacePoints = new();

            for (int i = 0; i < 4; i++)
            {
                Vector3 start = controlPoints[i * 4];
                Vector3 control1 = controlPoints[i * 4 + 1];
                Vector3 control2 = controlPoints[i * 4 + 2];
                Vector3 end = controlPoints[i * 4 + 3];

                GenerateCurve(start, control1, control2, end, tempControlPoints);
            }

            for (int i = 0; i < precision; i++)
            {
                Vector3 start = tempControlPoints[i];
                Vector3 control1 = tempControlPoints[i + precision];
                Vector3 control2 = tempControlPoints[i + 2 * precision];
                Vector3 end = tempControlPoints[i + 3 * precision];

                GenerateCurve(start, control1, control2, end, surfacePoints);
            }

            List<Vertex> vertices = new();
            foreach (var point in surfacePoints)
            {
                vertices.Add(new Vertex { P = point });
            }

            RotateVerticies(vertices);

            for (int i = 0; i < precision - 1; i++)
            {
                for (int j = 0; j < precision - 1; j++)
                {
                    int p1 = i * precision + j;
                    int p2 = i * precision + j + 1;
                    int p3 = (i + 1) * precision + j;
                    int p4 = (i + 1) * precision + j + 1;

                    _mesh.Add(new Triangle(vertices[p1], vertices[p2], vertices[p3]));
                    _mesh.Add(new Triangle(vertices[p2], vertices[p4], vertices[p3]));
                }
            }
        }

        private void GenerateCurve(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, List<Vector3> outList)
        {
            int numOfPoints = precision;
            double d = 1.0 / (double)numOfPoints;
            double d2 = d * d;
            double d3 = d2 * d;

            double A0X = start.X;
            double A0Y = start.Y;
            double A0Z = start.Z;

            double A1X = 3 * (control1.X - start.X);
            double A1Y = 3 * (control1.Y - start.Y);
            double A1Z = 3 * (control1.Z - start.Z);

            double A2X = 3 * (control2.X - 2 * control1.X + start.X);
            double A2Y = 3 * (control2.Y - 2 * control1.Y + start.Y);
            double A2Z = 3 * (control2.Z - 2 * control1.Z + start.Z);

            double A3X = end.X - 3 * control2.X + 3 * control1.X - start.X;
            double A3Y = end.Y - 3 * control2.Y + 3 * control1.Y - start.Y;
            double A3Z = end.Z - 3 * control2.Z + 3 * control1.Z - start.Z;

            double prevP0X = A0X;
            double prevP0Y = A0Y;
            double prevP0Z = A0Z;
            double prevP1X = A3X * d3 + A2X * d2 + A1X * d;
            double prevP1Y = A3Y * d3 + A2Y * d2 + A1Y * d;
            double prevP1Z = A3Z * d3 + A2Z * d2 + A1Z * d;
            double prevP2X = 6 * A3X * d3 + 2 * A2X * d2;
            double prevP2Y = 6 * A3Y * d3 + 2 * A2Y * d2;
            double prevP2Z = 6 * A3Z * d3 + 2 * A2Z * d2;

            outList.Add(new Vector3((float)A0X, (float)A0Y, (float)A0Z));

            for (int step = 1; step < numOfPoints; step++)
            {
                prevP0X = prevP0X + prevP1X;
                prevP0Y = prevP0Y + prevP1Y;
                prevP0Z = prevP0Z + prevP1Z;

                prevP1X = prevP1X + prevP2X;
                prevP1Y = prevP1Y + prevP2Y;
                prevP1Z = prevP1Z + prevP2Z;

                prevP2X = prevP2X + 6 * A3X * d3;
                prevP2Y = prevP2Y + 6 * A3Y * d3;
                prevP2Z = prevP2Z + 6 * A3Z * d3;

                outList.Add(new Vector3((float)prevP0X, (float)prevP0Y, (float)prevP0Z));
            }
        }

        private void RotateVerticies(List<Vertex> vertices)
        {
            Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)alpha);
            Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)beta);

            foreach (var vertex in vertices)
            {
                vertex.P = Vector3.Transform(Vector3.Transform(vertex.P, rotMatrixZ), rotMatrixX);
            }
        }

        private void DrawBitmap()
        {
            Bitmap _bmp = new(mainPictureBox.Width, mainPictureBox.Height);
            Graphics g = Graphics.FromImage(_bmp);

            g.ScaleTransform(1.0f, -1.0f);
            g.TranslateTransform(mainPictureBox.Width / 2, -mainPictureBox.Height / 2);

            g.Clear(Color.White);

            foreach (var triangle in _mesh)
            {
                g.DrawLine(Pens.Black, triangle.v1.P.X, triangle.v1.P.Y, triangle.v2.P.X, triangle.v2.P.Y);
                g.DrawLine(Pens.Black, triangle.v2.P.X, triangle.v2.P.Y, triangle.v3.P.X, triangle.v3.P.Y);
                g.DrawLine(Pens.Black, triangle.v3.P.X, triangle.v3.P.Y, triangle.v1.P.X, triangle.v1.P.Y);
            }


            mainPictureBox.Image = _bmp;
        }
    }
}
