using Data_Package_Tool.Classes;
using Data_Package_Tool.Classes.Parsing;
using Data_Package_Tool.Helpers;
using System;
using System.Diagnostics;
using System.Security.Policy;
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

            if(SelectedAttachment.Message.Channel.IsDM())
            {
                copyUserIdToolStripMenuItem.Enabled = true;
                viewUserToolStripMenuItem.Enabled = true;
                openDmSELFBOTToolStripMenuItem.Enabled = true;
            }

            if(SelectedAttachment.Message.Channel.Guild != null)
            {
                copyGuildIdToolStripMenuItem.Enabled = true;
            }
        }

        public void LoadImage()
        {
            try
            {
                imagePb.Load(this.SelectedAttachment.Url);
            }
            catch (Exception)
            {
                imagePb.Image = imagePb.ErrorImage;
            }
        }

        private void imagePb_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = SelectedAttachment.Url,
                UseShellExecute = true
            });
        }

        private void jumpToMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var link = SelectedAttachment.Message.GetMessageLink();
                Discord.LaunchDiscordProtocol($"channels/{link}");
            }
            catch (Exception ex)
            {
                Util.MsgBoxErr(ex.Message);
            }
        }

        private void copyChannelIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedAttachment.Message.Channel.Id);
        }

        private void copyGuildIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedAttachment.Message.Channel.Guild.Id);
        }

        private void copyUserIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedAttachment.Message.Channel.GetOtherDMRecipient(Main.DataPackage.User));
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Discord.LaunchDiscordProtocol($"users/{SelectedAttachment.Message.Channel.GetOtherDMRecipient(Main.DataPackage.User)}");
            } catch(Exception ex)
            {
                Util.MsgBoxErr(ex.Message);
            }
        }

        private async void openDmSELFBOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = SelectedAttachment.Message.Channel.GetOtherDMRecipient(Main.DataPackage.User);
            string channelId = SelectedAttachment.Message.Channel.Id;
            if (Main.DataPackage.ChannelsMap[channelId].HasDuplicates)
            {
                Util.MsgBoxWarn(Consts.DuplicateDMWarning);
            }

            if(await Discord.OpenDMFlowAsync(userId, SelectedAttachment.Message.Channel.Id))
            {
                Discord.LaunchDiscordProtocol($"channels/@me/{channelId}");
            }
        }
    }
}
