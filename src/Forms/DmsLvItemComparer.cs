using System;
using System.Collections;
using System.Windows.Forms;

namespace Data_Package_Tool.Forms
{
    public class DmsLvItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public DmsLvItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            ListViewItem lvX = x as ListViewItem;
            ListViewItem lvY = y as ListViewItem;

            int val;

            var channelX = Main.ChannelsMap[lvX.SubItems[1].Text];
            var channelY = Main.ChannelsMap[lvY.SubItems[1].Text];

            switch (col)
            {
                case -1:
                case 0:
                case 1:
                    val = Math.Sign(Int64.Parse(channelX.id) - Int64.Parse(channelY.id));
                    break;
                case 2:
                    val = Math.Sign(Int64.Parse(lvX.SubItems[col].Text) - Int64.Parse(lvY.SubItems[col].Text));
                    break;
                case 4:
                    val = Int32.Parse(lvX.SubItems[col].Text) - Int32.Parse(lvY.SubItems[col].Text);
                    break;
                default:
                    val = String.Compare(lvX.SubItems[col].Text, lvY.SubItems[col].Text);
                    break;
            }

            if (order == SortOrder.Descending) val *= -1;
            return val;
        }
    }
}
