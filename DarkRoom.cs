using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Util;

namespace P3_Project
{
    public sealed class DarkRoom
    {
        private static DarkRoom instance = null;
        private static readonly object padlock = new object();
        private List<Image> targetImages = new List<Image>();
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
        public void detectStarts(Bgr color) {

            //dette skal gøres på alle billeder men for
            //nu bliver det kun gjordt på 1
            //første i listen

            try
            {
                //ved ikke hvad k er
                int k = 1;
                int uniguenessThreashold = 3;
                Mat img1 = GetMatFromSDImage((Image)targetImages[0].Clone());
                Mat img2 = GetMatFromSDImage((Image)targetImages[1].Clone());


                ORB orb = new ORB(numberOfFeatures: 1500, scaleFactor: 1.6f, nLevels: 12, fastThreshold: 15, edgeThreshold: 1);


                VectorOfKeyPoint vkeypoints1 = new VectorOfKeyPoint();
                VectorOfKeyPoint vkeypoints2 = new VectorOfKeyPoint();
                Mat outputImg1 = new Mat();


                Mat firstDescriptoir = new Mat();
                Mat secondDescriptoir = new Mat();
                orb.DetectAndCompute(img1, null, vkeypoints1, firstDescriptoir, false);
                orb.DetectAndCompute(img2, null, vkeypoints2, secondDescriptoir, false);

                VectorOfVectorOfDMatch maches = new VectorOfVectorOfDMatch();
                BFMatcher machter = new BFMatcher(DistanceType.Hamming, crossCheck: true);
                machter.KnnMatch(firstDescriptoir, secondDescriptoir, maches, k, null);
                Debug.WriteLine("machter ");
                Mat mask = new Mat(maches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));
                Debug.WriteLine("mask ");
                
                Mat result = new Mat();
                Debug.WriteLine(vkeypoints1.Length + " " + vkeypoints2.Length + " " + maches.Size);
                Features2DToolbox.DrawMatches(img1, vkeypoints1, img2, vkeypoints2, maches, result,new MCvScalar(100,100,230), new MCvScalar(0, 255, 20),null);
                Debug.WriteLine("result ");
                
                outputImage = result;
                for (int i = 0; i < maches.Size; i++) {
                    for (int j = 0; j < maches[i].Size; j++) {
                        Debug.WriteLine("index: " + i +"j index: "+j +" \ndistance: "+ maches[i][j].Distance 
                            + " \nTrainIdx " + maches[i][j].TrainIdx 
                            + " \nQueryIdx " + maches[i][j].QueryIdx
                            + " \n first keypoint: " + vkeypoints1[maches[i][j].TrainIdx].Point
                            + " \n second keypoint: " + vkeypoints2[maches[i][j].QueryIdx].Point
                            );
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


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

        public void addImages(List<Image> tm) {
            foreach (Image image in tm)
                targetImages.Add(image);
        }

        public void addImages(Image m)
        {
            targetImages.Add(m);
        }
        public List<Image> getImages() { 
            return targetImages;
        }
        public Image getImage(int i) {
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
}
