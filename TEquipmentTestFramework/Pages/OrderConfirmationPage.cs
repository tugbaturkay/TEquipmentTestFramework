using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Pages
{
    class OrderConfirmationPage : BasePage
    {
        private IWebElement orderID => Driver.FindElement(By.CssSelector("span.text-success"));
        
        public String getOrderNumber()
        {
            return orderID.Text;
            
        }
    }
}
