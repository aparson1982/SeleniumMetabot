using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumSetMethods : SeleniumProperties
    {
        
        public static string MoveToAndEnterText(string elementType, string element, string value)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            
            try
            {
                IWebElement item;
                Actions actions = new Actions(driver);

                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    item = driver.FindElement(By.Id(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    item = driver.FindElement(By.Name(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "tagname") ||(elementType.ToLower() == "tn"))
                {
                    item = driver.FindElement(By.TagName(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    item = driver.FindElement(By.PartialLinkText(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    item = driver.FindElement(By.LinkText(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    item = driver.FindElement(By.CssSelector(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    item = driver.FindElement(By.XPath(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }

                string elementValue = SeleniumGetMethods.GetInputValue(element, elementType);

                if (value.ToLower() == elementValue.ToLower())
                {
                    str = value + " entered successfully.";
                }
                else
                {
                    str = value + " not entered successfully.";
                }

                //TODO:  Validate value that is in textbox and return success or not

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


        public static string EnterText(string elementType, string element, string value)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    driver.FindElement(By.Id(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    driver.FindElement(By.Name(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    driver.FindElement(By.TagName(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    driver.FindElement(By.PartialLinkText(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    driver.FindElement(By.LinkText(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    driver.FindElement(By.CssSelector(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    driver.FindElement(By.XPath(element)).SendKeys(value);
                }

                string elementValue = SeleniumGetMethods.GetInputValue(element, elementType);

                //TODO:  Validate value that is in textbox and return success or not

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


        /// <summary>
        /// Searches for the element in all iFrames (if any) and then enters the text
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static string iEnterText(string elementType, string element, string value)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.Id(element)).SendKeys(value);
                    }

                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.Name(element)).SendKeys(value);
                    }
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.TagName(element)).SendKeys(value);
                    }
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.PartialLinkText(element)).SendKeys(value);
                    }
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.LinkText(element)).SendKeys(value);
                    }
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.CssSelector(element)).SendKeys(value);
                    }
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        driver.FindElement(By.CssSelector(element)).SendKeys(value);
                    }
                }

                string elementValue = SeleniumGetMethods.GetInputValue(element, elementType);
                if (!elementValue.Equals(value))
                {
                    str = "Warning:  The value entered in the element [" + elementType + ": " + element + "] may be incorrect.";
                }
                else
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]";
                }

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

        
    }
}
