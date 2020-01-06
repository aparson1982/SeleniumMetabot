using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumProperties
    {
        internal static bool MethodSuccess { get; set; } = true;
        public static bool doTakeScreenshot { get; set; } = false;

        internal static IWebDriver driver;
        
        internal static void InitializeDriver()
        {
            driver = new ChromeDriver();
        }


        private static string _Path;
        public static string Path
        {
            get { return _Path ?? String.Empty; }
            set
            {
                if (value == null)
                {
                    _Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
            }
        }
        //internal static NgWebDriver ngDriver { get; set; }
    }
}
