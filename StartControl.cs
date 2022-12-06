using Emgu.CV;
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

        
        string nextPage = "lightThreasholdControl1";
        public List<string> targetImages = new List<string>();
        public List<string> stackImages = new List<string>();
        int amountOfImage = 2;
        public StartControl()
        {
            InitializeComponent();
            Add_to_Stack_btn.Hide();
            Select_threshold_btn.Hide();
        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void createPictureBox(Mat loadedImage,FlowLayoutPanel fp)
        {

            PictureBox pb = new PictureBox();
            Bitmap lm = loadedImage.ToBitmap();
            pb.Height = lm.Height;
            pb.Width = lm.Width;
            pb.Image = lm;
            fp.Controls.Add(pb);
            if (stackImages.Count >= amountOfImage) {
                Select_threshold_btn.Show();
            }

        }

        private void loadfiles()
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
                        for (int i = 0; i < PageManager.Instance.rawFileFormats.Length; i++)
                        {
                            if (PageManager.Instance.rawFileFormats[i].Equals(fileformat, StringComparison.CurrentCultureIgnoreCase))
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
                                createPictureBox(loadedimage,Images_Sorting_fp);
                                found = true;
                                break;
                            }
                        }
                        for (int i = 0; i < PageManager.Instance.coomonFileFormats.Length; i++)
                        {
                            if (PageManager.Instance.coomonFileFormats[i].Equals(fileformat, StringComparison.CurrentCultureIgnoreCase))
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
                                createPictureBox(loadedimage,Images_Sorting_fp);
                                found = true;
                                break;
                            }
                        }
                        indexOFFile++;
                        GC.Collect(1);
                        GC.Collect(2);
                        if (!found)
                        {
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
            }
        }
        private void Add_files_btn_Click(object sender, EventArgs e)
        {
            loadfiles();
            if (targetImages.Count > 1)
            {
                Add_to_Stack_btn.Show();
            }
        }

        private void Add_to_Stack_btn_Click(object sender, EventArgs e)
        {
            Images_Sorting_fp.Controls.Clear();
            stackImages = targetImages;
            for (int i = 0; i < stackImages.Count; i++) {
                Mat loadedimage = new Mat(stackImages[i]);
                createPictureBox(loadedimage, ImageStack_fp);
            }
        }

        private void Select_threshold_btn_Click(object sender, EventArgs e)
        {
            DarkRoom.Instance.addImages(targetImages);
            LightThreasholdControl sr = (LightThreasholdControl)PageManager.Instance.getUserControl(nextPage);
            sr.loadWindow();
            PageManager.Instance.changePage(nextPage);
            targetImages.Clear();
        }

        private void Images_Sorting_fp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
