using OpenQA.Selenium.Chrome;
using Protractor;
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
            SeleniumProperties.ngDriver = new NgWebDriver(SeleniumProperties.driver);
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
