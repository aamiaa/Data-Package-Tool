using System.Collections.Generic;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAttachment
    {
        public static List<string> ImageExtensions = new List<string>{ ".png", ".gif", ".jpg", ".jpeg", ".apng", ".jfif", ".webp" };

        public DMessage message;
        public string url;

        public bool IsImage()
        {
            return ImageExtensions.Exists(x => url.EndsWith(x));
        }
    }
}
