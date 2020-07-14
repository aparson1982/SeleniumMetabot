using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Protractor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class SeleniumSetMethods : SeleniumProperties
    {
        
        public static string MoveToAndEnterText(string elementType, string element, string value, bool doClear = true)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            
            try
            {
                Actions actions = new Actions(driver);
                IWebElement webElement = ElementHelper.WebElement(elementType, element);

                if (doClear == true)
                {
                    webElement.Clear();
                }
                
                actions.MoveToElement(webElement).Click(webElement).SendKeys(value);

                string elementValue = SeleniumGetMethods.GetInputValue(elementType, element);

                if (!elementValue.Equals(value))
                {
                    str = "Warning:  The value entered in the element [" + elementType + ": " + element + "] may be incorrect." + Environment.NewLine;
                    str += "Expected Value:  " + value + Environment.NewLine;
                    str += "Actual Value:  " + elementValue + Environment.NewLine;
                }
                else
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]" + Environment.NewLine;
                }

                

            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        public static string EnterText(string elementType, string element, string value, bool doClear = true)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {

                IWebElement webElement = ElementHelper.WebElement(elementType, element);

                if (doClear == true)
                {
                    webElement.Clear();
                }
                
                webElement.SendKeys(value);


                string webElementValue = webElement.GetAttribute("value");
                string webElementText = webElement.Text;
                string elementValue = SeleniumGetMethods.GetInputValue(elementType, element);
                string elementText = SeleniumGetMethods.GetText(elementType, element);

                if (String.Equals(value, webElementValue, StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, webElementText, StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, elementValue, StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, elementText, StringComparison.OrdinalIgnoreCase)
                    )
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]" + Environment.NewLine;
                    if (webElementValue.Contains(value))
                    {
                        str += "[Exact Match](webElementValue) Retrieved Value:  " + webElementValue + Environment.NewLine;
                    }
                    else if (webElementText.Contains(value))
                    {
                        str += "[Exact Match](webElementText) Retrieved Value:  " + webElementText + Environment.NewLine;
                    }
                    else if (elementValue.Contains(value))
                    {
                        str += "[Exact Match](elementValue) Retrieved Value:  " + elementValue + Environment.NewLine;
                    }
                    else if (elementText.Contains(value))
                    {
                        str += "[Exact Match](elementText) Retrieved Value:  " + elementText + Environment.NewLine;
                    }
                }
                else if (webElementValue.Contains(value) || webElementText.Contains(value) || elementValue.Contains(value) || elementText.Contains(value))
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]" + Environment.NewLine;
                    if (webElementValue.Contains(value))
                    {
                        str += "[Partial Match](webElementValue) Retrieved Value:  " + webElementValue + Environment.NewLine;
                    }
                    else if (webElementText.Contains(value))
                    {
                        str += "[Partial Match](webElementText) Retrieved Value:  " + webElementText + Environment.NewLine;
                    }
                    else if (elementValue.Contains(value))
                    {
                        str += "[Partial Match](elementValue) Retrieved Value:  " + elementValue + Environment.NewLine;
                    }
                    else if (elementText.Contains(value))
                    {
                        str += "[Partial Match](elementText) Retrieved Value:  " + elementText + Environment.NewLine;
                    }

                }
                else
                {
                    str = "WARNING:  The value entered in the element [" + elementType + ": " + element + "] may be incorrect." + Environment.NewLine;
                    str += "Expected Value:  " + value + Environment.NewLine;
                    str += "(webElementValue) Retrieved Value:  " + webElementValue + Environment.NewLine;
                    str += "(webElementText) Retrieved Value:  " + webElementText + Environment.NewLine;
                    str += "(elementValue) Retrieved Value:  " + elementValue + Environment.NewLine;
                    str += "(elementText) Retrieved Value:  " + elementText + Environment.NewLine;
                }

                MethodSuccess = true;
                

            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        private static string iEnterTextSubMethod(string elementType, string element, string value, bool doClear = true)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            
            try
            {
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                if (doClear == true)
                {
                    webElement.Clear();
                }

                webElement.SendKeys(value);


                string webElementValue = webElement.GetAttribute("value");
                string webElementText = webElement.Text;
                string elementValue = SeleniumGetMethods.iGetValue(elementType, element);
                string elementText = SeleniumGetMethods.iGetText(elementType, element);

                
                if (String.Equals(value, webElementValue, StringComparison.OrdinalIgnoreCase) || 
                    String.Equals(value, webElementText, StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, elementValue, StringComparison.OrdinalIgnoreCase) ||
                    String.Equals(value, elementText, StringComparison.OrdinalIgnoreCase)
                    )
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]" + Environment.NewLine;
                    if (webElementValue.Contains(value))
                    {
                        str += "[Exact Match](webElementValue) Retrieved Value:  " + webElementValue + Environment.NewLine;
                    }
                    else if (webElementText.Contains(value))
                    {
                        str += "[Exact Match](webElementText) Retrieved Value:  " + webElementText + Environment.NewLine;
                    }
                    else if (elementValue.Contains(value))
                    {
                        str += "[Exact Match](elementValue) Retrieved Value:  " + elementValue + Environment.NewLine;
                    }
                    else if (elementText.Contains(value))
                    {
                        str += "[Exact Match](elementText) Retrieved Value:  " + elementText + Environment.NewLine;
                    }
                }
                else if (webElementValue.Contains(value) || webElementText.Contains(value) || elementValue.Contains(value) || elementText.Contains(value))
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]" + Environment.NewLine;
                    if (webElementValue.Contains(value))
                    {
                        str += "[Partial Match](webElementValue) Retrieved Value:  " + webElementValue + Environment.NewLine;
                    }
                    else if (webElementText.Contains(value))
                    {
                        str += "[Partial Match](webElementText) Retrieved Value:  " + webElementText + Environment.NewLine;
                    }
                    else if (elementValue.Contains(value))
                    {
                        str += "[Partial Match](elementValue) Retrieved Value:  " + elementValue + Environment.NewLine;
                    }
                    else if (elementText.Contains(value))
                    {
                        str += "[Partial Match](elementText) Retrieved Value:  " + elementText + Environment.NewLine;
                    }
                    
                }
                else
                {
                    str = "WARNING:  The value entered in the element [" + elementType + ": " + element + "] may be incorrect." + Environment.NewLine;
                    str += "Expected Value:  " + value + Environment.NewLine;
                    str += "(webElementValue) Retrieved Value:  " + webElementValue + Environment.NewLine;
                    str += "(webElementText) Retrieved Value:  " + webElementText + Environment.NewLine;
                    str += "(elementValue) Retrieved Value:  " + elementValue + Environment.NewLine;
                    str += "(elementText) Retrieved Value:  " + elementText + Environment.NewLine;
                }

                MethodSuccess = true;


            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                MethodSuccess = false;
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value + Environment.NewLine;
            }
            return SeleniumUtilities.MethodName() + ":  " + str;
        }


        /// <summary>
        /// Searches for the element in all iFrames (if any) and then enters the text
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="doClear"></param>
        public static string iEnterText(string elementType, string element, string value, bool doClear = true)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));


                str = iEnterTextSubMethod(elementType, element, value, doClear);
                if (MethodSuccess == false)
                {
                    foreach(IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        str = iEnterTextSubMethod(elementType, element, value, doClear);
                    }
                    
                }


                //string elementValue = SeleniumGetMethods.iGetValue(elementType, element);
                //if (!elementValue.Equals(value))
                //{
                //    str = "Warning:  The value entered in the element [" + elementType + ": " + element + "] may be incorrect." + Environment.NewLine;
                //    str += "Expected Value:  " + value + Environment.NewLine;
                //    str += "Actual Value:  " + elementValue + Environment.NewLine;
                //}
                //else
                //{
                //    str = "Entered " + value + " into element [" + elementType + ": " + element + "]" + Environment.NewLine;
                //}

            }
            catch (Exception e)
            {
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value + Environment.NewLine;
            }
            finally
            {
                Navigation.SwitchToDefaultFrame();
            }
            return SeleniumUtilities.MethodName() + ":  " + str;

        }

        
    }
}
