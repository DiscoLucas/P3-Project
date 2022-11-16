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

namespace P3_Project
{
    public sealed class DarkRoom
    {
        private static DarkRoom instance = null;
        private static readonly object padlock = new object();
        /// <summary>
        /// list of the file path for the target images
        /// </summary>
        private List<string> targetImages = new List<string>();
        private Mat outputImage = null;
        private string outputImagePath = "opm.TIFF";
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
        public void detectStartsAndStack() {
            int k = 1;
            List<MachtedImage> imagesmachtes = new List<MachtedImage>(); 
            Mat stakkedImage = new Mat();
            VectorOfKeyPoint vkeypoints1 = new VectorOfKeyPoint();
            ORB orb = new ORB(numberOfFeatures: 1500, scaleFactor: 1.2f, nLevels: 8, fastThreshold: 20, edgeThreshold: 31, scoreType: ORB.ScoreType.Harris, patchSize: 31, WTK_A: 2,firstLevel: 1);
            Mat firstDescriptoir = new Mat();
            
            for (int i = 1; i < targetImages.Count; i++) {
                try
                {
                    if (i == 1)
                    {
                        stakkedImage = new Mat(targetImages[0]);
                        orb.DetectAndCompute(stakkedImage, null, vkeypoints1, firstDescriptoir, false);
                        MachtedImage machtedImage1 = new MachtedImage(null, vkeypoints1, null, firstDescriptoir, stakkedImage, targetImages[0]);
                        imagesmachtes.Add(machtedImage1);
                    }

                    Mat img2 = new Mat(targetImages[i]);
                    VectorOfKeyPoint vkeypoints2 = new VectorOfKeyPoint();
                    Mat secondDescriptoir = new Mat();
                    orb.DetectAndCompute(img2, null, vkeypoints2, secondDescriptoir, false);
                    VectorOfVectorOfDMatch maches = new VectorOfVectorOfDMatch();
                    BFMatcher machter = new BFMatcher(DistanceType.Hamming, crossCheck: false);
                    machter.KnnMatch(firstDescriptoir, secondDescriptoir, maches, k, null);
                    Mat mask = new Mat(img2.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                    mask.SetTo(new MCvScalar(255));
                    Features2DToolbox.VoteForUniqueness(maches, 0.8, mask);
                    int nonZeroPix = CvInvoke.CountNonZero(mask);
                    if (nonZeroPix >= 0)
                    {
                        Debug.WriteLine("is null: \n" + " vk1: " + (vkeypoints1 == null) + " m " + (maches == null) + " mask " + (mask == null) + " ");
                        int amountOfOkFeatures = Features2DToolbox.VoteForSizeAndOrientation(vkeypoints1, vkeypoints2, maches, mask, 1.5, 20);

                        if (amountOfOkFeatures >= 4)
                        {
                            MachtedImage machtedImage2 = new MachtedImage(maches, vkeypoints2, mask, secondDescriptoir, img2, targetImages[i]);
                            imagesmachtes.Add(machtedImage2);
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
            output[0] = imagesmachtes[0].images;
            Size size = imagesmachtes[0].images.Size;
            string[] paths = new string[(int)imagesmachtes.Count];
            paths[0] = targetImg.imagepath;
            targetImg.images.Save(targetImg.imagepath);
            for (int i = 1; i < imagesmachtes.Count; i++) {
                MachtedImage wrapedImg = imagesmachtes[i];
                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(wrapedImg.vkeypoints, targetImg.vkeypoints, wrapedImg.maches, wrapedImg.mask, 0.5);
                Mat warpedImage = new Mat();
                CvInvoke.WarpPerspective(wrapedImg.images, warpedImage, homography, size);
                output[i] = warpedImage;
                warpedImage.Save(wrapedImg.imagepath);
                paths[i] = wrapedImg.imagepath;
            }
            PageManager.Instance.writeLineToLog(1, paths);
            return output;
        }

        private Mat stackImages(Mat[] wrapeImages)
        {
            Mat staggedImages = wrapeImages[0];
            staggedImages /= wrapeImages.Length;
            for (int i = 1; i < wrapeImages.Length; i++) {
                Mat wrapedImg = wrapeImages[i];
                wrapedImg /= wrapeImages.Length;
                staggedImages += wrapedImg;
            }
            outputImagePath = Directory.GetCurrentDirectory() + PageManager.Instance.cacheFolder + outputImagePath;
            Debug.WriteLine(outputImagePath);
            staggedImages.Save(outputImagePath);
            return staggedImages;
        }
       



        /// <summary>
        /// stolen from https://stackoverflow.com/questions/40384487/system-drawing-image-to-emgu-cv-mat
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Mat GetMatFromSDImage(System.Drawing.Image image)
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

        public void addImages(List<string> tm) {
            foreach (string path in tm)
                targetImages.Add(path);
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

        public Image getOutputImageAsImage() {
            
            return outputImage.ToBitmap();
            
                
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
