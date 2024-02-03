using System;
using System.Collections.Generic;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DMessage
    {
        public bool deleted = false;

        public string id;
        public DateTime timestamp;
        public string content;
        public List<DAttachment> attachments = new List<DAttachment>();
        public DChannel channel;

        public string GetMessageLink()
        {
            string guild = "";
            if (this.channel.Guild != null)
            {
                guild = this.channel.Guild.id;
            }
            else if (this.channel.IsDM() || this.channel.IsGroupDM())
            {
                guild = "@me";
            }
            else
            {
                throw new Exception($"Unable to find the server this message was sent in. This usually happens if you've left the server.");
            }

            return $"{guild}/{this.channel.Id}/{this.id}";
        }
    }
}
