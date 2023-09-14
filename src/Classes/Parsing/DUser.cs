using System;
using System.Collections.Generic;
using System.Drawing;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DUser
    {
        public string id;
        public string username;
        public string global_name;
        public string discriminator;
        public string avatar_hash;

        public DRelationship[] relationships;
        public Dictionary<string, string> notes;

        private int DefaultAvatarId
        {
            get
            {
                if(this.IsPomelo())
                {
                    return (int)((Int64.Parse(this.id) >> 22) % 6);
                } else
                {
                    return Int32.Parse(this.discriminator) % 5;
                }
            }
        }

        public bool IsPomelo()
        {
            return this.discriminator == "0" || this.discriminator == "0000";
        }

        public string GetTag()
        {
            if(this.IsPomelo())
            {
                return this.username;
            }

            return $"{this.username}#{this.discriminator}";
        }

        public Bitmap GetDefaultAvatar()
        {
            switch (this.DefaultAvatarId)
            {
                case 0:
                    return Properties.Resources.DefaultAvatar0;
                case 1:
                    return Properties.Resources.DefaultAvatar1;
                case 2:
                    return Properties.Resources.DefaultAvatar2;
                case 3:
                    return Properties.Resources.DefaultAvatar3;
                case 4:
                    return Properties.Resources.DefaultAvatar4;
                case 5:
                    return Properties.Resources.DefaultAvatar5;
                default:
                    throw new Exception("This shouldn't happen");
            }
        }
    }
}
