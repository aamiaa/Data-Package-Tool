using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Package_Tool.Classes
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
            if (this.channel.guild != null)
            {
                guild = this.channel.guild.id;
            }
            else if (this.channel.IsDM() || this.channel.IsGroupDM())
            {
                guild = "@me";
            }
            else
            {
                throw new Exception($"Couldn't find guild id for channel {this.channel.id} type {this.channel.type}");
            }

            return $"{guild}/{this.channel.id}/{this.id}";
        }
    }
}
