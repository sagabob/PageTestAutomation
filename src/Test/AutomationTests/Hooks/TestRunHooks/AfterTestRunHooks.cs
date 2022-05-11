using AutomationTests.Core;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks.TestRunHooks
{
    [Binding]
    public class AfterTestRunHooks : BaseTestingClass
    {
        public AfterTestRunHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [AfterTestRun(Order = 1)]
        public static void AfterTestRun1()
        {
        }
    }
}