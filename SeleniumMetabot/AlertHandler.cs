using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class AlertHandler
    {
        public static bool IsAlertPresent()
        {
            try
            {
                SeleniumProperties.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
        }

        public static void DismissAlert()
        {
            if (IsAlertPresent())
            {
                SeleniumProperties.driver.SwitchTo().Alert();
                SeleniumProperties.driver.SwitchTo().Alert().Accept();
                SeleniumProperties.driver.SwitchTo().DefaultContent();
            }
        }

        public static void AcceptAlert()
        {
            if (IsAlertPresent())
            {
                SeleniumProperties.driver.SwitchTo().Alert();
                SeleniumProperties.driver.SwitchTo().Alert().Dismiss();
                SeleniumProperties.driver.SwitchTo().DefaultContent();
            }
        }

    }
}
