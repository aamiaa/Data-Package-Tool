using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DChannel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("guild")]
        public DPartialGuild Guild { get; set; }
        [JsonProperty("recipients")]
        public List<string> RecipientIds { get; set; }

        public List<DMessage> Messages { get; } = new List<DMessage>();
        public bool HasDuplicates { get; set; }

        public void LoadMessages(string csv)
        {
            using(TextFieldParser parser = new TextFieldParser(new StringReader(csv)))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    string idField = fields[0];
                    string timestampField = fields[1];
                    string contentField = fields[2];
                    string attachmentsField = fields[3];

                    if (idField == "ID") continue; // Header collumns

                    var msg = new DMessage
                    {
                        Id = idField,
                        Timestamp = DateTime.Parse(timestampField),
                        Content = contentField,
                        Channel = this
                    };

                    if (attachmentsField != "")
                    {
                        foreach (var url in attachmentsField.Split(' '))
                        {

                            var attachment = new DAttachment(url, msg);
                            msg.Attachments.Add(attachment);
                        }
                    }

                    this.Messages.Add(msg);
                }
            }
        }

        public bool IsDM()
        {
            return this.Type == 1;
        }

        public bool IsGroupDM()
        {
            return this.Type == 3;
        }

        public bool IsVoice()
        {
            return this.Type == 2 || this.Type == 13;
        }

        public string GetOtherDMRecipient(DUser user)
        {
            if(!this.IsDM())
            {
                throw new Exception("GetDMRecipient can only be used on dm channels");
            }

            foreach(string id in RecipientIds)
            {
                if(id != user.id)
                {
                    return id;
                }
            }

            throw new Exception("This shouldn't happen");
        }
    }
}
