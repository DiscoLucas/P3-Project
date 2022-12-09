using Emgu.CV;
using Emgu.CV.Structure;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace P3_Project
{
    public partial class ImageProcessing : UserControl
    {
        Bitmap resizeImg = null;
        float rValue = 1;
        float gValue = 1;
        float bValue = 1;
        //min 0.1 max 3
        float alphaValue = 1;
        //min -255 max 255
        float betaValue = 0;
        bool surfaceBrightnesscuts = false;
        public float gammaValue = 1;
        Image<Bgr, Byte> output;
        Mat noiseImage = null;
        public ImageProcessing()
        {
            InitializeComponent();
        }

        public void ImageProcessing_Load()
        {
            resizeImg = DarkRoom.Instance.getOutputImageAsImage(0.5f);
            panAndZoomPictureBox1.Image = resizeImg;
            output = DarkRoom.Instance.GetMatFromSDImage(resizeImg).ToImage<Bgr, Byte>();
            updateChart(output);
            Color[] plattet ={ Color.Red,Color.Green,Color.Blue};
            RGBLINECHART.PaletteCustomColors = plattet;

        }
        public void ImageProcessing_Load(float r, float g, float b, float alpha, float beta, float gamma, bool sbc)
        {
            rValue = r;
            gValue = g;
            bValue = b;
            alphaValue = alpha;
            betaValue = beta;
            gammaValue = gamma;
            surfaceBrightnesscuts = sbc;
            ImageProcessing_Load();
            loadAllValues();
        }

        public void loadAllValues()
        {
            updateSliderAndBox(r_slider, r_numericUpDown, rValue, 100);
            updateSliderAndBox(g_slider, g_numericUpDown, gValue, 100);
            updateSliderAndBox(b_slider, b_numericUpDown, bValue, 100);
            updateSliderAndBox(Alpha_slider, numericUpDown3, alphaValue, 100);
            updateSliderAndBox(trackBar3, numericUpDown4, betaValue, 100);
            updateSliderAndBox(Gamma_slider, slider_numericUpDown, gammaValue, 100);

            updateImage();
        }

        void updateSliderAndBox(TrackBar slider,NumericUpDown box,float value, float multiply ) {
            int min = slider.Minimum;
            int max = slider.Maximum;
            int newValue = (int)(value * multiply);
            if (newValue > max) {
                newValue = max;
            }else if (newValue < min)
            {
                newValue = min;
            }

            slider.Value = newValue;
            
            box.Value = (decimal)(value * multiply);
        }
        private void panAndZoomPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SurfaceBrightnessCutsForm sbc = new SurfaceBrightnessCutsForm();
            sbc.loadWindow();
            sbc.Show();
        }
        
        private void IntensityMapping_btn_Click(object sender, EventArgs e)
        {
            IntensityMappingForm imf = new IntensityMappingForm();
            imf.loadWindow();
            imf.Show();
        }

        private void Contrast_btn_Click(object sender, EventArgs e)
        {
            ContrastForm cf = new ContrastForm();
            cf.loadWindow();
            cf.Show();
        }

        private void Color_Balance_btn_Click(object sender, EventArgs e)
        {
            ColorBalanceForm cbf = new ColorBalanceForm();
            cbf.loadWindow();
            cbf.Show();
        }
            Image<Bgr, Byte> updateImg(Image<Bgr, Byte> img) {
            if (!(rValue == 1 && gValue == 1 && bValue == 1))
            {
                img = DarkRoom.Instance.colorBalance(img, rValue, gValue, bValue).ToImage<Bgr, Byte>();
            }

            if (surfaceBrightnesscuts)
            {
                Image<Gray, Byte> gray = null;
                if (noiseImage != null)
                    gray = noiseImage.ToImage<Gray, Byte>();

                img = DarkRoom.Instance.surfaceBrightnessCuts(img, gray).ToImage<Bgr, Byte>();
            }
            if (alphaValue != 1 || betaValue != 0)
            {
                img = DarkRoom.Instance.contrast(img, alphaValue, betaValue).ToImage<Bgr, Byte>();
            }
            if (gammaValue != 1)
            {
                img = DarkRoom.Instance.intensityMapping(img, gammaValue).ToImage<Bgr, Byte>();
            }

            return img;
        }

        void updateChart(Image<Bgr, Byte> img) {
            int[][] channels = DarkRoom.Instance.getImageChartList(img);
            RGBLINECHART.Series["Red Channel"].Points.Clear();
            RGBLINECHART.Series["Green Channel"].Points.Clear();
            RGBLINECHART.Series["Blue Channel"].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                if (channels[i] == null)
                {
                    RGBLINECHART.Series["Red Channel"].Points.AddXY(i, 0);
                    RGBLINECHART.Series["Green Channel"].Points.AddXY(i, 0);
                    RGBLINECHART.Series["Blue Channel"].Points.AddXY(i, 0);
                }
                else
                {
                    RGBLINECHART.Series["Red Channel"].Points.AddXY(i, channels[i][0]);
                    RGBLINECHART.Series["Green Channel"].Points.AddXY(i, channels[i][1]);
                    RGBLINECHART.Series["Blue Channel"].Points.AddXY(i, channels[i][2]);

                    Debug.WriteLine(channels[i][0] + " , " + channels[i][1] + " , " + channels[i][2]);
                }

                Debug.WriteLine(i);
            }
        }
        void updateImage() {

            Image<Bgr, Byte> img = output.Clone();
            img = updateImg(img);
            updateChart(img);
            panAndZoomPictureBox1.Image = img.ToBitmap();

        }

     /*   void colorUpdateImage() {
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(resizeImg).ToImage<Bgr, Byte>();
            panAndZoomPictureBox1.Image = DarkRoom.Instance.colorBalance(img, bValue, gValue, rValue).ToBitmap();
        }

        void contrastUpdateImage() {
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(resizeImg).ToImage<Bgr, Byte>();
            panAndZoomPictureBox1.Image = DarkRoom.Instance.contrast(img, alphaValue, betaValue).ToBitmap();
        }

        void intenstyUpdateImage() {
            Image<Bgr, Byte> img = DarkRoom.Instance.GetMatFromSDImage(resizeImg).ToImage<Bgr, Byte>();
            panAndZoomPictureBox1.Image = DarkRoom.Instance.intensityMapping(img, gammaValue).ToBitmap();
        }*/
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void r_slider_Scroll(object sender, EventArgs e)
        {
            rValue = (float)r_slider.Value / 100;
            r_numericUpDown.Value = (decimal)r_slider.Value;
            updateImage();
        }

        private void g_slider_Scroll(object sender, EventArgs e)
        {
            gValue = (float)g_slider.Value / 100;
            g_numericUpDown.Value = (decimal)g_slider.Value;
            updateImage();
        }

        private void b_slider_Scroll(object sender, EventArgs e)
        {
            bValue = (float)b_slider.Value / 100;
            b_numericUpDown.Value = (decimal)b_slider.Value;
            updateImage();
        }
        
        private void r_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rValue = (float)r_numericUpDown.Value / 100;
            r_slider.Value = (int)r_numericUpDown.Value;
            updateImage();
        }

        private void g_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gValue = (float)g_numericUpDown.Value / 100;
            g_slider.Value = (int)g_numericUpDown.Value;
            updateImage();
        }

        private void b_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            bValue = (float)b_numericUpDown.Value / 100;
            b_slider.Value = (int)b_numericUpDown.Value;
            updateImage();
        }

        private void Alpha_slider_Scroll(object sender, EventArgs e)
        {
            alphaValue = (Alpha_slider.Value) / 100;
            numericUpDown3.Value = Alpha_slider.Value;
            updateImage();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            betaValue = (trackBar3.Value) / 100;
            numericUpDown4.Value = trackBar3.Value;
            updateImage();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            alphaValue = ((float)numericUpDown3.Value) / 100;
            Alpha_slider.Value = (int)numericUpDown3.Value;
            updateImage();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            betaValue = ((float)numericUpDown4.Value) / 100;
            trackBar3.Value = (int)numericUpDown4.Value;
            updateImage();
        }

        private void sbc_btn_Click(object sender, EventArgs e)
        {
            surfaceBrightnesscuts = true;
            updateImage();
        }

        private void UploadedNoiseMAt_btn_Click(object sender, EventArgs e)
        {
            loadfiles();
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
                                noiseImage = new Mat(newImagePath);
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
                                magickimage.Dispose();
                                noiseImage = new Mat(newImagePath);
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
            }
        }

        private void Gamma_slider_Scroll(object sender, EventArgs e)
        {
            gammaValue = (Gamma_slider.Value + 1) / 100;
            if (slider_numericUpDown.Minimum > Gamma_slider.Value)
            {
                slider_numericUpDown.Value = slider_numericUpDown.Minimum;
            }
            else { 
                slider_numericUpDown.Value = Gamma_slider.Value;
            }
            
            updateImage();
        }

        private void slider_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gammaValue = ((float)slider_numericUpDown.Value + 1) / 100;
            if (slider_numericUpDown.Minimum > Gamma_slider.Value)
            {
                Gamma_slider.Value = (int)Gamma_slider.Minimum;
            }
            else
            {
                Gamma_slider.Value = (int)slider_numericUpDown.Value;
            }
            updateImage();
        }

        private void sp_btn_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> img = DarkRoom.Instance.getOutputImage().ToImage<Bgr, Byte>();
            img = updateImg(img);
            Mat outputImage = img.Mat;
            DarkRoom.Instance.saveOutputImage(outputImage, rValue, gValue, bValue, alphaValue, betaValue, gammaValue,surfaceBrightnesscuts);
            PageManager.Instance.changePage("exportControl1");
            ExportControl ec = (ExportControl)PageManager.Instance.getUserControl("exportControl1");
            ec.loadPage();
        }

        private void panAndZoomPictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
