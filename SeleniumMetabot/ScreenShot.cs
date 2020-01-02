using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class ScreenShot : SeleniumProperties
    {
        
        public static string TakeScreenShot(string fqpn = null)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(fqpn))
            {
                fqpn = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myUniqueFileName = $@"\Image{DateTime.Now.Ticks}.png";
                fqpn = fqpn + myUniqueFileName;
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
