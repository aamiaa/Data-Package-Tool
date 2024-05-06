using Newtonsoft.Json;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DRelationship
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        // Data packages from before 04.2024 have `type` set to a number,
        // while the current ones have it set to a string.
        // The enum resolves both automatically.
        [JsonProperty("type")]
        public RelationshipType Type { get; set; }
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        [JsonProperty("user")]
        public DUser User { get; set; }
    }

    public enum RelationshipType
    {
        MONE = 0,
        FRIEND = 1,
        BLOCKED = 2,
        PENDING_INCOMING = 3,
        PENDING_OUTGOING = 4,
        IMPLICIT = 5
    }
}
