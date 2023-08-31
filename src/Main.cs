using Data_Package_Tool.Classes;
using Data_Package_Tool.Forms;
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
using System.Windows.Forms;

namespace Data_Package_Tool
{
    public partial class Main : Form
    {
        private readonly int MaxResults = 500;
        private int TotalMessages = 0;
        private List<DChannel> Channels = new List<DChannel>();
        private DateTime PackageCreationTime;
        
        public static DUser User;
        public static MemoryStream UserAvatar = new MemoryStream();
        public static List<DAttachment> AllAttachments = new List<DAttachment>();
        public static List<DAnalyticsGuild> AllJoinedGuilds = new List<DAnalyticsGuild>();
        public static Dictionary<string, DChannel> ChannelsMap = new Dictionary<string, DChannel>();
        public static dynamic CurrentGuilds;
        public static string AccountToken = "";
        public Main()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if(Properties.Settings.Default.DeletedMessageIDs == null)
            {
                Properties.Settings.Default.DeletedMessageIDs = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }

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
                case "web_stable":
                    webStableRb.Checked = true;
                    break;
                case "web_ptb":
                    webPTBRb.Checked = true;
                    break;
                case "web_canary":
                    webCanaryRb.Checked = true;
                    break;
            }
        }

        private void DisplayMessage(DMessage message)
        {
            var msgControl = new MessageWPF(message, User);
            ((MessageListWPF)elementHost1.Child).AddToList(msgControl);
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

                        // Get the earliest join date
                        var timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, System.Globalization.DateTimeStyles.RoundtripKind);
                        if(timestamp < guild.timestamp)
                        {
                            guild.timestamp = timestamp;
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
                loadBw.RunWorkerAsync();
                loadTimer.Start();
            }
        }

        private string LoadStatusText = "";
        private int LoadProgress = 0;
        private void loadBw_DoWork(object sender, DoWorkEventArgs e)
        {
            var startTime = DateTime.Now;

            using (var file = File.OpenRead(openFileDialog1.FileName))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                progressBar1.Invoke((MethodInvoker)delegate {
                    progressBar1.Maximum = zip.Entries.Count;
                });

                var userFile = zip.GetEntry("account/user.json");
                if (userFile == null)
                {
                    throw new Exception("Invalid data package: missing user.json");
                }

                PackageCreationTime = userFile.LastWriteTime.DateTime;

                using (var r = new StreamReader(userFile.Open()))
                {
                    var json = r.ReadToEnd();
                    User = Newtonsoft.Json.JsonConvert.DeserializeObject<DUser>(json);
                }

                using (var r = new StreamReader(zip.GetEntry("servers/index.json").Open()))
                {
                    var json = r.ReadToEnd();
                    CurrentGuilds = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                }

                if (User.avatar_hash != null)
                {
                    // Can't create BitmapImage here because it can only be accessed from the thread it was created in
                    using (var s = zip.GetEntry("account/avatar.png").Open()) // TODO: check if the extension changes when the avatar is animated
                    {
                        s.CopyTo(UserAvatar);
                    }
                } else
                {
                    Properties.Resources._0.Save(UserAvatar, System.Drawing.Imaging.ImageFormat.Png);
                }

                int i = 0;
                foreach (var entry in zip.Entries)
                {
                    i++;
                    LoadStatusText = $"Reading {entry.FullName}\n{i}/{zip.Entries.Count}";
                    LoadProgress = i;

                    if (Regex.IsMatch(entry.FullName, @"messages/c?\d+/messages\.csv", RegexOptions.None))
                    {
                        var match = Regex.Matches(entry.FullName, @"messages/(c?(\d+))/messages\.csv", RegexOptions.None)[0];
                        var channelId = match.Groups[2].Value;
                        var folderName = match.Groups[1].Value; // folder name might not start with "c" in older versions
                        using (var rJson = new StreamReader(zip.GetEntry($"messages/{folderName}/channel.json").Open()))
                        using (var rCsv = new StreamReader(entry.Open()))
                        {
                            var json = rJson.ReadToEnd();
                            var csv = rCsv.ReadToEnd();

                            var channel = Newtonsoft.Json.JsonConvert.DeserializeObject<DChannel>(json);
                            channel.LoadMessages(csv);

                            TotalMessages += channel.messages.Count;
                            Channels.Add(channel);
                            ChannelsMap[channel.id] = channel;
                        }
                    }
                }
            }

            AllAttachments = AllAttachments.OrderByDescending(o => Int64.Parse(o.message.id)).ToList();

            dmsLv.Invoke((MethodInvoker)delegate
            {
                var dmChannels = Channels.Where(x => x.IsDM()).OrderByDescending(o => Int64.Parse(o.id)).ToList();
                var duplicateChannelsMap = new Dictionary<string, dynamic>();

                tabControl1.TabPages[4].Text = $"Direct Messages - {dmChannels.Count}";

                foreach (var dmChannel in dmChannels)
                {
                    string recipientId = dmChannel.GetOtherDMRecipient(User);
                    string recipientUsername = "";
                    var relationship = User.relationships.ToList().Find(x => x.id == recipientId);
                    if (relationship != null) recipientUsername = relationship.user.GetTag();

                    string[] values = { Util.SnowflakeToTimestap(dmChannel.id).ToShortDateString(), dmChannel.id, recipientId, recipientUsername, dmChannel.messages.Count.ToString(), User.notes.ContainsKey(recipientId) ? User.notes[recipientId] : "" };
                    var lvItem = new ListViewItem(values);

                    if (duplicateChannelsMap.ContainsKey(recipientId)) // Optimization. Calling Find() every time would be slow
                    {
                        duplicateChannelsMap[recipientId].item.BackColor = Color.Yellow;
                        lvItem.BackColor = Color.Yellow;

                        duplicateChannelsMap[recipientId].channel.has_duplicates = true;
                        dmChannel.has_duplicates = true;
                    }
                    else
                    {
                        duplicateChannelsMap[recipientId] = new { item = lvItem, channel = dmChannel };
                    }

                    dmsLv.Items.Add(lvItem);
                }
            });

            loadingLb.Invoke((MethodInvoker)delegate {
                loadingLb.Text = $"Finished! Parsed {TotalMessages.ToString("N0", new NumberFormatInfo { NumberGroupSeparator = " " })} messages in {Math.Floor((DateTime.Now - startTime).TotalSeconds)}s\nPackage created at: {PackageCreationTime.ToShortDateString()}";
            });
        }
        private void loadTimer_Tick(object sender, EventArgs e)
        {
            loadingLb.Text = LoadStatusText;
            progressBar1.Value = LoadProgress;
        }

        private void loadBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadTimer.Stop();
            if (e.Error != null)
            {
                loadFileBtn.Show();
                progressBar1.Hide();

                MessageBox.Show($"An error occurred:\n\n{e.Error.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            progressBar1.Value = progressBar1.Maximum;
        }

        private List<DMessage> LastSearchResults;
        private int SearchResultsOffset = 0;
        private void LoadSearchResults()
        {
            ((MessageListWPF)elementHost1.Child).Clear();
            resultsCountLb.Text = $"{SearchResultsOffset + 1}-{Math.Min(SearchResultsOffset + MaxResults, LastSearchResults.Count)} of {LastSearchResults.Count}";
            for (int i = SearchResultsOffset; i < SearchResultsOffset + MaxResults; i++)
            {
                if(i >= LastSearchResults.Count) return;

                var msg = LastSearchResults[i];
                DisplayMessage(msg);
            }
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SearchMode == "regex")
            {
                try
                {
                    new Regex(searchTb.Text);
                } catch(Exception ex)
                {
                    MessageBox.Show($"Invalid regex: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            searchBtn.Enabled = false;
            searchTb.Enabled = false;
            searchOptionsBtn.Enabled = false;
            messagesPrevBtn.Enabled = false;
            messagesNextBtn.Enabled = false;
            messagesPanel.Hide();
            //messagesPanel.Controls.Clear();
            ((MessageListWPF)elementHost1.Child).Clear();

            searchBw.RunWorkerAsync();
            searchTimer.Start();
        }

        private void searchBw_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchResultsOffset = 0;

            var searchText = searchTb.Text;
            int count = 0;

            LastSearchResults = new List<DMessage>();

            // Optimization - precompile regex and reuse it
            Regex compiledRegex = null;
            if (Properties.Settings.Default.SearchMode == "words")
            {
                compiledRegex = new Regex($"^{String.Join("", Regex.Escape(searchText).Split(' ').Select(x => $"(?=.*?\\b{x}\\b)").ToArray())}", RegexOptions.Compiled); // https://stackoverflow.com/a/70484431
            } else if(Properties.Settings.Default.SearchMode == "regex")
            {
                compiledRegex = new Regex(searchText, RegexOptions.Compiled);
            }

            foreach (var channel in Channels)
            {
                // Filters
                if (channel.IsDM() && Properties.Settings.Default.SearchExcludeDMs) continue;
                if (channel.IsGroupDM() && Properties.Settings.Default.SearchExcludeGDMs) continue;
                if (!channel.IsDM() && !channel.IsGroupDM() && Properties.Settings.Default.SearchExcludeGuilds) continue;
                if (Properties.Settings.Default.SearchExcludeIDs != null)
                {
                    if (Properties.Settings.Default.SearchExcludeIDs.Contains(channel.id)) continue;
                    if (channel.guild != null && channel.guild.id != null && Properties.Settings.Default.SearchExcludeIDs.Contains(channel.guild.id)) continue;
                }
                if(Properties.Settings.Default.SearchWhitelistIDs != null && Properties.Settings.Default.SearchWhitelistIDs.Count > 0)
                {
                    if (!Properties.Settings.Default.SearchWhitelistIDs.Contains(channel.id) && !(channel.guild != null && channel.guild.id != null && Properties.Settings.Default.SearchWhitelistIDs.Contains(channel.guild.id))) continue;
                }

                // Search modes
                // Optimization - single condition which picks the function, rather than running the condition on every iteration
                if (Properties.Settings.Default.SearchMode == "exact")
                {
                    count += SearchExact(searchText, channel);
                }
                else if (Properties.Settings.Default.SearchMode == "words")
                {
                    count += SearchRegex(searchText, compiledRegex, channel);
                }
                else if (Properties.Settings.Default.SearchMode == "regex")
                {
                    count += SearchRegex(searchText, compiledRegex, channel);
                }
            }

            LastSearchResults = LastSearchResults.OrderByDescending(o => Int64.Parse(o.id)).ToList();
            foreach(var message in LastSearchResults)
            {
                if(Properties.Settings.Default.DeletedMessageIDs.Contains(message.id))
                {
                    message.deleted = true;
                }
            }
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            if (LastSearchResults.Count > 0)
            {
                if (LastSearchResults.Count >= MaxResults)
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{SearchResultsOffset + MaxResults} of {LastSearchResults.Count}";
                }
                else
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{LastSearchResults.Count} of {LastSearchResults.Count}";
                }
            }
        }

        private void searchBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            searchTimer.Stop();

            if (LastSearchResults.Count > 0)
            {
                LoadSearchResults();

                if (LastSearchResults.Count >= MaxResults)
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{SearchResultsOffset + MaxResults} of {LastSearchResults.Count}";
                }
                else
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{LastSearchResults.Count} of {LastSearchResults.Count}";
                }
            } else
            {
                resultsCountLb.Text = "No results";
            }

            messagesPanel.Show();
            searchBtn.Enabled = true;
            searchTb.Enabled = true;
            searchOptionsBtn.Enabled = true;
            messagesPrevBtn.Enabled = true;
            messagesNextBtn.Enabled = true;
        }

        private List<DMessage> FilterMessages(List<DMessage> messages)
        {
            IEnumerable<DMessage> m = messages;
            if (Properties.Settings.Default.SearchBeforeEnabled)
            {
                m = m.Where(x => x.timestamp < Properties.Settings.Default.SearchBeforeDate);
            }

            if(Properties.Settings.Default.SearchAfterEnabled)
            {
                m = m.Where(x => x.timestamp > Properties.Settings.Default.SearchAfterDate);
            }

            return m is List<DMessage> l ? l : m.ToList();
        }

        private int SearchExact(string searchText, DChannel channel)
        {
            int count = 0;

            foreach (var msg in FilterMessages(channel.messages))
            {

                if (msg.content.Contains(searchText))
                {
                    LastSearchResults.Add(msg);
                    count++;
                }
            }

            return count;
        }

        private int SearchRegex(string searchText, Regex compiledRegex, DChannel channel)
        {
            int count = 0;

            foreach (var msg in FilterMessages(channel.messages))
            {

                if (compiledRegex.IsMatch(msg.content))
                {
                    LastSearchResults.Add(msg);
                    count++;
                }
            }

            return count;
        }

        private void messagesPrevBtn_Click(object sender, EventArgs e)
        {
            SearchResultsOffset -= MaxResults;
            LoadSearchResults();
        }

        private void messagesNextBtn_Click(object sender, EventArgs e)
        {
            SearchResultsOffset += MaxResults;
            LoadSearchResults();
        }

        private int imagesOffset = 0;
        private int imagesPerPage = 36;
        private int imagesPerRow = 9;
        private int imageSquareSize = 200;
        private void LoadImages()
        {
            if(AllAttachments.Count == 0)
            {
                imagesCountLb.Text = $"No images found";
                return;
            }

            imagesNextBtn.Enabled = false;
            imagesPrevBtn.Enabled = false;

            if (imagesOffset < 0) imagesOffset = 0;
            if (imagesOffset >= AllAttachments.Count || imagesOffset + imagesPerPage >= AllAttachments.Count) imagesOffset = AllAttachments.Count - imagesPerPage;

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
            } else if(webStableRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "web_stable";
            }
            else if (webPTBRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "web_ptb";
            }
            else if (webCanaryRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "web_canary";
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
                        timestamp = DateTime.Parse(eventData.timestamp.Replace("\"", ""), null, DateTimeStyles.RoundtripKind)
                    });
                }
                else if (!guild.invites.Contains(eventData.invite))
                {
                    guild.invites.Add(eventData.invite);
                }
            }

            AllJoinedGuilds = AllJoinedGuilds.OrderByDescending(o => o.timestamp.Ticks).ToList();

            tabControl1.TabPages[3].Text = $"Servers - {AllJoinedGuilds.Count}";

            serversLv.Items.Clear();
            foreach (var guild in AllJoinedGuilds)
            {
                string guildName = "";
                if(CurrentGuilds[guild.id] != null)
                {
                    guildName = CurrentGuilds[guild.id];
                }

                string[] values = { guild.timestamp.ToShortDateString(), guild.id, guildName, guild.join_type, guild.location, String.Join(", ", guild.invites.ToArray()) };
                var lvItem = new ListViewItem(values);
                serversLv.Items.Add(lvItem);
            }
        }

        private int MassDeleteIdx = 0;
        private void massDeleteBtn_Click(object sender, EventArgs e)
        {
            if(massDeleteTimer.Enabled == true)
            {
                massDeleteTimer.Stop();
                massDeleteBtn.Text = "Mass Delete";
                searchTb.Enabled = true;
                searchBtn.Enabled = true;
                return;
            }

            if(LastSearchResults == null || LastSearchResults.Count == 0)
            {
                MessageBox.Show("You need to search for something first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var prompt = new MassDeletePrompt();
            prompt.ShowDialog();
            if(prompt.DialogSuccess)
            {
                MassDeleteIdx = 0;
                massDeleteTimer.Interval = prompt.GetDelay();
                AccountToken = prompt.GetToken();

                searchTb.Enabled = false;
                searchBtn.Enabled = false;
                massDeleteBtn.Text = "Click to stop";

                DHeaders.Init();
                massDeleteTimer.Start();
            }
        }

        private void massDeleteTimer_Tick(object sender, EventArgs e)
        {
            massDeleteTimer.Stop(); // Stop and restart the timer every time to prevent overlaps

            DMessage msg;
            while(true)
            {
                if (MassDeleteIdx >= LastSearchResults.Count)
                {
                    massDeleteBtn.Text = "Mass Delete";
                    searchTb.Enabled = true;
                    searchBtn.Enabled = true;

                    MessageBox.Show("Mass Delete Finished!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                msg = LastSearchResults[MassDeleteIdx++];
                if (!msg.deleted) break;
            }

            try
            {
                var res = DRequest.Request("DELETE", $"https://discord.com/api/v9/channels/{msg.channel.id}/messages/{msg.id}", new Dictionary<string, string>
                {
                    {"Authorization", AccountToken}
                });
                
                switch(res.response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.NoContent:
                        msg.deleted = true;
                        ((MessageListWPF)elementHost1.Child).RemoveMessage(msg.id);

                        Properties.Settings.Default.DeletedMessageIDs.Add(msg.id);
                        Properties.Settings.Default.Save();
                        break;
                    case (HttpStatusCode)429:
                        MassDeleteIdx--;
                        Thread.Sleep((int)Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(res.body).retry_after * 1000);
                        break;
                    case HttpStatusCode.Forbidden:
                        break;
                    default:
                        MessageBox.Show($"Request error: {res.response.StatusCode} {res.body}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Request error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            massDeleteTimer.Start();
        }

        private void copyIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string guildId = serversLv.SelectedItems[0].SubItems[1].Text;
            Clipboard.SetText(guildId);
        }

        private void copyInvitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string invites = serversLv.SelectedItems[0].SubItems[5].Text;
            Clipboard.SetText(invites);
        }

        private void searchOptionsBtn_Click(object sender, EventArgs e)
        {
            var prompt = new SearchOptionsPrompt();
            prompt.ShowDialog();
        }

        private void copyUserIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = dmsLv.SelectedItems[0].SubItems[2].Text;
            Clipboard.SetText(userId);
        }

        private void copyChannelIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string channelId = dmsLv.SelectedItems[0].SubItems[1].Text;
            Clipboard.SetText(channelId);
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = dmsLv.SelectedItems[0].SubItems[2].Text;
            string channelId = dmsLv.SelectedItems[0].SubItems[1].Text;
            if (ChannelsMap[channelId].has_duplicates)
            {
                MessageBox.Show("You have multiple dm channels with this recipient. There is no guarantee that Discord will open the right one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                Util.LaunchDiscordProtocol($"users/{userId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openDmSELFBOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = dmsLv.SelectedItems[0].SubItems[2].Text;
            string channelId = dmsLv.SelectedItems[0].SubItems[1].Text;
            if (ChannelsMap[channelId].has_duplicates)
            {
                MessageBox.Show("You have multiple dm channels with this recipient. There is no guarantee that Discord will open the right one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DHeaders.Init();

            string token = Interaction.InputBox("Enter your token", "Prompt", AccountToken);
            if (token == "") return;
            if (!Util.ValidateToken(token, User.id))
            {
                MessageBox.Show("Entered token is invalid or doesn't belong to the same account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AccountToken = token;

            var body = new Dictionary<string, string[]>
            {
                { "recipients", new string[] { userId } }
            };

            var response = DRequest.Request("POST", "https://discord.com/api/v9/users/@me/channels", new Dictionary<string, string>
            {
                {"Authorization", token},
                {"Content-Type", "application/json"},
                {"X-Context-Properties", Convert.ToBase64String(Encoding.UTF8.GetBytes("{}"))}
            }, Newtonsoft.Json.JsonConvert.SerializeObject(body), true);

            if (response.response.StatusCode == HttpStatusCode.OK)
            {
                Util.LaunchDiscordProtocol($"channels/@me/{channelId}");
            }
            else
            {
                MessageBox.Show($"Request error: {response.response.StatusCode} {response.body}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int dmsLvSortColumn = -1;
        private void dmsLv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(e.Column != dmsLvSortColumn)
            {
                dmsLvSortColumn = e.Column;
                dmsLv.Sorting = SortOrder.Ascending;
            } else
            {
                if (dmsLv.Sorting == SortOrder.Ascending)
                    dmsLv.Sorting = SortOrder.Descending;
                else
                    dmsLv.Sorting = SortOrder.Ascending;
            }

            dmsLv.ListViewItemSorter = new DmsLvItemComparer(e.Column, dmsLv.Sorting);
        }
    }
}
