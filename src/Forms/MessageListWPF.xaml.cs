using Data_Package_Tool.Classes.Parsing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Data_Package_Tool
{
    /// <summary>
    /// Interaction logic for MessageListWPF.xaml
    /// </summary>
    public partial class MessageListWPF : UserControl
    {
        public class MessageAndUser
        {
            public DUser User { get; set; }
            public DMessage Message { get; set; }
        }

        public ObservableCollection<MessageAndUser> Messages { get; set; } = new ObservableCollection<MessageAndUser>();
        public MessageListWPF()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void Clear()
        {
            Messages.Clear();
        }

        public void DisplayMessages(DUser user, List<DMessage> messages, int startIdx, int endIdx)
        {
            for(int i=startIdx;i<=endIdx;i++)
            {
                var message = messages[i];
                Messages.Add(new MessageAndUser { User = user, Message = message });
            }
        }
    }
}
