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

        public static string Wait(string elementType, string element, int timeoutInSeconds)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until<IWebElement>((d) =>
                {
                    if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                    {
                        IWebElement webElement = d.FindElement(By.Id(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by Id.";
                            return webElement;
                        }
                    }
                    if ((elementType.ToLower().Trim(' ') == "name") || (elementType.ToLower().Trim(' ') == "n"))
                    {
                        IWebElement webElement = d.FindElement(By.Name(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by Name.";
                            return webElement;
                        }
                    }
                    if ((elementType.ToLower().Trim(' ') == "tagname") || (elementType.ToLower().Trim(' ') == "tn"))
                    {
                        IWebElement webElement = d.FindElement(By.TagName(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by TagName.";
                            return webElement;
                        }
                    }
                    if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                    {
                        IWebElement webElement = d.FindElement(By.PartialLinkText(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by Partial Link Text.";
                            return webElement;
                        }
                    }
                    if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                    {
                        IWebElement webElement = d.FindElement(By.LinkText(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by Link Text.";
                            return webElement;
                        }
                    }
                    if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                    {
                        IWebElement webElement = d.FindElement(By.CssSelector(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by CSS Selector.";
                            return webElement;
                        }
                    }
                    if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                    {
                        IWebElement webElement = d.FindElement(By.XPath(element));
                        if (webElement.Displayed && webElement.Enabled && webElement.GetAttribute("aria-disabled") == null)
                        {
                            str = "Found by XPath.";
                            return webElement;
                        }
                    }
                    return null;

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



        internal static int elementTypeHelper(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");

            if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
            {
                if (SeleniumUtilities.IsElementPresent(By.Id(element)))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
            {
                if (SeleniumUtilities.IsElementPresent(By.Name(element)))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
            {
                if (SeleniumUtilities.IsElementPresent(By.TagName(element)))
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
            if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
            {
                if (SeleniumUtilities.IsElementPresent(By.PartialLinkText(element)))
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
            if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
            {
                if (SeleniumUtilities.IsElementPresent(By.LinkText(element)))
                {
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
            {
                if (SeleniumUtilities.IsElementPresent(By.CssSelector(element)))
                {
                    return 6;
                }
                else
                {
                    return 0;
                }
            }
            if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
            {
                if (SeleniumUtilities.IsElementPresent(By.XPath(element)))
                {
                    return 7;
                }
                else
                {
                    return 0;
                }
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
                switch (ElementHelper.elementTypeHelper(elementType, element))
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
                }
            }
            catch (Exception )
            {
                throw;
            }
            
        }
    }
}
