using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
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
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    IWebElement webElement = driver.FindElement(By.Id(element));
                    actions.Click(webElement).Perform();
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    IWebElement webElement = driver.FindElement(By.Name(element));
                    actions.Click(webElement).Perform();
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                {
                    IWebElement webElement = driver.FindElement(By.TagName(element));
                    actions.Click(webElement).Perform();
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                {
                    IWebElement webElement = driver.FindElement(By.PartialLinkText(element));
                    actions.Click(webElement).Perform();
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                {
                    IWebElement webElement = driver.FindElement(By.LinkText(element));
                    actions.Click(webElement).Perform();
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    IWebElement webElement = driver.FindElement(By.CssSelector(element));
                    actions.Click(webElement).Perform();
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    IWebElement webElement = driver.FindElement(By.XPath(element));
                    actions.Click(webElement).Perform();
                }
                str = "Clicked " + SeleniumGetMethods.GetInputValue(element, elementType);
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

        public static string Submit(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    driver.FindElement(By.Id(element)).Submit();
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    driver.FindElement(By.Name(element)).Submit();
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    driver.FindElement(By.TagName(element)).Submit();
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    driver.FindElement(By.PartialLinkText(element)).Submit();
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    driver.FindElement(By.LinkText(element)).Submit();
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    driver.FindElement(By.CssSelector(element)).Submit();
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    driver.FindElement(By.XPath(element)).Submit();
                }
                str = "Clicked " + SeleniumGetMethods.GetInputValue(element, elementType);
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


        public static string RightClick(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            Actions actions = new Actions(driver);
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    IWebElement webElement = driver.FindElement(By.Id(element));
                    actions.ContextClick(webElement).Perform();

                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    IWebElement webElement = driver.FindElement(By.Name(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                {
                    IWebElement webElement = driver.FindElement(By.TagName(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                {
                    IWebElement webElement = driver.FindElement(By.PartialLinkText(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                {
                    IWebElement webElement = driver.FindElement(By.LinkText(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    IWebElement webElement = driver.FindElement(By.CssSelector(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    IWebElement webElement = driver.FindElement(By.XPath(element));
                    actions.ContextClick(webElement).Perform();
                }
                str = "Clicked " + SeleniumGetMethods.GetInputValue(element, elementType);
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

        public static string JSClick(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    IWebElement webElement = driver.FindElement(By.Id(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);

                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    IWebElement webElement = driver.FindElement(By.Name(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                {
                    IWebElement webElement = driver.FindElement(By.TagName(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                {
                    IWebElement webElement = driver.FindElement(By.PartialLinkText(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                {
                    IWebElement webElement = driver.FindElement(By.LinkText(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    IWebElement webElement = driver.FindElement(By.CssSelector(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    IWebElement webElement = driver.FindElement(By.XPath(element));
                    executor.ExecuteScript("arguments[0].click();", webElement);
                    str = "Clicked " + webElement.Text;
                }
                //str = "Clicked " + SeleniumGetMethods.GetInputValue(element, elementType);
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


        //TODO:  Add iClick.  Look into searching all frames and clicking.  Also look into incorporating JSClick if Click doesn't work.
    }
}
