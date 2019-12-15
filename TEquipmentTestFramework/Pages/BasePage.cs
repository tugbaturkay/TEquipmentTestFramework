using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Pages
{
    public class BasePage : Page
    {
        public IWebDriver Driver { get; set; }

        public IWebElement waitForClickability(IWebElement element, int sec = 20)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(sec));
            return wait.Until
                (SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
