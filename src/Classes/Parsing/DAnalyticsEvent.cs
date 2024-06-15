using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAnalyticsEvent
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("guild")]
        public string GuildId { get; set; } // the guild id on invite events
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; } // the channel id on voice events
        [JsonProperty("channel_type")]
        public string ChannelType { get; set; }
        [JsonProperty("invite")]
        public string InviteCode { get; set; }

        [JsonProperty("guild_id")]
        private string GuildId2 { set => GuildId = value; }
        [JsonProperty("join_type")]
        public string JoinType { get; set; }
        [JsonProperty("join_method")]
        public string JoinMethod { get; set; }
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("invite_code")]
        private string InviteCode2 { set => InviteCode = value; }
        public DateTime Timestamp { get; set; }
        [JsonProperty("timestamp")]
        private string Timestamp2 { set => Timestamp = DateTime.Parse(value.Replace("\"", ""), null, DateTimeStyles.RoundtripKind); }

        [JsonProperty("duration")]
        public long Duration { get; set; } // the call duration on voice disconnect events
    }
}
