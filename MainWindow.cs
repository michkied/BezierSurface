using System.Drawing;
using System.Net;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BezierSurface
{
    public partial class MainWindow : Form
    {
        private List<Triangle> _mesh = new();
        private List<Vertex> _vertices = new();
        private List<Vector3> _controlPoints = new();
        private DirectBitmap mainBmp;

        public MainWindow()
        {
            InitializeComponent();
            precisionSlider.Value = Config.precision;
            alphaSlider.Value = (int)(Config.alpha * 180 / Math.PI);
            betaSlider.Value = (int)(Config.beta * 180 / Math.PI * 1.5);

            kdSlider.Value = (int)(Config.kd * 100);
            ksSlider.Value = (int)(Config.ks * 100);
            mSlider.Value = (int)Config.m;
            lightHeightSlider.Value = Config.lightHeight;

            meshColorIndicator.BackColor = Config.meshColor;
            surfColorIndicator.BackColor = Config.surfaceColor;
            lightColorIndicator.BackColor = Config.lightColor;

            mainBmp = new(mainPictureBox.Width, mainPictureBox.Height);
            Show();

            LoadControlData();
            LoadDefaultTexture();
            GenerateVerticies();
            RotateVerticies();
            GenerateMesh();

            Thread renderThread = new(RenderLoop);
            renderThread.IsBackground = true;
            renderThread.Start();
        }

        private void RenderLoop()
        {
            int time = 0;
            while (true)
            {
                lock (_mesh)
                {
                    DrawBitmap();
                }
                if (lightMoveBox.Checked && !showMeshBox.Checked)
                    LightSource.Move(ref time);
                Thread.Sleep(1000 / Config.refreshRate);
            }
        }

        private void LoadControlData()
        {
            openFileDialog.Reset();

            string CombinedPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\resources");
            openFileDialog.InitialDirectory = Path.GetFullPath(CombinedPath);
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(1);
            }

            using (var file = new StreamReader(openFileDialog.FileName))
            {
                string? line = file.ReadLine();
                for (int i = 0; i < 16; i++)
                {
                    if (line == null)
                    {
                        MessageBox.Show("Not enough lines in the shape file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }

                    var elems = line.Replace(',', '.').Split(' ');
                    if (elems.Count() != 3)
                    {
                        MessageBox.Show($"Line {i + 1} has invalid structure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }

                    try
                    {
                        float x = float.Parse(elems[0]);
                        float y = float.Parse(elems[1]);
                        float z = float.Parse(elems[2]);
                        _controlPoints.Add(new Vector3(x, y, z));
                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show($"Line {i + 1} is not a vlaid set of numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }

                    line = file.ReadLine();
                }
            }
        }

        private void LoadDefaultTexture()
        {
            try
            {
                Config.texture = new DirectBitmap("..\\..\\..\\resources\\texture.jpg");
                surfColorIndicator.BackColor = Color.Transparent;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load default texture.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerateVerticies()
        {
            List<Vector3> tempControlPointsX = new();
            List<Vector3> tempControlPointsY = new();

            for (int i = 0; i < 4; i++)
            {
                GeometryHelpers.GenerateCurve(
                    _controlPoints[i * 4],
                    _controlPoints[i * 4 + 1],
                    _controlPoints[i * 4 + 2],
                    _controlPoints[i * 4 + 3],
                    tempControlPointsX
                );

                GeometryHelpers.GenerateCurve(
                    _controlPoints[i],
                    _controlPoints[i + 4],
                    _controlPoints[i + 8],
                    _controlPoints[i + 12],
                    tempControlPointsY
                );
            }

            List<Vector3> surfacePoints = new();
            List<Vector3> tangentsU = new();
            List<Vector3> tangentsV = new();
            List<double> u = new();
            List<double> v = new();

            for (int i = 0; i < Config.precision; i++)
            {
                GeometryHelpers.GenerateCurve(
                    tempControlPointsX[i],
                    tempControlPointsX[i + Config.precision],
                    tempControlPointsX[i + 2 * Config.precision],
                    tempControlPointsX[i + 3 * Config.precision],
                    surfacePoints,
                    tangentsU,
                    u
                );

                GeometryHelpers.GenerateCurve(
                    tempControlPointsY[i],
                    tempControlPointsY[i + Config.precision],
                    tempControlPointsY[i + 2 * Config.precision],
                    tempControlPointsY[i + 3 * Config.precision],
                    null,
                    tangentsV,
                    v
                );
            }

            _vertices.Clear();
            for (int i = 0; i < surfacePoints.Count; i++)
            {
                int i2 = (i / Config.precision) + (i % Config.precision) * Config.precision;
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
        }

        private void RotateVerticies()
        {
            Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)Config.alpha);
            Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)Config.beta);

            foreach (var vertex in _vertices)
            {
                vertex.Rotate(rotMatrixZ, rotMatrixX);
            }
        }

        public void GenerateMesh()
        {
            _mesh.Clear();
            for (int i = 0; i < Config.precision - 1; i++)
            {
                for (int j = 0; j < Config.precision - 1; j++)
                {
                    int p1 = i * Config.precision + j;
                    int p2 = i * Config.precision + j + 1;
                    int p3 = (i + 1) * Config.precision + j;
                    int p4 = (i + 1) * Config.precision + j + 1;

                    _mesh.Add(new Triangle(_vertices[p1], _vertices[p2], _vertices[p3]));
                    _mesh.Add(new Triangle(_vertices[p2], _vertices[p4], _vertices[p3]));
                }
            }
        }

        private void DrawBitmap()
        {
            if (mainPictureBox.Width != mainBmp.Width || mainPictureBox.Height != mainBmp.Height)
            {
                mainBmp = new DirectBitmap(mainPictureBox.Width, mainPictureBox.Height);
            }

            int centerX = mainBmp.Width / 2;
            int centerY = mainBmp.Height / 2;
            Graphics g = Graphics.FromImage(mainBmp.Bitmap);

            g.Clear(Color.LightBlue);

            foreach (var triangle in _mesh)
            {
                if (showMeshBox.Checked)
                {
                    foreach (var e in triangle.edges)
                    {
                        g.DrawLine(new Pen(Config.meshColor), e.v1.P_rotated.X + centerX, e.v1.P_rotated.Y + centerY, e.v2.P_rotated.X + centerX, e.v2.P_rotated.Y + centerY);
                    }
                    continue;
                }

                triangle.Fill(mainBmp, centerX, centerY);
            }

            if (!showMeshBox.Checked)
            {
                Vector3 source = GeometryHelpers.Rotate(LightSource.source);
                g.FillEllipse(new SolidBrush(Config.lightColor), source.X + centerX - 10, source.Y + centerY - 10, 20, 20);
            }

            mainPictureBox.Image = mainBmp.Bitmap;
        }

        private void precisionSlider_Scroll(object sender, EventArgs e)
        {
            Config.precision = precisionSlider.Value;
            lock (_mesh)
            {
                GenerateVerticies();
                RotateVerticies();
                GenerateMesh();
            }
        }

        private void alphaSlider_Scroll(object sender, EventArgs e)
        {
            Config.alpha = (float)alphaSlider.Value / 180.0f * (float)Math.PI;
            lock (_mesh)
            {
                RotateVerticies();
            }
        }

        private void betaSlider_Scroll(object sender, EventArgs e)
        {
            Config.beta = (float)betaSlider.Value / 180.0f * (float)Math.PI / 1.5f;
            lock (_mesh)
            {
                RotateVerticies();
            }
        }

        private void kdSlider_Scroll(object sender, EventArgs e)
        {
            Config.kd = (float)kdSlider.Value / 100;
        }

        private void ksSlider_Scroll(object sender, EventArgs e)
        {
            Config.ks = (float)ksSlider.Value / 100;
        }

        private void mSlider_Scroll(object sender, EventArgs e)
        {
            Config.m = (float)mSlider.Value;
        }

        private void lightHeightSlider_Scroll(object sender, EventArgs e)
        {
            Config.lightHeight = lightHeightSlider.Value;
        }

        private void meshColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Reset();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                meshColorIndicator.BackColor = colorDialog.Color;
                Config.meshColor = colorDialog.Color;
            }
        }

        private void surfaceColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Reset();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                surfColorIndicator.BackColor = colorDialog.Color;
                Config.surfaceColor = colorDialog.Color;
                Config.texture = null;
            }
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Reset();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColorIndicator.BackColor = colorDialog.Color;
                Config.lightColor = colorDialog.Color;
            }
        }

        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();

            string CombinedPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\resources");
            openFileDialog.InitialDirectory = Path.GetFullPath(CombinedPath);
            openFileDialog.Filter = "Image files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Config.texture = new DirectBitmap(openFileDialog.FileName);
                surfColorIndicator.BackColor = Color.Transparent;
            }
        }

        private void loadNVMButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();

            string CombinedPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\resources");
            openFileDialog.InitialDirectory = Path.GetFullPath(CombinedPath);
            openFileDialog.Filter = "Image files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Config.normalMap = new DirectBitmap(openFileDialog.FileName);
                NVMSurfaceButton.Enabled = true;
            }
        }

        private void NVMSurfaceButton_CheckedChanged(object sender, EventArgs e)
        {
            Config.useNormalMap = NVMSurfaceButton.Checked;
        }
    }
}
