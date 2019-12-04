using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumMetabot;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Initialize.OpenUrl("http://sw72cseapqa:8080/CSWI/login/login.jsp");
            //Thread.Sleep(1000);
            //Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='userId']", "SOLLRPA"));
            //Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='password']", "fR3kZwFe7UDGVHEe"));

            //Button.Submit("xp", "//input[@class='button']");
            //Thread.Sleep(3000);
            //Button.Click("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]");
            //Button.Click("xp", "//li[7]//ul[1]//li[5]//a[1]");
            //Thread.Sleep(3000);
            //string bolNumber = "987588";
            ////SeleniumSetMethods.EnterText("bolNbr", "" + bolNumber, "id");
            //Console.WriteLine(SeleniumSetMethods.MoveToAndEnterText("xp", "//input[@name='bolNbr']", bolNumber));
            //Thread.Sleep(1000);
            //Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='bolDate']", "11/27/2019"));
            //Button.Click("xp", "//body[@class='tundra']//td//td[1]//input[1]");
            //Thread.Sleep(5000);

            ////CleanUp.Demolish();

        }

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
            Initialize.InitializeChromeDriver();
            Initialize.OpenUrl("http://sw72cseapqa:8080/CSWI/login/login.jsp");
            PageSetup.MaximizeWindow();
            Thread.Sleep(1000);
            Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='userId']", "SOLLRPA"));
            Console.WriteLine(SeleniumSetMethods.EnterText("xp", "//input[@name='password']", "fR3kZwFe7UDGVHEe"));
            MouseActions.Submit("xp", "//input[@class='button']");
            Thread.Sleep(3000);

            //Console.WriteLine(SeleniumUtilities.PageSourceCode());
            //Navigation.NavigateTo("http://sw72cseapdv:8080/CSWI/Layout.jsp?pageUrl=/CSWI/order/FreightOrderLineRateDisplay.jsp");
            MouseActions.Click("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]");
            MouseActions.Click("xp", "//li[7]//ul[1]//li[5]//a[1]");
            Thread.Sleep(3000);
            string bolNumber = "987588";
            Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            Console.WriteLine(SeleniumUtilities.PageSourceCode());
            //Console.WriteLine(ElementHelper.Wait("xp", "//body[@class='tundra']//td//td[1]//input[1]", 10));
            //Console.WriteLine(MouseActions.JSClick("xp", "//body[@class='tundra']//td//td[1]//input[1]"));
            ////MouseActions.Click("xp", "//td[contains(text(),'BOL:')]");
            //Thread.Sleep(3000);
            //MouseActions.Click("xp", "//input[@id='bolNbr']");
            SeleniumProperties.driver.FindElement(By.Id("bolNbr")).SendKeys(bolNumber);
        }
    }
}
