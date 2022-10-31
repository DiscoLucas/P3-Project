namespace P3_Project
{
    partial class ExportControl
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
            this.ExportImage = new System.Windows.Forms.Button();
            this.TryAgain = new System.Windows.Forms.Button();
            this.OutPutImage = new Emgu.CV.UI.PanAndZoomPictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportImage
            // 
            this.ExportImage.Location = new System.Drawing.Point(32, 42);
            this.ExportImage.Name = "ExportImage";
            this.ExportImage.Size = new System.Drawing.Size(199, 79);
            this.ExportImage.TabIndex = 0;
            this.ExportImage.Text = "ExportImage";
            this.ExportImage.UseVisualStyleBackColor = true;
            this.ExportImage.Click += new System.EventHandler(this.ExportImage_Click);
            // 
            // TryAgain
            // 
            this.TryAgain.Location = new System.Drawing.Point(32, 146);
            this.TryAgain.Name = "TryAgain";
            this.TryAgain.Size = new System.Drawing.Size(199, 80);
            this.TryAgain.TabIndex = 1;
            this.TryAgain.Text = "TryAgain";
            this.TryAgain.UseMnemonic = false;
            this.TryAgain.UseVisualStyleBackColor = true;
            this.TryAgain.Click += new System.EventHandler(this.TryAgain_Click);
            // 
            // OutPutImage
            // 
            this.OutPutImage.Location = new System.Drawing.Point(292, 42);
            this.OutPutImage.Name = "OutPutImage";
            this.OutPutImage.Size = new System.Drawing.Size(652, 435);
            this.OutPutImage.TabIndex = 2;
            this.OutPutImage.TabStop = false;
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.OutPutImage);
            this.Controls.Add(this.TryAgain);
            this.Controls.Add(this.ExportImage);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(996, 561);
            ((System.ComponentModel.ISupportInitialize)(this.OutPutImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExportImage;
        private System.Windows.Forms.Button TryAgain;
        private Emgu.CV.UI.PanAndZoomPictureBox OutPutImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
