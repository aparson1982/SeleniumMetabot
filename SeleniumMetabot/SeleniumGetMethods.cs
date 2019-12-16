using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumGetMethods : SeleniumProperties
    {
        
        public static string GetInputValue(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                str = webElement.GetAttribute("value");
                MethodSuccess = true;
            }
            catch(Exception e)
            {
                MethodSuccess = false;
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }

        public static string GetText(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                str = webElement.Text;

                MethodSuccess = true;
            }
            catch (Exception e)
            {
                MethodSuccess = false;
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }

        //TODO:  Search all frames for value
        public static string iGetValue(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                GetInputValue(elementType, element);
                if (MethodSuccess == false)
                {
                    if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                    {

                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.Id(element)).GetAttribute("value");
                        }

                    }
                    if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.Name(element)).GetAttribute("value");
                        }
                    }
                    if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.TagName(element)).GetAttribute("value");
                        }
                    }
                    if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.PartialLinkText(element)).GetAttribute("value");
                        }
                    }
                    if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.LinkText(element)).GetAttribute("value");
                        }
                    }
                    if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.CssSelector(element)).GetAttribute("value");
                        }
                    }
                    if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.CssSelector(element)).GetAttribute("value");
                        }
                    }
                }

                Navigation.SwitchToDefaultFrame();
            }
            catch (Exception e)
            {
                Navigation.SwitchToDefaultFrame();
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }


        //TODO:  Search all frames for text
        public static string iGetText(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                GetInputValue(elementType, element);
                if (MethodSuccess == false)
                {
                    if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                    {

                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.Id(element)).Text;
                        }

                    }
                    if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.Name(element)).Text;
                        }
                    }
                    if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.TagName(element)).Text;
                        }
                    }
                    if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            driver.FindElement(By.PartialLinkText(element)).GetAttribute("value");
                        }
                    }
                    if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.LinkText(element)).Text;
                        }
                    }
                    if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.CssSelector(element)).Text;
                        }
                    }
                    if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                    {
                        foreach (IWebElement iframe in iframes)
                        {
                            driver.SwitchTo().Frame(iframe);
                            str = driver.FindElement(By.CssSelector(element)).Text;
                        }
                    }
                }

                Navigation.SwitchToDefaultFrame();
            }
            catch (Exception e)
            {
                Navigation.SwitchToDefaultFrame();
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }
    }
}
