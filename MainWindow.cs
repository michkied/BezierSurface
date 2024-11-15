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
        private List<Vertex> _vertices = new();
        //private Bitmap? _bmp;
        private List<Vector3> controlPoints = new();

        public static double alpha = 10.0 / 180 * Math.PI;
        public static double beta = 60.0 / 180 * Math.PI;

        public static float kd = 0.5f;
        public static float ks = 0.5f;
        public static float m = 10;
        public static int lightHeight = 100;

        public static bool drawMesh = false;

        public static Color meshColor = Color.Black;
        public static Color lightColor = Color.White;
        public static Color surfaceColor = Color.Red;

        public static Bitmap? texture;

        private int precision = 10;

        public MainWindow()
        {
            InitializeComponent();
            precisionSlider.Value = precision;
            alphaSlider.Value = (int)(alpha * 180 / Math.PI);
            betaSlider.Value = (int)(beta * 180 / Math.PI * 1.5);

            kdSlider.Value = (int)(kd * 100);
            ksSlider.Value = (int)(ks * 100);
            mSlider.Value = (int)m;
            lightHeightSlider.Value = lightHeight;

            showMeshBox.Checked = drawMesh;
            meshColorIndicator.BackColor = meshColor;
            surfColorIndicator.BackColor = surfaceColor;
            lightColorIndicator.BackColor = lightColor;

            LoadData();
            GenerateVerticies();

            Thread renderThread = new(RenderLoop);
            renderThread.IsBackground = true;
            renderThread.Start();
        }

        private void RenderLoop()
        {
            while (true)
            {
                lock (_mesh)
                {
                    DrawBitmap();
                }
                Thread.Sleep(1000 / 60);
            }
        }

        private void LoadData()
        {
            controlPoints = new List<Vector3>
            {
                new Vector3(-120, 120, -30),
                new Vector3(-40, 120, 0),
                new Vector3(40, 120, 0),
                new Vector3(120, 120, -30),
                new Vector3(-120, 40, 0),
                new Vector3(-40, 40, 0),
                new Vector3(40, 40, 0),
                new Vector3(120, 40, 0),
                new Vector3(-120, -40, 0),
                new Vector3(-40, -40, 0),
                new Vector3(40, -40, 0),
                new Vector3(120, -40, 0),
                new Vector3(-120, -120, -30),
                new Vector3(-40, -120, 0),
                new Vector3(40, -120, 0),
                new Vector3(120, -120, -30)
            };

            for (int i = 0; i < 16; i++)
            {
                controlPoints[i] *= 1.8f;
            }

            //controlPoints = new List<Vector3>
            //{
            //    new Vector3(-120, 120, 50),
            //    new Vector3(-40, 120, -20),
            //    new Vector3(40, 120, 20),
            //    new Vector3(120, 120, -30),

            //    new Vector3(-120, 40, -10),
            //    new Vector3(-40, 40, 40),
            //    new Vector3(40, 40, -80),
            //    new Vector3(120, 40, 30),

            //    new Vector3(-120, -40, 30),
            //    new Vector3(-40, -40, -30),
            //    new Vector3(40, -40, 40),
            //    new Vector3(120, -40, -10),

            //    new Vector3(-120, -120, -80),
            //    new Vector3(-40, -120, 30),
            //    new Vector3(40, -120, -20),
            //    new Vector3(120, -120, 50)
            //};
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
            List<double> u = new();
            List<double> v = new();

            for (int i = 0; i < precision; i++)
            {
                GenerateCurve(
                    tempControlPointsX[i],
                    tempControlPointsX[i + precision],
                    tempControlPointsX[i + 2 * precision],
                    tempControlPointsX[i + 3 * precision],
                    surfacePoints,
                    tangentsU,
                    u
                );

                GenerateCurve(
                    tempControlPointsY[i],
                    tempControlPointsY[i + precision],
                    tempControlPointsY[i + 2 * precision],
                    tempControlPointsY[i + 3 * precision],
                    null,
                    tangentsV,
                    v
                );
            }

            _vertices.Clear();
            for (int i = 0; i < surfacePoints.Count; i++)
            {
                int i2 = (i / precision) + (i % precision) * precision;
                _vertices.Add(
                    new Vertex
                    {
                        P = surfacePoints[i],
                        Pu = tangentsU[i],
                        Pv = tangentsV[i2],
                        N = Vector3.Normalize(
                            Vector3.Cross(
                                tangentsU[i],
                                tangentsV[i2]
                                )
                            ),
                        u = u[i],
                        v = v[i2]
                    }
                );
            }

            RotateVerticies();

            _mesh.Clear();
            for (int i = 0; i < precision - 1; i++)
            {
                for (int j = 0; j < precision - 1; j++)
                {
                    int p1 = i * precision + j;
                    int p2 = i * precision + j + 1;
                    int p3 = (i + 1) * precision + j;
                    int p4 = (i + 1) * precision + j + 1;

                    _mesh.Add(new Triangle(_vertices[p1], _vertices[p2], _vertices[p3]));
                    _mesh.Add(new Triangle(_vertices[p2], _vertices[p4], _vertices[p3]));
                }
            }
        }

        private void GenerateCurve(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, List<Vector3>? points, List<Vector3>? tangents = null, List<double>? indexes = null)
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
                indexes?.Add(step * d);
            }
            indexes?.Add(1);
        }

        private void RotateVerticies()
        {
            Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)alpha);
            Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)beta);

            foreach (var vertex in _vertices)
            {
                vertex.P_rotated = Vector3.Transform(Vector3.Transform(vertex.P, rotMatrixZ), rotMatrixX);
                vertex.Pu_rotated = Vector3.Transform(Vector3.Transform(vertex.Pu, rotMatrixZ), rotMatrixX);
                vertex.Pv_rotated = Vector3.Transform(Vector3.Transform(vertex.Pv, rotMatrixZ), rotMatrixX);
                vertex.N_rotated = Vector3.Transform(Vector3.Transform(vertex.N, rotMatrixZ), rotMatrixX);
            }
        }

        private void DrawBitmap()
        {
            Bitmap bmp = new(mainPictureBox.Width, mainPictureBox.Height);
            int centerX = bmp.Width / 2;
            int centerY = bmp.Height / 2;
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            foreach (var triangle in _mesh)
            {
                List<Edge>[] ET = triangle.ET;
                List<Edge> AET = new List<Edge>();

                foreach (var e in triangle.edges)
                {
                    e.xMin = e.v1.P_rotated.Y < e.v2.P_rotated.Y ? e.v1.P_rotated.X : e.v2.P_rotated.X;
                }

                for (int i = 0; i < triangle.ySize + 1; i++)
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
                            int adjY = i + triangle.yMin + centerY;
                            if (adjX >= bmp.Width || adjX < 0 || adjY >= bmp.Height || adjY < 0) continue;

                            bmp.SetPixel(
                                k + centerX,
                                i + triangle.yMin + centerY,
                                triangle.GetColor(k, i + triangle.yMin)
                                );
                        }
                    }

                    List<Edge> toRemove = new();
                    foreach (var e in AET)
                    {
                        if (e.yMax <= i + 1 + triangle.yMin)
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

                if (!drawMesh) continue;

                foreach (var e in triangle.edges)
                {
                    g.DrawLine(new Pen(meshColor), e.v1.P_rotated.X + centerX, e.v1.P_rotated.Y + centerY, e.v2.P_rotated.X + centerX, e.v2.P_rotated.Y + centerY);
                }
            }

            mainPictureBox.Image = bmp;
        }

        private void precisionSlider_Scroll(object sender, EventArgs e)
        {
            precision = precisionSlider.Value;
            lock (_mesh)
            {
                GenerateVerticies();
            }
        }

        private void alphaSlider_Scroll(object sender, EventArgs e)
        {
            alpha = (double)alphaSlider.Value / 180 * Math.PI;
            lock (_mesh)
            {
                RotateVerticies();
            }
        }

        private void betaSlider_Scroll(object sender, EventArgs e)
        {
            beta = (double)betaSlider.Value / 180 * Math.PI / 1.5;
            lock (_mesh)
            {
                RotateVerticies();
            }
        }

        private void kdSlider_Scroll(object sender, EventArgs e)
        {
            kd = (float)kdSlider.Value / 100;
        }

        private void ksSlider_Scroll(object sender, EventArgs e)
        {
            ks = (float)ksSlider.Value / 100;
        }

        private void mSlider_Scroll(object sender, EventArgs e)
        {
            m = (float)mSlider.Value;
        }

        private void showMeshBox_CheckedChanged(object sender, EventArgs e)
        {
            drawMesh = showMeshBox.Checked;
        }

        private void lightHeightSlider_Scroll(object sender, EventArgs e)
        {
            lightHeight = lightHeightSlider.Value;
        }

        private void meshColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Reset();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                meshColorIndicator.BackColor = colorDialog.Color;
                meshColor = colorDialog.Color;
            }
        }

        private void surfaceColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Reset();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                surfColorIndicator.BackColor = colorDialog.Color;
                surfaceColor = colorDialog.Color;
                texture = null;
            }
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Reset();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColorIndicator.BackColor = colorDialog.Color;
                lightColor = colorDialog.Color;
            }
        }

        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                texture = new Bitmap(openFileDialog.FileName);
                surfColorIndicator.BackColor = Color.Transparent;
            }
        }
    }
}
