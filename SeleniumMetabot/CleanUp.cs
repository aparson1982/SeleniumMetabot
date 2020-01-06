using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                //Process[] processes = Process.GetProcessesByName("chromedriver.exe");
                var chromeDriverProcesses = Process.GetProcesses().Where(pr => pr.ProcessName.CaseInsensitiveContains("chrome"));
                var driverProcesses = chromeDriverProcesses.ToList();
                if (!driverProcesses.Any()) return;
                foreach (var process in driverProcesses)
                {
                    process.Kill();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public static string DeleteOldFiles(string dirName, int days = 30)
        {
            string str = string.Empty;
            try
            {
                Directory.GetFiles(dirName).Select(f => new FileInfo(f)).Where(f => f.LastAccessTime < DateTime.Now.AddDays(-days)).ToList().ForEach(f => f.Delete());
                str = SeleniumUtilities.MethodName() + ":  " + "Deleted files > " + days + " old in directory " +
                      dirName + Environment.NewLine;
            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine +
                      "Parameters:  dirName = " + dirName + " | days = " + days;
            }

            return str;
        }


        public static string DeleteOldFilesWithExtension(string dirName, string ext, int days = 30)
        {
            string str = string.Empty;
            try
            {
                Directory.GetFiles(dirName).Select(f => new FileInfo(f)).Where(f => f.LastAccessTime < DateTime.Now.AddDays(-days) && f.Extension.CaseInsensitiveContains(ext)).ToList().ForEach(f => f.Delete());
                str = SeleniumUtilities.MethodName() + ":  " + "Deleted ." + ext.ToUpper() + " files > " + days + " old in directory " +
                      dirName + Environment.NewLine;
            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine +
                      "Parameters:  dirName = " + dirName + "ext = " + ext + " | days = " + days;
            }

            return str;
        }
    }
}
