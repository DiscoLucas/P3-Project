using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PageManager.Instance.setForm(this);
            PageManager.Instance.changePage(startControl1);

        }

        private void menusControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageManager.Instance.changePage(startControl1);
        }

        public void ShowAllImportenComponets() {
            menuStrip1.Show();
            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageManager.Instance.changePage(settingsControl1);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void starRecognitionControl1_Load(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new UserSettingsForm();
            myForm.Show();
        }
    }
}
