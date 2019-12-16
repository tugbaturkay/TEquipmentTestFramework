using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEquipmentTestFramework.Utils;

namespace TEquipmentTestFramework.Pages
{
    class PaymentPage : BasePage
    {
        private IWebElement creditCardInputField => Driver.FindElement(By.XPath("//input[@id='CT_Main_0_txtCardNumber']"));
        private IWebElement expiryDateInputField => Driver.FindElement(By.Id("txtExpiryDate"));
        private IWebElement cVVInputField => Driver.FindElement(By.XPath("//input[@id='CT_Main_0_txtCVV']"));
        private IWebElement submitOrderButton => Driver.FindElement(By.Id("btnPayment"));

        public OrderConfirmationPage submitOrder()
        {
            creditCardInputField.SendKeys(Settings.CardNumber);
            expiryDateInputField.SendKeys(Settings.ExpiryDate);
            cVVInputField.SendKeys(Settings.CVV);
            submitOrderButton.Click();

                return InstanceOf<OrderConfirmationPage>();
        }
    }
}
