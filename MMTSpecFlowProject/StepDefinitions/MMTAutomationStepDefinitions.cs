using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics.Metrics;
using TechTalk.SpecFlow;

namespace MMTSpecFlowProject
{
    [Binding]
    public class MMTAutomationStepDefinitions 
    {

        MMTClass mmt;

        public void setup()
        {
           BaseClass.Initialization();
           BaseClass.GoToURL("https://www.makemytrip.com/");
        }

        [Given(@"User is on the Home page of the MMT website")]
        public void GivenUserIsOnTheHomePageOfTheMMTWebsite()
        {
            mmt = new MMTClass(BaseClass.driver);
            mmt.CloseAdPopUpBox();
            Assert.IsTrue(mmt.GetPageTitle().Contains("MakeMyTrip"));
        }

        [Given(@"User selects the roundtrip")]
        public void GivenUserSelectsTheRoundtrip()
        {
           mmt.ClickOnRoundTripRadioButton();
        }

        [When(@"User select ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserSelectAnd(string fromCity, string toCity)
        {
            mmt.SelectFromCity(fromCity);
            mmt.SelectToCity(toCity);
        }

        [When(@"User select the Departure after (.*) days from Today's date")]
        public void WhenUserSelectTheDepartureAfterDaysFromTodaysDate(int afterNoOfDays)
        {
            mmt.SelectDepartureDate(afterNoOfDays);
        }

        [When(@"User select the Return (.*) days after the departure Date")]
        public void WhenUserSelectTheReturndaysafterthedepartureDate(int afterNoOfDays)
        {
            mmt.SelectJourneyDate(afterNoOfDays);
        }



    }
}
