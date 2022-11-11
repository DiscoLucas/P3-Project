namespace P3_Project
{
    partial class UserSettingsForm
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
            this.cudaCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cudaCheckBox
            // 
            this.cudaCheckBox.AutoSize = true;
            this.cudaCheckBox.Location = new System.Drawing.Point(350, 129);
            this.cudaCheckBox.Name = "cudaCheckBox";
            this.cudaCheckBox.Size = new System.Drawing.Size(152, 24);
            this.cudaCheckBox.TabIndex = 0;
            this.cudaCheckBox.Text = "Use GPU (cuda)";
            this.cudaCheckBox.UseVisualStyleBackColor = true;
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cudaCheckBox);
            this.Name = "UserSettingsForm";
            this.Text = "UserSettingsForm";
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cudaCheckBox;
    }
}