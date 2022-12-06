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
    public partial class LightThreasholdControl : UserControl
    {
        Bitmap pictureShow = null;
        string nextPage = "starRecognitionControl1";
        public LightThreasholdControl()
        {
            InitializeComponent();
        }

        public void loadWindow()
        {
            Bitmap original = DarkRoom.Instance.getImage(0).ToBitmap();
            Bitmap resized = new Bitmap(original, new Size(original.Width / 6, original.Height / 6));
            panAndZoomPictureBox1.Image = resized;
            pictureShow = resized;
            updateImage();
        }
        void updateImage()
        {
            Image images = pictureShow;
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(images).ToImage<Bgr, Byte>();

            panAndZoomPictureBox1.Image = DarkRoom.Instance.getDetectionMaskFromImage(img.Mat, 0).ToBitmap();
        }
        private void Apply_btn_Click(object sender, EventArgs e)
        {
            StarRecognitionControl sr = (StarRecognitionControl)PageManager.Instance.getUserControl(nextPage);
            sr.startRecognition();
            PageManager.Instance.changePage(nextPage);
            
        }

        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Gamma_Scroll(object sender, EventArgs e)
        {
            DarkRoom.Instance.lightThreashold = (Gamma.Value) / 1000;
            numericUpDown1.Value = Gamma.Value;
            updateImage();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DarkRoom.Instance.lightThreashold = ((float)numericUpDown1.Value) / 1000;
            Gamma.Value = (int)numericUpDown1.Value;
            updateImage();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dt_label_Click(object sender, EventArgs e)
        {

        }
    }
}
