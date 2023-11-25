using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAttachment
    {
        public static List<string> ImageExtensions = new List<string>{ "png", "gif", "jpg", "jpeg", "apng", "jfif", "webp" };
        public static List<string> VideoExtensions = new List<string> { "mp4", "webm", "avi", "mov" };

        public string url;
        public DMessage message;

        public string id;
        public string filename;
        public string extension;

        public DAttachment(string url, DMessage message)
        {
            this.url = url;
            this.message = message;

            var match = Regex.Match(url, @"attachments\/\d+\/(\d+)\/([\w.-]+\.(\w+))");
            this.id = match.Groups[1].Value;
            this.filename = match.Groups[2].Value;
            this.extension = match.Groups[3].Value;
        }

        public bool IsImage()
        {
            return ImageExtensions.Contains(this.extension);
        }

        public bool IsVideo()
        {
            return VideoExtensions.Contains(this.extension);
        }
    }
}
