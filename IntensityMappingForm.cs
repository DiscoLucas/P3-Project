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
using System.Diagnostics;

namespace P3_Project
{
    public partial class IntensityMappingForm : Form
    {
        public float gammaValue = 1;
        Bitmap pictureShow = null;
        public IntensityMappingForm()
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
        private void Run_btn_Click(object sender, EventArgs e)
        {
             
        }

        private void Gamma_Scroll(object sender, EventArgs e)
        {
            
            gammaValue = (Gamma.Value+1) / 100;
            Debug.WriteLine("gV: " + gammaValue);
            Image images = pictureShow;
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(images).ToImage<Bgr, Byte>();
            panAndZoomPictureBox1.Image = DarkRoom.Instance.intensityMapping(img,gammaValue).ToBitmap();
            numericUpDown1.Value = Gamma.Value;



        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> img = DarkRoom.Instance.getOutputImage().ToImage<Bgr, Byte>();
            Mat outputMat = DarkRoom.Instance.intensityMapping(img, gammaValue);
            //DarkRoom.Instance.saveChangeToImage(outputMat);
            ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
            ip.ImageProcessing_Load();
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            gammaValue = (((float)numericUpDown1.Value) + 1) / 100;
            Image images = pictureShow;
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(images).ToImage<Bgr, Byte>();
            panAndZoomPictureBox1.Image = DarkRoom.Instance.intensityMapping(img, gammaValue).ToBitmap();
            Gamma.Value = (int)numericUpDown1.Value;

        }

        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
