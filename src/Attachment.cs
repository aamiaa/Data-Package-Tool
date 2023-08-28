using Data_Package_Tool.Classes;
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
                Util.LaunchDiscordProtocol($"channels/{link}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Clipboard.SetText(SelectedAttachment.message.channel.GetOtherDMRecipient(Main.User));
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Util.LaunchDiscordProtocol($"users/{SelectedAttachment.message.channel.GetOtherDMRecipient(Main.User)}");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
