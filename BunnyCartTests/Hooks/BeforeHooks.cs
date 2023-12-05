using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;

namespace BunnyCartTests.Hooks
{
    [Binding]
    public sealed class BeforeHooks
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
    }
}