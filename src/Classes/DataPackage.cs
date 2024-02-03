using Data_Package_Tool.Classes.Parsing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Data_Package_Tool.Classes
{
    public struct LoadStatus
    {
        public int Progress;
        public int Max;
        public string Status;
        public bool Finished;
    }
    public class DataPackage
    {
        public DUser User { get; private set; }
        public readonly MemoryStream Avatar = new();
        public readonly List<DChannel> Channels = new();
        public readonly Dictionary<string, DChannel> ChannelsMap = new();
        public readonly Dictionary<string, DMessage> MessagesMap = new();

        public List<DAttachment> ImageAttachments { get; private set; } = new List<DAttachment>();
        public List<DAnalyticsGuild> JoinedGuilds { get; private set; } = new List<DAnalyticsGuild>();
        public List<DAnalyticsEvent> AcceptedInvites { get; private set; } = new List<DAnalyticsEvent>();
        public Dictionary<string, string> GuildNamesMap { get; private set; } = new Dictionary<string, string>();

        public DateTime CreationTime { get; private set; }
        public int TotalMessages { get; private set; } = 0;

        public bool UsesUnsignedCDNLinks
        {
            get => ImageAttachments.Count > 0 && !ImageAttachments[0].Url.Contains("?ex=");
        }

        public LoadStatus LoadStatus = new()
        {
               Progress = 0,
               Max = 0,
               Status = "",
               Finished = false
        };

        public LoadStatus GuildsLoadStatus = new()
        {
            Progress = 0,
            Max = 100,
            Status = "",
            Finished = false
        };

        public void Load(string fileName)
        {
            var startTime = DateTime.Now;

            using (var file = File.OpenRead(fileName))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                this.LoadStatus.Max = zip.Entries.Count;

                var userFile = zip.GetEntry("account/user.json");
                if (userFile == null)
                {
                    throw new Exception("Invalid data package: missing user.json");
                }

                this.CreationTime = userFile.LastWriteTime.DateTime;

                using (var r = new StreamReader(userFile.Open()))
                {
                    var json = r.ReadToEnd();
                    this.User = Newtonsoft.Json.JsonConvert.DeserializeObject<DUser>(json);
                }

                using (var r = new StreamReader(zip.GetEntry("servers/index.json").Open()))
                {
                    var json = r.ReadToEnd();
                    this.GuildNamesMap = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }

                if (User.AvatarHash == null)
                {
                    this.User.GetDefaultAvatarBitmap().Save(this.Avatar, System.Drawing.Imaging.ImageFormat.Png);
                }

                var messagesRegex = new Regex(@"messages/(c?(\d+))/messages\.csv", RegexOptions.Compiled);
                var avatarRegex = new Regex(@"account/avatar\.[a-z]+", RegexOptions.Compiled);
                int i = 0;
                foreach (var entry in zip.Entries)
                {
                    i++;
                    this.LoadStatus.Progress = i;
                    this.LoadStatus.Status = $"Reading {entry.FullName}\n{i}/{zip.Entries.Count}";

                    var match = messagesRegex.Match(entry.FullName);
                    if (match.Success)
                    {
                        var channelId = match.Groups[2].Value;
                        var folderName = match.Groups[1].Value; // folder name might not start with "c" in older versions
                        using (var rJson = new StreamReader(zip.GetEntry($"messages/{folderName}/channel.json").Open()))
                        using (var rCsv = new StreamReader(entry.Open()))
                        {
                            var json = rJson.ReadToEnd();
                            var csv = rCsv.ReadToEnd();

                            var channel = Newtonsoft.Json.JsonConvert.DeserializeObject<DChannel>(json);
                            channel.LoadMessages(csv);

                            foreach(var msg in channel.Messages)
                            {
                                this.MessagesMap.Add(msg.Id, msg);
                                
                                foreach(var attachment in msg.Attachments)
                                {
                                    if(attachment.IsImage)
                                    {
                                        this.ImageAttachments.Add(attachment);
                                    }
                                }
                            }

                            this.TotalMessages += channel.Messages.Count;
                            this.Channels.Add(channel);
                            this.ChannelsMap[channel.Id] = channel;
                        }
                    }
                    else if (avatarRegex.IsMatch(entry.FullName))
                    {
                        using (var s = entry.Open())
                        {
                            // Can't create BitmapImage here because it can only be accessed from the thread it was created in
                            s.CopyTo(this.Avatar);
                            this.Avatar.Position = 0;
                        }
                    }
                }
            }

            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                var avImg = new BitmapImage();
                avImg.BeginInit();
                avImg.StreamSource = this.Avatar;
                avImg.CacheOption = BitmapCacheOption.OnLoad;
                avImg.EndInit();
                avImg.Freeze();

                this.User.AvatarImage = avImg;
            });

            this.ImageAttachments = this.ImageAttachments.OrderByDescending(o => Int64.Parse(o.Message.Id)).ToList();
            this.LoadStatus.Status = $"Finished! Parsed {this.TotalMessages.ToString("N0", new NumberFormatInfo { NumberGroupSeparator = " " })} messages in {Math.Floor((DateTime.Now - startTime).TotalSeconds)}s\nPackage created at: {this.CreationTime.ToShortDateString()}";

            this.LoadStatus.Finished = true;
        }

        public void LoadGuilds(string fileName)
        {
            var compiledRegex = new Regex(@"activity/reporting/events.+\.json", RegexOptions.Compiled);

            using (var file = File.OpenRead(fileName))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    if (compiledRegex.IsMatch(entry.FullName))
                    {
                        using (var data = new StreamReader(entry.Open()))
                        {
                            long bytesRead = 0;
                            while (!data.EndOfStream)
                            {
                                var line = data.ReadLine();
                                bytesRead += line.Length;

                                this.GuildsLoadStatus.Progress = (int)((double)bytesRead / (long)entry.Length * 100);
                                ProcessAnalyticsLine(line);
                            }
                        }
                    }
                }
            }

            this.AcceptedInvites = this.AcceptedInvites.OrderBy(o => o.Timestamp.Ticks).ToList();

            foreach (var eventData in this.AcceptedInvites)
            {
                var guild = this.JoinedGuilds.Find(x => x.Id == eventData.GuildId);
                if (guild == null)
                {
                    this.JoinedGuilds.Add(new DAnalyticsGuild
                    {
                        Id = eventData.GuildId,
                        JoinType = "invite",
                        Invites = new List<string> { eventData.InviteCode },
                        Timestamp = eventData.Timestamp
                    });
                }
                else
                {
                    if (!guild.Invites.Contains(eventData.InviteCode))
                    {
                        guild.Invites.Add(eventData.InviteCode);
                    }

                    // Handle the case where the original join didn't create a guild_join event, but did create accepted_instant_invite, and then a rejoin created a newer guild_join
                    // (i.e. use older date from accepted_instant_invite if there is one)
                    var joinDate = eventData.Timestamp;
                    if (joinDate.Ticks < guild.Timestamp.Ticks)
                    {
                        guild.Timestamp = joinDate;
                    }
                }
            }

            this.JoinedGuilds = this.JoinedGuilds.OrderByDescending(o => o.Timestamp.Ticks).ToList();

            this.GuildsLoadStatus.Finished = true;
        }

        private void ProcessAnalyticsLine(string line)
        {
            // Pro optimization
            if (!line.StartsWith("{\"event_type\":\"guild_joined") && !line.StartsWith("{\"event_type\":\"create_guild") && !line.StartsWith("{\"event_type\":\"accepted_instant_invite"))
            {
                return;
            }

            var eventData = Newtonsoft.Json.JsonConvert.DeserializeObject<DAnalyticsEvent>(line);

            switch (eventData.EventType)
            {
                case "guild_joined":
                case "guild_joined_pending":
                    var idx = this.JoinedGuilds.FindIndex(x => x.Id == eventData.GuildId);
                    if (idx > -1)
                    {
                        var guild = this.JoinedGuilds[idx];
                        if (eventData.InviteCode != null && !guild.Invites.Contains(eventData.InviteCode))
                        {
                            guild.Invites.Add(eventData.InviteCode);
                        }

                        // Get the earliest join date
                        var timestamp = eventData.Timestamp;
                        if (timestamp < guild.Timestamp)
                        {
                            guild.Timestamp = timestamp;
                        }
                    }
                    else
                    {
                        this.JoinedGuilds.Add(new DAnalyticsGuild
                        {
                            Id = eventData.GuildId,
                            JoinType = eventData.JoinType,
                            JoinMethod = eventData.JoinMethod,
                            ApplicationId = eventData.ApplicationId,
                            Location = eventData.Location,
                            Invites = (eventData.InviteCode != null ? new List<string> { eventData.InviteCode } : new List<string>()),
                            Timestamp = eventData.Timestamp
                        });
                    }
                    break;
                case "create_guild":
                    this.JoinedGuilds.Add(new DAnalyticsGuild
                    {
                        Id = eventData.GuildId,
                        JoinType = "created by you",
                        Invites = new List<string>(),
                        Timestamp = eventData.Timestamp
                    });
                    break;
                case "accepted_instant_invite":
                    if (eventData.GuildId != null) this.AcceptedInvites.Add(eventData);
                    break;
            }
        }
    }
}
