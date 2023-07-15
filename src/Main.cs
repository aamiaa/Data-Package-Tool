using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Package_Images
{
    public partial class Main : Form
    {
        private readonly int MaxResults = 500;
        private int TotalMessages = 0;
        private List<DChannel> Channels = new List<DChannel>();
        
        public static DUser User;
        public static List<DAttachment> AllAttachments = new List<DAttachment>();
        public static List<DAnalyticsGuild> AllJoinedGuilds = new List<DAnalyticsGuild>();

        public Main()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            switch(Properties.Settings.Default.UseDiscordInstance)
            {
                case "default":
                    defaultRb.Checked = true;
                    break;
                case "stable":
                    stableRb.Checked = true;
                    break;
                case "ptb":
                    ptbRb.Checked = true;
                    break;
                case "canary":
                    canaryRb.Checked = true;
                    break;
            }
        }

        public static void LaunchDiscordProtocol(string url)
        {
            string instance = Properties.Settings.Default.UseDiscordInstance;
            if(instance == "default")
            {
                Process.Start(url);
                return;
            }

            string folderName;
            switch(instance)
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
            if(!Directory.Exists(path))
            {
                throw new Exception($"Couldn't find Discord folder path for {instance}");
            }

            foreach(var folder in Directory.GetDirectories(path))
            {
                string exePath = Path.Combine(folder, $"{folderName}.exe");
                if(new DirectoryInfo(folder).Name.StartsWith("app-") && File.Exists(exePath))
                {
                    Process.Start(exePath, $"--url -- \"{url}\"");
                    return;
                }
            }

            throw new Exception("Couldn't find the Discord exe file");
        }

        private void DisplayMessage(DMessage message)
        {
            /*var loc = new Point(0, 0);
            if (messagesPanel.Controls.Count > 0)
            {
                var last = (Message)messagesPanel.Controls[messagesPanel.Controls.Count - 1];
                var endsAtY = Math.Max(last.Location.Y + last.GetTextSize().Height - 73, last.Location.Y + last.Size.Height + 3);
                loc = new Point(0, endsAtY);
            }

            new Message(message, User)
            {
                Parent = messagesPanel,
                Location = loc,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };*/
            var msgControl = new MessageWPF(message, User);
            ((ListWPF)elementHost1.Child).AddToList(msgControl);
        }

        private List<DAnalyticsEvent> AllInvites = new List<DAnalyticsEvent>();
        private void ProcessAnalyticsLine(string line)
        {
            // Pro optimization
            if(!line.StartsWith("{\"event_type\":\"guild_joined") && !line.Contains("{\"event_type\":\"create_guild") && !line.Contains("{\"event_type\":\"accepted_instant_invite"))
            {
                return;
            }

            var eventData = Newtonsoft.Json.JsonConvert.DeserializeObject<DAnalyticsEvent>(line);

            switch (eventData.event_type)
            {
                case "guild_joined":
                case "guild_joined_pending":
                    var idx = AllJoinedGuilds.FindIndex(x => x.id == eventData.guild_id);
                    if (idx > -1)
                    {
                        var guild = AllJoinedGuilds[idx];
                        if (eventData.invite_code != null && !guild.invites.Contains(eventData.invite_code))
                        {
                            guild.invites.Add(eventData.invite_code);
                        }
                    }
                    else
                    {
                        AllJoinedGuilds.Add(new DAnalyticsGuild
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
                    AllJoinedGuilds.Add(new DAnalyticsGuild
                    {
                        id = eventData.guild_id,
                        join_type = "created by you",
                        invites = new List<string>(),
                        timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, System.Globalization.DateTimeStyles.RoundtripKind)
                    });
                    break;
                case "accepted_instant_invite":
                    if(eventData.guild != null) AllInvites.Add(eventData);
                    break;
            }
        }

        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadFileBtn.Hide();
                progressBar1.Show();

                guildsBw.RunWorkerAsync();

                var startTime = DateTime.Now;

                using (var file = File.OpenRead(openFileDialog1.FileName))
                using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    progressBar1.Maximum = zip.Entries.Count;

                    var userFile = zip.GetEntry("account/user.json");
                    if (userFile == null)
                    {
                        MessageBox.Show("Invalid data package: missing user.json", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        loadFileBtn.Show();
                        progressBar1.Hide();
                        progressBar1.Value = 0;
                        return;
                    }

                    using (var r = new StreamReader(userFile.Open()))
                    {
                        var json = r.ReadToEnd();
                        User = Newtonsoft.Json.JsonConvert.DeserializeObject<DUser>(json);
                    }

                    int i = 0;
                    foreach (var entry in zip.Entries)
                    {
                        i++;
                        if(i%100 == 0)
                        {
                            loadingLb.Text = $"Reading {entry.FullName}\n{i}/{zip.Entries.Count}";
                            progressBar1.Value = i;
                            Application.DoEvents();
                        }

                        if (Regex.IsMatch(entry.FullName, @"messages/c\d+/messages\.csv", RegexOptions.None))
                        {
                            var channelId = Regex.Matches(entry.FullName, @"messages/c(\d+)/messages\.csv", RegexOptions.None)[0].Groups[1].Value;
                            using (var rJson = new StreamReader(zip.GetEntry($"messages/c{channelId}/channel.json").Open()))
                            using (var rCsv = new StreamReader(entry.Open()))
                            {
                                var json = rJson.ReadToEnd();
                                var csv = rCsv.ReadToEnd();

                                var channel = Newtonsoft.Json.JsonConvert.DeserializeObject<DChannel>(json);
                                channel.LoadMessages(csv);

                                TotalMessages += channel.messages.Count;
                                Channels.Add(channel);
                            }
                        }
                    }
                }

                progressBar1.Value = progressBar1.Maximum;
                loadingLb.Text = $"Finished! Parsed {TotalMessages.ToString("N0", new NumberFormatInfo { NumberGroupSeparator = " " })} messages in {Math.Floor((DateTime.Now - startTime).TotalSeconds)}s";
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            searchBtn.Enabled = false;
            messagesPanel.Hide();
            //messagesPanel.Controls.Clear();
            ((ListWPF)elementHost1.Child).Clear();

            var searchText = searchTb.Text;
            int count = 0;

            List<DMessage> list = new List<DMessage>();

            foreach (var channel in Channels)
            {
                foreach (var msg in channel.messages)
                {
                    if (msg.content.Contains(searchText))
                    {
                        list.Add(msg);
                        count++;

                        if (count >= MaxResults)
                        {
                            resultsCountLb.Text = $"Results: {count} (only {MaxResults} shown)";
                        }
                        else
                        {
                            resultsCountLb.Text = $"Results: {count}";
                        }

                        if(count%100 == 0) Application.DoEvents();
                    }
                }
            }

            if (count == 0)
            {
                resultsCountLb.Text = $"No results";
            }
            else
            {
                list = list.OrderByDescending(o => Int64.Parse(o.id)).ToList();
                for(int i=0;i<Math.Min(count, MaxResults);i++)
                {
                    var msg = list[i];
                    DisplayMessage(msg);
                }
            }

            messagesPanel.Show();
            searchBtn.Enabled = true;

            ResumeLayout();
        }

        private int imagesOffset = 0;
        private int imagesPerPage = 36;
        private int imagesPerRow = 9;
        private int imageSquareSize = 200;
        private void LoadImages()
        {
            imagesNextBtn.Enabled = false;
            imagesPrevBtn.Enabled = false;

            imagesPanel.Controls.Clear();
            imagesCountLb.Text = $"{imagesOffset + 1}-{imagesOffset + imagesPerPage} of {AllAttachments.Count}";

            for (int i = 0; i < imagesPerPage; i++)
            {
                var loc = new Point(3, 3);
                if (imagesPanel.Controls.Count > 0)
                {
                    var last = (Attachment)imagesPanel.Controls[imagesPanel.Controls.Count - 1];
                    loc = new Point(imagesPanel.Controls.Count % imagesPerRow == 0 ? 3 : last.Location.X + last.Size.Width + 6, imagesPanel.Controls.Count % imagesPerRow == 0 ? last.Location.Y + imageSquareSize + 44 : last.Location.Y);
                }

                var attachment = AllAttachments[imagesOffset + i];

                var pb = new Attachment(attachment)
                {
                    Size = new Size(imageSquareSize, imageSquareSize),
                    Location = loc,
                    Parent = imagesPanel,
                };

                ThreadPool.QueueUserWorkItem(state => pb.LoadImage());

                Application.DoEvents();
            }

            imagesNextBtn.Enabled = true;
            imagesPrevBtn.Enabled = true;
        }
        private void imagesNextBtn_Click(object sender, EventArgs e)
        {
            if(imagesPanel.Controls.Count > 0)
            {
                imagesOffset += imagesPerPage;
            }
            LoadImages();
        }

        private void imagesPrevBtn_Click(object sender, EventArgs e)
        {
            if (imagesPanel.Controls.Count > 0)
            {
                imagesOffset -= imagesPerPage;
            }
            LoadImages();
        }

        private void imagesCountLb_DoubleClick(object sender, EventArgs e)
        {
            var offset = Interaction.InputBox("Enter the offset number", "Prompt");
            try
            {
                imagesOffset = Int32.Parse(offset);
                LoadImages();
            }
            catch (Exception) { }
        }

        private void discordInstanceSettingsChange(object sender, EventArgs e)
        {
            if(defaultRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "default";
            } else if(stableRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "stable";
            } else if(ptbRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "ptb";
            } else if(canaryRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "canary";
            }

            Properties.Settings.Default.Save();
        }

        private void guildsBw_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var file = File.OpenRead(openFileDialog1.FileName))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    if (Regex.IsMatch(entry.FullName, @"activity/reporting/events.+\.json", RegexOptions.None))
                    {
                        using (var data = new StreamReader(entry.Open()))
                        {
                            int lineNum = 0;
                            while (!data.EndOfStream)
                            {
                                lineNum++;

                                var line = data.ReadLine();
                                //ThreadPool.QueueUserWorkItem(state => ProcessAnalyticsLine(line));
                                ProcessAnalyticsLine(line);
                            }
                        }
                    }
                }
            }
        }

        private void guildsBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var eventData in AllInvites)
            {
                var guild = AllJoinedGuilds.Find(x => x.id == eventData.guild);
                if (guild == null)
                {
                    AllJoinedGuilds.Add(new DAnalyticsGuild
                    {
                        id = eventData.guild,
                        join_type = "invite",
                        invites = new List<string> { eventData.invite },
                        timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, System.Globalization.DateTimeStyles.RoundtripKind)
                    });
                }
                else if (!guild.invites.Contains(eventData.invite))
                {
                    guild.invites.Add(eventData.invite);
                }
            }

            AllJoinedGuilds = AllJoinedGuilds.OrderByDescending(o => o.timestamp.Ticks).ToList();

            serversLv.Items.Clear();
            foreach (var guild in AllJoinedGuilds)
            {
                string[] values = { guild.timestamp.ToShortDateString(), guild.id, guild.join_type, guild.location, String.Join(", ", guild.invites.ToArray()) };
                var lvItem = new ListViewItem(values);
                serversLv.Items.Add(lvItem);
            }

            AllAttachments = AllAttachments.OrderByDescending(o => Int64.Parse(o.message.id)).ToList();
        }
    }
}
