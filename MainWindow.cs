using System.Drawing;
using System.Net;
using System.Numerics;
using System.Windows.Forms;

namespace BezierSurface
{
    public partial class MainWindow : Form
    {
        private List<Triangle> _mesh = new();
        private Bitmap? _bmp;
        private List<Vector3> vertices = new();

        private double alpha = 30 / Math.PI * .5;
        private double beta = 5 / Math.PI * .5;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            RotateVerticies();
            DrawBitmap();
        }

        private void LoadData()
        {
            vertices = new List<Vector3>
            {
                new Vector3(-120, 120, 0),
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

        private void RotateVerticies()
        {
            List<Vector3> newVerticies = new();
            Matrix4x4 rotMatrixZ = Matrix4x4.CreateRotationZ((float)alpha);
            Matrix4x4 rotMatrixX = Matrix4x4.CreateRotationX((float)beta);

            foreach (var vertex in vertices)
            {
                newVerticies.Add(Vector3.Transform(Vector3.Transform(vertex, rotMatrixZ), rotMatrixX));
            }

            vertices = newVerticies;
        }

        private void DrawBitmap()
        {
            Bitmap _bmp = new(mainPictureBox.Width, mainPictureBox.Height);
            Graphics g = Graphics.FromImage(_bmp);

            g.ScaleTransform(1.0f, -1.0f);
            g.TranslateTransform(mainPictureBox.Width / 2, -mainPictureBox.Height / 2);

            g.Clear(Color.White);

            foreach (var vertex in vertices)
            {
                g.FillEllipse(Brushes.Black, vertex.X, vertex.Y, 10, 10);
            }


            mainPictureBox.Image = _bmp;
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            Pen pen = new Pen(Color.Black, 2); // Line color and thickness

            // Define start and end points of the line
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(100, 100);

            // Draw the line
            g.DrawLine(pen, startPoint, endPoint);

            //// Dispose of the Pen after use
            pen.Dispose();
        }
    }
}
