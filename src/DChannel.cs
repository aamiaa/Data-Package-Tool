using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Data_Package_Images
{
    public class PartialGuild
    {
        public string id;
        public string name;
    }
    public class DMessage
    {
        public string id;
        public string timestamp;
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
            else if (this.channel.IsDM()|| this.channel.IsGroupDM())
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
    public class DAttachment
    {
        public static string[] ImageExtensions = {".png", ".gif", ".jpg", ".jpeg", ".apng", ".jfif", ".webp"};

        public DMessage message;
        public string url;

        public bool IsImage()
        {
            foreach(var ext in DAttachment.ImageExtensions)
            {
                if(this.url.EndsWith(ext))
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class DChannel
    {
        public string id;
        public int type;
        public string name;
        public PartialGuild guild;
        public List<DMessage> messages = new List<DMessage>();
        public string[] recipients;

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
                        id = idField,
                        timestamp = timestampField,
                        content = contentField,
                        channel = this
                    };

                    if (attachmentsField != "")
                    {
                        foreach (var url in attachmentsField.Split(' '))
                        {

                            var attachment = new DAttachment
                            {
                                message = msg,
                                url = url
                            };
                            msg.attachments.Add(attachment);

                            if (attachment.IsImage())
                            {
                                Main.AllAttachments.Add(attachment);
                            }
                        }
                    }

                    messages.Add(msg);
                }
            }
        }

        public bool IsDM()
        {
            return this.type == 1;
        }

        public bool IsGroupDM()
        {
            return this.type == 3;
        }

        public bool IsVoice()
        {
            return this.type == 2 || this.type == 13;
        }

        public string GetOtherDMRecipient(DUser user)
        {
            if(!this.IsDM())
            {
                throw new Exception("GetDMRecipient can only be used on dm channels");
            }

            foreach(string id in recipients)
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
