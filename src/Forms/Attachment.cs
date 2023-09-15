using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Helpers;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Data_Package_Tool
{
    public partial class Attachment : UserControl
    {
        private DAttachment SelectedAttachment;
        public Attachment(DAttachment attachment)
        {
            InitializeComponent();
            SelectedAttachment = attachment;

            if(SelectedAttachment.message.channel.IsDM())
            {
                copyUserIdToolStripMenuItem.Enabled = true;
                viewUserToolStripMenuItem.Enabled = true;
                openDmSELFBOTToolStripMenuItem.Enabled = true;
            }

            if(SelectedAttachment.message.channel.guild != null)
            {
                copyGuildIdToolStripMenuItem.Enabled = true;
            }
        }

        public void LoadImage()
        {
            try
            {
                imagePb.Load(this.SelectedAttachment.url);
            }
            catch (Exception)
            {
                imagePb.Image = imagePb.ErrorImage;
            }
        }

        private void imagePb_Click(object sender, EventArgs e)
        {
            Process.Start(SelectedAttachment.url);
        }

        private void jumpToMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var link = SelectedAttachment.message.GetMessageLink();
                Discord.LaunchDiscordProtocol($"channels/{link}");
            }
            catch (Exception ex)
            {
                Util.MsgBoxErr(ex.Message);
            }
        }

        private void copyChannelIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedAttachment.message.channel.id);
        }

        private void copyGuildIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedAttachment.message.channel.guild.id);
        }

        private void copyUserIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedAttachment.message.channel.GetOtherDMRecipient(Main.DataPackage.User));
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Discord.LaunchDiscordProtocol($"users/{SelectedAttachment.message.channel.GetOtherDMRecipient(Main.DataPackage.User)}");
            } catch(Exception ex)
            {
                Util.MsgBoxErr(ex.Message);
            }
        }

        private void openDmSELFBOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = SelectedAttachment.message.channel.GetOtherDMRecipient(Main.DataPackage.User);
            string channelId = SelectedAttachment.message.channel.id;
            if (Main.DataPackage.ChannelsMap[channelId].has_duplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            if(Discord.OpenDMFlow(userId, SelectedAttachment.message.channel.id))
            {
                Discord.LaunchDiscordProtocol($"channels/@me/{channelId}");
            }
        }
    }
}
