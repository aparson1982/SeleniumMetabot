using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return(" at line " + lineNumber + " (" + caller + ") " + Environment.NewLine);
        }

        public static string LineNumber([CallerLineNumber] int lineNumber = 0)
        {
            return (" (" + lineNumber + "):  " );
        }

        public static string MethodName([CallerMemberName] string caller = null)
        {
            return (" (" + caller + ") ");
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

        public static string Invoke(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action.Invoke();
            stopwatch.Stop();
            return (stopwatch.Elapsed.ToString() + "  |  " + action);
        }

    }
}
