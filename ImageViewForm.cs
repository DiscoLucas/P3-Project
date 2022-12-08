using Emgu.CV;
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
    public partial class ImageViewForm : Form
    {
        public ImageViewForm()
        {
            InitializeComponent();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Loaded_PreviewWindow(string path) {
            panAndZoomPictureBox1.Image = new Mat(path).ToBitmap();
        }
        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
