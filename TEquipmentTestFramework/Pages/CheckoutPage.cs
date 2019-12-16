using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using TEquipmentTestFramework.Utils;


namespace TEquipmentTestFramework.Pages
{
    class CheckoutPage : BasePage
    {
       private IWebElement emailInputField => Driver.FindElement(By.XPath("//*[@name='CT_Main_0$txtEmail']"));
       private IWebElement firstNameInputField => Driver.FindElement(By.Id("txtShippingFirstName"));
        private IWebElement lastNameInputField => Driver.FindElement(By.Id("txtShippingLastName"));
        private IWebElement phoneInputField => Driver.FindElement(By.Id("txtShippingPhone"));
        private IWebElement address1InputField => Driver.FindElement(By.Id("txtShippingAddress1"));
        private IWebElement cityInputField => Driver.FindElement(By.Id("txtShippingCity"));
       private IWebElement stateDropDown =>Driver.FindElement(By.Id("drpShippingState"));
        private IWebElement zipCodeInputField => Driver.FindElement(By.Id("txtShippingZip"));

        private IWebElement shippingMethodButton => Driver.FindElement(By.XPath("//a[@id='btnBilling']"));
        		
        public CheckoutPage fillOutShippingInfo()
        {
            emailInputField.SendKeys(Settings.Email);
            firstNameInputField.SendKeys(Settings.FirstName);
            lastNameInputField.SendKeys(Settings.LastName);
            phoneInputField.SendKeys(Settings.PhoneNo);
            address1InputField.SendKeys(Settings.Address);
            cityInputField.SendKeys(Settings.City);
            var selectElement = new SelectElement(stateDropDown);
              selectElement.SelectByValue("IL");
            zipCodeInputField.SendKeys(Settings.Zipcode);

            return this;
        }

        public ShippingInfoPage clickShippingMethodButton()
        {
            shippingMethodButton.Click();
            return InstanceOf<ShippingInfoPage>();
        }

    }
}
