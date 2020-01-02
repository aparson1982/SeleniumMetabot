using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumMetabot
{
    public class SeleniumUtilities : SeleniumProperties
    {
        
        public static string ShowMessage(string message, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            return(Environment.NewLine + Environment.NewLine + message + " at line " + lineNumber + " (" + caller + ") " + Environment.NewLine);
        }
        
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
        
    }
}
