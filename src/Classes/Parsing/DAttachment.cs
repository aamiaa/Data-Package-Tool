using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data_Package_Tool.Classes.Parsing
{
    public class DAttachment
    {
        public static readonly List<string> ImageExtensions = new() { "png", "gif", "jpg", "jpeg", "apng", "jfif", "webp" };
        public static readonly List<string> VideoExtensions = new() { "mp4", "webm", "avi", "mov" };

        public string Url { get; private set; }
        public DMessage Message { get; private set; }

        public string Id { get; private set; }
        public string FileName { get; private set; }
        public string Extension { get; private set; }

        public bool IsImage
        {
            get => ImageExtensions.Contains(this.Extension);
        }
        public bool IsVideo
        {
            get => VideoExtensions.Contains(this.Extension);
        }

        public DAttachment(string url, DMessage message)
        {
            this.Url = url;
            this.Message = message;

            var match = Regex.Match(url, @"attachments\/\d+\/(\d+)\/([\w.-]+\.(\w+))");
            this.Id = match.Groups[1].Value;
            this.FileName = match.Groups[2].Value;
            this.Extension = match.Groups[3].Value;
        }
    }
}
