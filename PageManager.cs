using Emgu.CV;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace P3_Project
{
    
    public sealed class PageManager
    {
        public string cacheFolder = '\u005c'+"cache" + '\u005c';
        public string logPath = "log.csv";
        bool logpathBeenSet = false;
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

        /// <summary>
        /// M.I.S
        /// </summary>
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
        /// <summary>
        /// This function writes to the log what step your on and ...
        /// </summary>
        /// <param name="stepnumber"></param>
        public void writeLineToLog(int stepnumber, string[] imagesPath) {
            // TextWriter klassen skal bruges
            TextWriter tw;
            if (!logpathBeenSet)
            {
                logPath = Directory.GetCurrentDirectory() + cacheFolder + logPath;

                logpathBeenSet = true;
                // Tjekker at der er en fil med det navn
                if (!File.Exists(logPath))
                {
                    //skriv kode her hvis vi gerne ville have headers
                }
                for (int i = 0; i < imagesPath.Length; i++)
                {

                    string input = "," + imagesPath[i];
                    if (i == 0)
                    {
                        Debug.WriteLine(input);
                        input = stepnumber + input;
                        Debug.WriteLine(input);
                        writeCSVLine(input,false);
                    }
                    else {
                        Debug.WriteLine(input);
                        writeCSVLine(input,true);
                    }
                    
                }
            }
            else { 
                //skriver en linje i csv filen
                for (int i = 0; i < imagesPath.Length; i++) {

                    string input = "," + imagesPath[i];
                    if (i == 0) {
                        input = stepnumber + input;
                    }
                    writeCSVLine(input,true);
                }
            }
            
            

        }

        void writeCSVLine(string input,bool append)
        {
            // TextWriter klassen skal bruges
            TextWriter tw;
            // tw indstilles til StreamWriter og til appending
            tw = new StreamWriter(logPath, append);
            // tw tilføjer en linje med input
            tw.WriteLine(input);
            // Derefter lukkes den igen
            tw.Close();
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