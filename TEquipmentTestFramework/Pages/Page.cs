using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEquipmentTestFramework.Utils.Drivers;

namespace TEquipmentTestFramework.Pages
{
   public abstract class Page
    {
        protected T InstanceOf<T>() where T : BasePage, new()
        {
            var pageClass = new T { Driver = DriverController.Instance.WebDriver };
            return pageClass;
        }
    }
}
