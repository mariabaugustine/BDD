using BunnyCartTests.Hooks;
using BunnyCartTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BunnyCartTests.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartStepDefinitions:CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        string? label;
        [Given(@"Search page is loaded")]
        public void GivenSearchPageIsLoaded()
        {
            driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water";
        }

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string prono)
        {
            IWebElement prod = driver.FindElement(By.XPath("//*[@id=\"amasty-shopby-product-list\"]/div[2]/ol/li[1]/div/div[2]/strong/a[" +prono + "]"));
            label = prod.Text;
            prod.Click();
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Equals(label));
        }




    }
}
