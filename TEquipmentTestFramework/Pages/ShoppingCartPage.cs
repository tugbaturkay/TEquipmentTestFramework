using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Pages
{
    class ShoppingCartPage : BasePage
    {
        private IWebElement quantityInputField => Driver.FindElement(By.XPath("//*[@name='rptRecipients$ctl00$rptCart$ctl00$txtQty']"));
        private IWebElement checkOutButton => Driver.FindElement(By.XPath("//button[@id='btnCheckout']"));

        public ShoppingCartPage changeQuantity(int quantity)
        {
            waitForClickability(quantityInputField).Click();
            Thread.Sleep(100);
            quantityInputField.Clear();
            Thread.Sleep(100);
            quantityInputField.SendKeys(quantity.ToString());
            Thread.Sleep(100);
            quantityInputField.SendKeys(Keys.Enter);
            return this;
        }

        public CheckoutPage clickCheckoutButton()
        {
            try
            {
                waitForClickability(checkOutButton).Click();
            }
            catch (ElementClickInterceptedException)
            {
                Thread.Sleep(2000);
                waitForClickability(checkOutButton).Click();
            }
            
            return InstanceOf<CheckoutPage>();
        }
    }
}
