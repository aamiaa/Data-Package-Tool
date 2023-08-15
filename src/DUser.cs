using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Package_Images
{
    public class DRelationship
    {
        public string id;
        public int type;
        public string nickname;
        public DUser user;
    }
    public class DUser
    {
        public string id;
        public string username;
        public string discriminator;
        public string avatar_hash;

        public DRelationship[] relationships;
        public dynamic[] user_sessions;

        public string GetAvatarURL()
        {
            if(avatar_hash != null)
            {
                return $"https://cdn.discordapp.com/avatars/{id}/{avatar_hash}.png?size=64";
            }

            if(IsPomelo())
            {
                return $"https://cdn.discordapp.com/embed/avatars/{(Int64.Parse(id) >> 22) % 6}.png?size=64";
            }

            return $"https://cdn.discordapp.com/embed/avatars/{Int32.Parse(discriminator) % 5}.png?size=64";
        }

        public bool IsPomelo()
        {
            return discriminator == "0" || discriminator == "0000";
        }

        public string GetTag()
        {
            if(this.IsPomelo())
            {
                return this.username;
            }

            return $"{this.username}#{this.discriminator}";
        }
    }
}
