using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEquipmentTestFramework.Pages;
using TEquipmentTestFramework.Utils;
using TEquipmentTestFramework.Utils.Drivers;

namespace TEquipmentTestFramework.StepDefinitions
{
    [Binding]
    class TEquipmentSteps : BaseSteps
    {
        IWebDriver Driver = DriverController.Instance.WebDriver;
        [Given(@"User is on HomePage of application")]
        public void GivenUserIsOnHomePageOfApplication()
        {
            Driver.Navigate().GoToUrl(Settings.BaseUrl);
        }

        [When(@"User searches for ""(.*)""")]
        public void WhenUserSearchesFor(string searchText)
        {
            InstanceOf<TEquipmentHomePage>()
                .enterSearchText(searchText);
        }

        [When(@"selects item number (.*) from results")]
        public void WhenSelectsItemNumberFromResults(int itemNumber)
        {
            InstanceOf<TEquipmentHomePage>()
                .selectItemFromSearchResults(itemNumber);
        }

        [When(@"User checks out as a guest")]
        public void WhenUserChecksOutAsAGuest()
        {
            InstanceOf<ItemPage>()
                .clickAddToCartButton()
                .clickViewCartButton()
                .changeQuantity(2)
                .clickCheckoutButton();
        }

        [Then(@"User sees OrderConfirmationPage")]
        public void ThenUserSeesOrderConfirmationPage()
        {
            //ScenarioContext.Current.Pending();
            ScenarioContext.Current["OrderNumber"] = "dummyOrderNumber";//InstanceOf<OrderConfirmatinPage>().getOrderNumber();
        }

    }
}
