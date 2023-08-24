using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Package_Images.Classes
{
    public class DAttachment
    {
        public static string[] ImageExtensions = { ".png", ".gif", ".jpg", ".jpeg", ".apng", ".jfif", ".webp" };

        public DMessage message;
        public string url;

        public bool IsImage()
        {
            foreach (var ext in DAttachment.ImageExtensions)
            {
                if (this.url.EndsWith(ext))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
