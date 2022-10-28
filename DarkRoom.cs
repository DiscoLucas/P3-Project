using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace P3_Project
{
    public sealed class DarkRoom
    {
        private static DarkRoom instance = null;
        private static readonly object padlock = new object();
        private List<Image> targetImages = new List<Image>();
        
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
    }
}
