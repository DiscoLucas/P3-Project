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

        private void StarRecognitionControl_Load(object sender, EventArgs e)
        {

        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            PageManager.Instance.changePage("exportControl1");
            ExportControl expControl = (ExportControl)PageManager.Instance.getUserControl("exportControl1");
            expControl.showExportWindow();
        }
    }
}
