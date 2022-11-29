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
    public partial class ImageProcessing : UserControl
    {
        public ImageProcessing()
        {
            InitializeComponent();
        }

        public void ImageProcessing_Load()
        {
            panAndZoomPictureBox1.Image = DarkRoom.Instance.getOutputImageAsImage();
            histogramBox1.GenerateHistograms(DarkRoom.Instance.getOutputImage(), 256);
        }

        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
