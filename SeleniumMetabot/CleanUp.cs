using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot 
{
    public class CleanUp : SeleniumProperties
    {
        
        public static void Demolish()
        {
            driver.Close();
        }
    }
}
