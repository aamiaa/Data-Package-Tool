using Data_Package_Tool.Classes;
using Data_Package_Tool.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Data_Package_Tool.Forms
{
    /// <summary>
    /// Interaction logic for FileAttachmentWPF.xaml
    /// </summary>
    public partial class FileAttachmentWPF : UserControl
    {
        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileAttachmentWPF));

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        // The default value is to prevent random internal WPF errors when scrolling
        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(FileAttachmentWPF), new PropertyMetadata("https://example.com"));

        public FileAttachmentWPF()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string url = this.Url;
            ThreadPool.QueueUserWorkItem(state =>
            {
                string fileSize = "Unknown size";
                try
                {
                    var res = DRequest.Request("HEAD", url, null, null, false);
                    var size = res.response.ContentLength;
                    fileSize = Util.SizeSuffix(size, 2);
                }
                catch (Exception) { }

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    fileSizeLb.Text = fileSize;
                }));
            });
        }
    }
}
