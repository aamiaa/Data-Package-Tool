using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAttachment
    {
        public static List<string> ImageExtensions = new List<string>{ ".png", ".gif", ".jpg", ".jpeg", ".apng", ".jfif", ".webp" };
        public static List<string> VideoExtensions = new List<string> { ".mp4", ".webm", ".avi", ".mov" };

        public string id
        {
            get
            {
                return Regex.Match(this.url, @"attachments\/\d+\/(\d+)\/").Groups[1].Value;
            }
        }
        public string url;
        public DMessage message;

        public bool IsImage()
        {
            return ImageExtensions.Exists(x => url.EndsWith(x));
        }

        public bool IsVideo()
        {
            return VideoExtensions.Exists(x => url.EndsWith(x));
        }
    }
}
