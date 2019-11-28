using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumMetabot
{
    public class PageNavigation
    {
        public static void ScrollIntoView(string element, string elementType)
        {
            string str = string.Empty;
            if ((elementType.ToLower().Trim(' ') == "id") || (elementType.ToLower().Trim(' ') == "i"))
            {
                var item = SeleniumProperties.driver.FindElement(By.Id(element));
                Actions actions = new Actions(SeleniumProperties.driver);
                actions.MoveToElement(item);
                actions.Perform();
            }
            if ((elementType.ToLower() == "name") || (elementType.ToLower().Trim(' ') == "n"))
            {
                var item = SeleniumProperties.driver.FindElement(By.Name(element));
                Actions actions = new Actions(SeleniumProperties.driver);
                actions.MoveToElement(item);
                actions.Perform();
            }
                       //TODO Finish Writing the rest of the method
        }
    }
}
