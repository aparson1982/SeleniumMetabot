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
        public static string TakeScreenShot(string fqpn)
        {
            string str = string.Empty;
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
