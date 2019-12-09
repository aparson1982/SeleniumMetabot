using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class PageSetup : SeleniumProperties
    {
        
        public static void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }
        //TODO:  Create methods for Maximize, Minimize, Resize?, Zoom, etc
    }
}
