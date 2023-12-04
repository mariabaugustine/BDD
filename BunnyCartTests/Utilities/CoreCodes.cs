using NUnit.Framework.Internal;
using OpenQA.Selenium;
using Serilog;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCartTests.Utilities
{
     public  class CoreCodes
     {
       public  IWebDriver driver;
        public void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss = screenshot.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string filepath = currentDirectory + "/Screenshots/screenshot_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);
            Console.WriteLine("Take screenshot");

        }
        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);
            if (errorMessage == null)
            {
                Log.Information(testName + "Passed");
                
            }
            else
            {
                Log.Error($"Test Failed for {testName}. \n Exception: \n {errorMessage}");
            }
        }

    }
}
