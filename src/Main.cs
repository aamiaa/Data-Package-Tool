using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Forms;
using Data_Package_Tool.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Package_Tool
{
    public partial class Main : Form
    {
        public static DataPackage DataPackage = new DataPackage();

        public static string AccountToken = "";
        private static readonly int MaxSearchResults = 500;

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

        private void LoadDMChannels()
        {
            dmsLv.Items.Clear();

            var dmChannels = DataPackage.Channels.Where(x => x.IsDM()).OrderByDescending(o => Int64.Parse(o.id)).ToList();
            var duplicateChannelsMap = new Dictionary<string, dynamic>();

            tabControl1.TabPages[4].Text = $"Direct Messages - {dmChannels.Count}";

            foreach (var dmChannel in dmChannels)
            {
                string recipientId = dmChannel.GetOtherDMRecipient(DataPackage.User);
                string recipientUsername = "";
                var relationship = DataPackage.User.relationships.ToList().Find(x => x.id == recipientId);
                if (relationship != null) recipientUsername = relationship.user.GetTag();

                string[] values = { Discord.SnowflakeToTimestap(dmChannel.id).ToShortDateString(), dmChannel.id, recipientId, recipientUsername, dmChannel.messages.Count.ToString(), DataPackage.User.notes.ContainsKey(recipientId) ? DataPackage.User.notes[recipientId] : "" };
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
        }

        private void LoadJoinedGuilds()
        {
            tabControl1.TabPages[3].Text = $"Servers - {DataPackage.JoinedGuilds.Count}";

            serversLv.Items.Clear();
            foreach (var guild in DataPackage.JoinedGuilds)
            {
                string guildName = "";
                if (DataPackage.Guilds[guild.id] != null)
                {
                    guildName = DataPackage.Guilds[guild.id];
                }

                string[] values = { guild.timestamp.ToShortDateString(), guild.id, guildName, guild.join_type, guild.location, String.Join(", ", guild.invites.ToArray()) };
                var lvItem = new ListViewItem(values);
                serversLv.Items.Add(lvItem);
            }
        }

        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadFileBtn.Hide();
                progressBar1.Show();

                Task task = new Task(() =>
                {
                    try
                    {
                        DataPackage.Load(openFileDialog1.FileName);
                    } catch (Exception ex)
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            loadFileBtn.Show();
                            progressBar1.Hide();

                            Util.MsgBoxErr($"An error occurred:\n\n{ex.ToString()}");
                        });
                    }
                });
                task.ContinueWith(t =>
                {
                    foreach(var messageId in Properties.Settings.Default.DeletedMessageIDs)
                    {
                        if (DataPackage.MessagesMap.ContainsKey(messageId)) DataPackage.MessagesMap[messageId].deleted = true;
                    }

                    LoadDMChannels();

                    loadingLb.Text = DataPackage.LoadStatus.Status;
                    progressBar1.Value = progressBar1.Maximum;
                }, TaskScheduler.FromCurrentSynchronizationContext());

                var guildsTask = new Task(() =>
                {
                    DataPackage.LoadGuilds(openFileDialog1.FileName);
                });
                guildsTask.ContinueWith(t =>
                {
                    LoadJoinedGuilds();

                    serversStatusStrip.Visible = false;
                }, TaskScheduler.FromCurrentSynchronizationContext());

                serversStatusStrip.Visible = true;
                task.Start();
                guildsTask.Start();

                loadTimer.Start();
            }
        }
        private void loadTimer_Tick(object sender, EventArgs e)
        {
            if(DataPackage.LoadStatus.Finished && DataPackage.GuildsLoadStatus.Finished)
            {
                loadTimer.Stop();
            }

            loadingLb.Text = DataPackage.LoadStatus.Status;
            progressBar1.Maximum = DataPackage.LoadStatus.Max;
            progressBar1.Value = DataPackage.LoadStatus.Progress;
            serversPb.Value = DataPackage.GuildsLoadStatus.Progress;
        }

        private List<DMessage> LastSearchResults;
        private int SearchResultsOffset = 0;
        private void LoadSearchResults()
        {
            if (LastSearchResults == null || LastSearchResults.Count == 0) return;

            ((MessageListWPF)elementHost1.Child).Clear();
            resultsCountLb.Text = $"{SearchResultsOffset + 1}-{Math.Min(SearchResultsOffset + MaxSearchResults, LastSearchResults.Count)} of {LastSearchResults.Count}";
            ((MessageListWPF)elementHost1.Child).DisplayMessages(DataPackage.User, LastSearchResults, SearchResultsOffset, Math.Min(LastSearchResults.Count-1, SearchResultsOffset + MaxSearchResults));
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
                    Util.MsgBoxErr($"Invalid regex: {ex.Message}");
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
            var regexOptions = Properties.Settings.Default.SearchCaseSensitive ? RegexOptions.Compiled : RegexOptions.Compiled | RegexOptions.IgnoreCase;
            if (Properties.Settings.Default.SearchMode == "words")
            {
                compiledRegex = new Regex($"^{String.Join("", searchText.Split(' ').Select(x => $"(?=.*?\\b{Regex.Escape(x)}\\b)").ToArray())}", regexOptions); // https://stackoverflow.com/a/70484431
            } else if(Properties.Settings.Default.SearchMode == "regex")
            {
                compiledRegex = new Regex(searchText, regexOptions);
            }

            // Optimization - do this once instead of a possible if statement every time
            StringComparison stringComp = Properties.Settings.Default.SearchCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            foreach (var channel in DataPackage.Channels)
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
                    count += SearchExact(searchText, stringComp, channel);
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
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            if (LastSearchResults.Count > 0)
            {
                if (LastSearchResults.Count >= MaxSearchResults)
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{SearchResultsOffset + MaxSearchResults} of {LastSearchResults.Count}";
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

                if (LastSearchResults.Count >= MaxSearchResults)
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{SearchResultsOffset + MaxSearchResults} of {LastSearchResults.Count}";
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

        private int SearchExact(string searchText, StringComparison stringComp, DChannel channel)
        {
            int count = 0;

            foreach (var msg in FilterMessages(channel.messages))
            {

                if (msg.content.IndexOf(searchText, stringComp) >= 0)
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
            if (SearchResultsOffset - MaxSearchResults < 0) return;

            SearchResultsOffset -= MaxSearchResults;
            LoadSearchResults();
        }

        private void messagesNextBtn_Click(object sender, EventArgs e)
        {
            if (LastSearchResults.Count <= MaxSearchResults) return;
            if(SearchResultsOffset + MaxSearchResults > LastSearchResults.Count) return;

            SearchResultsOffset += MaxSearchResults;
            LoadSearchResults();
        }

        private int imagesOffset = 0;
        private int imagesPerPage = 36;
        private int imagesPerRow = 9;
        private int imageSquareSize = 200;
        private void LoadImages()
        {
            if(DataPackage.Attachments.Count == 0)
            {
                imagesCountLb.Text = $"No images found";
                return;
            }

            imagesNextBtn.Enabled = false;
            imagesPrevBtn.Enabled = false;

            if (imagesOffset < 0) imagesOffset = 0;
            if (imagesOffset >= DataPackage.Attachments.Count || imagesOffset + imagesPerPage >= DataPackage.Attachments.Count) imagesOffset = DataPackage.Attachments.Count - imagesPerPage;

            imagesPanel.Controls.Clear();
            imagesCountLb.Text = $"{imagesOffset + 1}-{imagesOffset + imagesPerPage} of {DataPackage.Attachments.Count}";

            for (int i = 0; i < imagesPerPage; i++)
            {
                var loc = new Point(3, 3);
                if (imagesPanel.Controls.Count > 0)
                {
                    var last = (Attachment)imagesPanel.Controls[imagesPanel.Controls.Count - 1];
                    loc = new Point(imagesPanel.Controls.Count % imagesPerRow == 0 ? 3 : last.Location.X + last.Size.Width + 6, imagesPanel.Controls.Count % imagesPerRow == 0 ? last.Location.Y + imageSquareSize + 44 : last.Location.Y);
                }

                var attachment = DataPackage.Attachments[imagesOffset + i];

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
                Util.MsgBoxErr("You need to search for something first!");
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

                    Util.MsgBoxInfo("Mass Delete Finished!");
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
                        //((MessageListWPF)elementHost1.Child).RemoveMessage(msg.id);

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
                        Util.MsgBoxErr($"Request error: {res.response.StatusCode} {res.body}");
                        return;
                }
            } catch(Exception ex)
            {
                Util.MsgBoxErr($"Request error: {ex}");
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
            if (DataPackage.ChannelsMap[channelId].has_duplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            try
            {
                Discord.LaunchDiscordProtocol($"users/{userId}");
            }
            catch (Exception ex)
            {
                Util.MsgBoxErr(ex.Message);
            }
        }

        private void openDmSELFBOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = dmsLv.SelectedItems[0].SubItems[2].Text;
            string channelId = dmsLv.SelectedItems[0].SubItems[1].Text;
            if (DataPackage.ChannelsMap[channelId].has_duplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            if(Discord.OpenDMFlow(userId))
            {
                Discord.LaunchDiscordProtocol($"channels/@me/{channelId}");
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
