using OpenQA.Selenium;
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
        public static IWebDriver driver { get; set; }
        public static NgWebDriver ngDriver { get; set; }
    }
}
