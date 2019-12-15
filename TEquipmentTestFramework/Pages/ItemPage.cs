using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Pages
{
    class ItemPage :BasePage
    {
        private IWebElement addToCartButton => Driver.FindElement(By.CssSelector("a.btnAddToCart-Large.btn-success"));
        private IWebElement viewCartButton => Driver.FindElement(By.XPath("//a[text() = 'View Cart']"));

        public ItemPage clickAddToCartButton()
        {
            addToCartButton.Click();
            return this;
        }

        public ShoppingCartPage clickViewCartButton()
        {
            viewCartButton.Click();
            return InstanceOf<ShoppingCartPage>();

        }
    }
}
