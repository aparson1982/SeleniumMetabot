using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumMetabot
{
    public class Navigation
    {
        public static void ScrollIntoView(string element, string elementType)
        {
            string str = string.Empty;
            if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
            {
                var item = SeleniumProperties.driver.FindElement(By.Id(element));
                Actions actions = new Actions(SeleniumProperties.driver);
                actions.MoveToElement(item);
                actions.Perform();
            }
            if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
            {
                var item = SeleniumProperties.driver.FindElement(By.Name(element));
                Actions actions = new Actions(SeleniumProperties.driver);
                actions.MoveToElement(item);
                actions.Perform();
            }
                       //TODO Finish Writing the rest of the method
        }

        public static void NavigateTo(string url)
        {
            SeleniumProperties.driver.Navigate().GoToUrl(url);
        }


        public static string SwitchFrames(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(SeleniumProperties.driver.FindElement(By.Id(element)));
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(element);
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(SeleniumProperties.driver.FindElement(By.TagName(element)));
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(SeleniumProperties.driver.FindElement(By.PartialLinkText(element)));
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(SeleniumProperties.driver.FindElement(By.LinkText(element)));
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(SeleniumProperties.driver.FindElement(By.CssSelector(element)));
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    SeleniumProperties.driver.SwitchTo().Frame(SeleniumProperties.driver.FindElement(By.XPath(element)));
                }

                
            }
            catch (Exception e)
            {
                str = "There was an exception switching Frames." + Environment.NewLine + Environment.NewLine +
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }

        /// <summary>
        /// Switches to the first frame on the page or the main document when a page contains iFrames
        /// </summary>
        public static void SwitchToDefaultFrame()
        {
            SeleniumProperties.driver.SwitchTo().DefaultContent();
        }
    }
}
