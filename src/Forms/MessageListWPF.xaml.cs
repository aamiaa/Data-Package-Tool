using Data_Package_Tool.Classes.Parsing;
using System;
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
        public ObservableCollection<DMessage> Messages { get; set; } = new ObservableCollection<DMessage>();
        public MessageListWPF()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void Clear()
        {
            Messages.Clear();
        }

        public void DisplayMessages(List<DMessage> messages)
        {
            foreach(var msg in messages)
            {
                Messages.Add(msg);
            }

            mainList.ScrollIntoView(messages[0]);
        }
    }
}
