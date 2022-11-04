namespace P3_Project
{
    partial class StarRecognitionControl
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
            this.NextPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NextPage
            // 
            this.NextPage.Location = new System.Drawing.Point(405, 413);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(159, 94);
            this.NextPage.TabIndex = 0;
            this.NextPage.Text = "button1";
            this.NextPage.UseVisualStyleBackColor = true;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // StarRecognitionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NextPage);
            this.Name = "StarRecognitionControl";
            this.Size = new System.Drawing.Size(978, 519);
            this.Load += new System.EventHandler(this.StarRecognitionControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NextPage;
    }
}
