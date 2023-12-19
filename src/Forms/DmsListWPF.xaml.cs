using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Data_Package_Tool.Forms
{
    /// <summary>
    /// Interaction logic for DmsListWPF.xaml
    /// </summary>
    public partial class DmsListWPF : UserControl
    {
        public class DmsListEntry : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private string UserIdValue;
            public string UserId
            {
                get
                {
                    return this.UserIdValue;
                }
                set
                {
                    this.UserIdValue = value;
                    NotifyPropertyChanged();
                }
            }
            public string ChannelId { get; set; }
            private string UsernameValue;
            public string Username
            {
                get
                {
                    return this.UsernameValue;
                }
                set
                {
                    this.UsernameValue = value;
                    NotifyPropertyChanged();
                }
            }
            private BitmapImage AvatarValue;
            public BitmapImage Avatar
            {
                get
                {
                    return this.AvatarValue;
                }
                set
                {
                    this.AvatarValue = value;
                    NotifyPropertyChanged();
                }
            }
            public string Date { get; set; }
            public int MessagesCount { get; set; }
            private string NoteValue;
            public string Note
            {
                get
                {
                    return this.NoteValue;
                }
                set
                {
                    this.NoteValue = value;
                    NotifyPropertyChanged();
                }
            }
            private bool NeedsFetchingValue;
            public bool NeedsFetching
            {
                get
                {
                    return this.NeedsFetchingValue;
                }
                set
                {
                    this.NeedsFetchingValue = value;
                    NotifyPropertyChanged();
                }
            }
            private bool UnknownIdValue;
            public bool UnknownId
            {
                get
                {
                    return this.UnknownIdValue;
                }
                set
                {
                    this.UnknownIdValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<DmsListEntry> DirectMessages { get; set; } = new ObservableCollection<DmsListEntry>();
        public DmsListWPF()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void DisplayMessages(DUser user, List<DChannel> channels)
        {
            foreach (var channel in channels)
            {
                var recipientId = channel.GetOtherDMRecipient(user);
                var relationship = user.relationships.ToList().Find(x => x.id == recipientId);

                BitmapImage avatar;
                if(relationship != null && relationship.user.avatar != null)
                {
                    avatar = new BitmapImage();
                    avatar.BeginInit();
                    avatar.UriSource = new Uri(relationship.user.GetAvatarURL());
                    avatar.CacheOption = BitmapCacheOption.OnLoad;
                    avatar.EndInit();
                } else
                {;
                    avatar = new DUser() { id = recipientId, discriminator = "0" }.GetDefaultAvatarBitmapImage();
                }

                bool isDeletedUser = recipientId == Consts.DeletedUserId;

                // Get saved id, if exists
                if (isDeletedUser)
                {
                    int idx = Properties.Settings.Default.ResolvedDeletedUsers.IndexOf(channel.id);
                    if(idx != -1)
                    {
                        recipientId = Properties.Settings.Default.ResolvedDeletedUsers[idx + 1];
                        isDeletedUser = false;
                    }
                }

                DirectMessages.Add(new DmsListEntry
                { 
                    UserId = isDeletedUser ? "???" : recipientId,
                    ChannelId = channel.id,
                    Username = isDeletedUser ? "(Deleted User)" : relationship != null ? relationship.user.GetTag() : "(Unknown User)",
                    Avatar = avatar,
                    Date = Discord.SnowflakeToTimestap(channel.id).ToShortDateString(),
                    MessagesCount = channel.messages.Count,
                    Note = user.notes.ContainsKey(recipientId) ? user.notes[recipientId] : "",
                    NeedsFetching = relationship == null,
                    UnknownId = isDeletedUser
                });
            }
        }

        private int currentColumn = 1;
        private void nameLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentColumn != 0)
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.OrderBy(x => x.Username));
            }
            else
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.Reverse());
            }

            currentColumn = 0;
            mainList.ItemsSource = DirectMessages;
        }
        private void firstDmDateLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(currentColumn != 1)
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.OrderByDescending(x => Int64.Parse(x.ChannelId)));
            } else
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.Reverse());
            }

            currentColumn = 1;
            mainList.ItemsSource = DirectMessages;
        }

        private void yourMessagesLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentColumn != 2)
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.OrderByDescending(x => x.MessagesCount));
            }
            else
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.Reverse());
            }

            currentColumn = 2;
            mainList.ItemsSource = DirectMessages;
        }

        private void noteLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentColumn != 3)
            {
                // Grab the ones which contain notes -> sort them -> append the ones which don't contain notes
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages
                    .Where(x => x.Note != "")
                    .OrderBy(x => x.Note)
                    .Concat(DirectMessages
                        .Where(x => x.Note == "")
                        .OrderByDescending(x => Int64.Parse(x.ChannelId)) // Reset the order of the rest to default
                    )
                );
            }
            else
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages
                    .Where(x => x.Note != "")
                    .Reverse()
                    .Concat(DirectMessages.Where(x => x.Note == ""))
                );
            }

            currentColumn = 3;
            mainList.ItemsSource = DirectMessages;
        }
    }
}
