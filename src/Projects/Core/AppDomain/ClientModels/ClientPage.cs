using Newtonsoft.Json;

namespace AppDomain.ClientModels
{
    public class IdClientPage
    {
        [JsonProperty("AppID")] public int AppId { get; set; }

        [JsonProperty("PageID")] public int PageId { get; set; }

        [JsonProperty] public string Alias { get; set; }

        [JsonProperty] public bool Disabled { get; set; }

        [JsonProperty] public bool Draft { get; set; }

        [JsonProperty] public bool Secure { get; set; }

        [JsonProperty] public bool IsExport { get; set; }
    }
}