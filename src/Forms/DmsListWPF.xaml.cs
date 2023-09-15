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
            public string UserId { get; set; }
            public string ChannelId { get; set; }
            private string UsernameVal;
            public string Username
            {
                get
                {
                    return this.UsernameVal;
                }
                set
                {
                    this.UsernameVal = value;
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
            public string Note { get; set; }
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

                DirectMessages.Add(new DmsListEntry
                { 
                    UserId = recipientId,
                    ChannelId = channel.id,
                    Username = relationship != null ? relationship.user.GetTag() : "(Unknown User)",
                    Avatar = avatar,
                    Date = Discord.SnowflakeToTimestap(channel.id).ToShortDateString(),
                    MessagesCount = channel.messages.Count,
                    Note = user.notes.ContainsKey(recipientId) ? user.notes[recipientId] : "",
                    NeedsFetching = relationship == null
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
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.OrderByDescending(x => x.Note));
            }
            else
            {
                DirectMessages = new ObservableCollection<DmsListEntry>(DirectMessages.Reverse());
            }

            currentColumn = 3;
            mainList.ItemsSource = DirectMessages;
        }
    }
}
