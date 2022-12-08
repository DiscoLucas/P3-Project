namespace P3_Project
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.exportControl1 = new P3_Project.ExportControl();
            this.imageProcessing1 = new P3_Project.ImageProcessing();
            this.starRecognitionControl1 = new P3_Project.StarRecognitionControl();
            this.lightThreasholdControl1 = new P3_Project.LightThreasholdControl();
            this.startControl1 = new P3_Project.StartControl();
            this.startScreenUserControl1 = new P3_Project.StartScreenUserControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1179, 30);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 26);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Export";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // exportControl1
            // 
            this.exportControl1.BackColor = System.Drawing.Color.Transparent;
            this.exportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportControl1.Location = new System.Drawing.Point(0, 30);
            this.exportControl1.Name = "exportControl1";
            this.exportControl1.Size = new System.Drawing.Size(1179, 705);
            this.exportControl1.TabIndex = 9;
            // 
            // imageProcessing1
            // 
            this.imageProcessing1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageProcessing1.Location = new System.Drawing.Point(0, 30);
            this.imageProcessing1.Name = "imageProcessing1";
            this.imageProcessing1.Size = new System.Drawing.Size(1179, 705);
            this.imageProcessing1.TabIndex = 8;
            this.imageProcessing1.Load += new System.EventHandler(this.imageProcessing1_Load);
            // 
            // starRecognitionControl1
            // 
            this.starRecognitionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.starRecognitionControl1.Location = new System.Drawing.Point(0, 30);
            this.starRecognitionControl1.Name = "starRecognitionControl1";
            this.starRecognitionControl1.Size = new System.Drawing.Size(1179, 705);
            this.starRecognitionControl1.TabIndex = 7;
            // 
            // lightThreasholdControl1
            // 
            this.lightThreasholdControl1.BackColor = System.Drawing.Color.Transparent;
            this.lightThreasholdControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightThreasholdControl1.Location = new System.Drawing.Point(0, 30);
            this.lightThreasholdControl1.Name = "lightThreasholdControl1";
            this.lightThreasholdControl1.Size = new System.Drawing.Size(1179, 705);
            this.lightThreasholdControl1.TabIndex = 6;
            // 
            // startControl1
            // 
            this.startControl1.BackColor = System.Drawing.Color.Transparent;
            this.startControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startControl1.Location = new System.Drawing.Point(0, 30);
            this.startControl1.Name = "startControl1";
            this.startControl1.Size = new System.Drawing.Size(1179, 705);
            this.startControl1.TabIndex = 5;
            // 
            // startScreenUserControl1
            // 
            this.startScreenUserControl1.AutoSize = true;
            this.startScreenUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startScreenUserControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startScreenUserControl1.BackgroundImage")));
            this.startScreenUserControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startScreenUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startScreenUserControl1.Location = new System.Drawing.Point(0, 30);
            this.startScreenUserControl1.Name = "startScreenUserControl1";
            this.startScreenUserControl1.Size = new System.Drawing.Size(1179, 705);
            this.startScreenUserControl1.TabIndex = 4;
            this.startScreenUserControl1.Load += new System.EventHandler(this.startScreenUserControl1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1179, 735);
            this.Controls.Add(this.exportControl1);
            this.Controls.Add(this.imageProcessing1);
            this.Controls.Add(this.starRecognitionControl1);
            this.Controls.Add(this.lightThreasholdControl1);
            this.Controls.Add(this.startControl1);
            this.Controls.Add(this.startScreenUserControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Stack";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private StartScreenUserControl startScreenUserControl1;
        private StartControl startControl1;
        private LightThreasholdControl lightThreasholdControl1;
        private StarRecognitionControl starRecognitionControl1;
        private ImageProcessing imageProcessing1;
        private ExportControl exportControl1;
    }
}