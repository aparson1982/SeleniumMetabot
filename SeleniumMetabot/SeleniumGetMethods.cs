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
        

        public static string GetInputValue(string element, string elementType)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    str = driver.FindElement(By.Id(element)).GetAttribute("value");
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    str = driver.FindElement(By.Name(element)).GetAttribute("value");
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    str = driver.FindElement(By.TagName(element)).GetAttribute("value");
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    str = driver.FindElement(By.PartialLinkText(element)).GetAttribute("value");
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    str = driver.FindElement(By.LinkText(element)).GetAttribute("value");
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    str = driver.FindElement(By.CssSelector(element)).GetAttribute("value");
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    str = driver.FindElement(By.XPath(element)).GetAttribute("value");
                }
            }
            catch(Exception e)
            {
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }

        public static string GetText(string element, string elementType)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    str = driver.FindElement(By.Id(element)).Text;
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    str = driver.FindElement(By.Name(element)).Text;
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    str = driver.FindElement(By.TagName(element)).Text;
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    str = driver.FindElement(By.PartialLinkText(element)).Text;
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    str = driver.FindElement(By.LinkText(element)).Text;
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    str = driver.FindElement(By.CssSelector(element)).Text;
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    str = driver.FindElement(By.XPath(element)).Text;
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

        //TODO:  Search all frames for value
        public static string iGetValue()
        {
            return null;
        }


        //TODO:  Search all frames for text
        public static string iGetText()
        {
            return null;
        }
    }
}
