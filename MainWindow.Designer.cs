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
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
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
            mainPictureBox.Paint += mainPictureBox_Paint;
            // 
            // PropertiesBox
            // 
            PropertiesBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PropertiesBox.Dock = DockStyle.Right;
            PropertiesBox.Location = new Point(500, 0);
            PropertiesBox.Margin = new Padding(10);
            PropertiesBox.Name = "PropertiesBox";
            PropertiesBox.Size = new Size(308, 501);
            PropertiesBox.TabIndex = 1;
            PropertiesBox.TabStop = false;
            PropertiesBox.Text = "Properties";
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
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mainPictureBox;
        private GroupBox PropertiesBox;
    }
}
