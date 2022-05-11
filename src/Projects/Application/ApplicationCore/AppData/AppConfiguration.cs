namespace ApplicationCore.AppData
{
    public class AppConfiguration
    {
        public TestData TestData { get; set; }
        public TestConfiguration TestConfig { get; set; }
    }

    public class TestConfiguration
    {
        public int ExpectedPageLoadingTime { get; set; }

        public int ExpectedFindElementTime { get; set; }

        public string PageNotFoundMessage { get; set; }
    }

    public class TestData
    {
        public string BaseUrl { get; set; }
    }
}