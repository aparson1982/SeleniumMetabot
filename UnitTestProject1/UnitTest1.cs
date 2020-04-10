using System;
using System.Diagnostics;
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

            Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
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


            
        }

        [TestMethod]
        public void SClickTest()
        {
            //SeleniumProperties.doTakeScreenshot = true;
            
            Initialize.OpenUrl("http://sw72cseapdv:8080/CSWI/login/login.jsp");

            PageSetup.MaximizeWindow();
            SeleniumProperties.SpeedSettings(0);
            Console.WriteLine(MouseActions.JClick("xp", "duh"));
            Console.WriteLine(SeleniumUtilities.LineNumber() + ElementHelper.iExplicitWait("xp", "//input[@name='userId']", 5));
            Console.WriteLine(SeleniumUtilities.LineNumber() + (SeleniumSetMethods.iEnterText("xp", "//input[@name='userId']", "SOLLRPA")));

            Console.WriteLine(SeleniumUtilities.LineNumber() + (SeleniumSetMethods.iEnterText("xp", "//input[@name='password']", "fR3kZwFe7UDGVHEe")));

            MouseActions.Submit("xp", "//input[@class='button']");

            var stopWatch = Stopwatch.StartNew();

            Console.WriteLine(Navigation.GetCurrentWindowHandle());

            Console.WriteLine(ElementHelper.PollingWait("xp", "//iframe[@id='frame2']", 30, 100));
            Console.WriteLine(Navigation.SwitchFrames("xp", "//iframe[@id='frame2']"));
            Console.WriteLine(ElementHelper.PollingWait("name", "ORDERNBR", 30, 200));
            Console.WriteLine(ElementHelper.PollingWait("xp", "//iframe[@id='frame2']", 10, 100));
            Console.WriteLine(SeleniumSetMethods.iEnterText("name", "ORDERNBR", "031252", false));

            Console.WriteLine(MouseActions.iClick("name", "Find"));

            //Console.WriteLine(ElementHelper.iWaitForElement("xp", "//b[contains(text(),'SHIPPED(S)')]", 1));
            //Console.WriteLine(SeleniumProperties.MethodSuccess.ToString());
            Console.WriteLine(ElementHelper.iWaitForElement("xp", @"//td[@class='detailText']//child::font[@class='lineText']//child::b", 1));
            Console.WriteLine(SeleniumGetMethods.iGetText("xp", @"//td[@class='detailText']//child::font[@class='lineText']//child::b"));

            Console.WriteLine(ElementHelper.PollingWait("xp", "//iframe[@id='frame2']", 30, 100));
            Console.WriteLine(Navigation.SwitchFrames("xp", "//iframe[@id='frame2']"));
            Console.WriteLine(ElementHelper.PollingWait("xp", @"//a[@id='shiptomod']", 30, 200));
            Console.WriteLine(MouseActions.iClick("xp", @"//a[@id='shiptomod']"));
            //Console.WriteLine(Navigation.RefreshPage());
            //Console.WriteLine(SeleniumUtilities.LineNumber() + (MouseActions.iClick("xp", "//body/nav[@class='navbar fixed-top navbar-light']/table[@id='app_main_menu_table']/tbody/tr/td[@class='appHeader']/table[@class='appHeader']/tbody/tr/td/div[@id='mainMenuDiv']/ul/li[7]/a[1]")));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);
            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + (MouseActions.iClick("xp", "//li[7]//ul[1]//li[5]//a[1]")));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //string bolNumber = "989039";
            //string bolDate = "12/09/2019";

            ////Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + (SeleniumSetMethods.iEnterText("id", "bolNbr", bolNumber + Keys.Enter)));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //stopWatch.Restart();
            //Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);
            ////Console.WriteLine(SeleniumUtilities.LineNumber() + ("BolNumber:  " + SeleniumGetMethods.iGetValue("id", "bolNbr")));
            ////Console.WriteLine((SeleniumSetMethods.iEnterText("id", "bolNbr", Keys.Enter)));

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + ElementHelper.iExplicitWait("id", "bolDate", 5));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumSetMethods.iEnterText("id", "bolDate", bolDate + Keys.Enter));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //Console.WriteLine(Navigation.SwitchFrames("name", "frame2"));
            ////Console.WriteLine((SeleniumSetMethods.iEnterText(bolDate, "id", "bolDate")));
            ////ElementHelper.WaitTilReady("xp", "//input[@onclick='return displayOrder();']", 15);
            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + ElementHelper.iExplicitWait("xp", "//input[@onclick='return displayOrder();']", 5));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);
            ////Thread.Sleep(3000);
            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + (MouseActions.iClick("xp", "//input[@onclick='return displayOrder();']")));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //Navigation.SwitchFrames("name", "frame2");

            //if (ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]").Equals("True"))
            //{
            //    Console.WriteLine(ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]"));
            //    //Console.WriteLine(MouseActions.JClick("xp", "//span[contains(text(),'Ok')]"));
            //    Console.WriteLine(MouseActions.iClick("xp", "//span[contains(text(),'Ok')]"));
            //}

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + (ElementHelper.IsElementAvailable("xp", "//span[contains(text(),'Ok')]")));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + ElementHelper.iExplicitWait("xp", "//table[2]//tbody//tr//td[contains(text(),'DROP')]/following-sibling::td[@align='left']", 5));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            ////Console.WriteLine(SeleniumUtilities.LineNumber() + (ElementHelper.WaitTilReady("xp", "//table[2]//tbody//tr//td[contains(text(),'DROP')]/following-sibling::td[@align='left']", 15)));
            //Navigation.SwitchToDefaultFrame();
            //Navigation.SwitchFrames("id", "frame2");
            ////ElementHelper.WaitTilReady("xp", "//table[2]//tbody//tr//td[contains(text(),'FUEL')]/following-sibling::td[@align='left']", 15);
            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + ElementHelper.iExplicitWait("xp", "//table[2]//tbody//tr//td[contains(text(),'DROP')]/following-sibling::td[@align='left']", 5));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);
            //var fuel = SeleniumGetMethods.iGetText("xp", "//table[2]//tbody//tr//td[contains(text(),'FUEL')]/following-sibling::td[@align='left']");
            //var drop = SeleniumGetMethods.iGetText("xp", "//table[2]//tbody//tr//td[contains(text(),'DROP')]/following-sibling::td[@align='left']");

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + MouseActions.iClick("plt", "Freight"));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + MouseActions.iClick("plt", "Transportation Que"));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);
            //// MouseActions.SmartClick("//a[contains(text(),'Transportation Queue')]");

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + SeleniumSetMethods.iEnterText("name", "bolNbr", bolNumber));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + "2nd BolNbr:  " + SeleniumGetMethods.iGetValue("name", "bolNbr"));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            //stopWatch.Restart();
            //Console.WriteLine(SeleniumUtilities.LineNumber() + MouseActions.iClick("xp", "//div[@id='searchCriteria']//td[1]//input[1]"));
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed + Environment.NewLine + Environment.NewLine);

            CleanUp.Demolish();
        }

        [TestMethod]
        public void DoubleClickTest()
        {
            
            Initialize.OpenUrl("https://usflvtprd.shawinc.com/usf/mvc/gui/launch");
            PageSetup.MaximizeWindow();
            SeleniumProperties.SpeedSettings(2);
            Thread.Sleep(3000);
            Console.WriteLine(SeleniumSetMethods.iEnterText("id","username", "svcbotqa"));
            Console.WriteLine(SeleniumSetMethods.iEnterText("id","password", "IywHYeOFXj9IEMgv"));
            Console.WriteLine(MouseActions.iClick("id", "kc-login"));
            Console.WriteLine(MouseActions.iDoubleClick("xp", "//a[@class='x-tree-node-anchor']//span[contains(text(),'Reports')]"));
            Console.WriteLine(MouseActions.iClick("xp", "//span[contains(text(),'Run report')]"));
            Console.WriteLine(MouseActions.iClick("xp", "//div[contains(text(),'User Override')]"));
            Console.WriteLine(MouseActions.iClick("xp", "//body[contains(@class,'ext-webkit ext-chrome x-border-layout-ct')]/div[contains(@class,'x-tab-panel x-border-panel')]/div[@class='x-tab-panel-bwrap']/div[@class='x-tab-panel-body x-tab-panel-body-top']/div[contains(@class,'x-panel x-panel-noborder')]/div[@class='x-panel-bwrap']/div[@class='x-panel-body x-panel-body-noheader x-panel-body-noborder x-box-layout-ct']/div[@class='x-box-inner']/div[contains(@class,'x-panel x-box-item')]/div[@class='x-panel-bwrap']/div[@class='x-panel-body']/div[contains(@class,'x-panel x-panel-noborder x-form-label-left')]/div[@class='x-panel-bwrap']/form[@class='x-panel-body formPannelPad x-panel-body-noheader x-panel-body-noborder x-form']/div[contains(@class,'x-form-item')]/div[@class='x-form-element']/div[contains(@class,'x-panel x-tree')]/div[@class='x-panel-bwrap']/div[@class='x-panel-body x-panel-body-noheader']/ul[@class='x-tree-root-ct x-tree-arrows']/div[@class='x-tree-root-node']/li[@class='x-tree-node']/ul[@class='x-tree-node-ct']/li[@class='x-tree-node']/ul[@class='x-tree-node-ct']/li[1]/div[1]/input[1]"));

            //MouseActions.DoubleClick("xp", "//button[contains(text(),'Double-Click Me To See Alert')]");
            Thread.Sleep(9000);
            CleanUp.Demolish();
        }

        [TestMethod]
        public void NewTabTest()
        {
            Initialize.OpenUrl("http://automationpractice.com/index.php");
            PageSetup.MaximizeWindow();
            SeleniumProperties.SpeedSettings(2);
            Thread.Sleep(3000);
            Console.WriteLine(ElementHelper.PollingWait("xp", "//li[@class='twitter']//a", 30, 100));
            Console.WriteLine(MouseActions.iClick("xp", "//li[@class='twitter']//a"));
            Console.WriteLine(Navigation.SwitchToTab("Selenium Framework (@seleniumfrmwrk) / Twitter"));
            Console.WriteLine(ElementHelper.PollingWait("xp", "//span[contains(text(),'Followers')]", 30, 100));
            Console.WriteLine(MouseActions.iClick("xp", "//span[contains(text(),'Followers')]"));
            Console.WriteLine(ElementHelper.PollingWait("xp", "//body/div[@id='react-root']/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div[1]//*[local-name()='svg']", 30, 100));
            Console.WriteLine(MouseActions.iClick("xp", "//body/div[@id='react-root']/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div[1]//*[local-name()='svg']"));
            Console.WriteLine(Navigation.CloseCurrentTab());
            Thread.Sleep(9000);
            CleanUp.Demolish();
        }

    }
}
