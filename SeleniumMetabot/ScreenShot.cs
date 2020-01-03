using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class ScreenShot : SeleniumProperties
    {
        
        public static string TakeScreenShot(string fileName = null, string fqpn = null)
        {
            string str = string.Empty;
            string dateTimeTicks = $@"{DateTime.Now.Ticks}.png";
            if (string.IsNullOrEmpty(fileName))
            {
                string tmp = new StackFrame(2).GetMethod().Name;
                string tmp2 = new StackFrame(3).GetMethod().Name;
                if (tmp2.CaseInsensitiveContains("Smart"))
                {
                    fileName = @"\" + tmp2 + "(" + new StackFrame(1).GetMethod().Name + ")";
                }
                else if (tmp.CaseInsensitiveContains("Smart") || tmp.CaseInsensitiveContains("iClick") || tmp.CaseInsensitiveContains("iGet") || tmp.CaseInsensitiveContains("iEnter"))
                {
                    fileName = @"\" + tmp + "(" + new StackFrame(1).GetMethod().Name + ")";
                }
                else
                {
                    fileName = @"\" + new StackFrame(1).GetMethod().Name;
                }
                
            }
            if (string.IsNullOrEmpty(fqpn))
            {
                fqpn = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string logFolderPath = @"\Automation Anywhere Files\Automation Anywhere\Shaw Files\LogFiles\Images";
                fqpn = fqpn + logFolderPath + fileName + dateTimeTicks;
            }
            else
            {
                fqpn = fqpn + fileName + dateTimeTicks;
            }
            try
            {
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                str = image.AsBase64EncodedString;
                image.SaveAsFile(fqpn, ScreenshotImageFormat.Png);

            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException;
            }
            return str;
        }
    }
}
