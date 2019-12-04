using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class PageSetup
    {
        public static void MaximizeWindow()
        {
            SeleniumProperties.driver.Manage().Window.Maximize();
        }
        //TODO:  Create methods for Maximize, Minimize, Resize?, Zoom, etc
    }
}
