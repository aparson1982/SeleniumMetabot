using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumUtilities : SeleniumProperties
    {
        
        
        public static string PageSourceCode()
        {
            return driver.PageSource;
        }

        public static string PageTitle()
        {
            return driver.Title;
        }

        public static int FramesCount()
        {
            return driver.FindElements(By.XPath("//iframe")).Count();
        }
        
        //public IList<string> Iframes()
        //{
        //    IList<IWebElement> iFrames = driver.FindElements(By.XPath("//iframe"));
        //    return iFrames;
        //}
        
        


    }
}
