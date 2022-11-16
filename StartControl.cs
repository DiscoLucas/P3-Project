﻿using Emgu.CV;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace P3_Project
{
    public partial class StartControl : UserControl
    {
        
        string nextPage = "starRecognitionControl1";
        public List<string> targetImages = new List<string>();
        string[] coomonFileFormats = { "JPEG", "JPG", "JPE", "PNG", "BMP" };
        string[] rawFileFormats = { "NEF", "CR2", "RAW" };
        public StartControl()
        {
            InitializeComponent();
            NextPage.Hide();
        }

        private void StartControl_Load(object sender, EventArgs e)
        {

        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void createPictureBox(Mat loadedImage) {
           
            PictureBox pb = new PictureBox();
            Bitmap lm = loadedImage.ToBitmap();
            pb.Height = lm.Height;
            pb.Width = lm.Width;
            pb.Image = lm;
            flowLayoutPanel1.Controls.Add(pb);

        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog.multiselect?view=windowsdesktop-6.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                int indexOFFile = 0;
                // Read the files
                foreach (String file in openFileDialog1.FileNames)
                {
                    
                    try
                    {
                       
                        bool found = false;
                        string[] fileString = file.Split('.');
                        string fileformat = fileString[fileString.Length - 1];
                        Debug.WriteLine(fileString[fileString.Length - 1]);
                        for (int i = 0; i < rawFileFormats.Length; i++) {
                            if (rawFileFormats[i].Equals(fileformat, StringComparison.CurrentCultureIgnoreCase)) {
                                
                                MagickImage magickimage = new MagickImage(file);
                                magickimage.Format = MagickFormat.Tiff;
                                magickimage.SetCompression(CompressionMethod.NoCompression);
                                magickimage.SetBitDepth(16);
                                string newImagePath = Directory.GetCurrentDirectory() + PageManager.Instance.cacheFolder;
                                bool exists = System.IO.Directory.Exists(newImagePath);

                                if (!exists)
                                    System.IO.Directory.CreateDirectory(newImagePath);
                                newImagePath += indexOFFile +".TIFF";
                                Debug.WriteLine(newImagePath);
                                magickimage.Write(newImagePath);
                                magickimage.Dispose();
                                targetImages.Add(newImagePath);
                                Mat loadedimage = new Mat(newImagePath);
                                createPictureBox(loadedimage);
                                found = true;
                                break;
                            }
                        }
                        for (int i = 0; i < coomonFileFormats.Length; i++)
                        {
                            if ( coomonFileFormats[i].Equals(fileformat, StringComparison.CurrentCultureIgnoreCase))
                            {

                                MagickImage magickimage = new MagickImage(file);
                                magickimage.Format = MagickFormat.Tiff;
                                magickimage.SetCompression(CompressionMethod.NoCompression);
                                magickimage.SetBitDepth(16);
                                string newImagePath = Directory.GetCurrentDirectory() + PageManager.Instance.cacheFolder;
                                bool exists = System.IO.Directory.Exists(newImagePath);

                                if (!exists)
                                    System.IO.Directory.CreateDirectory(newImagePath);
                                newImagePath += indexOFFile + ".TIFF";
                                Debug.WriteLine(newImagePath);
                                magickimage.Write(newImagePath);
                                magickimage.Dispose();
                                targetImages.Add(newImagePath);
                                Mat loadedimage = new Mat(newImagePath);
                                createPictureBox(loadedimage);
                                found = true;
                                break;
                            }
                        }
                        indexOFFile++;
                        GC.Collect(1);
                        GC.Collect(2);
                        if (!found) {
                            MessageBox.Show("the file format is not supported try another one"
                        );
                        }
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }

                Debug.WriteLine("Amount of Image loaded is: " + targetImages.Count);
                if (targetImages.Count > 1) {
                    NextPage.Show();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// Change To The next page when button is clickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, EventArgs e)
        {
            DarkRoom.Instance.addImages(targetImages);
            StarRecognitionControl sr = (StarRecognitionControl)PageManager.Instance.getUserControl(nextPage);
            sr.startRecognition();
            PageManager.Instance.changePage(nextPage);
            targetImages.Clear();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
