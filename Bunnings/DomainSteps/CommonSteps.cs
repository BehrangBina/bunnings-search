using Bunnings.WebBrowser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Bunnings.DomainSteps
{
    [Binding]
    class CommonSteps
    {
        private static IWebDriver driver;
         
        [BeforeFeature]
        public static void Setup()
        {
            driver = new BrowserDriver().Current;
        }
        [AfterFeature]
        public static void TearDown()
        {
            driver.Dispose();
        }
        [Given(@"User Navigates to (.*)")]
        public void GivenUserNavigatesTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        [Then(@"difault search value is (.*)")]
        public void ThenDifaultSearchValueIsWhatCanWeHelpYouFindToday(string defaultSearchValue)
        {
            var placeHolder = QuerySearchText.GetAttribute("placeholder");
            Assert.AreEqual(defaultSearchValue, defaultSearchValue);
        }
        [When(@"click on search bar")]
        public void WhenClickOnSearchBar()
        {
            QuerySearchText.Click();
        }


        [Then(@"There are (.*) result on popular searchses")]
        public void ThenThereAreResultOnPopularSearchses(int expectedSearches)
        {
            var numberOfSearchesOnPage = driver.FindElements(By.XPath("//span[contains(@data-locator,'Popular')]")).ToList().Count;
            Assert.AreEqual(expectedSearches, numberOfSearchesOnPage);
        }
        [Then(@"There are (.*) result on popular right now")]
        public void ThenThereAreResultOnPopularRightNow(int expectedSearches)
        {
            var numberOfSearchesOnPage = driver.FindElements(By.XPath("//a//p[@data-locator='product-title']")).ToList().Count;
            Assert.AreEqual(expectedSearches, numberOfSearchesOnPage);
        }

        private IWebElement QuerySearchText
        {
            get
            {
                By _searchQueryElementFinder = By.Name("q");
                return driver.FindElement(_searchQueryElementFinder);
            }
        }

    }
}
