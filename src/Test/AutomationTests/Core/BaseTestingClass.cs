using System;
using System.Diagnostics;
using ApplicationCore.AppData;
using BoDi;
using JetBrains.Annotations;
using OpenQA.Selenium;
using Serilog.Core;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings.Reflection;

namespace AutomationTests.Core
{
    /// <summary>
    /// This base class is created based on the one in https://github.com/Drelanim/Drelanium/
    /// </summary>
    public abstract class BaseTestingClass : ISpecFlowContextContainer
    {
        protected BaseTestingClass(
            [NotNull] TestThreadContext testThreadContext,
            [NotNull] FeatureContext featureContext,
            [NotNull] ScenarioContext scenarioContext)
        {
            TestThreadContext = testThreadContext ?? throw new ArgumentNullException(nameof(testThreadContext));
            FeatureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
            ScenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        public TestThreadContext TestThreadContext { get; }

        /// <summary>
        ///     Gets the thread-safe context object, that can be used during the execution of the Feature.
        /// </summary>
        public FeatureContext FeatureContext { get; }

        /// <summary>
        ///     Gets the thread-safe context object, that can be used during the execution of the Scenario.
        /// </summary>
        public ScenarioContext ScenarioContext { get; }

        public ScenarioStepContext StepContext => ScenarioContext.StepContext;

        public IObjectContainer TestThreadContainer => TestThreadContext.TestThreadContainer;

        public IObjectContainer FeatureContainer => FeatureContext.FeatureContainer;

        public IObjectContainer ScenarioContainer => ScenarioContext.ScenarioContainer;

        public Exception ScenarioError => ScenarioContext.TestError;

        public virtual IWebDriver Driver
        {
            get => TestThreadContext.ContainsKey(nameof(Driver))
                ? TestThreadContext.Get<IWebDriver>(nameof(Driver))
                : null;
            set => TestThreadContext.Set(value, nameof(Driver));
        }

        public virtual IPageContext PageContext
        {
            get => TestThreadContext.ContainsKey(nameof(PageContext))
                ? TestThreadContext.Get<IPageContext>(nameof(PageContext))
                : null;
            set => TestThreadContext.Set(value, nameof(PageContext));
        }

        public virtual Logger Logger
        {
            get => TestThreadContext.ContainsKey(nameof(Logger)) ? TestThreadContext.Get<Logger>(nameof(Logger)) : null;
            set => TestThreadContext.Set(value, nameof(Logger));
        }

        public Stopwatch FeatureStopwatch
        {
            get => FeatureContext.ContainsKey(nameof(FeatureStopwatch))
                ? FeatureContext.Get<Stopwatch>(nameof(FeatureStopwatch))
                : null;
            set => FeatureContext.Set(value, nameof(FeatureStopwatch));
        }

        public Stopwatch TestThreadStopWatch
        {
            get => TestThreadContext.ContainsKey(nameof(TestThreadStopWatch))
                ? TestThreadContext.Get<Stopwatch>(nameof(TestThreadStopWatch))
                : null;
            set => TestThreadContext.Set(value, nameof(TestThreadStopWatch));
        }

        public Stopwatch StepStopWatch
        {
            get => StepContext.ContainsKey(nameof(StepStopWatch))
                ? StepContext.Get<Stopwatch>(nameof(StepStopWatch))
                : null;
            set => StepContext.Set(value, nameof(StepStopWatch));
        }

        public Stopwatch ScenarioStopwatch
        {
            get => ScenarioContext.ContainsKey(nameof(ScenarioStopwatch))
                ? ScenarioContext.Get<Stopwatch>(nameof(ScenarioStopwatch))
                : null;
            set => ScenarioContext.Set(value, nameof(ScenarioStopwatch));
        }
        public FeatureInfo FeatureInfo => FeatureContext.FeatureInfo;

        public ScenarioInfo ScenarioInfo => ScenarioContext.ScenarioInfo;

        public StepInfo StepInfo => StepContext.StepInfo;

        public string FeatureTitle => FeatureInfo.Title;

        public string ScenarioTitle => ScenarioInfo.Title;
        
        public string StepName => StepInfo.StepDefinitionType + " " + StepInfo.Text;

        public IBindingMethod BindingStepDefinitionMethod => StepInfo.BindingMatch.StepBinding.Method;

        public ScenarioExecutionStatus ScenarioExecutionStatus => ScenarioContext.ScenarioExecutionStatus;

       
    }
}