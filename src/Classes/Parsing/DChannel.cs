using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DChannel
    {
        public string id;
        public int type;
        public string name;
        public DPartialGuild guild;
        public List<DMessage> messages = new List<DMessage>();
        public string[] recipients;

        public bool has_duplicates;

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
                        timestamp = DateTime.Parse(timestampField),
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
                                Main.DataPackage.Attachments.Add(attachment);
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
