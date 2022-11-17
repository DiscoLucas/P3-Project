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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveSettings = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveClose = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cudaCheckBox
            // 
            this.cudaCheckBox.AutoSize = true;
            this.cudaCheckBox.Location = new System.Drawing.Point(3, 3);
            this.cudaCheckBox.Name = "cudaCheckBox";
            this.cudaCheckBox.Size = new System.Drawing.Size(152, 24);
            this.cudaCheckBox.TabIndex = 0;
            this.cudaCheckBox.Text = "Use GPU (cuda)";
            this.cudaCheckBox.UseVisualStyleBackColor = true;
            this.cudaCheckBox.CheckedChanged += new System.EventHandler(this.cudaCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cudaCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.41878F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.58122F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 426);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // saveSettings
            // 
            this.saveSettings.AutoSize = true;
            this.saveSettings.Location = new System.Drawing.Point(3, 3);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(75, 30);
            this.saveSettings.TabIndex = 1;
            this.saveSettings.Text = "Save";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.saveSettings);
            this.flowLayoutPanel1.Controls.Add(this.saveClose);
            this.flowLayoutPanel1.Controls.Add(this.close);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 383);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 40);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // saveClose
            // 
            this.saveClose.AutoSize = true;
            this.saveClose.Location = new System.Drawing.Point(84, 3);
            this.saveClose.Name = "saveClose";
            this.saveClose.Size = new System.Drawing.Size(127, 30);
            this.saveClose.TabIndex = 2;
            this.saveClose.Text = "Save and close";
            this.saveClose.UseVisualStyleBackColor = true;
            this.saveClose.Click += new System.EventHandler(this.saveClose_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Location = new System.Drawing.Point(217, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(163, 30);
            this.close.TabIndex = 3;
            this.close.Text = "Close without saving";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserSettingsForm";
            this.Text = "UserSettingsForm";
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cudaCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button saveClose;
        private System.Windows.Forms.Button close;
    }
}