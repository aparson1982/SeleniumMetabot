using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class Initialize
    {
        public static void InitializeChromeDriver()
        {
            SeleniumProperties.driver = new ChromeDriver();
        }

        public static void OpenUrl(string url)
        {
            SeleniumProperties.driver = new ChromeDriver();
            SeleniumProperties.driver.Url = url;
        }

        public static void NavigateToUrl(string url)
        {
            SeleniumProperties.driver.Navigate().GoToUrl(url);
        }
    }
}
