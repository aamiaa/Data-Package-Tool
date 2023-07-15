using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Package_Images
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(!ValidateToken())
            {
                MessageBox.Show("Entered token is invalid or doesn't belong to the same account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogSuccess = true;
            Close();
        }

        private bool ValidateToken()
        {
            var token = tokenTb.Text;
            var parts = token.Split('.');

            if (parts.Length != 3) return false;

            var userIdPart = parts[0];
            try
            {
                var userId = Encoding.UTF8.GetString(Convert.FromBase64String(userIdPart));
                return userId == Main.User.id;
            } catch(Exception)
            {
                return false;
            }
        }

        public string GetToken()
        {
            return tokenTb.Text;
        }

        public int GetDelay()
        {
            return delayTb.Value * 100;
        }
    }
}
