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
                IWebElement webElement = ElementHelper.WebElement(elementType, element);


                //if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                //{
                //    webElement = driver.FindElement(By.Id(element));
                    
                //}
                //if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                //{
                //    webElement = driver.FindElement(By.Name(element));

                //}
                //if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                //{
                //    webElement = driver.FindElement(By.TagName(element));

                //}
                //if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                //{
                //    webElement = driver.FindElement(By.PartialLinkText(element));

                //}
                //if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                //{
                //    webElement = driver.FindElement(By.LinkText(element));

                //}
                //if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                //{
                //    webElement = driver.FindElement(By.CssSelector(element));
  
                //}
                //if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                //{
                //    webElement = driver.FindElement(By.XPath(element));
                    
                //}


                if (webElement != null)
                {
                    actions.Click(webElement).Perform();
                    str = "Clicked " + webElement.Text;
                }
                
            }
            catch (Exception e)
            {
                str = "Click Exception." + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
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
            Actions actions = new Actions(driver);
            try
            {
                IWebElement webElement = null;
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    webElement = driver.FindElement(By.Id(element));

                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    webElement = driver.FindElement(By.Name(element));

                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn"))
                {
                    webElement = driver.FindElement(By.TagName(element));

                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl"))
                {
                    webElement = driver.FindElement(By.PartialLinkText(element));
   
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt"))
                {
                    webElement = driver.FindElement(By.LinkText(element));

                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    webElement = driver.FindElement(By.CssSelector(element));

                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    webElement = driver.FindElement(By.XPath(element));

                }

                if (webElement != null)
                {
                    webElement.Submit();
                    str = "Clicked " + webElement.Text;
                }
            }
            catch (Exception e)
            {
                str = "Submit Exception." + Environment.NewLine + 
                      "Message:  " + e.Message + Environment.NewLine +
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
                IWebElement webElement = null;
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    webElement = driver.FindElement(By.Id(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    webElement = driver.FindElement(By.Name(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                {
                    webElement = driver.FindElement(By.TagName(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                {
                    webElement = driver.FindElement(By.PartialLinkText(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                {
                    webElement = driver.FindElement(By.LinkText(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    webElement = driver.FindElement(By.CssSelector(element));
                    actions.ContextClick(webElement).Perform();
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    webElement = driver.FindElement(By.XPath(element));
                    actions.ContextClick(webElement).Perform();
                }
                if (webElement != null) str = "Clicked " + webElement.Text;
            }
            catch (Exception e)
            {
                str = "RightClick Exception." + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }

        public static string JClick(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            try
            {
                IWebElement webElement = null;
                if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                {
                    webElement = driver.FindElement(By.Id(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                {
                    webElement = driver.FindElement(By.Name(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                {
                    webElement = driver.FindElement(By.TagName(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                {
                    webElement = driver.FindElement(By.PartialLinkText(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                {
                    webElement = driver.FindElement(By.LinkText(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                }
                if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                {
                    webElement = driver.FindElement(By.CssSelector(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                    
                }
                if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                {
                    webElement = driver.FindElement(By.XPath(element));
                    executor?.ExecuteScript("arguments[0].click();", webElement);
                }
                if (webElement != null) str = "Clicked " + webElement.Text;
                //str = "Clicked " + SeleniumGetMethods.GetInputValue(element, elementType);
            }
            catch (Exception e)
            {
                str = "JClick Exception." + Environment.NewLine +
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException;
            }
            return str;
        }


        /// <summary>
        /// Searches all frames when clicking.  Returns to the default frame when done.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string iClick(string elementType, string element)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));
                
                foreach (IWebElement iframe in iframes)
                {
                    driver.SwitchTo().Frame(iframe);
                    if (Regex.IsMatch(Click(elementType, element), @"\bClick Exception\b"))
                    {
                        str = Click(elementType, element) + Environment.NewLine + Environment.NewLine;
                    }
                    else if (Regex.IsMatch(JClick(elementType, element), @"\bJClick Exception\b"))
                    {
                        str += JClick(elementType, element) + Environment.NewLine + Environment.NewLine;
                    }
                    else if (Regex.IsMatch(Submit(elementType, element), @"\bSubmit Exception\b"))
                    {
                        str += JClick(elementType, element) + Environment.NewLine + Environment.NewLine;
                    }
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
        //TODO:  Add iClick.  Look into searching all frames and clicking.  Also look into incorporating JClick if Click doesn't work.
    }
}
