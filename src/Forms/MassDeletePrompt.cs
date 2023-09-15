using Data_Package_Tool.Classes;
using Data_Package_Tool.Helpers;
using System;
using System.Windows.Forms;

namespace Data_Package_Tool
{
    public partial class MassDeletePrompt : Form
    {
        public bool DialogSuccess = false;
        public MassDeletePrompt()
        {
            InitializeComponent();
        }

        private void delayTb_Scroll(object sender, EventArgs e)
        {
            delayLb.Text = $"Delay: {delayTb.Value * 100}ms";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (Discord.UserToken == null)
            {
                Util.MsgBoxErr(Consts.MissingTokenError);
                return;
            }
            if (!Discord.ValidateToken(Discord.UserToken, Main.DataPackage.User.id))
            {
                Util.MsgBoxErr(Consts.InvalidTokenError);
                return;
            }

            DialogSuccess = true;
            Close();
        }

        public int GetDelay()
        {
            return delayTb.Value * 100;
        }
    }
}
