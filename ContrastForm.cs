using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Project
{
    public partial class ContrastForm : Form
    {
        Bitmap pictureShow = null;
        //min 0.1 max 3
        float alphaValue = 0;
        //min -255 max 255
        float betaValue = 0;
        public ContrastForm()
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
                    panAndZoomPictureBox1.Image = DarkRoom.Instance.contrast(img, alphaValue, betaValue).ToBitmap();
                }
        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> img = DarkRoom.Instance.getOutputImage().ToImage<Bgr, Byte>();
            Mat outputMat = DarkRoom.Instance.contrast(img, alphaValue, betaValue);
            DarkRoom.Instance.saveChangeToImage(outputMat);
            ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
            ip.ImageProcessing_Load();
            this.Close();
        }
        
        private void Alpha_slider_Scroll(object sender, EventArgs e)
        {
            alphaValue = (Alpha_slider.Value) / 100;
            Alpha_numericUpDown.Value = Alpha_slider.Value;
            updateImage();

        }

        private void Alpha_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            alphaValue = ((float)Alpha_numericUpDown.Value) / 100;
            Alpha_slider.Value = (int)Alpha_numericUpDown.Value;
            updateImage();
        }

        private void Beta_slider_Scroll(object sender, EventArgs e)
        {
            betaValue = (Beta_slider.Value) / 100;
            Beta_numericUpDown.Value = Beta_slider.Value;
            updateImage();
        }

        private void Beta_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            betaValue = ((float)Beta_numericUpDown.Value) / 100;
            Beta_slider.Value = (int)Beta_numericUpDown.Value;
            updateImage();
        }
    }
}
