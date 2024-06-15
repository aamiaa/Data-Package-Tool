using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public string DMRecipientId { get; set; }
        public bool HasDuplicates { get; set; }

        public void LoadMessagesFromCsv(string csv)
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

                    AddMessage(idField, timestampField, contentField, attachmentsField);
                }
            }
        }

        public void LoadMessagesFromJson(string json)
        {
            var jsonMsgAray = JArray.Parse(json);
            foreach (var jsonMsg in jsonMsgAray)
            {
                string idField = jsonMsg["ID"].ToString();
                string timestampField = jsonMsg["Timestamp"].ToString();
                string contentField = jsonMsg["Contents"].ToString();
                string attachmentsField = jsonMsg["Attachments"].ToString();
                AddMessage(idField, timestampField, contentField, attachmentsField);
            }
        }

        private void AddMessage(string id, string timestamp, string contents, string attachments)
        {
            var msg = new DMessage
            {
                Id = id,
                Timestamp = DateTime.Parse(timestamp),
                Content = contents,
                Channel = this
            };

            if (attachments != "")
            {
                foreach (var url in attachments.Split(' '))
                {
                    var attachment = new DAttachment(url, msg);
                    msg.Attachments.Add(attachment);
                }
            }

            this.Messages.Add(msg);
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
                if(id != user.Id)
                {
                    return id;
                }
            }

            throw new Exception("This shouldn't happen");
        }
    }
}
