using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Helpers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public DmWPF()
        {
            InitializeComponent();
        }

        private void fetchBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Discord.BotToken == null)
            {
                Util.MsgBoxErr(Consts.MissingBotTokenError);
                return;
            }
            if(!Discord.ValidateToken(Discord.BotToken))
            {
                Util.MsgBoxErr(Consts.InvalidBotTokenError);
                return;
            }
            if(Discord.ValidateToken(Discord.BotToken, Main.DataPackage.User.id))
            {
                Util.MsgBoxErr(Consts.WrongTokenType);
                return;
            }

            var res = DRequest.Request("GET", $"https://discord.com/api/v9/users/{this.UserId}", new Dictionary<string, string>
            {
                {"Authorization", $"Bot {Discord.BotToken}"}
            }, null, false);

            if(res.response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DmsListEntry DataContext = this.DataContext as DmsListEntry;
                DUser recipient = Newtonsoft.Json.JsonConvert.DeserializeObject<DUser>(res.body);

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
            } else
            {
                Util.MsgBoxErr($"Status code {res.response.StatusCode} - {res.body}");
            }
        }

        private void openDmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Main.DataPackage.ChannelsMap[this.ChannelId].has_duplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            if (Discord.OpenDMFlow(this.UserId))
            {
                Discord.LaunchDiscordProtocol($"channels/@me/{this.ChannelId}");
            }
        }

        private void copyUserIdMi_Click(object sender, RoutedEventArgs e)
        {
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
