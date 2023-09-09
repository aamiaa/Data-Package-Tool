using System.Windows.Forms;

namespace Data_Package_Tool.Helpers
{
    public class Util
    {
        public static void MsgBox(string msg, string title = "Data Package Tool")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static void MsgBoxInfo(string msg, string title = "Information")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MsgBoxWarn(string msg, string title = "Warning")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MsgBoxErr(string msg, string title = "Error")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
