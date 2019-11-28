using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public class CleanUp
    {
        public static void Demolish()
        {
            SeleniumProperties.driver.Close();
        }
    }
}
