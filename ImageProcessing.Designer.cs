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
            // ImageProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
