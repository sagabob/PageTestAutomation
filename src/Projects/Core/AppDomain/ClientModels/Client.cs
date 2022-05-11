using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppDomain.ClientModels
{
    public class Client
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty] public int CountryId { get; set; }

        [JsonProperty] public string Name { get; set; }

        [JsonProperty] public string ShortName { get; set; }

        [JsonProperty] public string LongName { get; set; }

        [JsonProperty] public string HomePage { get; set; }

        [JsonProperty] public string Alias { get; set; }

        [JsonProperty] public bool HasPrefix { get; set; }

        [JsonProperty] public string ClientType { get; set; }

        [JsonProperty] public IEnumerable<IdClientPage> Pages { get; set; }
    }
}