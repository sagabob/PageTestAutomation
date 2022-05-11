using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Models;
using AutomationSupport.ExtendedModels;
using AutomationSupport.Extensions;
using AutomationTests.Core;
using AutomationTests.Utility;
using OpenQA.Selenium;
using Shouldly;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationTests.Steps
{
    [Binding]
    public class CheckSiteMenuSteps : BaseTestingClass
    {
        protected HousingPageDocument TestedPage;

        public CheckSiteMenuSteps(
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

        [Given(@"an input client alias like ""(.*)""")]
        public void GivenAPageAliasWith(string alias)
        {
            //set up driver
            DriverSetup.GeneralSetup(Driver, PageContext.TestConfig);

            ScenarioContext["ClientUrl"] = $"{PageContext.BaseUrl}/{alias}";
        }

        [When(@"I go to their page to check")]
        public void WhenIGoToTheirPage()
        {
            var selectedUrl = ScenarioContext["ClientUrl"];
            Driver.Navigate().GoToUrl((string) selectedUrl);
        }

        [Then(@"the site should be valid")]
        public void ThenTheirSiteShouldBeValid()
        {
            var isValid = TestedPage.IsPageExisted && !TestedPage.IsPageBlank;

            isValid.ShouldBe(true);
        }

        [Then(@"it should have the menu and it works")]
        public void ThenItShouldHaveTheMenu(Table table)
        {
            var listOfMenus = table.CreateSet<Menu>();
            ScenarioContext["Menu"] = listOfMenus;

            var ofMenus = listOfMenus.ToList();
            TestedPage.SideBarHasMenu(ofMenus).ShouldBeTrue();
        }

        [Then(@"sub-menu should also work")]
        public void ThenSubMenuShouldWork()
        {

            var menuList = (List<Menu>)ScenarioContext["Menu"];

            TestedPage.ExpandTestAllMenuItems(menuList).ShouldBeTrue();
        }
    }
}