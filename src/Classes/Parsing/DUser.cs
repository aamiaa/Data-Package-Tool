using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DUser
    {
        public string id;
        public string username;
        public string global_name;
        public string discriminator;
        public string avatar_hash;
        public string avatar; // relationship user field

        public DRelationship[] relationships;
        public Dictionary<string, string> notes;

        public BitmapImage avatar_image;

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

        public string GetAvatarURL()
        {
            string avatarHash = this.avatar_hash ?? this.avatar;
            if (avatarHash != null)
            {
                return $"https://cdn.discordapp.com/avatars/{id}/{avatarHash}.png?size=64";
            }

            if (IsPomelo())
            {
                return $"https://cdn.discordapp.com/embed/avatars/{this.DefaultAvatarId}.png?size=64";
            }

            return $"https://cdn.discordapp.com/embed/avatars/{this.DefaultAvatarId}.png?size=64";
        }

        public Bitmap GetDefaultAvatarBitmap()
        {
            return Properties.Resources.ResourceManager.GetObject($"DefaultAvatar{this.DefaultAvatarId}") as Bitmap;
        }

        public BitmapImage GetDefaultAvatarBitmapImage()
        {
            return Discord.DefaultAvatars[DefaultAvatarId];
        }
    }
}
