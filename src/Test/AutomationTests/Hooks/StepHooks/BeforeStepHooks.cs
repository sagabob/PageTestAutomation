using System.Diagnostics;
using AutomationTests.Core;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks.StepHooks
{
    [Binding]
    public class BeforeStepHooks : BaseTestingClass
    {
        public BeforeStepHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [BeforeStep(Order = 1)]
        public void BeforeStep1()
        {
            StepStopWatch = new Stopwatch();
            StepStopWatch.Start();
        }
    }
}