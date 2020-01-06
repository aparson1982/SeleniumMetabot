using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class MouseActions : SeleniumProperties
    {
        
        public static string Click(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            Actions actions = new Actions(driver);
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                
                if (webElement != null)
                {
                    actions.Click(webElement).Perform();
                    str = "Clicked " + element + Environment.NewLine;
                }
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }

                MethodSuccess = false;
                str = "Click Exception." + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        public static string Submit(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            Actions actions = new Actions(driver);
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);

                if (webElement != null)
                {
                    webElement.Submit();
                    str = "Clicked " + element + Environment.NewLine;
                }
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = "Submit Exception." + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        public static string RightClick(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            Actions actions = new Actions(driver);
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                actions.ContextClick(webElement).Perform();
                
                if (webElement != null) str = "Clicked " + element + Environment.NewLine;
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = "RightClick Exception." + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        public static string JClick(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                executor?.ExecuteScript("arguments[0].click();", webElement);
                
                if (webElement != null) str = "Clicked " + element + Environment.NewLine;
                
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = "JClick Exception." + Environment.NewLine +
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        /// <summary>
        /// Searches all frames when clicking.  Returns to the default frame when done.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string iClick(string elementType, string element)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                str = Click(elementType, element);
                str2 = str;
                if (MethodSuccess == false)
                {
                    str = JClick(elementType, element);
                    str2 += str;
                    if (MethodSuccess == false)
                    {

                        str = Submit(elementType, element);
                        str2 += str;
                        if (MethodSuccess == false)
                        {
                            foreach (IWebElement iframe in iframes)
                            {
                                driver.SwitchTo().Frame(iframe);

                                string tempString = Click(elementType, element);
                                str = "Frame: " + iframe.GetAttribute("id") + "  |  " + tempString + Environment.NewLine;
                                str2 += str;
                                if (Regex.IsMatch(tempString, @"\bClick Exception\b"))
                                {

                                    tempString = JClick(elementType, element);
                                    str = "Frame: " + iframe.GetAttribute("id") + "  |  " + tempString + Environment.NewLine;
                                    str2 += str;
                                    if (Regex.IsMatch(tempString, @"\bJClick Exception\b"))
                                    {

                                        tempString = Submit(elementType, element);
                                        str = "Frame: " + iframe.GetAttribute("id") + "  |  " + tempString + Environment.NewLine;
                                        str2 += str;
                                        if (Regex.IsMatch(tempString, @"\bSubmit Exception\b"))
                                        {
                                            str = "iClick Failed with the following exception(s):  " + Environment.NewLine + str2;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {

                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "Error" + Environment.NewLine + 
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            finally
            {
                Navigation.SwitchToDefaultFrame();
            }

            return SeleniumUtilities.MethodName() + ":  " + str;
        }

    }
}
