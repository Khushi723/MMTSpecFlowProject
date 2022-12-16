using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTSpecFlowProject
{
    public class BaseClass
    {
       public static IWebDriver driver = null;

        public static IWebDriver Initialization()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void GoToURL(String URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

    }
}
