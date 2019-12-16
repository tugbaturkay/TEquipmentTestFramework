using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEquipmentTestFramework.Utils;



namespace TEquipmentTestFramework.Pages
{
    class ShippingInfoPage : BasePage
    {
        private IWebElement shippingMethodRadioButton => Driver.FindElement(By.Id("ShippingMethodId_0_2"));
        private IWebElement addSignatureCheckBox => Driver.FindElement(By.Id("chkShippingSignature0"));
        private IWebElement paymentMethodButton => Driver.FindElement(By.Id("btnShipping0"));


        public PaymentPage fillOutShippingMethod()
        {
            shippingMethodRadioButton.Click();
            addSignatureCheckBox.Click();
            paymentMethodButton.Click();
            return InstanceOf<PaymentPage>();
        }
    }

    
   
   
   
}
