﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class ElementHelper : SeleniumProperties
    {
        private static string elementHelperMessages;


        public static string PollingWait(string elementType, string element, int timeoutInSeconds, int pollMilliseconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            var stopWatch = Stopwatch.StartNew();
            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
                {
                    Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
                    PollingInterval = TimeSpan.FromMilliseconds(pollMilliseconds)
                };
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Until((d) =>
                {
                    IWebElement webElement = WebElement(elementType, element);
                    if (webElement.Displayed || webElement.Enabled)
                    {
                        return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                MethodSuccess = true;
                str = "true";
            }
            catch (Exception e)
            {

                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            stopWatch.Stop();
            return SeleniumUtilities.MethodName() + ":  " + str + "Total wait time:  " + stopWatch.Elapsed + Environment.NewLine;
        }

        /// <summary>
        /// Implicitly waits for the element to be Displayed.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string WaitDisplayed(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<IWebElement>((d) =>
                {
                    IWebElement webElement = ElementHelper.WebElement(elementType, element);
                    if (webElement.Displayed)
                    {
                       return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                MethodSuccess = true;
                str = "true";
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string iWaitTilDisplayed(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            int count = 1;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                str = WaitDisplayed(elementType, element, timeoutInSeconds / 2);
                if (MethodSuccess == false)
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        while (count <= timeoutInSeconds && MethodSuccess == false)
                        {
                            str = "Attempting to find " + element + " in other frames...  " + WaitDisplayed(elementType, element, count) + Environment.NewLine;

                            count++;
                            
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
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        
        //internal static WaitTilClickable(string elementType, string element, int timeoutInSeconds)
        //{
        //    string str = string.Empty;
        //    elementType = Regex.Replace(elementType, @"s", "");
        //    try
        //    {
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        wait.Until(ExpectedConditions.ElementToBeClickable());
        //        //wait.Until((d) =>
        //        //{
        //        //    IWebElement webElement = WebElement(elementType, element);
        //        //    if (webElement.Enabled || webElement.GetAttribute("aria-disabled") == null)
        //        //    {
        //        //        return webElement;
        //        //    }
        //        //    throw new TimeoutException("Timed out.");

        //        //});
        //        MethodSuccess = true;
        //        str = "true";
        //    }
        //    catch (Exception e)
        //    {
        //        if (doTakeScreenshot)
        //        {
        //            ScreenShot.TakeScreenShot();
        //        }
        //        MethodSuccess = false;
        //        str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
        //            "Source:  " + e.Source + Environment.NewLine +
        //            "StackTrace:  " + e.StackTrace + Environment.NewLine +
        //            "Inner Exception:  " + e.InnerException + Environment.NewLine +
        //            "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
        //    }
        //    return str;
        //}


        /// <summary>
        /// Implicitly waits for the element to be Enabled.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string WaitTilEnabled(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<IWebElement>((d) =>
                {
                    IWebElement webElement = ElementHelper.WebElement(elementType, element);
                    if (webElement.Enabled)
                    {
                        return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                MethodSuccess = true;
                str = "true";
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string iWaitTilEnabled(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            int count = 1;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                str = WaitTilEnabled(elementType, element, timeoutInSeconds / 2);
                if (MethodSuccess == false)
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);

                        while (count <= timeoutInSeconds && MethodSuccess == false)
                        {

                            str = "Attempting to find " + element + " in other frames...  " + WaitTilEnabled(elementType, element, count) + Environment.NewLine;
                            count++;
                            
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
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string CheckIfAriaDisabledIsNull(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<IWebElement>((d) =>
                {
                    IWebElement webElement = ElementHelper.WebElement(elementType, element);
                    if (webElement.GetAttribute("aria-disabled") == null)
                    {
                        return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                MethodSuccess = true;
                str = "true";
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return str;
        }

        public static string iCheckIfAriaDisabledIsNull(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            int count = 1;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                str = CheckIfAriaDisabledIsNull(elementType, element, timeoutInSeconds / 2);

                if (MethodSuccess == false)
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        while (count <= timeoutInSeconds && MethodSuccess == false)
                        {
                            str = "Attempting to find " + element + " in other frames...  " + CheckIfAriaDisabledIsNull(elementType, element, count) + Environment.NewLine;
                            count++;
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
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }




        /// <summary>
        /// Implicit wait that waits for the element to be Enabled and Displayed
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string WaitTilReady(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<IWebElement>((d) =>
                {
                    IWebElement webElement = ElementHelper.WebElement(elementType, element);
                    if (webElement.Enabled && webElement.Displayed)
                    {
                        return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                MethodSuccess = true;
                str = "true";
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException + Environment.NewLine +
                      "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return str;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string iWaitTilReady(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            int count = 1;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                str = WaitTilReady(elementType, element, timeoutInSeconds / 2);

                if (MethodSuccess == false)
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        while (count <= timeoutInSeconds && MethodSuccess == false)
                        {
                            str = "Attempting to find " + element + " in other frames...  " + WaitTilReady(elementType, element, count) + Environment.NewLine;
                            count++;
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
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string iWaitForElement(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            var stopWatch = Stopwatch.StartNew();
            try
            {
                str = iWaitTilDisplayed(elementType, element, timeoutInSeconds);
                str2 = str;
                if (!str.Contains("true"))
                {
                    str = iWaitTilEnabled(elementType, element, timeoutInSeconds);
                    str2 += str;
                    if (!str.Contains("true"))
                    {
                        str = iWaitTilReady(elementType, element, timeoutInSeconds);
                        str2 += str;
                        if (!str.Contains("true"))
                        {
                            str = str2;
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
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            stopWatch.Stop();
            return SeleniumUtilities.MethodName() + ":  " + str + "Total wait time:  " + stopWatch.Elapsed + Environment.NewLine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string iCheckDisplayedEnabledReady(string elementType, string element, int timeoutInSeconds)
        {
            elementType = Regex.Replace(elementType, @"s", "");
            string str;
            var stopWatch = Stopwatch.StartNew();
            try
            {
                
                str = iWaitTilDisplayed(elementType, element, timeoutInSeconds);

                str += iWaitTilEnabled(elementType, element, timeoutInSeconds);

                str += iWaitTilReady(elementType, element, timeoutInSeconds);
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            stopWatch.Stop();
            return SeleniumUtilities.MethodName() + ":  " + str + "Total wait time:  " + stopWatch.Elapsed + Environment.NewLine;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        private static string ExplicitWait(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WaitForWebElement(elementType, element, timeoutInSeconds);
                if (MethodSuccess == true)
                {
                    str = "Successfully found the element:  " + element + Environment.NewLine;
                }
                else
                {
                    str = elementHelperMessages;
                }
                
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }

        /// <summary>
        /// Use the Explicit Wait to cover a broader number of conditions.  
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string iExplicitWait(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                str = ExplicitWait(elementType, element, timeoutInSeconds);
                if (MethodSuccess == false)
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        str = "Attempting to find in other frames...  " + ExplicitWait(elementType, element, timeoutInSeconds) + Environment.NewLine;
                    }

                }
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }



        private static int WebElementHelper(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");

            if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
            {
                return 1;
            }
            if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
            {
                return 2;
            }
            if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
            {
                return 3;
            }
            if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
            {
                return 4;
            }
            if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
            {
                return 5;
            }
            if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
            {
                return 6;
            }
            if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }

        internal static IWebElement WaitForWebElement(string elementType, string element, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                switch (WebElementHelper(elementType, element))
                {
                    case 1:
                        IWebElement myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.Id(element)));
                        MethodSuccess = true;
                        return myDynamicElement;
                    case 2:
                        myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.Name(element)));
                        MethodSuccess = true;
                        return myDynamicElement;
                    case 3:
                        myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.TagName(element)));
                        MethodSuccess = true;
                        return myDynamicElement;
                    case 4:
                        myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.PartialLinkText(element)));
                        MethodSuccess = true;
                        return myDynamicElement;
                    case 5:
                        myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.LinkText(element)));
                        MethodSuccess = true;
                        return myDynamicElement;
                    case 6:
                        myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.CssSelector(element)));
                        MethodSuccess = true;
                        return myDynamicElement;                        
                    case 7:
                        myDynamicElement = wait.Until<IWebElement>((d) => d.FindElement(By.XPath(element)));
                        MethodSuccess = true;
                        return myDynamicElement;
                    default:
                        throw new ArgumentException("The given argument " + elementType + " for elementType is invalid.");
                }
                
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                elementHelperMessages += SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + Environment.NewLine;
            }
            return null;
        }

        

        internal static IWebElement WebElement(string elementType, string element)
        {
            try
            {
                switch (WebElementHelper(elementType, element))
                {
                    case 1:
                        return driver.FindElement(By.Id(element));
                    case 2:
                        return driver.FindElement(By.Name(element));
                    case 3:
                        return driver.FindElement(By.TagName(element));
                    case 4:
                        return driver.FindElement(By.PartialLinkText(element));
                    case 5:
                        return driver.FindElement(By.LinkText(element));
                    case 6:
                        return driver.FindElement(By.CssSelector(element));
                    case 7:
                        return driver.FindElement(By.XPath(element));
                    default:
                        throw new ArgumentException("The given argument " + elementType + " for elementType is invalid.");
                }
            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                throw e;
            }
            
        }

        internal static bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string IsElementAvailable(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");

            Navigation.SwitchToDefaultFrame();
            switch (ElementHelper.WebElementHelper(elementType, element))
            {
                case 1:
                    str = IsElementPresent(By.Id(element)) ? true.ToString() : false.ToString();
                    break;
                case 2:
                    str = IsElementPresent(By.Name(element)) ? true.ToString() : false.ToString();
                    break;
                case 3:
                    str = IsElementPresent(By.TagName(element)) ? true.ToString() : false.ToString();
                    break;
                case 4:
                    str = IsElementPresent(By.PartialLinkText(element)) ? true.ToString() : false.ToString();
                    break;
                case 5:
                    str = IsElementPresent(By.LinkText(element)) ? true.ToString() : false.ToString();
                    break;
                case 6:
                    str = IsElementPresent(By.CssSelector(element)) ? true.ToString() : false.ToString();
                    break;
                case 7:
                    str = IsElementPresent(By.XPath(element)) ? true.ToString() : false.ToString();
                    break;
                default:
                    throw new ArgumentException("The given argument " + elementType + " for elementType is invalid.");
            }
            IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));
            if (str.Contains("false"))
            {
                foreach (IWebElement iframe in iframes)
                {
                    driver.SwitchTo().Frame(iframe);
                    switch (ElementHelper.WebElementHelper(elementType, element))
                    {
                        case 1:
                            str = IsElementPresent(By.Id(element)) ? true.ToString() : false.ToString();
                            break;
                        case 2:
                            str = IsElementPresent(By.Name(element)) ? true.ToString() : false.ToString();
                            break;
                        case 3:
                            str = IsElementPresent(By.TagName(element)) ? true.ToString() : false.ToString();
                            break;
                        case 4:
                            str = IsElementPresent(By.PartialLinkText(element)) ? true.ToString() : false.ToString();
                            break;
                        case 5:
                            str = IsElementPresent(By.LinkText(element)) ? true.ToString() : false.ToString();
                            break;
                        case 6:
                            str = IsElementPresent(By.CssSelector(element)) ? true.ToString() : false.ToString();
                            break;
                        case 7:
                            str = IsElementPresent(By.XPath(element)) ? true.ToString() : false.ToString();
                            break;
                        default:
                            throw new ArgumentException("The given argument " + elementType + " for elementType is invalid.");
                    }
                }
            }
            return str;
            
        }
    }
}
