using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEquipmentTestFramework.Pages
{
    class CheckoutPage : BasePage
    {
       private IWebElement emailInputField => Driver.FindElement(By.XPath("//*[@name='CT_Main_0$txtEmail']"));
        private IWebElement nameInputField => Driver.FindElement(By.Id("txtShippingFirstName"));
        //private IWebElement lastnameInputField=>Driver.FindElement(By.id("txtShippingFirstName")).sendKeys("Tugba");
        //		driver.findElement(By.id("txtShippingLastName")).sendKeys("Turkay");
        //		driver.findElement(By.id("txtShippingPhone")).sendKeys("7733979119");
        //		driver.findElement(By.id("txtShippingAddress1")).sendKeys("Berwyn Ave");  
        //		driver.findElement(By.id("txtShippingCity")).sendKeys("Chicago");
    }
}
