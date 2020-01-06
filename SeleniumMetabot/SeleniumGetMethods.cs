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
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element;
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
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element;
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
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        str = GetInputValue(elementType, element);
                    }
                    
                }

            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = SeleniumUtilities.MethodName() + ":  " + "Error:  " + Environment.NewLine + 
                    "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element;
            }
            finally
            {
                Navigation.SwitchToDefaultFrame();
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
                    foreach (IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        str = GetText(elementType, element);
                    }
                    
                }

            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = SeleniumUtilities.MethodName() + ":  " + "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element;
            }
            finally
            {
                Navigation.SwitchToDefaultFrame();
            }
            return str;
        }


        public static string SmartGetValue(string element)
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

            while (str.Contains("Error") || str.Contains("Exception") || str.Contains("Failed") || count == 0)
            {
                str = iGetValue(eTypesQueue.Dequeue(), element);
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


        public static string SmartGetText(string element)
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

            while (str.Contains("Error") || str.Contains("Exception") || str.Contains("Failed") || count == 0)
            {
                str = iGetText(eTypesQueue.Dequeue(), element);
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
