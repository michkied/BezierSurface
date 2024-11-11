using System.Windows.Forms;

namespace BezierSurface
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(1.0f, -1.0f);
            g.TranslateTransform(PropertiesBox.Width / 2, -PropertiesBox.Height / 2);

            Pen pen = new Pen(Color.Black, 2); // Line color and thickness

            // Define start and end points of the line
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(100, 100);

            // Draw the line
            g.DrawLine(pen, startPoint, endPoint);

            //// Dispose of the Pen after use
            //pen.Dispose();
        }
    }
}
