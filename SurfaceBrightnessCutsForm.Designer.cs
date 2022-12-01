namespace P3_Project
{
    partial class SurfaceBrightnessCutsForm
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
            this.panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.UploadedNoiseMAt_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panAndZoomPictureBox1
            // 
            this.panAndZoomPictureBox1.Location = new System.Drawing.Point(-2, -3);
            this.panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            this.panAndZoomPictureBox1.Size = new System.Drawing.Size(1030, 474);
            this.panAndZoomPictureBox1.TabIndex = 0;
            this.panAndZoomPictureBox1.TabStop = false;
            this.panAndZoomPictureBox1.Click += new System.EventHandler(this.panAndZoomPictureBox1_Click);
            // 
            // UploadedNoiseMAt_btn
            // 
            this.UploadedNoiseMAt_btn.Location = new System.Drawing.Point(12, 502);
            this.UploadedNoiseMAt_btn.Name = "UploadedNoiseMAt_btn";
            this.UploadedNoiseMAt_btn.Size = new System.Drawing.Size(284, 102);
            this.UploadedNoiseMAt_btn.TabIndex = 1;
            this.UploadedNoiseMAt_btn.Text = "Upload Camera Noise Image";
            this.UploadedNoiseMAt_btn.UseVisualStyleBackColor = true;
            this.UploadedNoiseMAt_btn.Click += new System.EventHandler(this.UploadedNoiseMAt_btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 502);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(284, 102);
            this.button2.TabIndex = 2;
            this.button2.Text = "Run Surface Brightness Cut";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(733, 502);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(284, 102);
            this.button3.TabIndex = 3;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SurfaceBrightnessCutsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 634);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.UploadedNoiseMAt_btn);
            this.Controls.Add(this.panAndZoomPictureBox1);
            this.Name = "SurfaceBrightnessCutsForm";
            this.Text = "SurfaceBrightnessCutsForm";
            this.Load += new System.EventHandler(this.SurfaceBrightnessCutsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
        private System.Windows.Forms.Button UploadedNoiseMAt_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}