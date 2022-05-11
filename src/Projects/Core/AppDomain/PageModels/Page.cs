using Newtonsoft.Json;

namespace AppDomain.PageModels
{
    public class Page
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("PageID")] public int PageId { get; set; }

        [JsonProperty("ParentPageID")] public int ParentPageId { get; set; }

        [JsonProperty("ApplicationID")] public int ApplicationId { get; set; }

        [JsonProperty] public string Alias { get; set; }

        [JsonProperty] public string Title { get; set; }

        [JsonProperty] public string SubTitle { get; set; }

        [JsonProperty] public string MenuTitle { get; set; }
    }
}