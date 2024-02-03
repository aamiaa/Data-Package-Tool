using System;
using System.Collections.Generic;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAnalyticsGuild
    {
        public string Id { get; set; }
        public string JoinType { get; set; }
        public string JoinMethod { get; set; }
        public string ApplicationId { get; set; }
        public string Location { get; set; }
        public List<string> Invites { get; set; } = new();
        public DateTime Timestamp { get; set; }
    }
}
