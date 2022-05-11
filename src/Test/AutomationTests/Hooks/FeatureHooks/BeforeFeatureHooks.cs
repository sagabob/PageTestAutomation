using System.Diagnostics;
using AutomationTests.Core;
using AutomationTests.Utility;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks.FeatureHooks
{
    [Binding]
    public class BeforeFeatureHooks : BaseTestingClass 
    {
        public BeforeFeatureHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [BeforeFeature(Order = 1)]
        public static void BeforeFeature1(
            TestThreadContext testThreadContext,
            FeatureContext featureContext)
        {
            testThreadContext.Set(new Stopwatch(), nameof(TestThreadStopWatch));
            testThreadContext.Get<Stopwatch>(nameof(TestThreadStopWatch)).Start();

        }

        [BeforeFeature(Order = 2)]
        public static void BeforeFeature2(
            TestThreadContext testThreadContext,
            FeatureContext featureContext)
        {
            featureContext.Set(new Stopwatch(), nameof(FeatureStopwatch));
            featureContext.Get<Stopwatch>(nameof(FeatureStopwatch)).Start();
        }
        

        [BeforeFeature(Order = 3)]
        public static void BeforeFeature3(
            TestThreadContext testThreadContext,
            FeatureContext featureContext)
        {
            var webDriver = new ChromeDriver();

            testThreadContext.Set(webDriver, "Driver");

            var pageContext = TestDataHelpers.PageDataInitializer();

            testThreadContext.Set(pageContext, "PageContext");
        }
    }
}