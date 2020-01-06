using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class AlertHandler : SeleniumProperties
    {
        private static string alertMsg;
        
        public static bool IsAlertPresent()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alertMsg += SeleniumUtilities.MethodName() + ":  " + "Alert Present" + Environment.NewLine;
                return true;
            }
            catch (NoAlertPresentException)
            {
                alertMsg += SeleniumUtilities.MethodName() + ":  " + "Alert Not Found." + Environment.NewLine;
                return false;
            }
        }

        public static string DismissAlert()
        {
            if (!IsAlertPresent()) return alertMsg;
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
                alertMsg += SeleniumUtilities.MethodName() + ":  " + "Alert Dismissed" + Environment.NewLine;
            }
            catch (Exception e)
            {
                alertMsg += "Unable to Dismiss the Alert.  " + Environment.NewLine + 
                            "Message:  " + e.Message + Environment.NewLine +
                            "Source:  " + e.Source + Environment.NewLine +
                            "StackTrace:  " + e.StackTrace + Environment.NewLine +
                            "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }

            return SeleniumUtilities.MethodName() + ":  " +  alertMsg;
        }

        public static string AcceptAlert()
        {
            
            if (!IsAlertPresent()) return alertMsg;
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                alertMsg += SeleniumUtilities.MethodName() + ":  " + "Alert Accepted" + Environment.NewLine;
            }
            catch (Exception e)
            {
                alertMsg += "Unable to Accept the Alert.  " + Environment.NewLine +
                            "Message:  " + e.Message + Environment.NewLine +
                            "Source:  " + e.Source + Environment.NewLine +
                            "StackTrace:  " + e.StackTrace + Environment.NewLine +
                            "Inner Exception:  " + e.InnerException + Environment.NewLine;
            }

            return SeleniumUtilities.MethodName() + ":  " + alertMsg;
        }

        public static string GetAlertText()
        {
            string str = string.Empty;
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                str = alert.Text;
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
                      "Target Site:  " + e.TargetSite + Environment.NewLine +
                      "Help Link:  " + e.HelpLink + Environment.NewLine +
                      "Data:  " + e.Data + Environment.NewLine;
            }
            return str;
        }

    }
}
