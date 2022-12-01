namespace P3_Project
{
    partial class ImageProcessing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.histogramBox1 = new Emgu.CV.UI.HistogramBox();
            this.SurfaceBrightnessCut = new System.Windows.Forms.Button();
            this.IntensityMapping_btn = new System.Windows.Forms.Button();
            this.Contrast_btn = new System.Windows.Forms.Button();
            this.Color_Balance_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panAndZoomPictureBox1
            // 
            this.panAndZoomPictureBox1.Location = new System.Drawing.Point(463, 0);
            this.panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            this.panAndZoomPictureBox1.Size = new System.Drawing.Size(746, 642);
            this.panAndZoomPictureBox1.TabIndex = 0;
            this.panAndZoomPictureBox1.TabStop = false;
            this.panAndZoomPictureBox1.Click += new System.EventHandler(this.panAndZoomPictureBox1_Click);
            // 
            // histogramBox1
            // 
            this.histogramBox1.Location = new System.Drawing.Point(3, 515);
            this.histogramBox1.Name = "histogramBox1";
            this.histogramBox1.Size = new System.Drawing.Size(461, 124);
            this.histogramBox1.TabIndex = 2;
            this.histogramBox1.TabStop = false;
            // 
            // SurfaceBrightnessCut
            // 
            this.SurfaceBrightnessCut.Location = new System.Drawing.Point(40, 34);
            this.SurfaceBrightnessCut.Name = "SurfaceBrightnessCut";
            this.SurfaceBrightnessCut.Size = new System.Drawing.Size(327, 70);
            this.SurfaceBrightnessCut.TabIndex = 3;
            this.SurfaceBrightnessCut.Text = "Surface Brightness Cuts";
            this.SurfaceBrightnessCut.UseVisualStyleBackColor = true;
            this.SurfaceBrightnessCut.Click += new System.EventHandler(this.button1_Click);
            // 
            // IntensityMapping_btn
            // 
            this.IntensityMapping_btn.Location = new System.Drawing.Point(40, 110);
            this.IntensityMapping_btn.Name = "IntensityMapping_btn";
            this.IntensityMapping_btn.Size = new System.Drawing.Size(327, 70);
            this.IntensityMapping_btn.TabIndex = 5;
            this.IntensityMapping_btn.Text = "Intensity Mapping";
            this.IntensityMapping_btn.UseVisualStyleBackColor = true;
            this.IntensityMapping_btn.Click += new System.EventHandler(this.IntensityMapping_btn_Click);
            // 
            // Contrast_btn
            // 
            this.Contrast_btn.Location = new System.Drawing.Point(40, 186);
            this.Contrast_btn.Name = "Contrast_btn";
            this.Contrast_btn.Size = new System.Drawing.Size(327, 70);
            this.Contrast_btn.TabIndex = 6;
            this.Contrast_btn.Text = "Contrast";
            this.Contrast_btn.UseVisualStyleBackColor = true;
            this.Contrast_btn.Click += new System.EventHandler(this.Contrast_btn_Click);
            // 
            // Color_Balance_btn
            // 
            this.Color_Balance_btn.Location = new System.Drawing.Point(40, 262);
            this.Color_Balance_btn.Name = "Color_Balance_btn";
            this.Color_Balance_btn.Size = new System.Drawing.Size(327, 70);
            this.Color_Balance_btn.TabIndex = 7;
            this.Color_Balance_btn.Text = "Color Balance";
            this.Color_Balance_btn.UseVisualStyleBackColor = true;
            this.Color_Balance_btn.Click += new System.EventHandler(this.Color_Balance_btn_Click);
            // 
            // ImageProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Color_Balance_btn);
            this.Controls.Add(this.Contrast_btn);
            this.Controls.Add(this.IntensityMapping_btn);
            this.Controls.Add(this.SurfaceBrightnessCut);
            this.Controls.Add(this.histogramBox1);
            this.Controls.Add(this.panAndZoomPictureBox1);
            this.Name = "ImageProcessing";
            this.Size = new System.Drawing.Size(1209, 642);
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
        private Emgu.CV.UI.HistogramBox histogramBox1;
        private System.Windows.Forms.Button SurfaceBrightnessCut;
        private System.Windows.Forms.Button IntensityMapping_btn;
        private System.Windows.Forms.Button Contrast_btn;
        private System.Windows.Forms.Button Color_Balance_btn;
    }
}
