using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;


namespace MMTSpecFlowProject
{
    public class MMTClass
    {
        public IWebDriver driver;

        By popUpBox => By.CssSelector("i.we_close");
        By roundTripRadioButton => By.CssSelector("[data-cy='roundTrip']");
        By fromCitySearchBox => By.CssSelector("input[placeholder='From']");
        By toCitySearchBox => By.CssSelector("input[placeholder='To']");

        By applyButton => By.CssSelector("button[data-cy='travellerApplyBtn']");
        By searchButton => By.CssSelector("a.widgetSearchBtn");
        By morningDepartureFilter => By.CssSelector("span[title='Morning Departures']");
        DateTime departureDate;

        private By JourneyDate(string journeyDate)
        {
            return By.CssSelector($"div[aria-label*= '{journeyDate}']");
        }

        private By Adults(int noOfAdults)
        {
            return By.CssSelector($"li[data-cy*= 'adults-{noOfAdults}']");
        }

        private By Children(int noOfChildren)
        {
            return By.CssSelector($"li[data-cy*= 'children-{noOfChildren}']");
        }

        public MMTClass(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CloseAdPopUpBox()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(popUpBox));
            driver.FindElement(popUpBox).Click();
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void ClickOnRoundTripRadioButton()
        {
            driver.FindElement(roundTripRadioButton).Click();
        }

        public void SelectFromCity(string fromCity)
        {
            driver.FindElement(fromCitySearchBox).Click();
            driver.FindElement(fromCitySearchBox).SendKeys(fromCity);
            driver.FindElement(fromCitySearchBox).SendKeys(Keys.Tab);
        }

        public void SelectToCity(string toCity)
        {
            driver.FindElement(toCitySearchBox).Click();
            driver.FindElement(toCitySearchBox).SendKeys(toCity);
            driver.FindElement(toCitySearchBox).SendKeys(Keys.Tab);
        }


        public void SelectDepartureDate(int addNoOfDaysToTodayDate)
        {
            departureDate = (DateTime.Today.AddDays(addNoOfDaysToTodayDate));
            string departDate = departureDate.ToString("MMM dd yyyy");
            driver.FindElement(JourneyDate(departDate)).Click();
        }

        public void SelectReturnDate(int addNoOfDaysToDepartureDate)
        {
            string returnDate =(departureDate.AddDays(addNoOfDaysToDepartureDate)).ToString("MMM dd yyyy");
            driver.FindElement(JourneyDate(returnDate)).Click();
            driver.FindElement(JourneyDate(returnDate)).SendKeys(Keys.Tab);
        }

        public void SelectAdults(int noOfAdults)
        {
            driver.FindElement(Adults(noOfAdults)).Click();
        }

        public void SelectChildren(int noOfChildren)
        {
            driver.FindElement(Children(noOfChildren)).Click();
        }

        public void ClickApplyButton()
        {
            driver.FindElement(applyButton).Click();
        }

        public void ClickSearchButton()
        {
            driver.FindElement(searchButton).Click();
        }

        public void ApplyMorningDepartureFilter()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(morningDepartureFilter)));
            driver.FindElement(morningDepartureFilter).Click();
        }
    }
}
