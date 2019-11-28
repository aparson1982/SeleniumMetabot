using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumMetabot;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Initialize.OpenUrl("http://sw72cseapqa:8080/CSWI/login/login.jsp");
            Thread.Sleep(10000);
            SeleniumSetMethods.EnterText("//input[@name='userId']", "SOLLRPA", "xp");
            SeleniumSetMethods.EnterText("//input[@name='password']", "fR3kZwFe7UDGVHEe", "xp");
            Button.Submit("xp", "//input[@class='button']");
            Thread.Sleep(5000);
            Button.Click("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]");
            Button.Click("xp", "//li[7]//ul[1]//li[5]//a[1]");
            Thread.Sleep(5000);
            int bolNumber = 987588;
            //SeleniumSetMethods.EnterText("bolNbr", "" + bolNumber, "id");
            SeleniumSetMethods.EnterNumericalValue("bolNbr", bolNumber, "id");
            Thread.Sleep(1000);
            SeleniumSetMethods.EnterText("bolDate", "11/27/2019", "id");
            Button.Click("xp", "//body[@class='tundra']//td//td[1]//input[1]");
            Thread.Sleep(5000);



            //CleanUp.Demolish();

        }
    }
}
