using ApplicationCore.AppData;
using ApplicationCore.Models;

namespace AutomationTests.Utility
{
    public class TestDataHelpers
    {
        public static IPageContext PageDataInitializer()
        {
            var appConfig =  AppConfigurationHandler<AppConfiguration>.GetConfig("jsConfig.json", "AppConfiguration");

            var pageModel = AppConfigurationHandler<HousingPageModel>.GetConfig("housingPageModel.json", "HousingPageModel");

            IPageContext pageContext = new PageContext(appConfig, pageModel);

            return pageContext;
        }
    }
}