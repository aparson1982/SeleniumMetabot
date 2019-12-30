using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
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
                
                if (webElement != null)
                {
                    actions.Click(webElement).Perform();
                    str = "Clicked " + webElement.Text;
                }
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                MethodSuccess = false;
                str = Environment.NewLine + "Click Exception." + Environment.NewLine + 
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
                IWebElement webElement = ElementHelper.WebElement(elementType, element);

                if (webElement != null)
                {
                    webElement.Submit();
                    str = "Clicked " + webElement.Text;
                }
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                MethodSuccess = false;
                str = Environment.NewLine + "Submit Exception." + Environment.NewLine + 
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
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                actions.ContextClick(webElement).Perform();
                //if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
                //{
                //    webElement = driver.FindElement(By.Id(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                //if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
                //{
                //    webElement = driver.FindElement(By.Name(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                //if ((elementType.ToLower() == "tagname") || (elementType.ToLower() == "tn") || (elementType.ToLower() == "t") || (elementType.ToLower() == "tag"))
                //{
                //    webElement = driver.FindElement(By.TagName(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                //if ((elementType.ToLower() == "partiallinktext") || (elementType.ToLower() == "plt") || (elementType.ToLower() == "pl") || (elementType.ToLower() == "plink"))
                //{
                //    webElement = driver.FindElement(By.PartialLinkText(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                //if ((elementType.ToLower() == "linktext") || (elementType.ToLower() == "lt") || (elementType.ToLower() == "link"))
                //{
                //    webElement = driver.FindElement(By.LinkText(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                //if ((elementType.ToLower() == "cssselector") || (elementType.ToLower() == "csss") || (elementType.ToLower() == "csselector") || (elementType.ToLower() == "cselector") || (elementType.ToLower() == "css"))
                //{
                //    webElement = driver.FindElement(By.CssSelector(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                //if ((elementType.ToLower() == "xpath") || (elementType.ToLower() == "xp") || (elementType.ToLower() == "x"))
                //{
                //    webElement = driver.FindElement(By.XPath(element));
                //    actions.ContextClick(webElement).Perform();
                //}
                if (webElement != null) str = "Clicked " + webElement.Text;
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                MethodSuccess = false;
                str = Environment.NewLine + "RightClick Exception." + Environment.NewLine + 
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
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                executor?.ExecuteScript("arguments[0].click();", webElement);
                
                if (webElement != null) str = "Clicked " + webElement.Text;
                
                MethodSuccess = true;
            }
            catch (Exception e)
            {
                MethodSuccess = false;
                str = Environment.NewLine + "JClick Exception." + Environment.NewLine +
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
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));

                Click(elementType, element);
                if (MethodSuccess == false)
                {
                    JClick(elementType, element);
                    if (MethodSuccess == false)
                    {
                        Submit(elementType, element);
                        if (MethodSuccess == false)
                        {
                            foreach (IWebElement iframe in iframes)
                            {
                                driver.SwitchTo().Frame(iframe);
                                if (Regex.IsMatch(Click(elementType, element), @"\bClick Exception\b"))
                                {
                                    if (Regex.IsMatch(JClick(elementType, element), @"\bJClick Exception\b"))
                                    {
                                        if (Regex.IsMatch(Submit(elementType, element), @"\bSubmit Exception\b"))
                                        {
                                            str = "iClick Failed.";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                str = Environment.NewLine + "Error" + Environment.NewLine + 
                      "Message:  " + e.Message + Environment.NewLine +
                      "Source:  " + e.Source + Environment.NewLine +
                      "StackTrace:  " + e.StackTrace + Environment.NewLine +
                      "Inner Exception:  " + e.InnerException;
            }
            finally
            {
                Navigation.SwitchToDefaultFrame();
            }

            return str;
        }


        public static string SmartClick(string element)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            Queue<string> eTypesQueue = new Queue<string>();
            eTypesQueue.Enqueue("id");
            eTypesQueue.Enqueue("name");
            eTypesQueue.Enqueue("tagname");
            eTypesQueue.Enqueue("plt");
            eTypesQueue.Enqueue("lt");
            eTypesQueue.Enqueue("css");
            eTypesQueue.Enqueue("xp");
            int count = 0;

            while(str.Contains("Error") || str.Contains("Exception") || str.Contains("Failed") || count == 0)
            {
                str = iClick(eTypesQueue.Dequeue(), element);
                str2 += str;
                count++;
                if (!eTypesQueue.Any())
                {
                    break;
                }
            }

            if (str.Contains("Error") || str.Contains("Exception") || str.Contains("Failed"))
            {
                str = str2;
            }
            
            return str;

        }
        
    }
}
