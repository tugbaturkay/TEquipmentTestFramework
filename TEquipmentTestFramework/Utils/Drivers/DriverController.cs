using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Utils.Drivers
{
    class DriverController
    {
        private DriverController() { }
        public static DriverController Instance = new DriverController();


        internal IWebDriver WebDriver { get; set; }
        internal void StartChrome()
        {
            if (WebDriver != null) return;

            WebDriver = ChromeWebDriver.LoadChromeDriver();
        }

        internal void StartHeadlessChrome()
        {
            if (WebDriver != null) return;

            //WebDriver = HeadlessChromeWebDriver.LoadHeadlessChromeDriver();
        }

        internal void StartIE()
        {
            if (WebDriver != null) return;
           // WebDriver = IEWebDriver.LoadIEDriver();
        }


        internal void StopWebDriver()
        {
            try
            {
                WebDriver.Quit();
                WebDriver.Dispose();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e, ":: WebDriver stop error");
            }

            WebDriver = null;
            Console.WriteLine(":: WebDriver stoped");
        }
    }
}
