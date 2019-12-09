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
        
        public static bool IsAlertPresent()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
        }

        public static void DismissAlert()
        {
            if (!IsAlertPresent()) return;
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public static void AcceptAlert()
        {
            if (!IsAlertPresent()) return;
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
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
                str = "Message:  " + e.Message + Environment.NewLine +
                                    "Source:  " + e.Source + Environment.NewLine +
                                    "StackTrace:  " + e.StackTrace + Environment.NewLine +
                                    "Inner Exception:  " + e.InnerException + Environment.NewLine +
                                    "Target Site:  " + e.TargetSite + Environment.NewLine +
                                    "Help Link:  " + e.HelpLink + Environment.NewLine +
                                    "Data:  " + e.Data;
            }
            return str;
        }

    }
}
