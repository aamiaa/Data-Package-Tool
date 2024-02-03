using System;
using System.Collections.Generic;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DMessage
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
        public List<DAttachment> Attachments { get; } = new List<DAttachment>();
        public DChannel Channel { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string GetMessageLink()
        {
            string guild;
            if (this.Channel.Guild != null)
            {
                guild = this.Channel.Guild.Id;
            }
            else if (this.Channel.IsDM() || this.Channel.IsGroupDM())
            {
                guild = "@me";
            }
            else
            {
                throw new Exception($"Unable to find the server this message was sent in. This usually happens if you've left the server.");
            }

            return $"{guild}/{this.Channel.Id}/{this.Id}";
        }
    }
}
