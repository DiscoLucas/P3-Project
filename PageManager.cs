using System.Diagnostics;
using System.Windows.Forms;

namespace P3_Project
{
    
    public sealed class PageManager
    {
        public string cacheFolder = '\u005c'+"cache" + '\u005c';
        private static PageManager instance = null;
        private static readonly object padlock = new object();
        private MainForm form;
        
        PageManager()
        {
        }

        public static PageManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PageManager();
                    }
                    return instance;
                }
            }
        }

        public void monkey() {
            Debug.WriteLine("ABE!");
        }

        public void setForm(MainForm mainForm) {
            form = mainForm;
            
            Debug.WriteLine("FormSet!" + " and have " + mainForm.Controls.Count + " Controls");
        }

        public void changePage(UserControl userControl) {
           
               for (int i = 0; i < form.Controls.Count; i++) {
                    if(form.Controls[i] != userControl)
                       form.Controls[i].Hide();

               }
               form.ShowAllImportenComponets();
               userControl.Show();
               userControl.BringToFront();

        }
        
        public void changePage(string userControlNAME)
        {

            for (int i = 0; i < form.Controls.Count; i++)
            {
                if (form.Controls[i].Name.Equals(userControlNAME))
                {
                    form.Controls[i].Show();
                }
                else {
                    form.Controls[i].Hide();
                }
                    

            }
            form.ShowAllImportenComponets();

        }

        public UserControl getUserControl(string userControlNAME)
        {
            UserControl userControl = null;
            for (int i = 0; i < form.Controls.Count; i++)
            {
                if (form.Controls[i].Name.Equals(userControlNAME))
                {
                    userControl = (UserControl) form.Controls[i];
                }
             


            }
            return userControl;

        }
    }
}