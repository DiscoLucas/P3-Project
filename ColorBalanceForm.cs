using Emgu.CV.Structure;
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
    public partial class ColorBalanceForm : Form
    {
        Bitmap pictureShow = null;
        float rValue = 0;
        float gValue = 0;
        float bValue = 0;

        public ColorBalanceForm()
        {
            InitializeComponent();
        }

        public void loadWindow()
        {
            Bitmap original = DarkRoom.Instance.getOutputImageAsImage();
            Bitmap resized = new Bitmap(original, new Size(original.Width / 2, original.Height / 2));
            panAndZoomPictureBox1.Image = resized;
            pictureShow = resized;
        }
        void updateImage()
        {
            Image images = pictureShow;
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(images).ToImage<Bgr, Byte>();
            panAndZoomPictureBox1.Image = DarkRoom.Instance.colorBalance(img, bValue, gValue, rValue).ToBitmap();
        }
        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void r_slider_Scroll(object sender, EventArgs e)
        {
            rValue = (float)r_slider.Value / 100;
            r_numericUpDown.Value = (decimal)r_slider.Value;
            updateImage();
        }

        private void r_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rValue = (float)r_numericUpDown.Value / 100;
            r_slider.Value = (int)r_numericUpDown.Value;
            updateImage();
        }

        private void g_slider_Scroll(object sender, EventArgs e)
        {
            gValue = (float)g_slider.Value / 100;
            g_numericUpDown.Value = (decimal)g_slider.Value;
            updateImage();
        }

        private void b_trackBar1_Scroll(object sender, EventArgs e)
        {
            bValue = (float)b_trackBar1.Value / 100;
            b_numericUpDown1.Value = (decimal)b_trackBar1.Value;
            updateImage();
        }

        private void g_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gValue = (float)g_numericUpDown.Value / 100;
            g_slider.Value = (int)g_numericUpDown.Value;
            updateImage();
        }

        private void b_numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bValue = (float)b_numericUpDown1.Value / 100;
            b_trackBar1.Value = (int)b_numericUpDown1.Value;
            updateImage();
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> img = DarkRoom.Instance.getOutputImage().ToImage<Bgr, Byte>();
            Mat outputMat = DarkRoom.Instance.colorBalance(img, bValue, gValue, rValue);
            //DarkRoom.Instance.saveChangeToImage(outputMat);
            ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
            ip.ImageProcessing_Load();
            this.Close();
        }
    }
}
