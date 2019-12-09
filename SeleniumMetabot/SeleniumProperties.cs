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
    public class SeleniumProperties
    {
        internal static IWebDriver driver;
        
        internal static void InitializeDriver()
        {
            driver = new ChromeDriver();
        }
        //internal static NgWebDriver ngDriver { get; set; }
    }
}
