using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Data_Package_Tool.Forms
{
    /// <summary>
    /// Interaction logic for DmsListWPF.xaml
    /// </summary>
    public partial class DmsListWPF : UserControl
    {
        public class DmsListEntry
        {
            public string UserId { get; set; }
            public string Username { get; set; }
            public BitmapImage Avatar { get; set; }
            public string Date { get; set; }
            public int MessagesCount { get; set; }
            public string Note { get; set; }
            public bool NeedsFetching { get; set; }
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
                    Username = relationship != null ? relationship.user.GetTag() : "(Unknown User)",
                    Avatar = avatar,
                    Date = Discord.SnowflakeToTimestap(channel.id).ToShortDateString(),
                    MessagesCount = channel.messages.Count,
                    Note = user.notes.ContainsKey(recipientId) ? user.notes[recipientId] : "",
                    NeedsFetching = relationship == null
                });
            }
        }
    }
}
