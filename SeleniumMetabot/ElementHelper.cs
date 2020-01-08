using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class ElementHelper : SeleniumProperties
    {
        private static string elementHelperMessages;
        
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
                    if (webElement.Displayed || webElement.GetAttribute("aria-disabled") == null)
                    {
                       return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                str = "true";
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
            return str;
        }

        /// <summary>
        /// Implicitly waits for the element to be Enabled.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static string WaitEnabled(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<IWebElement>((d) =>
                {
                    IWebElement webElement = ElementHelper.WebElement(elementType, element);
                    if (webElement.Enabled || webElement.GetAttribute("aria-disabled") == null)
                    {
                        return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                str = "true";
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
            return str;
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
                    if (webElement.Enabled && webElement.Displayed || webElement.GetAttribute("aria-disabled") == null && webElement.Displayed)
                    {
                        return webElement;
                    }
                    throw new TimeoutException("Timed out.");

                });
                str = "true";
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
            return str;
        }


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

            switch (ElementHelper.WebElementHelper(elementType, element))
            {
                case 1:
                    return IsElementPresent(By.Id(element)) ? true.ToString() : false.ToString();
                case 2:
                    return IsElementPresent(By.Name(element)) ? true.ToString() : false.ToString();
                case 3:
                    return IsElementPresent(By.TagName(element)) ? true.ToString() : false.ToString();
                case 4:
                    return IsElementPresent(By.PartialLinkText(element)) ? true.ToString() : false.ToString();
                case 5:
                    return IsElementPresent(By.LinkText(element)) ? true.ToString() : false.ToString();
                case 6:
                    return IsElementPresent(By.CssSelector(element)) ? true.ToString() : false.ToString();
                case 7:
                    return IsElementPresent(By.XPath(element)) ? true.ToString() : false.ToString();
                default:
                    throw new ArgumentException("The given argument " + elementType + " for elementType is invalid.");
            }

        }
    }
}
