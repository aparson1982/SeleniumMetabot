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

        public static void DefaultZoom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom'100%';");
        }
        //TODO:  Create methods for Maximize, Minimize, Resize?, Zoom, etc
    }
}
