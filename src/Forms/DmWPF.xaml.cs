using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Helpers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Data_Package_Tool.Forms.DmsListWPF;

namespace Data_Package_Tool.Forms
{
    /// <summary>
    /// Interaction logic for DmWPF.xaml
    /// </summary>
    public partial class DmWPF : UserControl
    {
        public string UserId
        {
            get { return (string)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        public static readonly DependencyProperty UserIdProperty =
            DependencyProperty.Register("UserId", typeof(string), typeof(DmWPF));

        public string ChannelId
        {
            get { return (string)GetValue(ChannelIdProperty); }
            set { SetValue(ChannelIdProperty, value); }
        }

        public static readonly DependencyProperty ChannelIdProperty =
            DependencyProperty.Register("ChannelId", typeof(string), typeof(DmWPF));

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(DmWPF));

        public BitmapImage Avatar
        {
            get { return (BitmapImage)GetValue(AvatarProperty); }
            set { SetValue(AvatarProperty, value); }
        }

        public static readonly DependencyProperty AvatarProperty =
            DependencyProperty.Register("Avatar", typeof(BitmapImage), typeof(DmWPF));

        // This is a string because WPF doesn't localize date format properly without a ton of gymnastics
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(string), typeof(DmWPF));

        public int MessagesCount
        {
            get { return (int)GetValue(MessagesCountProperty); }
            set { SetValue(MessagesCountProperty, value); }
        }

        public static readonly DependencyProperty MessagesCountProperty =
            DependencyProperty.Register("MessagesCount", typeof(int), typeof(DmWPF));

        public string Note
        {
            get { return (string)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(string), typeof(DmWPF));

        public bool NeedsFetching
        {
            get { return (bool)GetValue(NeedsFetchingProperty); }
            set { SetValue(NeedsFetchingProperty, value); }
        }

        public static readonly DependencyProperty NeedsFetchingProperty =
            DependencyProperty.Register("NeedsFetching", typeof(bool), typeof(DmWPF));

        public bool UnknownId
        {
            get { return (bool)GetValue(UnknownIdProperty); }
            set { SetValue(UnknownIdProperty, value); }
        }

        public static readonly DependencyProperty UnknownIdProperty =
            DependencyProperty.Register("UnknownId", typeof(bool), typeof(DmWPF));



        public DmWPF()
        {
            InitializeComponent();
        }

        private async Task<DUser> FetchUserFromChannel(string channelId)
        {
            if (Discord.UserToken == null)
            {
                Util.MsgBoxErr(Consts.MissingTokenError);
                return null;
            }
            if (!Discord.ValidateToken(Discord.UserToken, Main.DataPackage.User.id))
            {
                Util.MsgBoxErr(Consts.InvalidBotTokenError);
                return null;
            }

            await DHeaders.Init();

            var res = await DRequest.RequestAsync(HttpMethod.Get, $"https://discord.com/api/v9/channels/{channelId}", new Dictionary<string, string>
            {
                {"Authorization", Discord.UserToken}
            });

            if (res.response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DUser recipient = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(res.body).recipients[0].ToObject<DUser>();
                return recipient;
            }
            else
            {
                Util.MsgBoxErr($"Status code {res.response.StatusCode} - {res.body}");
                return null;
            }
        }

        private async Task<DUser> FetchUserFromLookup(string userId)
        {
            if (Discord.BotToken == null)
            {
                Util.MsgBoxErr(Consts.MissingBotTokenError);
                return null;
            }
            if (!Discord.ValidateToken(Discord.BotToken))
            {
                Util.MsgBoxErr(Consts.InvalidBotTokenError);
                return null;
            }
            if (Discord.ValidateToken(Discord.BotToken, Main.DataPackage.User.id))
            {
                Util.MsgBoxErr(Consts.WrongTokenType);
                return null;
            }

            var res = await DRequest.RequestAsync(HttpMethod.Get, $"https://discord.com/api/v9/users/{userId}", new Dictionary<string, string>
            {
                {"Authorization", $"Bot {Discord.BotToken}"}
            }, null, false);

            if (res.response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DUser recipient = Newtonsoft.Json.JsonConvert.DeserializeObject<DUser>(res.body);
                return recipient;
            } else
            {
                Util.MsgBoxErr($"Status code {res.response.StatusCode} - {res.body}");
                return null;
            }
        }

        private async void fetchBtn_Click(object sender, RoutedEventArgs e)
        {
            DmsListEntry DataContext = this.DataContext as DmsListEntry;
            DUser recipient;
               
            if(this.UnknownId)
            {
                recipient = await FetchUserFromChannel(this.ChannelId);
            } else
            {
                recipient = await FetchUserFromLookup(this.UserId);
            }

            if (recipient != null)
            {
                DataContext.UserId = recipient.id;
                DataContext.Username = recipient.GetTag();
                if (recipient.avatar != null)
                {
                    var avatar = new BitmapImage();
                    avatar.BeginInit();
                    avatar.UriSource = new Uri(recipient.GetAvatarURL());
                    avatar.CacheOption = BitmapCacheOption.OnLoad;
                    avatar.EndInit();

                    DataContext.Avatar = avatar;
                }
                DataContext.NeedsFetching = false;

                // Now that we know the id, do what we couldn't do before
                if(this.UnknownId)
                {
                    // Check if there's a note
                    DataContext.Note = Main.DataPackage.User.notes.ContainsKey(recipient.id) ? Main.DataPackage.User.notes[recipient.id] : "";

                    // Perform the duplicate channels check
                    var dmChannels = Main.DataPackage.Channels.Where(x => x.IsDM()).OrderByDescending(o => Int64.Parse(o.id)).ToList();
                    foreach (var dmChannel in dmChannels)
                    {
                        if (dmChannel.id == this.ChannelId) continue; // Don't count self as a duplicate

                        string recipientId = dmChannel.GetOtherDMRecipient(Main.DataPackage.User);
                        if(recipientId == this.UserId)
                        {
                            dmChannel.has_duplicates = true;
                            Main.DataPackage.ChannelsMap[this.ChannelId].has_duplicates = true;
                        }
                    }

                    DataContext.UnknownId = false;
                }
            }
        }

        private async void openDmBtn_Click(object sender, RoutedEventArgs e)
        {
            if(this.UnknownId)
            {
                Util.MsgBoxErr(Consts.UnknownDeletedUserId);
                return;
            }

            if (Main.DataPackage.ChannelsMap[this.ChannelId].has_duplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            if (await Discord.OpenDMFlowAsync(this.UserId, this.ChannelId))
            {
                Discord.LaunchDiscordProtocol($"channels/@me/{this.ChannelId}");
            }
        }

        private void copyUserIdMi_Click(object sender, RoutedEventArgs e)
        {
            if (this.UnknownId)
            {
                Util.MsgBoxErr(Consts.UnknownDeletedUserId);
                return;
            }

            Clipboard.SetText(this.UserId);
        }

        private void copyNoteMi_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.Note);
        }

        private void viewUserMi_Click(object sender, RoutedEventArgs e)
        {
            if (Main.DataPackage.ChannelsMap[this.ChannelId].has_duplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            try
            {
                Discord.LaunchDiscordProtocol($"users/{this.UserId}");
            }
            catch (Exception ex)
            {
                Util.MsgBoxErr(ex.Message);
            }
        }
    }
}
