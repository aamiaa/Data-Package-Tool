using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Package_Images
{
    public partial class Message : UserControl
    {
        private DMessage SelectedMessage;
        public Message(DMessage message, DUser user)
        {
            InitializeComponent();
            this.SelectedMessage = message;

            if (message.channel.IsDM())
            {
                viewUserToolStripMenuItem.Enabled = true;
            }

            // Set username
            if (user.IsPomelo())
            {
                usernameLb.Text = user.username;
            }
            else
            {
                usernameLb.Text = $"{user.username}#{user.discriminator}";
            }

            // Set metadata
            var channel = message.channel;
            string metadata = "Channel: ";
            if (channel.name != null)
            {
                if (channel.IsDM() || channel.IsGroupDM() || channel.IsVoice())
                {
                    metadata += channel.name;
                } else
                {
                    metadata += $"#{channel.name}";
                }
            } else if(channel.IsDM())
            {
                metadata += $"DMs with {channel.GetOtherDMRecipient(user)}";
            } else
            {
                metadata += $"unknown ({channel.id})";
            }

            if(channel.guild != null)
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

            if(message.attachments.Count > 0)
            {
                metadata += $", {message.attachments.Count} attachments";
            }

            metadataLb.Text = metadata;

            // Set content and timestamp
            contentLb.Text = message.content;
            dateLb.Text = message.timestamp;
            dateLb.Location = new Point(usernameLb.Location.X + usernameLb.Size.Width, usernameLb.Location.Y + (usernameLb.Size.Height - dateLb.Size.Height));

            var diff = contentLb.Location.Y + contentLb.Size.Height - Size.Height;
            if(diff > 0)
            {
                this.Size = new Size(Size.Width, Size.Height + diff);
            }

            // Set avatar
            try
            {
                avatarPb.Load(user.GetAvatarURL());
            } catch (Exception)
            {
                avatarPb.Image = Properties.Resources._0;
            }
        }

        public Size GetTextSize()
        {
            return contentLb.Size;
        }

        private void goToMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var link = SelectedMessage.GetMessageLink();
                Main.LaunchDiscordProtocol($"channels/{link}");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedMessage.content);
        }

        private void copyChannelIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedMessage.channel.id);
        }

        private void copyMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metadataLb.Text);
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
