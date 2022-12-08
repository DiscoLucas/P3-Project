namespace P3_Project
{
    partial class StartControl
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Add_to_Stack_btn = new System.Windows.Forms.Button();
            this.Add_files_btn = new System.Windows.Forms.Button();
            this.Select_threshold_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Back_to_Start = new System.Windows.Forms.Button();
            this.ImageListView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.48686F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.51313F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1035, 592);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.85139F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.14861F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel3.Controls.Add(this.Add_to_Stack_btn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Add_files_btn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Select_threshold_btn, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 439);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1029, 86);
            this.tableLayoutPanel3.TabIndex = 0;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // Add_to_Stack_btn
            // 
            this.Add_to_Stack_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Add_to_Stack_btn.Location = new System.Drawing.Point(226, 13);
            this.Add_to_Stack_btn.Name = "Add_to_Stack_btn";
            this.Add_to_Stack_btn.Size = new System.Drawing.Size(168, 59);
            this.Add_to_Stack_btn.TabIndex = 1;
            this.Add_to_Stack_btn.Text = "Add All Images to Stack";
            this.Add_to_Stack_btn.UseVisualStyleBackColor = true;
            this.Add_to_Stack_btn.Click += new System.EventHandler(this.Add_to_Stack_btn_Click);
            // 
            // Add_files_btn
            // 
            this.Add_files_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Add_files_btn.Location = new System.Drawing.Point(15, 13);
            this.Add_files_btn.Name = "Add_files_btn";
            this.Add_files_btn.Size = new System.Drawing.Size(168, 59);
            this.Add_files_btn.TabIndex = 0;
            this.Add_files_btn.Text = "Add files";
            this.Add_files_btn.UseVisualStyleBackColor = true;
            this.Add_files_btn.Click += new System.EventHandler(this.Add_files_btn_Click);
            // 
            // Select_threshold_btn
            // 
            this.Select_threshold_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Select_threshold_btn.Location = new System.Drawing.Point(800, 13);
            this.Select_threshold_btn.Name = "Select_threshold_btn";
            this.Select_threshold_btn.Size = new System.Drawing.Size(226, 59);
            this.Select_threshold_btn.TabIndex = 2;
            this.Select_threshold_btn.Text = "Select threshold";
            this.Select_threshold_btn.UseVisualStyleBackColor = true;
            this.Select_threshold_btn.Click += new System.EventHandler(this.Select_threshold_btn_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.2585F));
            this.tableLayoutPanel4.Controls.Add(this.Back_to_Start, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ImageListView, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16279F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.83721F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1029, 430);
            this.tableLayoutPanel4.TabIndex = 1;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // Back_to_Start
            // 
            this.Back_to_Start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Back_to_Start.Location = new System.Drawing.Point(3, 3);
            this.Back_to_Start.Name = "Back_to_Start";
            this.Back_to_Start.Size = new System.Drawing.Size(168, 42);
            this.Back_to_Start.TabIndex = 1;
            this.Back_to_Start.Text = "Back to Start";
            this.Back_to_Start.UseVisualStyleBackColor = true;
            this.Back_to_Start.Click += new System.EventHandler(this.Back_to_Start_Click);
            // 
            // ImageListView
            // 
            this.ImageListView.CheckBoxes = true;
            this.ImageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageListView.HideSelection = false;
            this.ImageListView.Location = new System.Drawing.Point(3, 51);
            this.ImageListView.MultiSelect = false;
            this.ImageListView.Name = "ImageListView";
            this.ImageListView.Size = new System.Drawing.Size(1023, 376);
            this.ImageListView.TabIndex = 2;
            this.ImageListView.UseCompatibleStateImageBehavior = false;
            this.ImageListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ImageListView_ItemCheck);
            this.ImageListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ImageListView_ItemChecked);
            this.ImageListView.SelectedIndexChanged += new System.EventHandler(this.ImageListView_SelectedIndexChanged);
            // 
            // StartControl
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "StartControl";
            this.Size = new System.Drawing.Size(1035, 592);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button Add_to_Stack_btn;
        private System.Windows.Forms.Button Add_files_btn;
        private System.Windows.Forms.Button Select_threshold_btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Back_to_Start;
        private System.Windows.Forms.ListView ImageListView;
    }
}
