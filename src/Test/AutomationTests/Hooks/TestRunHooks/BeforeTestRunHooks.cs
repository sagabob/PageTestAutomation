using AutomationTests.Core;
using AutomationTests.Utility;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks.TestRunHooks
{
    [Binding]
    public class BeforeTestRunHooks : BaseTestingClass
    {
        public BeforeTestRunHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [BeforeTestRun(Order = 1)]
        public static void BeforeTestRun1(TestThreadContext testThreadContext)
        {
           
        }
    }
}