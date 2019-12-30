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
        
        //public static IWebElement FindElement(By by, int timeoutInSeconds)
        //{
        //    if (timeoutInSeconds > 0)
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        return wait.Until(drv => drv.FindElement(by));
        //    }
        //    return driver.FindElement(by);
        //}

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
                return str;
            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }

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
                return str;
            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
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

        internal static IWebElement WebElement(string elementType, string element)
        {
            try
            {
                switch (ElementHelper.WebElementHelper(elementType, element))
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
            catch (Exception)
            {
                throw;
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
                    if (IsElementPresent(By.Id(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                case 2:
                    if (IsElementPresent(By.Name(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                case 3:
                    if (IsElementPresent(By.TagName(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                case 4:
                    if (IsElementPresent(By.PartialLinkText(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                case 5:
                    if (IsElementPresent(By.LinkText(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                case 6:
                    if (IsElementPresent(By.CssSelector(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                case 7:
                    if (IsElementPresent(By.XPath(element)))
                    {
                        return true.ToString();
                    }
                    else
                    {
                        return false.ToString();
                    }
                default:
                    throw new ArgumentException("The given argument " + elementType + " for elementType is invalid.");
            }

            //if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
            //{
            //    if (IsElementPresent(By.Id(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
            //{
            //    if (IsElementPresent(By.Name(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
            //{
            //    if (IsElementPresent(By.TagName(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
            //{
            //    if (IsElementPresent(By.PartialLinkText(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
            //{
            //    if (IsElementPresent(By.LinkText(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
            //{
            //    if (IsElementPresent(By.CssSelector(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
            //{
            //    if (IsElementPresent(By.XPath(element)))
            //    {
            //        return true.ToString();
            //    }
            //    else
            //    {
            //        return false.ToString();
            //    }
            //}
            //return "Invalid Argument For ElementType:  " + elementType + " is not a valid element type.";
        }
    }
}
