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
            Thread.Sleep(10000);
            Console.WriteLine(SeleniumSetMethods.iEnterText("xp", "//input[@name='userId']", "SOLLRPA"));
            Console.WriteLine("UserName:  " + SeleniumGetMethods.iGetValue("//input[@name='userId']", "xp"));
            Console.WriteLine(SeleniumSetMethods.iEnterText("xp", "//input[@name='password']", "fR3kZwFe7UDGVHEe"));
            Console.WriteLine("PWD:  " + SeleniumGetMethods.iGetValue("//input[@name='password']", "xp"));
            MouseActions.Submit("xp", "//input[@class='button']");
            //Thread.Sleep(3000);

            //Console.WriteLine(SeleniumUtilities.PageSourceCode());
            //Navigation.NavigateTo("http://sw72cseapdv:8080/CSWI/Layout.jsp?pageUrl=/CSWI/order/FreightOrderLineRateDisplay.jsp");
            MouseActions.iClick("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]");
            MouseActions.iClick("xp", "//li[7]//ul[1]//li[5]//a[1]");
            //Thread.Sleep(3000);
            string bolNumber = "989039";
            string bolDate = "12/13/2019";
            string enter = Keys.Enter;
            //Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            //Console.WriteLine(SeleniumUtilities.PageSourceCode());
            //Console.WriteLine(ElementHelper.Wait("xp", "//body[@class='tundra']//td//td[1]//input[1]", 10));
            //Console.WriteLine(MouseActions.JSClick("xp", "//body[@class='tundra']//td//td[1]//input[1]"));
            ////MouseActions.Click("xp", "//td[contains(text(),'BOL:')]");
            //Thread.Sleep(3000);

            Console.WriteLine(SeleniumSetMethods.iEnterText("id", "bolNbr", bolNumber));
            Console.WriteLine("BolNumber:  " + SeleniumGetMethods.iGetValue("id", "bolNbr"));
            Console.WriteLine(SeleniumSetMethods.iEnterText("id", "bolNbr", Keys.Enter));

            Console.WriteLine(ElementHelper.WaitDisplayed("id", "bolDate", 15));
            Console.WriteLine(SeleniumSetMethods.iEnterText("id", "bolDate", bolDate));
            //Console.WriteLine(SeleniumSetMethods.iEnterText("id", "bolDate", Keys.Enter));

            //Console.WriteLine(ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]"));

            Console.WriteLine(MouseActions.iClick("xp", "//body[@class='tundra']//td//td[1]//input[1]"));
            Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            if (ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]").Equals("True"))
            {
                Console.WriteLine(ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]"));
                Console.WriteLine(MouseActions.JClick("xp", "//span[contains(text(),'Ok')]"));
            }
            //Thread.Sleep(6000);
            Console.WriteLine(ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]"));
            Console.WriteLine(SeleniumGetMethods.GetText("body.tundra:nth-child(2) div.scroll-pane.jspScrollable div.jspContainer div.jspPane table:nth-child(2) tbody:nth-child(1) tr:nth-child(2) > td.detailText:nth-child(2)", "css"));
            Console.WriteLine(SeleniumGetMethods.GetInputValue("body.tundra:nth-child(2) div.scroll-pane.jspScrollable div.jspContainer div.jspPane table:nth-child(2) tbody:nth-child(1) tr:nth-child(2) > td.detailText:nth-child(2)", "css"));

            Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            var fuel = SeleniumGetMethods.GetText("//table[2]//tbody//tr//td[contains(text(),'FUEL')]/following-sibling::td[@align='left']", "xp");
            var drop = SeleniumGetMethods.GetText("//table[2]//tbody//tr//td[contains(text(),'DROP')]/following-sibling::td[@align='left']", "xp");

            MouseActions.iClick("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]");
            MouseActions.iClick("xp", "//a[contains(text(),'Transportation Queue')]");

            Console.WriteLine(SeleniumSetMethods.iEnterText("name", "bolNbr", bolNumber));
            Console.WriteLine("2nd BolNbr:  " + SeleniumGetMethods.iGetValue("name", "bolNbr"));
            Console.WriteLine(MouseActions.iClick("xp", "//div[@id='searchCriteria']//td[1]//input[1]"));


            //driver.FindElement(By.Id("bolNbr")).SendKeys(bolNumber);
        }


    }
}
