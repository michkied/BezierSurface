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

        private double alpha = 0 / Math.PI * .5;
        private double beta = 0 / Math.PI * .5;

        private int precision;

        public MainWindow()
        {
            InitializeComponent();
            precision = precisionSlider.Value;

            LoadData();
            GenerateVerticies();
            DrawBitmap();
        }

        private void LoadData()
        {
            controlPoints = new List<Vector3>
            {
                new Vector3(-120, 120, 30),
                new Vector3(-40, 120, 0),
                new Vector3(40, 120, 0),
                new Vector3(120, 120, 0),
                new Vector3(-120, 40, 0),
                new Vector3(-40, 40, 0),
                new Vector3(40, 40, 0),
                new Vector3(120, 40, 0),
                new Vector3(-120, -40, 0),
                new Vector3(-40, -40, 0),
                new Vector3(40, -40, 0),
                new Vector3(120, -40, 0),
                new Vector3(-120, -120, 0),
                new Vector3(-40, -120, 0),
                new Vector3(40, -120, 0),
                new Vector3(120, -120, 0)
            };
        }

        private void GenerateVerticies()
        {
            List<Vector3> tempControlPointsX = new();
            List<Vector3> tempControlPointsY = new();

            for (int i = 0; i < 4; i++)
            {
                GenerateCurve(
                    controlPoints[i * 4],
                    controlPoints[i * 4 + 1],
                    controlPoints[i * 4 + 2],
                    controlPoints[i * 4 + 3],
                    tempControlPointsX
                );

                GenerateCurve(
                    controlPoints[i],
                    controlPoints[i + 4],
                    controlPoints[i + 8],
                    controlPoints[i + 12],
                    tempControlPointsY
                );
            }

            List<Vector3> surfacePoints = new();
            List<Vector3> tangentsU = new();
            List<Vector3> tangentsV = new();

            for (int i = 0; i < precision; i++)
            {
                GenerateCurve(
                    tempControlPointsX[i],
                    tempControlPointsX[i + precision],
                    tempControlPointsX[i + 2 * precision],
                    tempControlPointsX[i + 3 * precision],
                    surfacePoints,
                    tangentsV
                );

                GenerateCurve(
                    tempControlPointsY[i],
                    tempControlPointsY[i + precision],
                    tempControlPointsY[i + 2 * precision],
                    tempControlPointsY[i + 3 * precision],
                    null,
                    tangentsU
                );
            }

            List<Vertex> vertices = new();
            for (int i = 0; i < surfacePoints.Count; i++)
            {
                vertices.Add(
                    new Vertex
                    {
                        P = surfacePoints[i],
                        Pu = tangentsU[i],
                        Pv = tangentsV[i],
                        N = Vector3.Normalize(Vector3.Cross(tangentsU[i], tangentsV[i])),
                    }
                );
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

        private void GenerateCurve(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, List<Vector3>? points, List<Vector3>? tangents = null)
        {
            int numOfPoints = precision - 1;
            float d = 1.0f / (float)numOfPoints;
            float d2 = d * d;
            float d3 = d2 * d;

            Vector3 A0 = start;
            Vector3 A1 = 3 * (control1 - start);
            Vector3 A2 = 3 * (control2 - 2 * control1 + start);
            Vector3 A3 = end - 3 * control2 + 3 * control1 - start;

            Vector3 nextP0 = A0;
            Vector3 nextP1 = A3 * d3 + A2 * d2 + A1 * d;
            Vector3 nextP2 = 6 * A3 * d3 + 2 * A2 * d2;

            Vector3 nextPt0 = A1;
            Vector3 nextPt1 = 3 * A3 * d2 + 2 * A2 * d;

            // u = 0
            // v = arg
            points?.Add(nextP0);
            tangents?.Add(Vector3.Normalize(nextPt0));

            for (int step = 0; step < numOfPoints; step++)
            {
                nextP0 += nextP1;
                nextP1 += nextP2;
                nextP2 += 6 * A3 * d3;

                nextPt0 += nextPt1;
                nextPt1 += 6 * A3 * d2;

                // u += d
                points?.Add(nextP0);
                tangents?.Add(Vector3.Normalize(nextPt0));
            }
        }

        private void RotateVerticies(List<Vertex> vertices)
        {
            Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)alpha);
            Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)beta);

            foreach (var vertex in vertices)
            {
                vertex.P_rotated = Vector3.Transform(Vector3.Transform(vertex.P, rotMatrixZ), rotMatrixX);
                vertex.Pu_rotated = Vector3.Transform(Vector3.Transform(vertex.Pu, rotMatrixZ), rotMatrixX);
                vertex.Pv_rotated = Vector3.Transform(Vector3.Transform(vertex.Pv, rotMatrixZ), rotMatrixX);
                vertex.N_rotated = Vector3.Transform(Vector3.Transform(vertex.N, rotMatrixZ), rotMatrixX);
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
                g.DrawLine(Pens.Black, triangle.v1.P_rotated.X, triangle.v1.P_rotated.Y, triangle.v2.P_rotated.X, triangle.v2.P_rotated.Y);
                g.DrawLine(Pens.Black, triangle.v2.P_rotated.X, triangle.v2.P_rotated.Y, triangle.v3.P_rotated.X, triangle.v3.P_rotated.Y);
                g.DrawLine(Pens.Black, triangle.v3.P_rotated.X, triangle.v3.P_rotated.Y, triangle.v1.P_rotated.X, triangle.v1.P_rotated.Y);
            }


            mainPictureBox.Image = _bmp;
        }

        private void precisionSlider_Scroll(object sender, EventArgs e)
        {
            precision = precisionSlider.Value;
            _mesh.Clear();
            GenerateVerticies();
            DrawBitmap();
        }

        private void alphaSlider_Scroll(object sender, EventArgs e)
        {
            alpha = alphaSlider.Value / Math.PI * .5;
            _mesh.Clear();
            GenerateVerticies();
            DrawBitmap();
        }

        private void betaSlider_Scroll(object sender, EventArgs e)
        {
            beta = betaSlider.Value / Math.PI * .5;
            _mesh.Clear();
            GenerateVerticies();
            DrawBitmap();
        }
    }
}
