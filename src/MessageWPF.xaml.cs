using Data_Package_Images.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        public DMessage SelectedMessage;
        public bool IsDeleted = false;
        public static BitmapImage AvatarSource;
        public MessageWPF(DMessage message, DUser user)
        {
            InitializeComponent();
            this.SelectedMessage = message;

            if(AvatarSource == null)
            {
                AvatarSource = new BitmapImage();
                AvatarSource.BeginInit();
                AvatarSource.UriSource = new Uri(user.GetAvatarURL(), UriKind.Absolute);
                AvatarSource.EndInit();
            }

            if (message.channel.IsDM())
            {
                viewUserMi.IsEnabled = true;
                openDMMi.IsEnabled = true;
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
                copyUserIdMi.IsEnabled = true;

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
                metadata += $"unknown ({channel.id}, {(channel.IsGroupDM() ? "Group DM" : "Text Channel")})";

                if(!channel.IsGroupDM())
                {
                    findGuildIdMi.IsEnabled = true;
                }
            }

            if (channel.guild != null)
            {
                copyGuildIdMi.IsEnabled = true;

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
            avatarImg.ImageSource = AvatarSource;

            // Add red tint if the message was deleted with mass deleter
            if(message.deleted)
            {
                MarkDeleted();
            }
        }

        public Size GetTextSize()
        {
            return contentLb.RenderSize;
        }

        public void MarkDeleted()
        {
            IsDeleted = true;
            rootGrid.Background = new SolidColorBrush(Color.FromArgb(255, 78, 54, 59));
        }

        private void ParseAndSet(string content)
        {
            contentLb.Text = "";

            bool isOnlyEmojis = Regex.Replace(content, @"<a?:\w+:\d+>", "").Trim() == "";

            var lines = content.Split('\n');
            for(int i=0;i<lines.Length;i++)
            {
                if(i > 0)
                {
                    contentLb.Inlines.Add(new Run("\n"));
                }

                var line = lines[i];
                foreach (var word in line.Split(' '))
                {
                    if (Regex.IsMatch(word, @"^<a?:\w+:\d+>$"))
                    {
                        var match = Regex.Matches(word, @"<(a?):\w+:(\d+)>", RegexOptions.None)[0];
                        var isAnimated = match.Groups[1].Value == "a";
                        var emojiId = match.Groups[2].Value;

                        var img = new Image();
                        if (isOnlyEmojis)
                        {
                            img.Width = 48;
                            img.Height = 48;
                        }
                        else
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
                    }
                    else
                    {
                        contentLb.Inlines.Add(new Run(word + " "));
                    }
                }
            }
        }

        private void goToMessageMi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var link = SelectedMessage.GetMessageLink();
                Main.LaunchDiscordProtocol($"channels/{link}");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if(IsDeleted)
            {
                rootGrid.Background = new SolidColorBrush(Color.FromArgb(255, 73, 51, 55));
            } else
            {
                rootGrid.Background = new SolidColorBrush(Color.FromArgb(255, 46, 48, 53));
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if(IsDeleted)
            {
                rootGrid.Background = new SolidColorBrush(Color.FromArgb(255, 78, 54, 59));
            } else
            {
                rootGrid.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
        }

        private void viewUserMi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.LaunchDiscordProtocol($"users/{SelectedMessage.channel.GetOtherDMRecipient(Main.User)}");
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

        private void copyUserIdMi_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(SelectedMessage.channel.GetOtherDMRecipient(Main.User));
        }

        private void copyGuildIdMi_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(SelectedMessage.channel.guild.id);
        }

        private void openDMMi_Click(object sender, RoutedEventArgs e)
        {
            DHeaders.Init();

            string token = Interaction.InputBox("Enter your token", "Prompt", Main.AccountToken);
            if (token == "") return;
            if (!Main.ValidateToken(token))
            {
                System.Windows.Forms.MessageBox.Show("Entered token is invalid or doesn't belong to the same account!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            Main.AccountToken = token;

            var body = new Dictionary<string, string[]>();
            body.Add("recipients", new string[]{SelectedMessage.channel.GetOtherDMRecipient(Main.User)});

            var response = DRequest.Request("POST", "https://discord.com/api/v9/users/@me/channels", new Dictionary<string, string>
            {
                {"Authorization", token},
                {"Content-Type", "application/json"},
                {"X-Context-Properties", Convert.ToBase64String(Encoding.UTF8.GetBytes("{}"))}
            }, Newtonsoft.Json.JsonConvert.SerializeObject(body), true);

            if(response.response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                goToMessageMi_Click(sender, e);
            }  else
            {
                System.Windows.Forms.MessageBox.Show($"Request error: {response.response.StatusCode} {response.body}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
