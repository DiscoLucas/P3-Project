using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.Face;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using static Emgu.CV.Features2D.ORB;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;
using Emgu.CV.XObjdetect;
using System.Linq;
using Emgu.CV.Dnn;
using Emgu.CV.Reg;
using Emgu.CV.CvEnum;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;
using System.Data.Common;

namespace P3_Project
{
    public sealed class DarkRoom
    {
        /// <summary>
        /// imellem 0 til 1 
        /// </summary>
        public float lightThreashold = 0.5f;
        private static DarkRoom instance = null;
        private static readonly object padlock = new object();
        /// <summary>
        /// list of the file path for the target images
        /// </summary>
        private List<string> targetImages = new List<string>();
        public Mat outputImage = null;
        public string filename = "opm.TIFF";
        private string outputImagePath = "opm.TIFF";

        private string saveStageName = "saveStage";
        private int indexOfImage = 0;
        private int currentIndexOfImage = 0;
        private int blurSize = 3;
        public int numberOfFeathures = 10000;
        private int borderSize = 3;
        private int minKeyPointSize = 3;
        /// <summary>
        /// Count of best matches found per each descriptor 
        /// or less if a descriptor has less than k possible matches in total.
        /// </summary>
        public int k = 2;
        public float ransac = 3f;
        double uniquenessthreshold = 0.80;// less this is the less uniqie can the machtes be
        DarkRoom()
        {
        }

        public static DarkRoom Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DarkRoom();
                    }
                    return instance;
                }
            }
        }

        public void saveOutputImage(Mat img) {
            string outputPath = PageManager.Instance.cacheFolder + saveStageName + currentIndexOfImage + ".TIFF";
            Debug.WriteLine(outputPath);
            outputImage.Save(outputImagePath);
            currentIndexOfImage++;
            indexOfImage++;
            outputImage = img;
        }
        void removeKeyPointsOutOfMask(VectorOfKeyPoint srcKeyPoints, out VectorOfKeyPoint outKeyPoints,Mat mask)
        {
            Debug.WriteLine("amount of keypoints: \n before: " + "size: " + srcKeyPoints.Size + " length: " + srcKeyPoints.Length);
            //skriv det der fjener ting fra masken
            Mat nMat = new Mat(srcKeyPoints.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            Image<Gray, Byte> nMask = nMat.ToImage<Gray, Byte>();
            srcKeyPoints.FilterByPixelsMask(nMask);
            Debug.Write("\n after: " + "size: " + srcKeyPoints.Size + " length: " + srcKeyPoints.Length + "\n");
            outKeyPoints = srcKeyPoints;
            
        }
        public Mat toGrayImage(Mat mat) {

            return mat.ToImage<Gray, Byte>().Mat;
        }
        public void detectStartsAndStack() {
            List<MachtedImage> imagesmachtes = new List<MachtedImage>();
            string PathToImage1 = targetImages[0];
            Mat Image1 = toGrayImage(CvInvoke.Imread(PathToImage1)); /* Emgu.CV.Mat is a class which can store the pixel values.*/
          
            Mat mask1 = getDetectionMaskFromImage(Image1,255);//create a mask of the area of where it should look for importent points
            VectorOfKeyPoint KeyPoints1 = new VectorOfKeyPoint(); // KeyPoints1 - for storing the keypoints of Image1

            ORB ORB = new ORB(numberOfFeathures); // Emgu.CV.Features2D.ORB class. this takes care of the orb dectiontion.
            Mat Descriptors1 = new Mat(); // Descriptors1 - for storing the descriptors of Image1
            ORB.DetectAndCompute(Image1, mask1, KeyPoints1, Descriptors1, false);
            removeKeyPointsOutOfMask(KeyPoints1, out KeyPoints1, mask1);

            MachtedImage machtedImage1 = new MachtedImage(null, KeyPoints1, null, Descriptors1, Image1, targetImages[0]);
            imagesmachtes.Add(machtedImage1);
            for (int j = 1; j < targetImages.Count; j++) {
                try {
                    
                    
                    string PathToImage2 = targetImages[j];
                    
                    Mat Image2 = toGrayImage(imageStackingPreparation(CvInvoke.Imread(PathToImage2))); // Image2 now have the details of second image 
                    Mat mask2 = getDetectionMaskFromImage(Image2,255);
                    VectorOfKeyPoint KeyPoints2 = new VectorOfKeyPoint(); // KeyPoints2 - for storing the keypoints of Image2
                    Mat Descriptors2 = new Mat(); // Descriptors2 - for storing the descriptors of Image2

                    /* Detects Keypoints in Image1 and then computes descriptors on the image from the keypoints. 
                     * Keypoints will be stored into - KeyPoints1 and Descriptors will be stored into - Descriptors1*/
                    //Feature Extraction from Image2
                    ORB.Clear();
                    ORB.DetectAndCompute(Image2, mask2, KeyPoints2, Descriptors2, false);
                    removeKeyPointsOutOfMask(KeyPoints2, out KeyPoints2, mask2);
                    BFMatcher matcher = new BFMatcher(DistanceType.Hamming2); // BruteForceMatcher to perform descriptor matching. and use Hamming 2 because it is speacil made for orb dec
                    matcher.Add(Descriptors2); // Descriptors of Image1 is added.
                    VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch(); // For storing the output of matching.
                    matcher.KnnMatch(Descriptors1, matches, k, null); // matches will now have the result of matching.
                    Mat mm = new Mat();
                    Features2DToolbox.DrawMatches(Image1, KeyPoints1, Image2, KeyPoints2, matches, mm, new MCvScalar(255, 0, 0, 100), new MCvScalar(255, 100, 0, 100), null);
                    
                    outputImage = mm;
                    mask2 = new Mat(matches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                    mask2.SetTo(new MCvScalar(255));
                    MDMatch[][] array = matches.ToArrayOfArray();
                    byte[] array2 = new byte[array.Length];
                    GCHandle gCHandle = GCHandle.Alloc(array2, GCHandleType.Pinned);
                    using (Mat mat = new Mat(array.Length, 1, DepthType.Cv8U, 1, gCHandle.AddrOfPinnedObject(), 1))
                    {
                        mask2.CopyTo(mat);
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array2[i] != 0 && (double)(array[i][0].Distance / array[i][1].Distance) > uniquenessthreshold)
                            {
                                array2[i] = 0;
                            }
                            

                            
                        }

                        mat.CopyTo(mask2);
                        mask2 = mat.Clone();
                        int nonzeroElement = CvInvoke.CountNonZero(mask2);
                        Features2DToolbox.DrawMatches(Image1, KeyPoints1, Image2, KeyPoints2, matches, mm, new MCvScalar(255, 0, 0, 100), new MCvScalar(255, 100, 0, 100), mask2);

                        Debug.WriteLine(nonzeroElement);
                        if (nonzeroElement >= 4)
                        {
                            MachtedImage machtedImage2 = new MachtedImage(matches, KeyPoints2, mask2, Descriptors2, Image2, targetImages[j]);
                            imagesmachtes.Add(machtedImage2);
                            
                            gCHandle.Free();
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            Mat[] wrapeImages = warpImages(imagesmachtes);
            Debug.WriteLine(wrapeImages.Length);
            outputImage = stackImages(wrapeImages);
        }
      
        private Mat[] warpImages(List<MachtedImage> imagesmachtes)
        {
            Mat homography = null;
            Mat[] output = new Mat[(int)imagesmachtes.Count];
            MachtedImage targetImg = imagesmachtes[0];
            output[0] = new Mat(imagesmachtes[0].imagepath);
            Size size = imagesmachtes[0].images.Size;
            string[] paths = new string[(int)imagesmachtes.Count];
            paths[0] = targetImg.imagepath;
            int amountOfErrors  = 0;
            for (int i = 1; i < imagesmachtes.Count; i++)
            {
                   
                    MachtedImage wrapedImg = imagesmachtes[i];
                    
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures( wrapedImg.vkeypoints, targetImg.vkeypoints, wrapedImg.maches, wrapedImg.mask, ransac);
                if (homography != null)
                {
                    Mat warpedImage = new Mat();

                    CvInvoke.WarpPerspective(new Mat(wrapedImg.imagepath), warpedImage, homography, size);
                    

                    output[i] = warpedImage;
                    warpedImage.Save(wrapedImg.imagepath);
                    paths[i] = wrapedImg.imagepath;

                    homography = null;

                }
                else {
                    amountOfErrors++;
                }
            }
            Debug.WriteLine("amount of errors: " + amountOfErrors);
            if (amountOfErrors > 0) {
                Mat[] noutput = new Mat[(int)imagesmachtes.Count- amountOfErrors];
                int npIndex = 0;
                for (int i = 0; i < output.Length; i++) {
                    Mat wPic = output[i];
                    if (wPic != null) {
                        noutput[npIndex] = wPic;
                        npIndex++;
                    }
                }
                return noutput;
            }
            PageManager.Instance.writeLineToLog(1, paths);
            return output;
        }
        public Mat convertToGray(Mat m) {
            Image<Gray, Byte> img = m.ToImage<Gray, Byte>();
            return img.Mat;
        }


        public Mat insertImageFromMask(Image<Bgr, Byte> simg, Image<Bgr, Byte> output)
        {
            for (int y = 0; y < output.Rows; y++)
            {
                for (int x = 0; x < output.Cols; x++)
                {
                    int b = output.Data[y, x, 0];
                    int g = output.Data[y, x, 1];
                    int r = output.Data[y, x, 2];
                    int a = (int)((b + g + r) / 3);
                    if (a >= 225)
                    {
                        output.Data[y, x, 0] = simg.Data[y, x, 0];
                        output.Data[y, x, 1] = simg.Data[y, x, 1];
                        output.Data[y, x, 2] = simg.Data[y, x, 2];
                    }
                }
            }
            return output.Mat;
        }
        public Mat getDetectionMaskFromImage(Mat srcImg, int colorgrey)
        {
            Image<Bgr, Byte> simg = srcImg.ToImage<Bgr, Byte>();
            int highestS = getHighestSaturation(srcImg.ToBitmap());
            int iterations = 3;
            Mat mask = new Mat(srcImg.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(0f));
            Image<Gray, Byte> imgMask = mask.ToImage<Gray, Byte>();
            for (int y = borderSize; y < srcImg.Rows- borderSize; y++)
            {
                for (int x = borderSize; x < srcImg.Cols- borderSize; x++)
                {
                    int b = simg.Data[y, x, 0];
                    int g = simg.Data[y, x, 1];
                    int r = simg.Data[y, x, 2];
                    int a = (int)((b + g + r) / 3);
                    if (a >= (highestS * lightThreashold))
                    {
                        imgMask.Data[y, x, 0] = 255;
                    }
                }
            }


            Mat element = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            CvInvoke.Dilate(imgMask, imgMask, element, new Point(-1, 1), iterations, borderType: Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(255, 255, 255));
            CvInvoke.Erode(imgMask, imgMask, element, new Point(-1, 1), iterations, borderType: Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(255, 255, 255));
            mask = imgMask.Mat;
            return mask;
        }
        public int getHighestSaturation(Bitmap bmp)
        {
            int highest = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel((int)x, (int)y);

                    int r = clr.R;
                    int g = clr.G;
                    int b = clr.B;
                    int h = (r + g + b) / 3;
                    if (highest < h) { 
                        highest= h;
                    }
                }
            }
            return highest;
        }
        public  Mat stackImages(Mat[] wrapeImages)
        {
            int newHeight = (int)Math.Sqrt((Math.Pow(wrapeImages[0].Size.Height, 2) + Math.Pow(wrapeImages[0].Size.Width, 2)));

            Mat staggedImages = wrapeImages[0];
            staggedImages /= wrapeImages.Length;
            for (int i = 1; i < wrapeImages.Length; i++) {
                Mat wrapedImg = wrapeImages[i];
                wrapedImg /= wrapeImages.Length;
                staggedImages += wrapedImg;
            }
            outputImagePath = Directory.GetCurrentDirectory() + PageManager.Instance.cacheFolder + outputImagePath;
            Debug.WriteLine(outputImagePath);
            try
            {
                staggedImages.Save(outputImagePath);
            }
            catch (Exception e) {
                Debug.WriteLine(outputImagePath);
            }
            return staggedImages;
        }
       



        /// <summary>
        /// stolen from https://stackoverflow.com/questions/40384487/system-drawing-image-to-emgu-cv-mat
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Mat GetMatFromSDImage(System.Drawing.Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
        }
        public Mat surfaceBrightnessCuts(Image<Bgr, Byte> image, Image<Gray, Byte> imageNoiseMat)
        {
            if (imageNoiseMat == null) {
                
                    imageNoiseMat = new Image<Gray, byte>(image.Size);
            }
            float fMax = getHighestSaturation(image.Mat.ToBitmap());
            Bgr color = image.GetAverage();
            float pGrey = (float)(color.Red + color.Green + color.Blue) / 3;
            
            Image<Gray, Byte> Fmin = imageNoiseMat.Copy();
            for (int y = 0; y < Fmin.Rows; y++)
            {
                for (int x = 0; x < Fmin.Cols; x++)
                {
                   float noiseValue = imageNoiseMat.Data[y, x, 0];
                    Fmin.Data[y, x, 0] = (byte)((noiseValue - pGrey * fMax) / (1 - pGrey));
                }
            }

            Image<Bgr, Byte> newImg = image.Copy();
            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        float imageValue = (float)(image.Data[y, x,c]);
                        float minValue = Fmin.Data[y, x, 0];
                        newImg.Data[y, x, c] = (byte)(255 - ((imageValue - minValue) / (fMax - minValue)));
                    }
                }
            }
      
            return newImg.Mat;

        }

        public Mat intensityMapping(Image<Bgr, Byte> image, double gamma)
        {
            Image<Bgr, Byte> newImg = image.Copy();
            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        newImg.Data[y, x, c] = (byte)(Math.Pow(image.Data[y, x, c] / 255.0, gamma) * 255.0);
                    }
                }
            }

            return newImg.Mat;
        }
        /// <summary>
        /// 1 channel is red, second green and third blue
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int[][] getImageChartList(Image<Bgr, Byte> image) {
            int[][] channelNumbers = new int[256][];
            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    int b = image.Data[y, x, 0];
                    int g = image.Data[y, x, 1];
                    int r = image.Data[y, x, 2];

                    if (channelNumbers[b] == null)
                    {
                        channelNumbers[b] = new int[3];
                        channelNumbers[b][2] += 1;
                    }
                    else {
                        channelNumbers[b][2] += 1;
                    }

                    if (channelNumbers[g] == null)
                    {
                        channelNumbers[g] = new int[3];
                        channelNumbers[g][1] += 1;
                    }
                    else
                    {
                        channelNumbers[g][1] += 1;
                    }

                    if (channelNumbers[r] == null)
                    {
                        channelNumbers[r] = new int[3];
                        channelNumbers[r][0] += 1;
                    }
                    else
                    {
                        channelNumbers[r][0] += 1;
                    }

                }
            }

            return channelNumbers;
        }
        public Mat contrast(Image<Bgr, Byte> image,double alpha, double beta)
        {
            Image<Bgr, Byte> newImg = image.Copy();
            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        newImg.Data[y, x, c] = (byte)(alpha * image.Data[y, x, c] + beta);
                    }
                }
            }

            return newImg.Mat;
        }

      
        public Mat colorBalance(Image<Bgr, Byte> image, double blue, double green, double red) {

            Image<Bgr, Byte> newImg = image.Copy();
            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    int b = image.Data[y, x, 0];
                    int g = image.Data[y, x, 1];
                    int r = image.Data[y, x, 2];

                    newImg.Data[y, x, 0] = (Byte)(b * blue);
                    newImg.Data[y, x, 1] = (Byte)(g * green);
                    newImg.Data[y, x, 2] = (Byte)(r * red);
                }
            }
            return newImg.Mat;
        }
        
        public Mat imageStackingPreparation(Mat srcImage) {

            //måske noget i denne stil https://www.researchgate.net/profile/Mukesh-Motwani/publication/228790062_Survey_of_image_denoising_techniques/links/5655816308ae4988a7b0b43f/Survey-of-image-denoising-techniques.pdf
            Mat blur = new Mat();
            CvInvoke.MedianBlur(srcImage, blur,blurSize);
            Image<Bgr, Byte> blurImg = blur.ToImage<Bgr, Byte>();
            Image<Bgr, Byte> mask = getDetectionMaskFromImage(blur, 255).ToImage<Bgr, Byte>();
            Image<Bgr, Byte> newImg = srcImage.ToImage<Bgr, Byte>();
            int minimum = 255;
            for (int y = 0; y < mask.Rows; y++)
            {
                for (int x = 0; x < mask.Cols; x++)
                {
                    int b = mask.Data[y, x, 0];
                    int g = mask.Data[y, x, 1];
                    int r = mask.Data[y, x, 2];
                    int a = (int)((b + g + r) / 3);

                    if (a < 225)
                    {
                        newImg.Data[y, x, 0] = blurImg.Data[y, x, 0];
                        newImg.Data[y, x, 1] = blurImg.Data[y, x, 1];
                        newImg.Data[y, x, 2] = blurImg.Data[y, x, 2];
                        a = (int)((newImg.Data[y, x, 0] + newImg.Data[y, x, 1] + newImg.Data[y, x, 2]) / 3);
                        if (a < minimum)
                        {
                            minimum = a;
                        }
                    }
                }
            }


            newImg -= minimum;

            return newImg.Mat; 
        }

        public void addImages(List<string> tm) {
            foreach (string path in tm) { 
                Mat nMat = new Mat(path);

                targetImages.Add(path);
            }
                
                
        }

        public void addImages(string m)
        {
            targetImages.Add(m);
        }
        public List<string> getImages() { 
            return targetImages;
        }
        public Mat getImage(int i) {
            return new Mat(targetImages[i]);
        }
        /// <summary>
        /// This Function cleans the dark room by:
        /// clearing the image list
        /// </summary>
        public void cleanDarkRoom() {
            targetImages.Clear();
        }

        public Mat getOutputImage() {
            return outputImage;
        }

        public Bitmap getOutputImageAsImage() {
            if (outputImage != null)
                return outputImage.ToBitmap();
            return null;
            
        }

        public Bitmap getOutputImageAsImage(float scale)
        {
            if (outputImage != null) { 
                Bitmap resized = new Bitmap(outputImage.ToBitmap(), new Size((int)(outputImage.ToBitmap().Width * scale),(int)( outputImage.ToBitmap().Height * scale)));
                return resized;
            }
                
            return null;

        }

        public void saveOutputImage(Mat outputImage, float rValue, float gValue, float bValue, float alphaValue, float betaValue, float gammaValue, bool surfaceBrightnesscuts)
        {
            string[] values = new string[8];
            values[0] = DarkRoom.instance.outputImagePath;
            values[1] = rValue.ToString();
            values[2] = gValue.ToString();
            values[3] = bValue.ToString();
            values[4] = alphaValue.ToString();
            values[5] = betaValue.ToString();
            values[6] = gammaValue.ToString();
            values[7] = (Convert.ToByte(surfaceBrightnesscuts)).ToString();
            PageManager.Instance.writeLineToLog(2, values);
            saveOutputImage(outputImage);
            
        }
    }

    internal class MachtedImage
    {
        public Mat images;
        public VectorOfKeyPoint vkeypoints;
        public Mat descriptoir;
        public Mat mask;
        public BFMatcher machter;
        public VectorOfVectorOfDMatch maches;
        public string imagepath;
        public MachtedImage(VectorOfVectorOfDMatch maches, VectorOfKeyPoint vkeypoints, Mat mask, Mat descriptoir,Mat images, string imagepath)
        {
            this.vkeypoints= vkeypoints;
            this.descriptoir= descriptoir;
            this.mask= mask;
            this.maches = maches;
            this.images = images;
            this.imagepath = imagepath;
        }
    }
}
