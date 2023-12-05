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
        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            IWebElement searchheading = driver.FindElement(By.XPath("//span[@class='base']"));
            Assert.That(searchtext, Does.Contain(searchheading.Text));
        }
        [Then(@"Title should have '([^']*)'")]
        public void ThenTitleShouldHave(string searchtext)
        {
            //IWebElement title = driver.FindElement(By.XPath("//span[@class='base']"));
            Assert.That(searchtext, Does.Contain(driver.Title));
        }


    }
}
