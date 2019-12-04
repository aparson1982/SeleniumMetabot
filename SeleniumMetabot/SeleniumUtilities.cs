using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumUtilities
    {
        public static string PageSourceCode()
        {
            return SeleniumProperties.driver.PageSource;
        }

        public static string PageTitle()
        {
            return SeleniumProperties.driver.Title;
        }

        public static void FramesCount()
        {
            SeleniumProperties.driver.FindElements(By.XPath("")).Count();
        }
        

    }
}
