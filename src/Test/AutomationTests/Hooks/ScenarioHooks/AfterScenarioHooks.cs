using System;
using AutomationTests.Core;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks.ScenarioHooks
{
    [Binding]
    public class AfterScenarioHooks : BaseTestingClass
    {
        public AfterScenarioHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [AfterScenario(Order = 1)]
        public void AfterScenario1()
        {
            ScenarioStopwatch.Stop();

            Logger?.Information(
                $"Elapsed time in the Scenario: {Math.Round(ScenarioStopwatch.Elapsed.TotalSeconds, 2)} seconds");
        }
    }
}