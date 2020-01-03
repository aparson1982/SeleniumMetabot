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
    public class Navigation : SeleniumProperties
    {
        
        public static string ScrollIntoView(string elementType, string element)
        {
            string str = string.Empty;
            try
            {
                Actions actions = new Actions(driver);
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                actions.MoveToElement(webElement);
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "There was an exception switching Frames." + Environment.NewLine + Environment.NewLine +
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element;
            }
            return str;
            
            
                       //TODO Finish Writing the rest of the method
        }

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        public static string SwitchFrames(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                driver.SwitchTo().Frame(webElement);
 
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "There was an exception switching Frames." + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine + 
                    "Parameters:  elementType = " + elementType + " | element = " + element ;
            }
            return str;
        }

        /// <summary>
        /// Switches to the first frame on the page or the main document when a page contains iFrames
        /// </summary>
        public static void SwitchToDefaultFrame()
        {
            driver.SwitchTo().DefaultContent();
        }


        
    }
}
