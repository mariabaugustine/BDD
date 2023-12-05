using BunnyCartTests.Hooks;
using BunnyCartTests.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using Serilog;
using System;
using TechTalk.SpecFlow;
using Log = Serilog.Log;

namespace BunnyCartTests.StepDefinitions
{

    [Binding]
    public class SearchStepDefinitions : CoreCodes
    {

        IWebDriver? driver = BeforeHooks.driver;


        [Given(@"User will be on the homepage")]
        public void GivenUserWillBeOnTheHomepage()
        {
            driver.Url = "https://www.bunnycart.com/";
        }

        [When(@"User will type the '([^']*)' in the search input box")]
        public void WhenUserWillTypeTheInTheSearchInputBox(string searchtext)
        {
            IWebElement searchinput = driver.FindElement(By.Id("search"));
            searchinput.SendKeys(searchtext);
            searchinput.SendKeys(Keys.Enter);
            Log.Information("Typed search text" + searchinput);
        }

        //[When(@"User clicks on search button")]
        //public void WhenUserClicksOnSearchButton()
        //{
        //    IWebElement? searchButton = driver.FindElement(By.XPath("//button[@title='Search']"));
        //    searchButton.Click();
        //}

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            
            TakeScreenShot(driver);
            Log.Information("SS Taken");
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Success");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
            
        }
        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            IWebElement searchheading = driver.FindElement(By.XPath("//span[@class='base']"));
            //Assert.That(searchtext, Does.Contain(searchheading.Text));
            Assert.That(searchheading.Text, Does.Contain(searchtext));
        }
        [Then(@"Title should have '([^']*)'")]
        public void ThenTitleShouldHave(string searchtext)
        {
            //IWebElement title = driver.FindElement(By.XPath("//span[@class='base']"));
            //Assert.That(searchtext, Does.Contain(driver.Title));
            Assert.That(driver.Title, Does.Contain(searchtext));
        }
    }
}
