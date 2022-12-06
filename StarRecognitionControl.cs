using Emgu.CV;
using Emgu.CV.UI;
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
    public partial class StarRecognitionControl : UserControl
    {
        public StarRecognitionControl()
        {
            InitializeComponent();
        }

        public void startRecognition() {
            DarkRoom.Instance.detectStartsAndStack();
            Bitmap original = DarkRoom.Instance.getOutputImageAsImage();
            panAndZoomPictureBox1.Image = original;
            
        }
        private void StarRecognitionControl_Load(object sender, EventArgs e)
        {

        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            PageManager.Instance.changePage("imageProcessing1");
            ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
            ip.ImageProcessing_Load();
        }
    }
}
