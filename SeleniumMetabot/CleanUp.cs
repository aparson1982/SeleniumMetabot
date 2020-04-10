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
        
        public static string Demolish()
        {
            string str = string.Empty;
            try
            {
                driver.Close();
                str += "Closed the browser." + Environment.NewLine;
            }
            catch (Exception e)
            {
                str = "Attempted driver.Close() but received error."+ Environment.NewLine +
                      "Error" + Environment.NewLine +
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            try
            {
                driver.Quit();
                str += "Quit the driver." + Environment.NewLine;
            }
            catch (Exception e)
            {
                str += "Attempted driver.Quit() but received error." + Environment.NewLine +
                      "Error" + Environment.NewLine +
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            str += KillChromeDriverProcess();

            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        public string Close()
        {
            string str = string.Empty;
            try
            {
                driver.Close();
                str += "Closed the browser." + Environment.NewLine;
            }
            catch (Exception e)
            {
                str = "Attempted driver.Close() but received error." + Environment.NewLine +
                      "Error" + Environment.NewLine +
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        internal static string KillChromeDriverProcess()
        {
            string str = string.Empty;
            try
            {
                var chromeDriverProcesses = Process.GetProcesses().Where(pr => pr.ProcessName.CaseInsensitiveContains("chrome"));
                var driverProcesses = chromeDriverProcesses.ToList();
                if (!driverProcesses.Any()) return null;
                foreach (var process in driverProcesses)
                {
                    str += "Killing " + process.ProcessName + "..." + Environment.NewLine; ;
                    process.Kill();
                }

            }
            catch (Exception e)
            {
                str += "Attempted to kill the ChromeDriver process but received an error." + Environment.NewLine +
                     "Error" + Environment.NewLine +
                     "Message:  " + e.Message + Environment.NewLine +
                     "Source:  " + e.Source + Environment.NewLine +
                     "StackTrace:  " + e.StackTrace + Environment.NewLine +
                     "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
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
