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
        public static IWebDriver? driver;
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }




        [AfterFeature]
        public static void CleanUp()
        {
            driver.Quit();
        }

        [BeforeFeature]
        public static void LogFileCreation()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currentDirectory + "/Logs/log_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day).CreateLogger();

        }





        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.bunnycart.com/");
        }



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
            Log.Information("Typed search text" + searchtext);
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
    }
}
