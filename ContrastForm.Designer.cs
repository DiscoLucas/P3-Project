namespace P3_Project
{
    partial class ContrastForm
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
            this.Alpha_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Apply_btn = new System.Windows.Forms.Button();
            this.Alpha_slider = new System.Windows.Forms.TrackBar();
            this.panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.Beta_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Beta_slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Beta_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Beta_slider)).BeginInit();
            this.SuspendLayout();
            // 
            // Alpha_numericUpDown
            // 
            this.Alpha_numericUpDown.Location = new System.Drawing.Point(31, 567);
            this.Alpha_numericUpDown.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.Alpha_numericUpDown.Name = "Alpha_numericUpDown";
            this.Alpha_numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.Alpha_numericUpDown.TabIndex = 9;
            this.Alpha_numericUpDown.ValueChanged += new System.EventHandler(this.Alpha_numericUpDown_ValueChanged);
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(741, 698);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(278, 74);
            this.Apply_btn.TabIndex = 8;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.UseVisualStyleBackColor = true;
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Alpha_slider
            // 
            this.Alpha_slider.Location = new System.Drawing.Point(11, 505);
            this.Alpha_slider.Maximum = 300;
            this.Alpha_slider.Minimum = 1;
            this.Alpha_slider.Name = "Alpha_slider";
            this.Alpha_slider.Size = new System.Drawing.Size(1008, 56);
            this.Alpha_slider.TabIndex = 7;
            this.Alpha_slider.Value = 1;
            this.Alpha_slider.Scroll += new System.EventHandler(this.Alpha_slider_Scroll);
            // 
            // panAndZoomPictureBox1
            // 
            this.panAndZoomPictureBox1.Location = new System.Drawing.Point(0, -2);
            this.panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            this.panAndZoomPictureBox1.Size = new System.Drawing.Size(1030, 474);
            this.panAndZoomPictureBox1.TabIndex = 6;
            this.panAndZoomPictureBox1.TabStop = false;
            this.panAndZoomPictureBox1.Click += new System.EventHandler(this.panAndZoomPictureBox1_Click);
            // 
            // Beta_numericUpDown
            // 
            this.Beta_numericUpDown.Location = new System.Drawing.Point(32, 667);
            this.Beta_numericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Beta_numericUpDown.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.Beta_numericUpDown.Name = "Beta_numericUpDown";
            this.Beta_numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.Beta_numericUpDown.TabIndex = 11;
            this.Beta_numericUpDown.ValueChanged += new System.EventHandler(this.Beta_numericUpDown_ValueChanged);
            // 
            // Beta_slider
            // 
            this.Beta_slider.Location = new System.Drawing.Point(12, 605);
            this.Beta_slider.Maximum = 255;
            this.Beta_slider.Minimum = -255;
            this.Beta_slider.Name = "Beta_slider";
            this.Beta_slider.Size = new System.Drawing.Size(1008, 56);
            this.Beta_slider.TabIndex = 10;
            this.Beta_slider.Value = 1;
            this.Beta_slider.Scroll += new System.EventHandler(this.Beta_slider_Scroll);
            // 
            // ContrastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 784);
            this.Controls.Add(this.Beta_numericUpDown);
            this.Controls.Add(this.Beta_slider);
            this.Controls.Add(this.Alpha_numericUpDown);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.Alpha_slider);
            this.Controls.Add(this.panAndZoomPictureBox1);
            this.Name = "ContrastForm";
            this.Text = "ContrastForm";
            ((System.ComponentModel.ISupportInitialize)(this.Alpha_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Beta_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Beta_slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Alpha_numericUpDown;
        private System.Windows.Forms.Button Apply_btn;
        private System.Windows.Forms.TrackBar Alpha_slider;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
        private System.Windows.Forms.NumericUpDown Beta_numericUpDown;
        private System.Windows.Forms.TrackBar Beta_slider;
    }
}