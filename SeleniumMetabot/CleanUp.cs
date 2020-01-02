using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumMetabot 
{
    public class CleanUp : SeleniumProperties
    {
        
        public static void Demolish()
        {
            driver.Close();
            driver.Quit();
            KillChromeDriverProcess();
        }

        internal static void KillChromeDriverProcess()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("chromedriver.exe");
                if (processes.Length > 0)
                {
                    foreach(Process proc in processes)
                    {
                        proc.Kill();
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
