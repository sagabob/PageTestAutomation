using System;
using System.Diagnostics;
using AutomationTests.Core;
using OpenQA.Selenium;
using Serilog.Core;
using TechTalk.SpecFlow;

namespace AutomationTests.Hooks.FeatureHooks
{
    [Binding]
    public class AfterFeatureHooks : BaseTestingClass
    {
        public AfterFeatureHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [AfterFeature(Order = 3)]
        public static void AfterFeature3(
            TestThreadContext testThreadContext,
            FeatureContext featureContext)
        {
            testThreadContext.Get<IWebDriver>(nameof(Driver)).Quit();
        }

        [AfterFeature(Order = 1)]
        public static void AfterFeature1(
            TestThreadContext testThreadContext,
            FeatureContext featureContext)
        {
            var featureStopwatch = featureContext.Get<Stopwatch>(nameof(FeatureStopwatch));
            featureStopwatch.Stop();

            testThreadContext.Get<Logger>(nameof(Logger)).Information(
                $"Elapsed time in the Feature: {Math.Round(featureStopwatch.Elapsed.TotalSeconds, 2)} seconds");
        }

        [AfterFeature(Order = 2)]
        public static void AfterFeature2(
            TestThreadContext testThreadContext,
            FeatureContext featureContext)
        {
            var testThreadStopWatch = testThreadContext.Get<Stopwatch>(nameof(TestThreadStopWatch));
            testThreadStopWatch.Stop();

            testThreadContext.Get<Logger>(nameof(Logger)).Information(
                $"Elapsed time in the TestThread: {Math.Round(testThreadStopWatch.Elapsed.TotalSeconds, 2)} seconds");
        }
    }
}