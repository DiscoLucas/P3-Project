﻿using System;
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

namespace P3_Project
{
    public sealed class DarkRoom
    {
        private static DarkRoom instance = null;
        private static readonly object padlock = new object();

        private List<Mat> targetImages = new List<Mat>();
        private Mat outputImage = null;
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
        public void detectStarts() {
            int k = 1;
            List<MachtedImage> imagesmachtes = new List<MachtedImage>(); 
            Mat stakkedImage = new Mat();
            VectorOfKeyPoint vkeypoints1 = new VectorOfKeyPoint();
            ORB orb = new ORB(numberOfFeatures: 1500, scaleFactor: 1.2f, nLevels: 12, fastThreshold: 8, edgeThreshold: 31);
            Mat firstDescriptoir = new Mat();
            
            for (int i = 1; i < targetImages.Count; i++) {
                try
                {
                   if (i == 1) {
                    stakkedImage = targetImages[0].Clone();
                    orb.DetectAndCompute(stakkedImage, null, vkeypoints1, firstDescriptoir, false);
                    MachtedImage machtedImage1 = new MachtedImage(null, vkeypoints1, null, firstDescriptoir,stakkedImage);
                    imagesmachtes.Add(machtedImage1);
                }
                
                Mat img2 = targetImages[i].Clone(); ;
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
                if (nonZeroPix >= 0) {
                    Debug.WriteLine("is null: \n"+ " vk1: " + (vkeypoints1 == null) + " m " + (maches == null) + " mask " + (mask == null) + " ");
                    int amountOfOkFeatures = Features2DToolbox.VoteForSizeAndOrientation(vkeypoints1, vkeypoints2, maches, mask, 1.5, 20);

                    if (amountOfOkFeatures >= 4)
                    {
                        MachtedImage machtedImage2 = new MachtedImage(maches, vkeypoints2, mask, secondDescriptoir, img2);
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
            for (int i = 1; i < imagesmachtes.Count; i++) {
                MachtedImage wrapedImg = imagesmachtes[i];
                
                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(wrapedImg.vkeypoints, targetImg.vkeypoints, wrapedImg.maches, wrapedImg.mask, 0.5);
                Mat warpedImage = new Mat();
                CvInvoke.WarpPerspective(wrapedImg.images, warpedImage, homography, size);
                output[i] = warpedImage;
                
            }

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

        public void addImages(List<Mat> tm) {
            foreach (Mat image in tm)
                targetImages.Add(image);
        }

        public void addImages(Mat m)
        {
            targetImages.Add(m);
        }
        public List<Mat> getImages() { 
            return targetImages;
        }
        public Mat getImage(int i) {
            return targetImages[i];
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
        public MachtedImage(VectorOfVectorOfDMatch maches, VectorOfKeyPoint vkeypoints, Mat mask, Mat descriptoir,Mat images)
        {
            this.vkeypoints= vkeypoints;
            this.descriptoir= descriptoir;
            this.mask= mask;
            this.maches = maches;
            this.images = images;
        }
    }
}
