using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Forms;
using Data_Package_Tool.Helpers;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace Data_Package_Tool
{
    public partial class Main : Form
    {
        public static DataPackage DataPackage = new DataPackage();

        private static readonly int MaxSearchResults = 500;

        public Main()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Initialize ElementHost.Child, since .NET Core's WinForms Designer:tm: doesn't support it
            elementHost1.Child = new MessageListWPF();
            elementHost2.Child = new DmsListWPF();

            for (int i = 0; i <= 5; i++)
            {
                var stream = new MemoryStream();
                ((Bitmap)Properties.Resources.ResourceManager.GetObject($"DefaultAvatar{i}")).Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                var img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = stream;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();

                Discord.DefaultAvatars.Add(img);
            }

            {
                var stream = new MemoryStream();
                Properties.Resources.LoadingAnim.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);

                var img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = stream;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();

                Discord.LoadingAnim = img;
            }

            // Persist settings across program versions
            if (!ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).HasFile)
            {
                Properties.Settings.Default.Upgrade();
            }

            if (Properties.Settings.Default.DeletedMessageIDs == null)
            {
                Properties.Settings.Default.DeletedMessageIDs = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.ResolvedDeletedUsers == null)
            {
                Properties.Settings.Default.ResolvedDeletedUsers = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }

            switch (Properties.Settings.Default.UseDiscordInstance)
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

            this.Text += " v" + Application.ProductVersion;
        }

        private void LoadDMChannels()
        {
            var dmChannels = DataPackage.Channels.Where(x => x.IsDM()).OrderByDescending(o => Int64.Parse(o.Id)).ToList();
            var duplicateChannelsMap = new Dictionary<string, DChannel>();

            tabControl1.TabPages[4].Text = $"Direct Messages - {dmChannels.Count}";

            foreach (var dmChannel in dmChannels)
            {
                string recipientId = dmChannel.DMRecipientId;
                if (recipientId == Consts.DeletedUserId) continue; // Don't mark the fake deleted user id as duplicate

                if (duplicateChannelsMap.ContainsKey(recipientId)) // Optimization. Calling Find() every time would be slow
                {
                    duplicateChannelsMap[recipientId].HasDuplicates = true;
                    dmChannel.HasDuplicates = true;
                }
                duplicateChannelsMap[recipientId] = dmChannel;
            }

            ((DmsListWPF)elementHost2.Child).DisplayMessages(DataPackage.User, dmChannels);
        }

        private void LoadJoinedGuilds()
        {
            var isMissingData = DataPackage.ActivityDataStatus.MissingData == true;
            tabControl1.TabPages[3].Text = $"Servers - {DataPackage.JoinedGuilds.Count}{(isMissingData ? "+" : "")}";

            serversLv.Items.Clear();
            foreach (var guild in DataPackage.JoinedGuilds)
            {
                string guildName = "";
                if (DataPackage.GuildNamesMap.ContainsKey(guild.Id))
                {
                    guildName = DataPackage.GuildNamesMap[guild.Id];
                }

                string[] values = { guild.Timestamp.ToShortDateString(), guild.Id, guildName, guild.JoinType, guild.Location, String.Join(", ", guild.Invites) };
                var lvItem = new ListViewItem(values);
                serversLv.Items.Add(lvItem);
            }

            if (isMissingData && tabControl1.SelectedIndex == 3)
            {
                ShowMissingAnalyticsDataWarning();
            }
        }

        public void JumpToGuild(string guildId)
        {
            for (int i = 0; i < serversLv.Items.Count; i++)
            {
                var item = serversLv.Items[i];
                if (item.SubItems[1].Text == guildId)
                {
                    tabControl1.SelectTab(3);

                    serversLv.SelectedIndices.Clear();
                    item.Selected = true;
                    serversLv.EnsureVisible(i);
                    return;
                }
            }

            Util.MsgBoxErr("Server could not be found in your joined servers list (bug?)");
        }

        private void ToggleSearchOptions(bool enabled)
        {
            searchBtn.Enabled = enabled;
            searchTb.Enabled = enabled;
            searchOptionsBtn.Enabled = enabled;
            messagesPrevBtn.Enabled = enabled;
            messagesNextBtn.Enabled = enabled;
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
                    }
                    catch (Exception ex)
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
                    foreach (var messageId in Properties.Settings.Default.DeletedMessageIDs)
                    {
                        if (DataPackage.MessagesMap.ContainsKey(messageId)) DataPackage.MessagesMap[messageId].IsDeleted = true;
                    }

                    LoadDMChannels();

                    loadingLb.Text = DataPackage.LoadStatus.Status;
                    progressBar1.Value = progressBar1.Maximum;

                    searchBtn.Enabled = true;
                    messagesPrevBtn.Enabled = true;
                    messagesNextBtn.Enabled = true;

                    if (DataPackage.UsesUnsignedCDNLinks)
                    {
                        Util.MsgBoxWarn("This data package was created before Discord's attachment url signing!\n\nIf you want to be able to view images and other attachments, please enter a bot token in the settings tab.");
                    }
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
            if (DataPackage.LoadStatus.Finished && DataPackage.GuildsLoadStatus.Finished)
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
        private async Task LoadSearchResults()
        {
            if (LastSearchResults == null || LastSearchResults.Count == 0) return;

            ToggleSearchOptions(false);

            // Clear images cache to free up RAM
            Discord.AttachmentsCache.Clear();
            GC.Collect();

            ((MessageListWPF)elementHost1.Child).Clear();
            var msgsToShow = LastSearchResults.Skip(SearchResultsOffset).Take(MaxSearchResults).ToList();

            // Refresh attachments on the current page, if possible
            if (DataPackage.UsesUnsignedCDNLinks)
            {
                var needRefreshing = new List<DAttachment>();
                foreach (var msg in msgsToShow)
                {
                    foreach (var attachment in msg.Attachments)
                    {
                        if (!attachment.IsSigned)
                        {
                            needRefreshing.Add(attachment);
                        }
                    }
                }

                if (needRefreshing.Count > 0)
                {
                    resultsCountLb.Text = $"Refreshing {needRefreshing.Count} attachments...";
                    await Discord.RefreshAttachmentsAsync(needRefreshing);
                }
            }

            ((MessageListWPF)elementHost1.Child).DisplayMessages(msgsToShow);
            resultsCountLb.Text = $"{SearchResultsOffset + 1}-{Math.Min(SearchResultsOffset + MaxSearchResults, LastSearchResults.Count)} of {LastSearchResults.Count}";

            ToggleSearchOptions(true);
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SearchMode == "regex")
            {
                try
                {
                    new Regex(searchTb.Text);
                }
                catch (Exception ex)
                {
                    Util.MsgBoxErr($"Invalid regex: {ex.Message}");
                    return;
                }
            }

            ToggleSearchOptions(false);
            ((MessageListWPF)elementHost1.Child).Clear();

            LastSearchResults = new List<DMessage>();
            SearchResultsOffset = 0;

            // Clear images cache to free up RAM
            Discord.AttachmentsCache.Clear();
            GC.Collect();

            searchBw.RunWorkerAsync();
            searchTimer.Start();
        }

        private void searchBw_DoWork(object sender, DoWorkEventArgs e)
        {
            var searchText = searchTb.Text;
            int count = 0;

            // Optimization - precompile regex and reuse it
            Regex compiledRegex = null;
            var regexOptions = Properties.Settings.Default.SearchCaseSensitive ? RegexOptions.Compiled : RegexOptions.Compiled | RegexOptions.IgnoreCase;
            if (Properties.Settings.Default.SearchMode == "words")
            {
                compiledRegex = new Regex($"^{String.Join("", searchText.Split(' ').Select(x => $"(?=.*?\\b{Regex.Escape(x)}\\b)").ToArray())}", regexOptions); // https://stackoverflow.com/a/70484431
            }
            else if (Properties.Settings.Default.SearchMode == "regex")
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
                    if (Properties.Settings.Default.SearchExcludeIDs.Contains(channel.Id)) continue;
                    if (channel.Guild != null && channel.Guild.Id != null && Properties.Settings.Default.SearchExcludeIDs.Contains(channel.Guild.Id)) continue;
                }
                if (Properties.Settings.Default.SearchWhitelistIDs != null && Properties.Settings.Default.SearchWhitelistIDs.Count > 0)
                {
                    if (!Properties.Settings.Default.SearchWhitelistIDs.Contains(channel.Id) && !(channel.Guild != null && channel.Guild.Id != null && Properties.Settings.Default.SearchWhitelistIDs.Contains(channel.Guild.Id))) continue;
                }

                // Search modes
                // Optimization - single condition which picks the function, rather than running the condition on every iteration
                if (searchText == "")
                {
                    count += SearchNoText(channel);
                }
                else if (Properties.Settings.Default.SearchMode == "exact")
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

            if (Properties.Settings.Default.SortMode == "asc")
            {
                LastSearchResults = LastSearchResults.OrderBy(o => Int64.Parse(o.Id)).ToList();
            }
            else
            {
                LastSearchResults = LastSearchResults.OrderByDescending(o => Int64.Parse(o.Id)).ToList();
            }
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

        private async void searchBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            searchTimer.Stop();

            if (LastSearchResults.Count > 0)
            {
                await LoadSearchResults();

                if (LastSearchResults.Count >= MaxSearchResults)
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{SearchResultsOffset + MaxSearchResults} of {LastSearchResults.Count}";
                }
                else
                {
                    resultsCountLb.Text = $"{SearchResultsOffset + 1}-{LastSearchResults.Count} of {LastSearchResults.Count}";
                }
            }
            else
            {
                resultsCountLb.Text = "No results";
                ToggleSearchOptions(true);
            }
        }

        private List<DMessage> FilterMessages(List<DMessage> messages)
        {
            IEnumerable<DMessage> m = messages;
            if (Properties.Settings.Default.SearchHasImage || Properties.Settings.Default.SearchHasVideo || Properties.Settings.Default.SearchHasFile)
            {
                m = m.Where(x =>
                {
                    if (x.Attachments.Count == 0) return false;

                    if (Properties.Settings.Default.SearchHasImage && x.Attachments.Find(y => y.IsImage) != null) return true;
                    if (Properties.Settings.Default.SearchHasVideo && x.Attachments.Find(y => y.IsVideo) != null) return true;
                    if (Properties.Settings.Default.SearchHasFile && x.Attachments.Find(y => !y.IsImage && !y.IsVideo) != null) return true;

                    return false;
                });

            }

            if (Properties.Settings.Default.SearchBeforeEnabled)
            {
                m = m.Where(x => x.Timestamp < Properties.Settings.Default.SearchBeforeDate);
            }

            if (Properties.Settings.Default.SearchAfterEnabled)
            {
                m = m.Where(x => x.Timestamp > Properties.Settings.Default.SearchAfterDate);
            }

            return m is List<DMessage> l ? l : m.ToList();
        }

        private int SearchNoText(DChannel channel)
        {
            int count = 0;

            foreach (var msg in FilterMessages(channel.Messages))
            {
                LastSearchResults.Add(msg);
                count++;
            }

            return count;
        }

        private int SearchExact(string searchText, StringComparison stringComp, DChannel channel)
        {
            int count = 0;

            foreach (var msg in FilterMessages(channel.Messages))
            {

                if (msg.Content.IndexOf(searchText, stringComp) >= 0)
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

            foreach (var msg in FilterMessages(channel.Messages))
            {

                if (compiledRegex.IsMatch(msg.Content))
                {
                    LastSearchResults.Add(msg);
                    count++;
                }
            }

            return count;
        }

        private async void messagesPrevBtn_Click(object sender, EventArgs e)
        {
            if (SearchResultsOffset - MaxSearchResults < 0) return;

            SearchResultsOffset -= MaxSearchResults;
            await LoadSearchResults();
        }

        private async void messagesNextBtn_Click(object sender, EventArgs e)
        {
            if (LastSearchResults.Count <= MaxSearchResults) return;
            if (SearchResultsOffset + MaxSearchResults > LastSearchResults.Count) return;

            SearchResultsOffset += MaxSearchResults;
            await LoadSearchResults();
        }

        private int imagesOffset = 0;
        private int imagesPerPage = 36;
        private int imagesPerRow = 9;
        private int imageSquareSize = 200;
        private async Task LoadImages()
        {
            if (DataPackage.ImageAttachments.Count == 0)
            {
                imagesCountLb.Text = $"No images found";
                return;
            }

            imagesNextBtn.Enabled = false;
            imagesPrevBtn.Enabled = false;

            if (imagesOffset < 0) imagesOffset = 0;
            if (imagesOffset >= DataPackage.ImageAttachments.Count || imagesOffset + imagesPerPage >= DataPackage.ImageAttachments.Count) imagesOffset = DataPackage.ImageAttachments.Count - imagesPerPage;

            // Refresh images on the current page
            if (DataPackage.UsesUnsignedCDNLinks)
            {
                var needRefreshing = new List<DAttachment>();
                for (int i = 0; i < imagesPerPage; i++)
                {
                    var attachment = DataPackage.ImageAttachments[imagesOffset + i];
                    if (!attachment.IsSigned)
                    {
                        needRefreshing.Add(attachment);
                    }
                }

                if (needRefreshing.Count > 0)
                {
                    imagesCountLb.Text = $"Refreshing {needRefreshing.Count} attachments...";
                    await Discord.RefreshAttachmentsAsync(needRefreshing);
                }
            }

            imagesPanel.Controls.Clear();
            imagesCountLb.Text = $"{imagesOffset + 1}-{imagesOffset + imagesPerPage} of {DataPackage.ImageAttachments.Count}";

            for (int i = 0; i < imagesPerPage; i++)
            {
                var loc = new Point(3, 3);
                if (imagesPanel.Controls.Count > 0)
                {
                    var last = (Attachment)imagesPanel.Controls[imagesPanel.Controls.Count - 1];
                    loc = new Point(imagesPanel.Controls.Count % imagesPerRow == 0 ? 3 : last.Location.X + last.Size.Width + 6, imagesPanel.Controls.Count % imagesPerRow == 0 ? last.Location.Y + imageSquareSize + 44 : last.Location.Y);
                }

                var attachment = DataPackage.ImageAttachments[imagesOffset + i];

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
        private async void imagesNextBtn_Click(object sender, EventArgs e)
        {
            if (imagesPanel.Controls.Count > 0)
            {
                imagesOffset += imagesPerPage;
            }
            await LoadImages();
        }

        private async void imagesPrevBtn_Click(object sender, EventArgs e)
        {
            if (imagesPanel.Controls.Count > 0)
            {
                imagesOffset -= imagesPerPage;
            }
            await LoadImages();
        }

        private async void imagesCountLb_DoubleClick(object sender, EventArgs e)
        {
            var offset = Interaction.InputBox("Enter the offset number", "Prompt");
            try
            {
                imagesOffset = Int32.Parse(offset);
                await LoadImages();
            }
            catch (Exception) { }
        }

        private void discordInstanceSettingsChange(object sender, EventArgs e)
        {
            if (defaultRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "default";
            }
            else if (stableRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "stable";
            }
            else if (ptbRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "ptb";
            }
            else if (canaryRb.Checked)
            {
                Properties.Settings.Default.UseDiscordInstance = "canary";
            }
            else if (webStableRb.Checked)
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
        private async void massDeleteBtn_Click(object sender, EventArgs e)
        {
            if (massDeleteTimer.Enabled == true)
            {
                massDeleteTimer.Stop();
                massDeleteBtn.Text = "Mass Delete";
                searchTb.Enabled = true;
                searchBtn.Enabled = true;
                return;
            }

            if (LastSearchResults == null || LastSearchResults.Count == 0)
            {
                Util.MsgBoxErr("You need to search for something first!");
                return;
            }

            var prompt = new MassDeletePrompt();
            prompt.ShowDialog();
            if (prompt.DialogSuccess)
            {
                MassDeleteIdx = 0;
                massDeleteTimer.Interval = prompt.GetDelay();

                searchTb.Enabled = false;
                searchBtn.Enabled = false;
                massDeleteBtn.Text = "Click to stop";

                await DHeaders.Init();
                massDeleteTimer.Start();
            }
        }

        private async void massDeleteTimer_Tick(object sender, EventArgs e)
        {
            massDeleteTimer.Stop(); // Stop and restart the timer every time to prevent overlaps

            DMessage msg;
            while (true)
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
                if (!msg.IsDeleted) break;
            }

            try
            {
                var res = await DRequest.RequestAsync(HttpMethod.Delete, $"https://discord.com/api/v9/channels/{msg.Channel.Id}/messages/{msg.Id}", new Dictionary<string, string>
                {
                    {"Authorization", Discord.UserToken}
                });

                switch (res.response.StatusCode)
                {
                    case HttpStatusCode.NotFound: // Already deleted = mark as deleted
                    case HttpStatusCode.NoContent:
                        msg.IsDeleted = true;

                        Properties.Settings.Default.DeletedMessageIDs.Add(msg.Id);
                        Properties.Settings.Default.Save();
                        break;
                    case HttpStatusCode.InternalServerError: // Retry on random backend errors
                    case HttpStatusCode.BadGateway:
                    case HttpStatusCode.ServiceUnavailable:
                    case HttpStatusCode.GatewayTimeout:
                        MassDeleteIdx--;
                        break;
                    case (HttpStatusCode)429:
                        MassDeleteIdx--;

                        try
                        {
                            dynamic errorData = JObject.Parse(res.body);

                            int retryAfter = errorData.retry_after;
                            Thread.Sleep(retryAfter * 1000);
                        }
                        catch (Exception) // Non-json response (cf error?)
                        {
                            Util.MsgBoxErr($"Unknown ratelimit error.");
                            return;
                        }
                        break;
                    case HttpStatusCode.Forbidden:
                        break;
                    default:
                        try
                        {
                            dynamic errorData = JObject.Parse(res.body);

                            string errorMsg = errorData.message;
                            int errorCode = errorData.code;
                            switch (errorCode)
                            {
                                case 50001: // No access to channel
                                case 50083: // Thread archived
                                    break;
                                default:
                                    Util.MsgBoxErr($"Discord error ({errorCode}): {errorMsg}");
                                    return;
                            }

                        }
                        catch (Exception)
                        {
                            Util.MsgBoxErr($"Request error: {res.response.StatusCode} {res.body}");
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.MsgBoxErr($"Request error: {ex.Message}");
            }

            massDeleteTimer.Start();
        }

        private void copyIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serversLv.SelectedItems.Count == 0) return;

            string guildId = serversLv.SelectedItems[0].SubItems[1].Text;
            Clipboard.SetText(guildId);
        }

        private void copyInvitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serversLv.SelectedItems.Count == 0) return;

            string invites = serversLv.SelectedItems[0].SubItems[5].Text;
            Clipboard.SetText(invites);
        }

        private void searchOptionsBtn_Click(object sender, EventArgs e)
        {
            var prompt = new SearchOptionsPrompt();
            prompt.ShowDialog();
        }

        private void userTokenTb_TextChanged(object sender, EventArgs e)
        {
            string token = userTokenTb.Text.Trim();
            if (token != "")
            {
                Discord.UserToken = token;
            }
            else
            {
                Discord.UserToken = null;
            }
        }

        private void botTokenTb_TextChanged(object sender, EventArgs e)
        {
            string token = botTokenTb.Text.Trim();
            if (token != "")
            {
                Discord.BotToken = token;
            }
            else
            {
                Discord.BotToken = null;
            }
        }

        private void repoLb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/aamiaa/Data-Package-Tool",
                UseShellExecute = true
            });
        }

        private bool AnalyticsWarningShown = false;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DataPackage.ActivityDataStatus.MissingData == true && !AnalyticsWarningShown)
            {
                ShowMissingAnalyticsDataWarning();
            }
        }

        private void ShowMissingAnalyticsDataWarning()
        {
            this.AnalyticsWarningShown = true;
            switch (DataPackage.ActivityDataStatus.Status)
            {
                case AnalyticsStatus.DisabledNow:
                    Util.MsgBoxWarn("It seems like your Discord account has analytics disabled.\nSince disabling analytics deletes past events in your package, the Servers tab will be limited to around past 6 months!");
                    break;
                case AnalyticsStatus.DisabledBefore:
                    Util.MsgBoxWarn($"It seems like you've disabled analytics on your Discord account in the past.\nSince disabling analytics deletes past events in your package, the Servers tab will be limited to the date when you've re-enabled analytics, that is {((DateTime)DataPackage.ActivityDataStatus.CutoffDate).ToShortDateString()}.");
                    break;
                case AnalyticsStatus.PartiallyDisabledNow:
                    Util.MsgBoxWarn($"It seems like you have some analytics disabled on your Discord account.\nSince disabling analytics deletes past events in your package, the Servers tab might show info from a limited time span!");
                    break;
            }
        }
    }
}
