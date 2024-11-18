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
            splitContainer2 = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            ShapeBox = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label16 = new Label();
            label10 = new Label();
            precisionSlider = new TrackBar();
            alphaSlider = new TrackBar();
            betaSlider = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            meshColorButton = new Button();
            meshColorIndicator = new PictureBox();
            showMeshBox = new CheckBox();
            label12 = new Label();
            waveCheckBox = new CheckBox();
            SurfaceBox = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            mSlider = new TrackBar();
            ksSlider = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            kdSlider = new TrackBar();
            tableLayoutPanel4 = new TableLayoutPanel();
            loadTextureButton = new Button();
            surfaceColorButton = new Button();
            surfColorIndicator = new PictureBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            loadNVMButton = new Button();
            label11 = new Label();
            smoothSurfaceButton = new RadioButton();
            NVMSurfaceButton = new RadioButton();
            label9 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            label17 = new Label();
            label14 = new Label();
            label13 = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            lightColorButton = new Button();
            lightColorIndicator = new PictureBox();
            tableLayoutPanel9 = new TableLayoutPanel();
            lightHeightSlider = new TrackBar();
            label15 = new Label();
            lightMoveBox = new CheckBox();
            tableLayoutPanel10 = new TableLayoutPanel();
            mLSlider = new TrackBar();
            lightOmnidirButton = new RadioButton();
            lightDirButton = new RadioButton();
            colorDialog = new ColorDialog();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ShapeBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)precisionSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaSlider).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)meshColorIndicator).BeginInit();
            SurfaceBox.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdSlider).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)surfColorIndicator).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightColorIndicator).BeginInit();
            tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightHeightSlider).BeginInit();
            tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mLSlider).BeginInit();
            SuspendLayout();
            // 
            // mainPictureBox
            // 
            mainPictureBox.Dock = DockStyle.Fill;
            mainPictureBox.Location = new Point(0, 0);
            mainPictureBox.Margin = new Padding(3, 4, 3, 4);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(861, 869);
            mainPictureBox.TabIndex = 0;
            mainPictureBox.TabStop = false;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(3, 4, 3, 4);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(mainPictureBox);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer2.Size = new Size(1306, 869);
            splitContainer2.SplitterDistance = 861;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(ShapeBox, 0, 0);
            tableLayoutPanel2.Controls.Add(SurfaceBox, 0, 1);
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 267F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 364F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 226F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(440, 869);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // ShapeBox
            // 
            ShapeBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ShapeBox.Controls.Add(tableLayoutPanel1);
            ShapeBox.Dock = DockStyle.Fill;
            ShapeBox.Location = new Point(3, 4);
            ShapeBox.Margin = new Padding(3, 4, 3, 4);
            ShapeBox.Name = "ShapeBox";
            ShapeBox.Padding = new Padding(3, 4, 3, 4);
            ShapeBox.Size = new Size(434, 259);
            ShapeBox.TabIndex = 1;
            ShapeBox.TabStop = false;
            ShapeBox.Text = "Shape";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label16, 0, 4);
            tableLayoutPanel1.Controls.Add(label10, 0, 3);
            tableLayoutPanel1.Controls.Add(precisionSlider, 1, 0);
            tableLayoutPanel1.Controls.Add(alphaSlider, 1, 1);
            tableLayoutPanel1.Controls.Add(betaSlider, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel7, 1, 3);
            tableLayoutPanel1.Controls.Add(waveCheckBox, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 24);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.000494F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0005016F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0005016F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9985027F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999981F));
            tableLayoutPanel1.Size = new Size(428, 231);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Dock = DockStyle.Fill;
            label16.Location = new Point(3, 184);
            label16.Name = "label16";
            label16.Size = new Size(74, 47);
            label16.TabIndex = 10;
            label16.Text = "Wave";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 138);
            label10.Name = "label10";
            label10.Size = new Size(74, 46);
            label10.TabIndex = 8;
            label10.Text = "Mesh";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // precisionSlider
            // 
            precisionSlider.Dock = DockStyle.Fill;
            precisionSlider.Location = new Point(83, 4);
            precisionSlider.Margin = new Padding(3, 4, 3, 0);
            precisionSlider.Maximum = 50;
            precisionSlider.Minimum = 3;
            precisionSlider.Name = "precisionSlider";
            precisionSlider.Size = new Size(342, 42);
            precisionSlider.TabIndex = 2;
            precisionSlider.Value = 4;
            precisionSlider.Scroll += precisionSlider_Scroll;
            // 
            // alphaSlider
            // 
            alphaSlider.Dock = DockStyle.Fill;
            alphaSlider.Location = new Point(83, 50);
            alphaSlider.Margin = new Padding(3, 4, 3, 4);
            alphaSlider.Maximum = 45;
            alphaSlider.Minimum = -45;
            alphaSlider.Name = "alphaSlider";
            alphaSlider.Size = new Size(342, 38);
            alphaSlider.TabIndex = 3;
            alphaSlider.Scroll += alphaSlider_Scroll;
            // 
            // betaSlider
            // 
            betaSlider.Dock = DockStyle.Fill;
            betaSlider.Location = new Point(83, 96);
            betaSlider.Margin = new Padding(3, 4, 3, 4);
            betaSlider.Maximum = 90;
            betaSlider.Name = "betaSlider";
            betaSlider.Size = new Size(342, 38);
            betaSlider.TabIndex = 4;
            betaSlider.Scroll += betaSlider_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 46);
            label1.TabIndex = 5;
            label1.Text = "Precision";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 46);
            label2.Name = "label2";
            label2.Size = new Size(74, 46);
            label2.TabIndex = 6;
            label2.Text = "Alpha";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 92);
            label3.Name = "label3";
            label3.Size = new Size(74, 46);
            label3.TabIndex = 7;
            label3.Text = "Beta";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 4;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(meshColorButton, 3, 0);
            tableLayoutPanel7.Controls.Add(meshColorIndicator, 2, 0);
            tableLayoutPanel7.Controls.Add(showMeshBox, 0, 0);
            tableLayoutPanel7.Controls.Add(label12, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(83, 142);
            tableLayoutPanel7.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(342, 38);
            tableLayoutPanel7.TabIndex = 9;
            // 
            // meshColorButton
            // 
            meshColorButton.Dock = DockStyle.Fill;
            meshColorButton.Location = new Point(157, 4);
            meshColorButton.Margin = new Padding(3, 4, 3, 4);
            meshColorButton.Name = "meshColorButton";
            meshColorButton.Size = new Size(182, 30);
            meshColorButton.TabIndex = 1;
            meshColorButton.Text = "Pick a color";
            meshColorButton.UseVisualStyleBackColor = true;
            meshColorButton.Click += meshColorButton_Click;
            // 
            // meshColorIndicator
            // 
            meshColorIndicator.BackColor = Color.White;
            meshColorIndicator.BorderStyle = BorderStyle.FixedSingle;
            meshColorIndicator.Dock = DockStyle.Fill;
            meshColorIndicator.Location = new Point(106, 4);
            meshColorIndicator.Margin = new Padding(3, 4, 3, 4);
            meshColorIndicator.Name = "meshColorIndicator";
            meshColorIndicator.Size = new Size(45, 30);
            meshColorIndicator.TabIndex = 3;
            meshColorIndicator.TabStop = false;
            // 
            // showMeshBox
            // 
            showMeshBox.AutoSize = true;
            showMeshBox.Dock = DockStyle.Fill;
            showMeshBox.Location = new Point(3, 4);
            showMeshBox.Margin = new Padding(3, 4, 3, 4);
            showMeshBox.Name = "showMeshBox";
            showMeshBox.Size = new Size(17, 30);
            showMeshBox.TabIndex = 0;
            showMeshBox.Text = "checkBox1";
            showMeshBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(26, 0);
            label12.Name = "label12";
            label12.Size = new Size(74, 38);
            label12.TabIndex = 1;
            label12.Text = "Show";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // waveCheckBox
            // 
            waveCheckBox.AutoSize = true;
            waveCheckBox.Dock = DockStyle.Left;
            waveCheckBox.Location = new Point(83, 187);
            waveCheckBox.Name = "waveCheckBox";
            waveCheckBox.Size = new Size(18, 41);
            waveCheckBox.TabIndex = 11;
            waveCheckBox.UseVisualStyleBackColor = true;
            // 
            // SurfaceBox
            // 
            SurfaceBox.Controls.Add(tableLayoutPanel3);
            SurfaceBox.Dock = DockStyle.Fill;
            SurfaceBox.Location = new Point(3, 271);
            SurfaceBox.Margin = new Padding(3, 4, 3, 4);
            SurfaceBox.Name = "SurfaceBox";
            SurfaceBox.Padding = new Padding(3, 4, 3, 4);
            SurfaceBox.Size = new Size(434, 356);
            SurfaceBox.TabIndex = 2;
            SurfaceBox.TabStop = false;
            SurfaceBox.Text = "Surface";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label8, 0, 4);
            tableLayoutPanel3.Controls.Add(label7, 0, 3);
            tableLayoutPanel3.Controls.Add(mSlider, 1, 2);
            tableLayoutPanel3.Controls.Add(ksSlider, 1, 1);
            tableLayoutPanel3.Controls.Add(label4, 0, 0);
            tableLayoutPanel3.Controls.Add(label5, 0, 1);
            tableLayoutPanel3.Controls.Add(label6, 0, 2);
            tableLayoutPanel3.Controls.Add(kdSlider, 1, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 1, 4);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 24);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel3.Size = new Size(428, 328);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(3, 240);
            label8.Name = "label8";
            label8.Size = new Size(74, 88);
            label8.TabIndex = 20;
            label8.Text = "Details";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 180);
            label7.Name = "label7";
            label7.Size = new Size(74, 60);
            label7.TabIndex = 18;
            label7.Text = "Fill";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // mSlider
            // 
            mSlider.Dock = DockStyle.Fill;
            mSlider.Location = new Point(83, 124);
            mSlider.Margin = new Padding(3, 4, 3, 0);
            mSlider.Maximum = 100;
            mSlider.Name = "mSlider";
            mSlider.Size = new Size(342, 56);
            mSlider.TabIndex = 17;
            mSlider.Value = 4;
            mSlider.Scroll += mSlider_Scroll;
            // 
            // ksSlider
            // 
            ksSlider.Dock = DockStyle.Fill;
            ksSlider.Location = new Point(83, 64);
            ksSlider.Margin = new Padding(3, 4, 3, 0);
            ksSlider.Maximum = 100;
            ksSlider.Name = "ksSlider";
            ksSlider.Size = new Size(342, 56);
            ksSlider.TabIndex = 16;
            ksSlider.Value = 4;
            ksSlider.Scroll += ksSlider_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(74, 60);
            label4.TabIndex = 8;
            label4.Text = "kd";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 60);
            label5.Name = "label5";
            label5.Size = new Size(74, 60);
            label5.TabIndex = 9;
            label5.Text = "ks";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 120);
            label6.Name = "label6";
            label6.Size = new Size(74, 60);
            label6.TabIndex = 10;
            label6.Text = "m";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // kdSlider
            // 
            kdSlider.Dock = DockStyle.Fill;
            kdSlider.Location = new Point(83, 4);
            kdSlider.Margin = new Padding(3, 4, 3, 0);
            kdSlider.Maximum = 100;
            kdSlider.Name = "kdSlider";
            kdSlider.Size = new Size(342, 56);
            kdSlider.TabIndex = 15;
            kdSlider.Value = 4;
            kdSlider.Scroll += kdSlider_Scroll;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel4.Controls.Add(loadTextureButton, 2, 0);
            tableLayoutPanel4.Controls.Add(surfaceColorButton, 1, 0);
            tableLayoutPanel4.Controls.Add(surfColorIndicator, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(83, 184);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(342, 52);
            tableLayoutPanel4.TabIndex = 19;
            // 
            // loadTextureButton
            // 
            loadTextureButton.Dock = DockStyle.Fill;
            loadTextureButton.Location = new Point(199, 4);
            loadTextureButton.Margin = new Padding(3, 4, 3, 4);
            loadTextureButton.Name = "loadTextureButton";
            loadTextureButton.Size = new Size(140, 44);
            loadTextureButton.TabIndex = 1;
            loadTextureButton.Text = "Texture";
            loadTextureButton.UseVisualStyleBackColor = true;
            loadTextureButton.Click += loadTextureButton_Click;
            // 
            // surfaceColorButton
            // 
            surfaceColorButton.Dock = DockStyle.Fill;
            surfaceColorButton.Location = new Point(54, 4);
            surfaceColorButton.Margin = new Padding(3, 4, 3, 4);
            surfaceColorButton.Name = "surfaceColorButton";
            surfaceColorButton.Size = new Size(139, 44);
            surfaceColorButton.TabIndex = 0;
            surfaceColorButton.Text = "Color";
            surfaceColorButton.UseVisualStyleBackColor = true;
            surfaceColorButton.Click += surfaceColorButton_Click;
            // 
            // surfColorIndicator
            // 
            surfColorIndicator.BackColor = Color.White;
            surfColorIndicator.BorderStyle = BorderStyle.FixedSingle;
            surfColorIndicator.Dock = DockStyle.Fill;
            surfColorIndicator.Location = new Point(3, 4);
            surfColorIndicator.Margin = new Padding(3, 4, 3, 4);
            surfColorIndicator.Name = "surfColorIndicator";
            surfColorIndicator.Size = new Size(45, 44);
            surfColorIndicator.TabIndex = 2;
            surfColorIndicator.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(loadNVMButton, 2, 1);
            tableLayoutPanel5.Controls.Add(label11, 1, 1);
            tableLayoutPanel5.Controls.Add(smoothSurfaceButton, 0, 0);
            tableLayoutPanel5.Controls.Add(NVMSurfaceButton, 0, 1);
            tableLayoutPanel5.Controls.Add(label9, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(83, 244);
            tableLayoutPanel5.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(342, 80);
            tableLayoutPanel5.TabIndex = 21;
            // 
            // loadNVMButton
            // 
            loadNVMButton.Dock = DockStyle.Fill;
            loadNVMButton.Location = new Point(162, 44);
            loadNVMButton.Margin = new Padding(3, 4, 3, 4);
            loadNVMButton.Name = "loadNVMButton";
            loadNVMButton.Size = new Size(177, 32);
            loadNVMButton.TabIndex = 6;
            loadNVMButton.Text = "Load";
            loadNVMButton.UseVisualStyleBackColor = true;
            loadNVMButton.Click += loadNVMButton_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(26, 40);
            label11.Name = "label11";
            label11.Size = new Size(130, 40);
            label11.TabIndex = 4;
            label11.Text = "Normal Vector Map";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // smoothSurfaceButton
            // 
            smoothSurfaceButton.AutoSize = true;
            smoothSurfaceButton.Checked = true;
            smoothSurfaceButton.Dock = DockStyle.Fill;
            smoothSurfaceButton.Location = new Point(3, 4);
            smoothSurfaceButton.Margin = new Padding(3, 4, 3, 4);
            smoothSurfaceButton.Name = "smoothSurfaceButton";
            smoothSurfaceButton.Size = new Size(17, 32);
            smoothSurfaceButton.TabIndex = 0;
            smoothSurfaceButton.TabStop = true;
            smoothSurfaceButton.Text = "radioButton1";
            smoothSurfaceButton.UseVisualStyleBackColor = true;
            // 
            // NVMSurfaceButton
            // 
            NVMSurfaceButton.AutoSize = true;
            NVMSurfaceButton.Dock = DockStyle.Fill;
            NVMSurfaceButton.Enabled = false;
            NVMSurfaceButton.Location = new Point(3, 44);
            NVMSurfaceButton.Margin = new Padding(3, 4, 3, 4);
            NVMSurfaceButton.Name = "NVMSurfaceButton";
            NVMSurfaceButton.Size = new Size(17, 32);
            NVMSurfaceButton.TabIndex = 1;
            NVMSurfaceButton.Text = "radioButton2";
            NVMSurfaceButton.UseVisualStyleBackColor = true;
            NVMSurfaceButton.CheckedChanged += NVMSurfaceButton_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(26, 0);
            label9.Name = "label9";
            label9.Size = new Size(130, 40);
            label9.TabIndex = 2;
            label9.Text = "Smooth";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel6);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 635);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(434, 218);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lighting";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(label17, 0, 2);
            tableLayoutPanel6.Controls.Add(label14, 0, 1);
            tableLayoutPanel6.Controls.Add(label13, 0, 0);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel8, 1, 0);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel9, 1, 1);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel10, 1, 2);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 24);
            tableLayoutPanel6.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(428, 190);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Dock = DockStyle.Fill;
            label17.Location = new Point(3, 120);
            label17.Name = "label17";
            label17.Size = new Size(74, 70);
            label17.TabIndex = 23;
            label17.Text = "Mode";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(3, 60);
            label14.Name = "label14";
            label14.Size = new Size(74, 60);
            label14.TabIndex = 21;
            label14.Text = "Move";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Location = new Point(3, 0);
            label13.Name = "label13";
            label13.Size = new Size(74, 60);
            label13.TabIndex = 19;
            label13.Text = "Color";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(lightColorButton, 0, 0);
            tableLayoutPanel8.Controls.Add(lightColorIndicator, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(83, 4);
            tableLayoutPanel8.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(342, 52);
            tableLayoutPanel8.TabIndex = 20;
            // 
            // lightColorButton
            // 
            lightColorButton.Dock = DockStyle.Fill;
            lightColorButton.Location = new Point(54, 4);
            lightColorButton.Margin = new Padding(3, 4, 3, 4);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(285, 44);
            lightColorButton.TabIndex = 4;
            lightColorButton.Text = "Pick a color";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // lightColorIndicator
            // 
            lightColorIndicator.BackColor = Color.White;
            lightColorIndicator.BorderStyle = BorderStyle.FixedSingle;
            lightColorIndicator.Dock = DockStyle.Fill;
            lightColorIndicator.Location = new Point(3, 4);
            lightColorIndicator.Margin = new Padding(3, 4, 3, 4);
            lightColorIndicator.Name = "lightColorIndicator";
            lightColorIndicator.Size = new Size(45, 44);
            lightColorIndicator.TabIndex = 3;
            lightColorIndicator.TabStop = false;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 3;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel9.Controls.Add(lightHeightSlider, 2, 0);
            tableLayoutPanel9.Controls.Add(label15, 1, 0);
            tableLayoutPanel9.Controls.Add(lightMoveBox, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(83, 64);
            tableLayoutPanel9.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(342, 52);
            tableLayoutPanel9.TabIndex = 22;
            // 
            // lightHeightSlider
            // 
            lightHeightSlider.Dock = DockStyle.Fill;
            lightHeightSlider.Location = new Point(106, 4);
            lightHeightSlider.Margin = new Padding(3, 4, 3, 0);
            lightHeightSlider.Maximum = 200;
            lightHeightSlider.Minimum = 20;
            lightHeightSlider.Name = "lightHeightSlider";
            lightHeightSlider.Size = new Size(233, 48);
            lightHeightSlider.SmallChange = 5;
            lightHeightSlider.TabIndex = 23;
            lightHeightSlider.Value = 20;
            lightHeightSlider.Scroll += lightHeightSlider_Scroll;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Dock = DockStyle.Fill;
            label15.Location = new Point(26, 0);
            label15.Name = "label15";
            label15.Size = new Size(74, 52);
            label15.TabIndex = 22;
            label15.Text = "Height";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lightMoveBox
            // 
            lightMoveBox.AutoSize = true;
            lightMoveBox.Checked = true;
            lightMoveBox.CheckState = CheckState.Checked;
            lightMoveBox.Dock = DockStyle.Fill;
            lightMoveBox.Location = new Point(3, 4);
            lightMoveBox.Margin = new Padding(3, 4, 3, 4);
            lightMoveBox.Name = "lightMoveBox";
            lightMoveBox.Size = new Size(17, 44);
            lightMoveBox.TabIndex = 0;
            lightMoveBox.Text = "checkBox2";
            lightMoveBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 2;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.2748528F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.7251472F));
            tableLayoutPanel10.Controls.Add(mLSlider, 0, 1);
            tableLayoutPanel10.Controls.Add(lightOmnidirButton, 0, 0);
            tableLayoutPanel10.Controls.Add(lightDirButton, 0, 1);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(83, 123);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Size = new Size(342, 64);
            tableLayoutPanel10.TabIndex = 24;
            // 
            // mLSlider
            // 
            mLSlider.Dock = DockStyle.Fill;
            mLSlider.Location = new Point(151, 36);
            mLSlider.Margin = new Padding(3, 4, 3, 0);
            mLSlider.Maximum = 50;
            mLSlider.Minimum = 1;
            mLSlider.Name = "mLSlider";
            mLSlider.Size = new Size(188, 28);
            mLSlider.TabIndex = 18;
            mLSlider.Value = 5;
            mLSlider.Scroll += mLSlider_Scroll;
            // 
            // lightOmnidirButton
            // 
            lightOmnidirButton.AutoSize = true;
            lightOmnidirButton.Checked = true;
            lightOmnidirButton.Dock = DockStyle.Left;
            lightOmnidirButton.Location = new Point(3, 3);
            lightOmnidirButton.Name = "lightOmnidirButton";
            lightOmnidirButton.Size = new Size(137, 26);
            lightOmnidirButton.TabIndex = 0;
            lightOmnidirButton.TabStop = true;
            lightOmnidirButton.Text = "Omnidirectional";
            lightOmnidirButton.UseVisualStyleBackColor = true;
            lightOmnidirButton.CheckedChanged += lightOmnidirButton_CheckedChanged;
            // 
            // lightDirButton
            // 
            lightDirButton.AutoSize = true;
            lightDirButton.Dock = DockStyle.Left;
            lightDirButton.Location = new Point(3, 35);
            lightDirButton.Name = "lightDirButton";
            lightDirButton.Size = new Size(103, 26);
            lightDirButton.TabIndex = 1;
            lightDirButton.TabStop = true;
            lightDirButton.Text = "Directional";
            lightDirButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 869);
            Controls.Add(splitContainer2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainWindow";
            Text = "Bezier Surface Visualiser";
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ShapeBox.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)precisionSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaSlider).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)meshColorIndicator).EndInit();
            SurfaceBox.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdSlider).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)surfColorIndicator).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lightColorIndicator).EndInit();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightHeightSlider).EndInit();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mLSlider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mainPictureBox;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox ShapeBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TrackBar precisionSlider;
        private TrackBar alphaSlider;
        private TrackBar betaSlider;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox SurfaceBox;
        private TableLayoutPanel tableLayoutPanel3;
        private TrackBar kdSlider;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TrackBar mSlider;
        private TrackBar ksSlider;
        private ColorDialog colorDialog;
        private TableLayoutPanel tableLayoutPanel4;
        private Button surfaceColorButton;
        private Button loadTextureButton;
        private Label label8;
        private PictureBox surfColorIndicator;
        private TableLayoutPanel tableLayoutPanel5;
        private RadioButton smoothSurfaceButton;
        private RadioButton NVMSurfaceButton;
        private Button loadNVMButton;
        private Label label11;
        private Label label9;
        private Label label10;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private CheckBox showMeshBox;
        private Label label12;
        private Button meshColorButton;
        private PictureBox meshColorIndicator;
        private Label label13;
        private TableLayoutPanel tableLayoutPanel8;
        private PictureBox lightColorIndicator;
        private Button lightColorButton;
        private Label label14;
        private TableLayoutPanel tableLayoutPanel9;
        private CheckBox lightMoveBox;
        private TrackBar lightHeightSlider;
        private Label label15;
        private OpenFileDialog openFileDialog;
        private Label label16;
        private CheckBox waveCheckBox;
        private Label label17;
        private TableLayoutPanel tableLayoutPanel10;
        private RadioButton lightOmnidirButton;
        private RadioButton lightDirButton;
        private TrackBar mLSlider;
    }
}
