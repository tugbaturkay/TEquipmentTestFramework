using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TEquipmentTestFramework.Utils
{
    class Settings
    {

        public static String BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        public static String Email = ConfigurationManager.AppSettings["Email"];
        public static String FirstName = ConfigurationManager.AppSettings["FirstName"];
        public static String LastName = ConfigurationManager.AppSettings["LastName"];
        public static String PhoneNo = ConfigurationManager.AppSettings["PhoneNo"];
        public static String Address = ConfigurationManager.AppSettings["Address"];
        public static String City = ConfigurationManager.AppSettings["City"];
        public static String Zipcode = ConfigurationManager.AppSettings["Zipcode"];
        public static String CardNumber = ConfigurationManager.AppSettings["CardNumber"];
        public static String ExpiryDate = ConfigurationManager.AppSettings["ExpiryDate"];
        public static String CVV = ConfigurationManager.AppSettings["CVV"];
        public static String Browser = ConfigurationManager.AppSettings["Browser"];
   
    }
}
