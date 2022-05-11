using System;
using ApplicationCore.AppData;
using OpenQA.Selenium;

namespace AutomationTests.Utility
{
    public class DriverSetup
    {
        public static void GeneralSetup(IWebDriver webDriver, TestConfiguration testConfiguration)
        {
            // set expected page loading time from input configuration
            webDriver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(testConfiguration.ExpectedFindElementTime);
            webDriver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(testConfiguration.ExpectedPageLoadingTime);
        }
    }
}