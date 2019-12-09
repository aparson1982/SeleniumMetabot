using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumMetabot;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void MyTestMethod()
        {
            //Initialize.OpenUrl("https://www.chattanoogamobility.com/");
            //Thread.Sleep(10000);
            //PageNavigation.ScrollIntoView("field1", "id");
        }

        [TestMethod]
        public void NewTest()
        {

            Initialize.OpenUrl("http://sw72cseapqa:8080/CSWI/login/login.jsp");
            PageSetup.MaximizeWindow();
            //Thread.Sleep(1000);
            Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='userId']", "SOLLRPA"));
            Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='password']", "fR3kZwFe7UDGVHEe"));
            MouseActions.Submit("xp", "//input[@class='button']");
            //Thread.Sleep(3000);

            //Console.WriteLine(SeleniumUtilities.PageSourceCode());
            //Navigation.NavigateTo("http://sw72cseapdv:8080/CSWI/Layout.jsp?pageUrl=/CSWI/order/FreightOrderLineRateDisplay.jsp");
            MouseActions.Click("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]");
            MouseActions.Click("xp", "//li[7]//ul[1]//li[5]//a[1]");
            //Thread.Sleep(3000);
            string bolNumber = "987588";
            //Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            //Console.WriteLine(SeleniumUtilities.PageSourceCode());
            //Console.WriteLine(ElementHelper.Wait("xp", "//body[@class='tundra']//td//td[1]//input[1]", 10));
            //Console.WriteLine(MouseActions.JSClick("xp", "//body[@class='tundra']//td//td[1]//input[1]"));
            ////MouseActions.Click("xp", "//td[contains(text(),'BOL:')]");
            //Thread.Sleep(3000);

            Console.WriteLine(SeleniumSetMethods.iEnterText("id", "bolNbr", bolNumber));

            Console.WriteLine(SeleniumUtilities.isElementExist("xp", "//span[contains(text(),'Ok')]"));

            Console.WriteLine(MouseActions.Click("xp", "//body[@class='tundra']//td//td[1]//input[1]"));

            if (SeleniumUtilities.isElementExist("xp", "//span[contains(text(),'Ok')]").Equals("True"))
            {
                Console.WriteLine(SeleniumUtilities.isElementExist("xp", "//span[contains(text(),'Ok')]"));
                Console.WriteLine(MouseActions.JSClick("xp", "//span[contains(text(),'Ok')]"));
            }
            //Thread.Sleep(6000);
            Console.WriteLine(SeleniumUtilities.isElementExist("xp", "//span[contains(text(),'Ok')]"));

            

            //driver.FindElement(By.Id("bolNbr")).SendKeys(bolNumber);
        }

        
    }
}
