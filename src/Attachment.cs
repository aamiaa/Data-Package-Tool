using Data_Package_Tool.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
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

        private void openDmSELFBOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userId = SelectedAttachment.message.channel.GetOtherDMRecipient(Main.User);
            string channelId = SelectedAttachment.message.channel.id;
            if (Main.ChannelsMap[channelId].has_duplicates)
            {
                MessageBox.Show("You have multiple dm channels with this recipient. There is no guarantee that Discord will open the right one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DHeaders.Init();

            string token = Interaction.InputBox("Enter your token", "Prompt", Main.AccountToken);
            if (token == "") return;
            if (!Util.ValidateToken(token, Main.User.id))
            {
                MessageBox.Show("Entered token is invalid or doesn't belong to the same account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Main.AccountToken = token;

            var body = new Dictionary<string, string[]>
            {
                { "recipients", new string[] { userId } }
            };

            var response = DRequest.Request("POST", "https://discord.com/api/v9/users/@me/channels", new Dictionary<string, string>
            {
                {"Authorization", token},
                {"Content-Type", "application/json"},
                {"X-Context-Properties", Convert.ToBase64String(Encoding.UTF8.GetBytes("{}"))}
            }, Newtonsoft.Json.JsonConvert.SerializeObject(body), true);

            if (response.response.StatusCode == HttpStatusCode.OK)
            {
                Util.LaunchDiscordProtocol($"channels/@me/{channelId}");
            }
            else
            {
                MessageBox.Show($"Request error: {response.response.StatusCode} {response.body}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
