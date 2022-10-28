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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startControl1 = new P3_Project.StartControl();
            this.settingsControl1 = new P3_Project.SettingsControl();
            this.starRecognitionControl1 = new P3_Project.StarRecognitionControl();
            this.exportControl1 = new P3_Project.ExportControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // startControl1
            // 
            this.startControl1.AutoSize = true;
            this.startControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startControl1.BackColor = System.Drawing.Color.DarkRed;
            this.startControl1.Location = new System.Drawing.Point(1, 31);
            this.startControl1.Name = "startControl1";
            this.startControl1.Size = new System.Drawing.Size(495, 398);
            this.startControl1.TabIndex = 5;
            // 
            // settingsControl1
            // 
            this.settingsControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.settingsControl1.Location = new System.Drawing.Point(0, 31);
            this.settingsControl1.Name = "settingsControl1";
            this.settingsControl1.Size = new System.Drawing.Size(824, 416);
            this.settingsControl1.TabIndex = 4;
            // 
            // starRecognitionControl1
            // 
            this.starRecognitionControl1.Location = new System.Drawing.Point(0, 31);
            this.starRecognitionControl1.Name = "starRecognitionControl1";
            this.starRecognitionControl1.Size = new System.Drawing.Size(978, 519);
            this.starRecognitionControl1.TabIndex = 6;
            this.starRecognitionControl1.Load += new System.EventHandler(this.starRecognitionControl1_Load);
            // 
            // exportControl1
            // 
            this.exportControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.exportControl1.Location = new System.Drawing.Point(0, 31);
            this.exportControl1.Name = "exportControl1";
            this.exportControl1.Size = new System.Drawing.Size(996, 561);
            this.exportControl1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(825, 450);
            this.Controls.Add(this.exportControl1);
            this.Controls.Add(this.starRecognitionControl1);
            this.Controls.Add(this.startControl1);
            this.Controls.Add(this.settingsControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private SettingsControl settingsControl1;
        private StartControl startControl1;
        private StarRecognitionControl starRecognitionControl1;
        private ExportControl exportControl1;
    }
}