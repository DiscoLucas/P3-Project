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
    public partial class ExportControl : UserControl
    {
        public ExportControl()
        {
            InitializeComponent();
        }

        public void showExportWindow()
        {
            //set the image in the picturebox
            OutPutImage.Image = DarkRoom.Instance.getImage(0);
        }

        private void ExportImage_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileDir = saveFileDialog1.FileName;
                if (fileDir.Length > 0) {
                    Debug.WriteLine(fileDir);
                    Image output = DarkRoom.Instance.getImage(0);
                    output.Save(fileDir);
                }
                
            }
        }

        private void TryAgain_Click(object sender, EventArgs e)
        {
            DarkRoom.Instance.cleanDarkRoom();
            PageManager.Instance.changePage("startControl1");
        }
    }
}
