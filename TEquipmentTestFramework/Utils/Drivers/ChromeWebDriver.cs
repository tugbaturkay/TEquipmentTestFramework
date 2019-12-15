using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Utils.Drivers
{
   internal class ChromeWebDriver
    {
        internal static IWebDriver LoadChromeDriver()
        {

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var options = new ChromeOptions();

            options.AddArgument("--disable-extensions");
            options.AddArgument("--allow-http-screen-capture");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--start-maximized");
            options.AddArgument("window-size=1920,1080");

            var driver = new ChromeDriver(driverService, options);

            return driver;

        }
    }
}
