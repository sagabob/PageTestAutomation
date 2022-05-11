using System.Diagnostics;
using AutomationTests.Core;
using Microsoft.Extensions.Configuration;
using Serilog;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace AutomationTests.Hooks.ScenarioHooks
{
    [Binding]
    public class BeforeScenarioHooks : BaseTestingClass
    {
        public BeforeScenarioHooks(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario1(ITestOutputHelper testOutputHelper)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("jsConfig.json")
                .Build();

            Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo
                .TestOutput(testOutputHelper)
                .CreateLogger();
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario2()
        {
            ScenarioStopwatch = new Stopwatch();
            ScenarioStopwatch.Start();
        }
    }
}