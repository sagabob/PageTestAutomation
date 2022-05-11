using ApplicationCore.Models;

namespace ApplicationCore.AppData
{
    public interface IPageContext
    {
        string BaseUrl { get; }

        TestConfiguration TestConfig { get; }

        HousingPageModel PageModel { get; }
    }
}