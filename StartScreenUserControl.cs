using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Project
{
    public partial class StartScreenUserControl : UserControl
    {
        public StartScreenUserControl()
        {
            InitializeComponent();
        }

        private void New_Project_btn_Click(object sender, EventArgs e)
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
    }
}
