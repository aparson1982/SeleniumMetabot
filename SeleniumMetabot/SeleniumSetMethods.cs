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
                Actions actions = new Actions(driver);
                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                actions.MoveToElement(webElement).Click(webElement).SendKeys(value);

                string elementValue = SeleniumGetMethods.GetInputValue(elementType, element);

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
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value;
            }
            return str;
        }


        public static string EnterText(string elementType, string element, string value)
        {
            string str = string.Empty;
            elementType = Regex.Replace(elementType, @"s", "");
            try
            {

                IWebElement webElement = ElementHelper.WebElement(elementType, element);
                webElement.SendKeys(value);

                
                string elementValue = SeleniumGetMethods.GetInputValue(elementType, element);

                if (!elementValue.Equals(value))
                {
                    str = "Warning:  The value entered in the element [" + elementType + ": " + element + "] may be incorrect.";
                }
                else
                {
                    str = "Entered " + value + " into element [" + elementType + ": " + element + "]";
                }

                MethodSuccess = true;
                //TODO:  Validate value that is in textbox and return success or not

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
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value;
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
                Navigation.SwitchToDefaultFrame();
                IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));
                

                EnterText(elementType, element, value);
                if (MethodSuccess == false)
                {
                    foreach(IWebElement iframe in iframes)
                    {
                        driver.SwitchTo().Frame(iframe);
                        EnterText(elementType, element, value);
                    }
                    
                }
                

                string elementValue = SeleniumGetMethods.GetInputValue(elementType, element);
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
                if (doTakeScreenshot)
                {
                    ScreenShot.TakeScreenShot();
                }
                str = "Message:  " + e.Message + Environment.NewLine +
                    "Source:  " + e.Source + Environment.NewLine +
                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                    "Parameters:  elementType = " + elementType + " | element = " + element + " | value = " + value;
            }
            finally
            {
                Navigation.SwitchToDefaultFrame();
            }
            return str;

        }

        
    }
}
