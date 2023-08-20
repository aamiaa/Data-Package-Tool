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
            if(Main.ValidateToken(tokenTb.Text))
            {
                MessageBox.Show("Entered token is invalid or doesn't belong to the same account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogSuccess = true;
            Close();
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
