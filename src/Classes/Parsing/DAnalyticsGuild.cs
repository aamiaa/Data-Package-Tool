using System;
using System.Collections.Generic;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAnalyticsGuild
    {
        public string id;
        public string join_type;
        public string join_method;
        public string application_id;
        public string location;
        public List<string> invites = new List<string>();
        public DateTime timestamp;
    }
}
