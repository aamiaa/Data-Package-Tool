using Newtonsoft.Json;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DRelationship
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        [JsonProperty("user")]
        public DUser User { get; set; }
    }
}
