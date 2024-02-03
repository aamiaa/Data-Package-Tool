using Newtonsoft.Json;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DPartialGuild
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
