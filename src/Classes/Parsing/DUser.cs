using Data_Package_Tool.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("global_name")]
        public string DisplayName { get; set; }
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
        [JsonProperty("avatar_hash")]
        public string AvatarHash { get; set; }
        [JsonProperty("avatar")]
        private string AvatarHash2 { set => AvatarHash = value; } // relationship user field
        [JsonProperty("relationships")]
        public List<DRelationship> Relationships { get; set; }
        [JsonProperty("notes")]
        public Dictionary<string, string> Notes { get; set; }

        public BitmapImage AvatarImage { get; set; }
        public bool IsPomelo
        {
            get => this.Discriminator == "0" || this.Discriminator == "0000";
        }
        public bool IsDeletedUser
        {
            get => this.Id == Consts.DeletedUserId;
        }
        public string Tag
        {
            get => this.IsPomelo ? this.Username : $"{this.Username}#{this.Discriminator}";
        }
        private int DefaultAvatarId
        {
            get
            {
                if(this.IsPomelo)
                {
                    return (int)((Int64.Parse(this.Id) >> 22) % 6);
                } else
                {
                    return Int32.Parse(this.Discriminator) % 5;
                }
            }
        }
        public string AvatarURL
        {
            get
            {
                string avatarHash = this.AvatarHash;
                if (avatarHash != null)
                {
                    return $"https://cdn.discordapp.com/avatars/{this.Id}/{avatarHash}.png?size=64";
                }

                return $"https://cdn.discordapp.com/embed/avatars/{this.DefaultAvatarId}.png?size=64";
            }
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
