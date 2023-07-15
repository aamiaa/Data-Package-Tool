using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Data_Package_Images
{
    /// <summary>
    /// Interaction logic for MessageWPF.xaml
    /// </summary>
    public partial class MessageWPF : UserControl
    {
        private DMessage SelectedMessage;
        public MessageWPF(DMessage message, DUser user)
        {
            InitializeComponent();
            this.SelectedMessage = message;

            if (message.channel.IsDM())
            {
                viewUserMi.IsEnabled = true;
            }

            // Set username
            usernameLb.Content = user.GetTag();

            // Set metadata
            var channel = message.channel;
            string metadata = "Channel: ";
            if (channel.name != null)
            {
                if (channel.IsDM() || channel.IsGroupDM() || channel.IsVoice())
                {
                    metadata += channel.name;
                }
                else
                {
                    metadata += $"#{channel.name}";
                }
            }
            else if (channel.IsDM())
            {
                var recipientId = channel.GetOtherDMRecipient(user);
                var recipientUserRelationship = Array.Find(user.relationships, x => x.id == recipientId);
                if(recipientUserRelationship != null)
                {
                    metadata += $"DMs with {recipientUserRelationship.user.GetTag()}";
                } else
                {
                    metadata += $"DMs with {recipientId}";
                }
            }
            else
            {
                metadata += $"unknown ({channel.id})";
            }

            if (channel.guild != null)
            {
                metadata += ", Guild: ";
                if (channel.guild.name != null)
                {
                    metadata += channel.guild.name;
                }
                else
                {
                    metadata += $"unknown ({channel.guild.id})";
                }
            }

            if (message.attachments.Count > 0)
            {
                metadata += $", {message.attachments.Count} attachments";
            }

            metadataLb.Content = metadata;

            // Set content and timestamp
            //contentLb.Text = message.content;
            ParseAndSet(message.content);
            var parsedDate = DateTime.Parse(message.timestamp, null, System.Globalization.DateTimeStyles.RoundtripKind);
            dateLb.Content = parsedDate.ToShortDateString() + " " + parsedDate.ToShortTimeString();

            // Set avatar
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(user.GetAvatarURL(), UriKind.Absolute);
            bitmap.EndInit();
            avatarImg.ImageSource = bitmap;
        }

        public Size GetTextSize()
        {
            return contentLb.RenderSize;
        }

        private void ParseAndSet(string content)
        {
            contentLb.Text = "";

            bool isOnlyEmojis = Regex.Replace(content, @"<a?:\w+:\d+>", "").Trim() == "";
            foreach (var word in content.Split(' '))
            {
                if(Regex.IsMatch(word, @"<a?:\w+:\d+>"))
                {
                    var match = Regex.Matches(word, @"<(a?):\w+:(\d+)>", RegexOptions.None)[0];
                    var isAnimated = match.Groups[1].Value == "a";
                    var emojiId = match.Groups[2].Value;

                    var img = new Image();
                    if(isOnlyEmojis)
                    {
                        img.Width = 48;
                        img.Height = 48;
                    } else
                    {
                        img.Width = 22;
                        img.Height = 22;
                    }

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri($"https://cdn.discordapp.com/emojis/{emojiId}.{(isAnimated ? "gif" : "png")}?size={(isOnlyEmojis ? "96" : "44")}&quality=lossless", UriKind.Absolute);
                    bitmap.EndInit();
                    img.Source = bitmap;

                    var inlineContainer = new InlineUIContainer(img);
                    inlineContainer.BaselineAlignment = BaselineAlignment.Center;
                    contentLb.Inlines.Add(inlineContainer);
                    contentLb.Inlines.Add(new Run(" "));
                } else
                {
                    contentLb.Inlines.Add(new Run(word + " "));
                }
            }
        }

        private void goToMessageMi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var link = SelectedMessage.GetMessageLink();
                Main.LaunchDiscordProtocol($"discord://-/channels/{link}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            rootGrid.Background = new SolidColorBrush(Color.FromArgb(255, 46, 48, 53));
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            rootGrid.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void viewUserMi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.LaunchDiscordProtocol($"discord://-/users/{SelectedMessage.channel.GetOtherDMRecipient(Main.User)}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void copyMessageMi_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(SelectedMessage.content);
        }

        private void copyChannelIdMi_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(SelectedMessage.channel.id);
        }

        private void copyMetadataMi_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((string)metadataLb.Content);
        }
    }
}
