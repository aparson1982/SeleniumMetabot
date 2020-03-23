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
        private static List<char> delimiterList = new List<char> { '`', '~', '!', '#', '$', '@', '^', '&', '*', '(', ')', '[', ']', '{', '}', '\\', '|', ':', ';', ',', '<', '>', '.', '/', '-', '_', '+' };
        public static string ScrollIntoView(string elementType, string element)
        {
            string str = string.Empty;
            try
            {
                Actions actions = new Actions(driver);
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                actions.MoveToElement(webElement);
                str = "Scrolled to the element " + element + Environment.NewLine;
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
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
            
            
                       //TODO Finish Writing the rest of the method
        }

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static string RefreshPage()
        {
            string str = string.Empty;
            try
            {
                driver.Navigate().Refresh();
                str = "Page refreshed successfully.";
            }
            catch (Exception e)
            {
                str = "There was an exception switching Frames." + Environment.NewLine +
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }
        public static string SwitchFrames(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                driver.SwitchTo().Frame(webElement);
                str = "Switched to the iframe element " + element + Environment.NewLine;

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
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        /// <summary>
        /// Switches to the first frame on the page or the main document when a page contains iFrames
        /// </summary>
        public static void SwitchToDefaultFrame()
        {
            driver.SwitchTo().DefaultContent();
        }

        public static string SwitchToLastOpenedWindow()
        {
            string str = string.Empty;
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());                
                str = "Switched to Window:  " + driver.Title;
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
                    "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        public static string GetCurrentWindowHandle()
        {
            string str = string.Empty;
            try
            {
                string winHandleBefore = driver.CurrentWindowHandle;
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
                    "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return str;
        }

        public static string SwitchToWindow(string handle)
        {
            string str = string.Empty;
            try
            {
                driver.SwitchTo().Window(handle);
                str = "Switched to Window:  " + driver.Title;
            }
            catch (Exception e)
            {
                str = "There was an exception switching Frames." + Environment.NewLine +
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        public static string GetMultipleWindowHandles(string delimiter)
        {
            string str = string.Empty;
            try
            {
                List<string> lstWindow = driver.WindowHandles.ToList();
                
                foreach(var element in lstWindow)
                {
                    if (element.Contains(delimiter))
                    {
                        str +=
                                "Error:  The delimiter '" + delimiter + "' cannot be used because one or more values contains that delimiter." + Environment.NewLine + "Available delimiters include:  " + Environment.NewLine;

                        string tempString = string.Join(",", lstWindow.ToArray());
                        char[] characters = tempString.ToCharArray();
                        var unusedDelimiters = delimiterList.Except(characters);

                        foreach (var character in unusedDelimiters)
                        {
                            str += character.ToString() + "  ";
                        }

                        return SeleniumUtilities.MethodName() + ":  " + str;
                    }
                }
                str = string.Join(delimiter.ToString(), lstWindow.ToArray());
            }
            catch (Exception e)
            {
                str = "There was an exception switching Frames." + Environment.NewLine +
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }
            return str;
        }


    }
}
