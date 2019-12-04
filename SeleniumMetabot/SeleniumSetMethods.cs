using OpenQA.Selenium;
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
    public static class SeleniumSetMethods
    {
        public static string MoveToAndEnterText(string elementType, string element, string value)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            
            try
            {
                IWebElement item;
                Actions actions = new Actions(SeleniumProperties.driver);

                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    item = SeleniumProperties.driver.FindElement(By.Id(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    item = SeleniumProperties.driver.FindElement(By.Name(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "tagname") ||(elementType.ToLower() == "tn"))
                {
                    item = SeleniumProperties.driver.FindElement(By.TagName(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    item = SeleniumProperties.driver.FindElement(By.PartialLinkText(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    item = SeleniumProperties.driver.FindElement(By.LinkText(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    item = SeleniumProperties.driver.FindElement(By.CssSelector(element));
                    actions.MoveToElement(item).Click(item).SendKeys(value);
                    actions.Perform();
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    item = SeleniumProperties.driver.FindElement(By.XPath(element));
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
                    SeleniumProperties.driver.FindElement(By.Id(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    SeleniumProperties.driver.FindElement(By.Name(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    SeleniumProperties.driver.FindElement(By.TagName(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    SeleniumProperties.driver.FindElement(By.PartialLinkText(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    SeleniumProperties.driver.FindElement(By.LinkText(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    SeleniumProperties.driver.FindElement(By.CssSelector(element)).SendKeys(value);
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    SeleniumProperties.driver.FindElement(By.XPath(element)).SendKeys(value);
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


        public static void ngEnterText(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                //SeleniumProperties.ngDriver.FindElement(NgBy.)
            }
            catch (Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }

            //return str;

        }

        
    }
}
