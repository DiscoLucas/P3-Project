using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Project
{
    public partial class ExportControl : UserControl
    {
        public ExportControl()
        {
            InitializeComponent();
        }

        public void showExportWindow()
        {
            //set the image in the picturebox
            //OutPutImage.Image = DarkRoom.Instance.getImage(0);
        }

        private void ExportImage_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileDir = saveFileDialog1.FileName;
                if (fileDir.Length > 0) {
                    Debug.WriteLine(fileDir);
                    //Image output = DarkRoom.Instance.getImage(0);
                   // output.Save(fileDir);
                }
                
            }
        }

        public void loadPage() {
            panAndZoomPictureBox1.Image = DarkRoom.Instance.getOutputImageAsImage();
        }
        private void OutPutImage_Click(object sender, EventArgs e)
        {

        }

        private void ExportControl_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            string logpathfile = "";
            if (PageManager.Instance.logpathBeenSet)
            {
                logpathfile = PageManager.Instance.logPath;
            }
            else
            {
                logpathfile = Directory.GetCurrentDirectory() + PageManager.Instance.cacheFolder + PageManager.Instance.logPath;
            }
            if (!File.Exists(logpathfile))
            {
                string message = "Log file have been delte  ";
                MessageBox.Show(message);
                //lav textbox
                return;
            }
            Debug.WriteLine("file read: " + logpathfile);
            string[] row = File.ReadAllLines(logpathfile);
            Debug.WriteLine(row[0]);
            DarkRoom.Instance.outputImage = new Mat(row[0].Split(',')[row[0].Split(',').Length - 1]);

            PageManager.Instance.changePage("imageProcessing1");
            ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
            ip.ImageProcessing_Load();
            ip.loadAllValues();
        }

        private void Export_btn_Click(object sender, EventArgs e)
        {
            Mat op = DarkRoom.Instance.getOutputImage();
            saveFileDialog1.Filter = saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Tiff Image|*.TIFF | Portable Network Graphic|*.PNG";
            if (op != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileDir = saveFileDialog1.FileName;
                    if (fileDir.Length > 0)
                    {
                        Debug.WriteLine(fileDir);
                        op.Save(fileDir);
                    }

                }
            }
            else
            {
                MessageBox.Show("No image to save");
            }
        }
    }
}
