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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PageManager.Instance.setForm(this);
            PageManager.Instance.changePage("startScreenUserControl1");

        }

        private void menusControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageManager.Instance.changePage("startScreenUserControl1");
        }

        public void ShowAllImportenComponets() {
            menuStrip1.Show();
            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PageManager.Instance.changePage(settingsControl1);
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mat op =DarkRoom.Instance.getOutputImage();
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
            else {
                MessageBox.Show("No image to save");
            }
        
            
        }

        private void startScreenUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gud tilgiv mig
            newProject();

        }

        private void imageProcessing1_Load(object sender, EventArgs e)
        {

        }
        public void newProject()
        {
            string newImagePath = Directory.GetCurrentDirectory() + PageManager.Instance.cacheFolder;
            string[] files = Directory.GetFiles(newImagePath);
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"{file} is deleted.");
            }
            PageManager.Instance.changePage("startControl1");
        }
        public void loadProject()
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
                string message = "Do projcet have been made ";
                MessageBox.Show(message);
                //lav textbox
                return;
            }
            Debug.WriteLine("file read: " + logpathfile);
            string[] row = File.ReadAllLines(logpathfile);
            Debug.WriteLine(row[0]);
            int colomCount = row[0].Split(',').Length;
            string[,] data = new string[row.Length, colomCount];
            for (int i = 0; i < row.Length; i++)
            {
                string[] colom = row[i].Split(',');
                Debug.WriteLine(colom.Length + " " + colomCount);
                for (int j = 0; j < colomCount; j++)
                {
                    Debug.WriteLine(colom[j]);
                    data[i, j] = colom[j];
                }
            }
            Debug.WriteLine("loading files " + data.GetLength(1) + " " + row.Length);
            int index = int.Parse(data[0, 0]);
            if (index == 1)
            {
                Mat[] mat = new Mat[row.Length];
                for (int i = 0; i < row.Length; i++)
                {
                    Debug.WriteLine(data[i, 1]);
                    mat[i] = new Mat(data[i, 1]);
                }
                DarkRoom.Instance.outputImage = DarkRoom.Instance.stackImages(mat);
                StarRecognitionControl sr = (StarRecognitionControl)PageManager.Instance.getUserControl("starRecognitionControl1");
                sr.loadImagePReview();
                PageManager.Instance.changePage("starRecognitionControl1");
            }
            else if (index == 2)
            {
                Mat mat = new Mat(data[0, 1]);
                DarkRoom.Instance.outputImage = mat;

                float r = float.Parse(data[1, 1]);
                float g = float.Parse(data[2, 1]);
                float b = float.Parse(data[3, 1]);
                float alpha = float.Parse(data[4, 1]);
                float beta = float.Parse(data[4, 1]);
                float gamma = float.Parse(data[5, 1]);
                bool sbc = (int.Parse(data[6, 1]) == 1);
                PageManager.Instance.changePage("imageProcessing1");
                ImageProcessing ip = (ImageProcessing)PageManager.Instance.getUserControl("imageProcessing1");
                ip.ImageProcessing_Load(r, g, b, alpha, beta, gamma, sbc);
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //undskyld gud jeg sønder !!!
            loadProject();
        }
    }
}
