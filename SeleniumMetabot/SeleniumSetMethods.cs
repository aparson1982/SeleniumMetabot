using OpenQA.Selenium;
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
        public static string EnterText(string element, string value, string elementType)
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
                if ((elementType.ToLower() == "tagname") ||(elementType.ToLower() == "tn"))
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



        public static string EnterNumericalValue(string element, int value, string elementType)
        {
            string str = string.Empty;
            IJavaScriptExecutor js = (IJavaScriptExecutor)SeleniumProperties.driver;
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    js.ExecuteScript("document.getElementById('" + element + "').setAttribute('value'," + value + ")");
                }
                str = "Success";
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
