using ApplicationCore.Models;

namespace ApplicationCore.AppData
{
    public class PageContext : IPageContext
    {
        private readonly AppConfiguration _appConfig;

        public PageContext(AppConfiguration appConfig, HousingPageModel pageModel)
        {
            _appConfig = appConfig;
            PageModel = pageModel;

            Init();
        }

        public HousingPageModel PageModel { get; }

        public TestConfiguration TestConfig { get; private set; }

        public string BaseUrl { get; private set; }

        private void Init()
        {
            BaseUrl = _appConfig.TestData.BaseUrl;

            TestConfig = _appConfig.TestConfig;
        }
    }
}