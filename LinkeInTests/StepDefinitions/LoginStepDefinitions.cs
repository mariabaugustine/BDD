using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkeInTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        public IWebDriver driver;
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver=new ChromeDriver();
            driver.Url = "https://www.linkedin.com/";
        }

        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            DefaultWait<OpenQA.Selenium.IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abc@gmail.com");
            //passwordInput.SendKeys("12345");

        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            DefaultWait<OpenQA.Selenium.IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement passwordInput = fluentWait.Until(dri => dri.FindElement(By.Id("session_password")));
            passwordInput.SendKeys("12345678");
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(5000);
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));

        }

        [Then(@"User will be redirected to home page")]
        public void ThenUserWillBeRedirectedToHomePage()
        {
            Assert.That(driver.Url.Contains("Log In"));
        }
    }
}
