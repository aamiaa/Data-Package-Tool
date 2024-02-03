using Data_Package_Tool.Classes.Parsing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
        public DUser User;
        public MemoryStream Avatar = new MemoryStream();
        public List<DAttachment> Attachments = new List<DAttachment>();
        public dynamic Guilds;
        public List<DChannel> Channels = new List<DChannel>();
        public Dictionary<string, DChannel> ChannelsMap = new Dictionary<string, DChannel>();
        public Dictionary<string, DMessage> MessagesMap = new Dictionary<string, DMessage>();

        public List<DAnalyticsGuild> JoinedGuilds = new List<DAnalyticsGuild>();
        public List<DAnalyticsEvent> AcceptedInvites = new List<DAnalyticsEvent>();

        public DateTime CreationTime;
        public int TotalMessages = 0;

        public bool UsesUnsignedCDNLinks
        {
            get => Attachments.Count > 0 && !Attachments[0].url.Contains("?ex=");
        }

        public LoadStatus LoadStatus = new LoadStatus
        {
               Progress = 0,
               Max = 0,
               Status = "",
               Finished = false
        };

        public LoadStatus GuildsLoadStatus = new LoadStatus
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
                    this.Guilds = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                }

                if (User.avatar_hash == null)
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
                                this.MessagesMap.Add(msg.id, msg);
                                
                                foreach(var attachment in msg.attachments)
                                {
                                    if(attachment.IsImage())
                                    {
                                        this.Attachments.Add(attachment);
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

                this.User.avatar_image = avImg;
            });

            this.Attachments = this.Attachments.OrderByDescending(o => Int64.Parse(o.message.id)).ToList();
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

            this.AcceptedInvites = this.AcceptedInvites.OrderBy(o => DateTime.Parse(o.timestamp.Replace("\"", ""), null, DateTimeStyles.RoundtripKind).Ticks).ToList();

            foreach (var eventData in this.AcceptedInvites)
            {
                var guild = this.JoinedGuilds.Find(x => x.id == eventData.guild);
                if (guild == null)
                {
                    this.JoinedGuilds.Add(new DAnalyticsGuild
                    {
                        id = eventData.guild,
                        join_type = "invite",
                        invites = new List<string> { eventData.invite },
                        timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, DateTimeStyles.RoundtripKind)
                    });
                }
                else
                {
                    if (!guild.invites.Contains(eventData.invite))
                    {
                        guild.invites.Add(eventData.invite);
                    }

                    // Handle the case where the original join didn't create a guild_join event, but did create accepted_instant_invite, and then a rejoin created a newer guild_join
                    // (i.e. use older date from accepted_instant_invite if there is one)
                    var joinDate = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, DateTimeStyles.RoundtripKind);
                    if (joinDate.Ticks < guild.timestamp.Ticks)
                    {
                        guild.timestamp = joinDate;
                    }
                }
            }

            this.JoinedGuilds = this.JoinedGuilds.OrderByDescending(o => o.timestamp.Ticks).ToList();

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

            switch (eventData.event_type)
            {
                case "guild_joined":
                case "guild_joined_pending":
                    var idx = this.JoinedGuilds.FindIndex(x => x.id == eventData.guild_id);
                    if (idx > -1)
                    {
                        var guild = this.JoinedGuilds[idx];
                        if (eventData.invite_code != null && !guild.invites.Contains(eventData.invite_code))
                        {
                            guild.invites.Add(eventData.invite_code);
                        }

                        // Get the earliest join date
                        var timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, System.Globalization.DateTimeStyles.RoundtripKind);
                        if (timestamp < guild.timestamp)
                        {
                            guild.timestamp = timestamp;
                        }
                    }
                    else
                    {
                        this.JoinedGuilds.Add(new DAnalyticsGuild
                        {
                            id = eventData.guild_id,
                            join_type = eventData.join_type,
                            join_method = eventData.join_method,
                            application_id = eventData.application_id,
                            location = eventData.location,
                            invites = (eventData.invite_code != null ? new List<string> { eventData.invite_code } : new List<string>()),
                            timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, System.Globalization.DateTimeStyles.RoundtripKind)
                        });
                    }
                    break;
                case "create_guild":
                    Debug.WriteLine(eventData.timestamp.Replace("\"", ""));
                    this.JoinedGuilds.Add(new DAnalyticsGuild
                    {
                        id = eventData.guild_id,
                        join_type = "created by you",
                        invites = new List<string>(),
                        timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, System.Globalization.DateTimeStyles.RoundtripKind)
                    });
                    break;
                case "accepted_instant_invite":
                    if (eventData.guild != null) this.AcceptedInvites.Add(eventData);
                    break;
            }
        }
    }
}
