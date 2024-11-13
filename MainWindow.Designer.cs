namespace BezierSurface
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPictureBox = new PictureBox();
            PropertiesBox = new GroupBox();
            betaSlider = new TrackBar();
            alphaSlider = new TrackBar();
            precisionSlider = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            PropertiesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)betaSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precisionSlider).BeginInit();
            SuspendLayout();
            // 
            // mainPictureBox
            // 
            mainPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainPictureBox.Location = new Point(0, 0);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(500, 501);
            mainPictureBox.TabIndex = 0;
            mainPictureBox.TabStop = false;
            // 
            // PropertiesBox
            // 
            PropertiesBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PropertiesBox.Controls.Add(betaSlider);
            PropertiesBox.Controls.Add(alphaSlider);
            PropertiesBox.Controls.Add(precisionSlider);
            PropertiesBox.Dock = DockStyle.Right;
            PropertiesBox.Location = new Point(500, 0);
            PropertiesBox.Margin = new Padding(10);
            PropertiesBox.Name = "PropertiesBox";
            PropertiesBox.Size = new Size(308, 501);
            PropertiesBox.TabIndex = 1;
            PropertiesBox.TabStop = false;
            PropertiesBox.Text = "Properties";
            // 
            // betaSlider
            // 
            betaSlider.Location = new Point(6, 185);
            betaSlider.Maximum = 100;
            betaSlider.Name = "betaSlider";
            betaSlider.Size = new Size(296, 45);
            betaSlider.TabIndex = 4;
            betaSlider.Scroll += betaSlider_Scroll;
            // 
            // alphaSlider
            // 
            alphaSlider.Location = new Point(6, 105);
            alphaSlider.Maximum = 90;
            alphaSlider.Minimum = -90;
            alphaSlider.Name = "alphaSlider";
            alphaSlider.Size = new Size(296, 45);
            alphaSlider.TabIndex = 3;
            alphaSlider.Scroll += alphaSlider_Scroll;
            // 
            // precisionSlider
            // 
            precisionSlider.Location = new Point(6, 39);
            precisionSlider.Maximum = 50;
            precisionSlider.Minimum = 3;
            precisionSlider.Name = "precisionSlider";
            precisionSlider.Size = new Size(296, 45);
            precisionSlider.TabIndex = 2;
            precisionSlider.Value = 4;
            precisionSlider.Scroll += precisionSlider_Scroll;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 501);
            Controls.Add(PropertiesBox);
            Controls.Add(mainPictureBox);
            Name = "MainWindow";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            PropertiesBox.ResumeLayout(false);
            PropertiesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)betaSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)precisionSlider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mainPictureBox;
        private GroupBox PropertiesBox;
        private TrackBar betaSlider;
        private TrackBar alphaSlider;
        private TrackBar precisionSlider;
    }
}
