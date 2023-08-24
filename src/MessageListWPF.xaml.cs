using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Data_Package_Tool
{
    /// <summary>
    /// Interaction logic for MessageListWPF.xaml
    /// </summary>
    public partial class MessageListWPF : UserControl
    {
        public MessageListWPF()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            mainGrid.RowDefinitions.Clear();
            mainGrid.Children.Clear();
        }

        public void AddToList(UIElement child)
        {
            mainGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = GridLength.Auto
            });
            child.SetValue(Grid.RowProperty, mainGrid.RowDefinitions.Count - 1);
            mainGrid.Children.Add(child);
        }

        public void RemoveMessage(string messageId)
        {
            foreach(MessageWPF msg in mainGrid.Children)
            {
                if(msg.SelectedMessage.id == messageId)
                {
                    msg.MarkDeleted();
                    break;
                }
            }
        }
    }
}
