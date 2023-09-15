using System;
using System.Windows.Forms;

namespace Data_Package_Tool.Helpers
{
    public class Util
    {
        public static DialogResult MsgBox(string msg, string title = "Data Package Tool", MessageBoxButtons btns = MessageBoxButtons.OK)
        {
            return MessageBox.Show(msg, title, btns, MessageBoxIcon.None);
        }

        public static DialogResult MsgBoxInfo(string msg, string title = "Information", MessageBoxButtons btns = MessageBoxButtons.OK)
        {
            return MessageBox.Show(msg, title, btns, MessageBoxIcon.Information);
        }

        public static DialogResult MsgBoxWarn(string msg, string title = "Warning", MessageBoxButtons btns = MessageBoxButtons.OK)
        {
            return MessageBox.Show(msg, title, btns, MessageBoxIcon.Warning);
        }

        public static DialogResult MsgBoxErr(string msg, string title = "Error", MessageBoxButtons btns = MessageBoxButtons.OK)
        {
            return MessageBox.Show(msg, title, btns, MessageBoxIcon.Error);
        }

        // https://stackoverflow.com/a/14488941
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
    }
}
