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
    public partial class UserSettingsForm : Form
    {
        // Based on tutorial here: https://youtu.be/tIOWI0JBFkg
        public UserSettingsForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Runs the method for returning the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSettingsForm_Load(object sender, EventArgs e)
        {
            GetSettings();
        }
        /// <summary>
        /// Sets the elements on the settings form to be equal to the persistent settings,
        /// from Settings.settings
        /// </summary>
        public void GetSettings()
        {
            cudaCheckBox.Checked = Properties.Settings.Default.useGPU;
        }
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveSettings_Click(object sender, EventArgs e)
        {

        }

        private void cudaCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
