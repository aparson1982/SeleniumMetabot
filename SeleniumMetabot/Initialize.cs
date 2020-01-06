using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class Initialize : SeleniumProperties
    {

        public static void InitializeChromeDriver()
        {
            InitializeDriver();
        }

        public static string OpenUrl(string url)
        {
            string str = string.Empty;
            try
            {
                InitializeDriver();
                driver.Url = url;
                str = "Opened the URL " + url;
            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Target Site:  " + e.TargetSite + Environment.NewLine +
                    "Help Link:  " + e.HelpLink + Environment.NewLine +
                    "Data:  " + e.Data + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        public static void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
