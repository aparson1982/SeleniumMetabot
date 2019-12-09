using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumUtilities : SeleniumProperties
    {
        
        public static string PageSourceCode()
        {
            return driver.PageSource;
        }

        public static string PageTitle()
        {
            return driver.Title;
        }

        public static int FramesCount()
        {
            return driver.FindElements(By.XPath("//iframe")).Count();
        }
        
        //public IList<string> Iframes()
        //{
        //    IList<IWebElement> iFrames = driver.FindElements(By.XPath("//iframe"));
        //    return iFrames;
        //}
        
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

        public static string isElementAvailable(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");

            if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
            {
                if (IsElementPresent(By.Id(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
            {
                if (IsElementPresent(By.Name(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
            {
                if (IsElementPresent(By.TagName(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
            {
                if (IsElementPresent(By.PartialLinkText(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
            {
                if (IsElementPresent(By.LinkText(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
            {
                if (IsElementPresent(By.CssSelector(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
            {
                if (IsElementPresent(By.XPath(element)))
                {
                    return true.ToString();
                }
                else
                {
                    return false.ToString();
                }
            }
            return "Invalid Argument For ElementType:  " + elementType + " is not a valid element type.";
        }


    }
}
