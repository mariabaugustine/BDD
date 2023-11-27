using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver driver;
        [BeforeScenario]
        public void InitializeBrowser()
        {
            driver=new ChromeDriver();
            
        }
        [AfterScenario]
        public void CleanupBrowser() 
        {
            driver.Quit();
        }

        [Given(@"Google homepage should be loaded")]//matching symbol
        public void GivenGoogleHomepageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""([^""]*)"" in the search text box")]
        public void WhenTypeInTheSearchTextBox(string searchtext)
        {
            IWebElement searchInput = driver.FindElement(By.Id("APjFqb"));
            searchInput.SendKeys(searchtext);
        }

        [When(@"click on the google search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout=TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";


            IWebElement? gsb = fluentWait.Until(d =>
            {
                IWebElement searchButton = driver.FindElement(By.ClassName("gNO89b"));
                return searchButton.Displayed ? searchButton : null;

            });
            if(gsb != null) 
            { 
                gsb.Click();
            }

        }
        [Then(@"the results should be displayed on the next page with title ""(.*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPage(string title)
        {
            Assert.That(driver?.Title, Is.EqualTo(title));
        }
        [When(@"click on the IMFL button")]
        public void WhenClickOnTheIMFLButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";


            IWebElement? imfl = fluentWait.Until(d =>
            {
                IWebElement searchButton = driver.FindElement(By.Name("btnI"));
                return searchButton.Displayed ? searchButton : null;

            });
            if (imfl != null)
            {
                imfl.Click();
            }


        }
        [Then(@"the results should be redirected to a page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToAPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }




    }
}
