namespace P3_Project
{
    partial class ColorBalanceForm
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
            this.g_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.g_slider = new System.Windows.Forms.TrackBar();
            this.r_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Apply_btn = new System.Windows.Forms.Button();
            this.r_slider = new System.Windows.Forms.TrackBar();
            this.panAndZoomPictureBox1 = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.b_numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.b_trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.g_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // g_numericUpDown
            // 
            this.g_numericUpDown.Location = new System.Drawing.Point(30, 658);
            this.g_numericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.g_numericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.g_numericUpDown.Name = "g_numericUpDown";
            this.g_numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.g_numericUpDown.TabIndex = 17;
            this.g_numericUpDown.ValueChanged += new System.EventHandler(this.g_numericUpDown_ValueChanged);
            // 
            // g_slider
            // 
            this.g_slider.Location = new System.Drawing.Point(10, 596);
            this.g_slider.Maximum = 300;
            this.g_slider.Minimum = -300;
            this.g_slider.Name = "g_slider";
            this.g_slider.Size = new System.Drawing.Size(1008, 56);
            this.g_slider.TabIndex = 16;
            this.g_slider.Value = 1;
            this.g_slider.Scroll += new System.EventHandler(this.g_slider_Scroll);
            // 
            // r_numericUpDown
            // 
            this.r_numericUpDown.Location = new System.Drawing.Point(30, 568);
            this.r_numericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.r_numericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.r_numericUpDown.Name = "r_numericUpDown";
            this.r_numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.r_numericUpDown.TabIndex = 15;
            this.r_numericUpDown.ValueChanged += new System.EventHandler(this.r_numericUpDown_ValueChanged);
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(740, 773);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(278, 74);
            this.Apply_btn.TabIndex = 14;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.UseVisualStyleBackColor = true;
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // r_slider
            // 
            this.r_slider.Location = new System.Drawing.Point(10, 506);
            this.r_slider.Maximum = 300;
            this.r_slider.Minimum = -300;
            this.r_slider.Name = "r_slider";
            this.r_slider.Size = new System.Drawing.Size(1008, 56);
            this.r_slider.TabIndex = 13;
            this.r_slider.Value = 1;
            this.r_slider.Scroll += new System.EventHandler(this.r_slider_Scroll);
            // 
            // panAndZoomPictureBox1
            // 
            this.panAndZoomPictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.panAndZoomPictureBox1.Name = "panAndZoomPictureBox1";
            this.panAndZoomPictureBox1.Size = new System.Drawing.Size(1030, 474);
            this.panAndZoomPictureBox1.TabIndex = 12;
            this.panAndZoomPictureBox1.TabStop = false;
            this.panAndZoomPictureBox1.Click += new System.EventHandler(this.panAndZoomPictureBox1_Click);
            // 
            // b_numericUpDown1
            // 
            this.b_numericUpDown1.Location = new System.Drawing.Point(30, 748);
            this.b_numericUpDown1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.b_numericUpDown1.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.b_numericUpDown1.Name = "b_numericUpDown1";
            this.b_numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.b_numericUpDown1.TabIndex = 19;
            this.b_numericUpDown1.ValueChanged += new System.EventHandler(this.b_numericUpDown1_ValueChanged);
            // 
            // b_trackBar1
            // 
            this.b_trackBar1.Location = new System.Drawing.Point(10, 686);
            this.b_trackBar1.Maximum = 300;
            this.b_trackBar1.Minimum = -300;
            this.b_trackBar1.Name = "b_trackBar1";
            this.b_trackBar1.Size = new System.Drawing.Size(1008, 56);
            this.b_trackBar1.TabIndex = 18;
            this.b_trackBar1.Value = 1;
            this.b_trackBar1.Scroll += new System.EventHandler(this.b_trackBar1_Scroll);
            // 
            // ColorBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 850);
            this.Controls.Add(this.b_numericUpDown1);
            this.Controls.Add(this.b_trackBar1);
            this.Controls.Add(this.g_numericUpDown);
            this.Controls.Add(this.g_slider);
            this.Controls.Add(this.r_numericUpDown);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.r_slider);
            this.Controls.Add(this.panAndZoomPictureBox1);
            this.Name = "ColorBalanceForm";
            this.Text = "ColorBalanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.g_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panAndZoomPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown g_numericUpDown;
        private System.Windows.Forms.TrackBar g_slider;
        private System.Windows.Forms.NumericUpDown r_numericUpDown;
        private System.Windows.Forms.Button Apply_btn;
        private System.Windows.Forms.TrackBar r_slider;
        private Emgu.CV.UI.PanAndZoomPictureBox panAndZoomPictureBox1;
        private System.Windows.Forms.NumericUpDown b_numericUpDown1;
        private System.Windows.Forms.TrackBar b_trackBar1;
    }
}