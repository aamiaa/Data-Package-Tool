using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Package_Tool.Classes
{
    public static class Util
    {
        public static void LaunchDiscordProtocol(string url)
        {
            string instance = Properties.Settings.Default.UseDiscordInstance;
            if (instance == "default")
            {
                Process.Start($"discord://-/{url}");
                return;
            }

            if (instance.StartsWith("web_"))
            {
                string hostname;
                switch (instance)
                {
                    case "web_stable":
                        hostname = "discord.com";
                        break;
                    case "web_ptb":
                        hostname = "ptb.discord.com";
                        break;
                    case "web_canary":
                        hostname = "canary.discord.com";
                        break;
                    default:
                        throw new Exception($"Invalid settings value: {instance}");
                }

                Process.Start($"https://{hostname}/{url}");
                return;
            }

            string folderName;
            switch (instance)
            {
                case "stable":
                    folderName = "Discord";
                    break;
                case "ptb":
                    folderName = "DiscordPTB";
                    break;
                case "canary":
                    folderName = "DiscordCanary";
                    break;
                default:
                    throw new Exception($"Invalid settings value: {instance}");
            }

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), folderName);
            if (!Directory.Exists(path))
            {
                throw new Exception($"Couldn't find Discord folder path for {instance}");
            }

            foreach (var folder in Directory.GetDirectories(path))
            {
                string exePath = Path.Combine(folder, $"{folderName}.exe");
                if (new DirectoryInfo(folder).Name.StartsWith("app-") && File.Exists(exePath))
                {
                    Process.Start(exePath, $"--url -- \"discord://-/{url}\"");
                    return;
                }
            }

            throw new Exception("Couldn't find the Discord exe file");
        }

        public static DateTime SnowflakeToTimestap(string snowflake)
        {
            var ms = Int64.Parse(snowflake) >> 22;
            var timestamp = ms + 1420070400000;

            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
        }

        public static bool ValidateToken(string token, string userId)
        {
            var parts = token.Split('.');

            if (parts.Length != 3) return false;

            var userIdPart = parts[0];
            try
            {
                var tokenUserId = Encoding.UTF8.GetString(Convert.FromBase64String(userIdPart));
                return tokenUserId == userId;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
