using System;
using AutomationSupport.ExtendedModels;
using AutomationSupport.Extensions;
using AutomationTests.Core;
using AutomationTests.Utility;
using Shouldly;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class BrowseHousingSitesSteps : BaseTestingClass
    {
        protected HousingPageDocument TestedPage;

        public BrowseHousingSitesSteps(
            TestThreadContext testThreadContext,
            FeatureContext featureContext,
            ScenarioContext scenarioContext)
            : base(testThreadContext, featureContext, scenarioContext)
        {
            Init();
        }

        public void Init()
        {
            TestedPage = Driver.HousingPageDocument(PageContext);
        }

        [Given(@"a client with alias with ""(.*)""")]
        public void GivenAPageAliasWith(string alias)
        {
            //set up driver
            DriverSetup.GeneralSetup(Driver, PageContext.TestConfig);

            ScenarioContext["ClientUrl"] = $"{PageContext.BaseUrl}/{alias}";
        }

        [When(@"I go to the page")]
        public void WhenIGoToThisPage()
        {
            var selectedUrl = ScenarioContext["ClientUrl"];
            Driver.Navigate().GoToUrl((string) selectedUrl);
            
        }

        [Then(@"the page should be ""(.*)""")]
        public void ThenThePageShouldBe(bool pageStatus)
        {
            var isValid = TestedPage.IsPageExisted && !TestedPage.IsPageBlank;

            isValid.ShouldBe(pageStatus);
        }
    }
}