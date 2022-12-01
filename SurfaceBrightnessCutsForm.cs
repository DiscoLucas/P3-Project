using Emgu.CV;
using Emgu.CV.Structure;
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
    public partial class SurfaceBrightnessCutsForm : Form
    {
        Mat noiseImage = null;
        Mat outputMat = null;
        public SurfaceBrightnessCutsForm()
        {
            InitializeComponent();
        }

        private void UploadedNoiseMAt_btn_Click(object sender, EventArgs e)
        {

        }
        public void loadWindow()
        {
            Bitmap original = DarkRoom.Instance.getOutputImageAsImage();
            panAndZoomPictureBox1.Image = original;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> img = DarkRoom.Instance.getOutputImage().ToImage<Bgr, Byte>();
            Image<Gray, Byte> gray = null;
            if (noiseImage != null)
             gray = noiseImage.ToImage<Gray, Byte>();
            outputMat = DarkRoom.Instance.surfaceBrightnessCuts(img, gray);
            panAndZoomPictureBox1.Image = outputMat.ToBitmap();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DarkRoom.Instance.saveChangeToImage(outputMat);
            ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
            ip.ImageProcessing_Load();
            this.Close();
        }

        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SurfaceBrightnessCutsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
