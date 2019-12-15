using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Pages
{
    class TEquipmentHomePage : BasePage
    {
        private IWebElement searchBoxInputField => Driver.FindElement(By.XPath("//input[@class='form-control form-control-lg']"));
        private IList<IWebElement> searchResults => Driver.FindElements(By.CssSelector("div.row.search-results a.search-link"));

        public TEquipmentHomePage enterSearchText(string searchText)
        {
            searchBoxInputField.SendKeys(searchText);
            return this;
        }

        public ItemPage selectItemFromSearchResults(int itemNumber)
        {
            searchResults[itemNumber - 1].Click();
            return InstanceOf<ItemPage>();
        }
    }
}
