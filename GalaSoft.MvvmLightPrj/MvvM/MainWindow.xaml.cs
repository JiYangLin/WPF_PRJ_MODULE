using GalaSoft.MvvmLight.Messaging;
using MvvM.ViewModels;
using System.Windows;

namespace MvvM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<MessageData>(this, OnMessageReceived);
        }

        private void OnMessageReceived(MessageData message)
        {
            switch (message.Id)
            {
                case MessageId.ShowData:
                    TB.Text = message.Data.ToString();
                    break;
                case MessageId.ThrData:
                    this.Dispatcher.Invoke(()=> { TB.Text = message.Data.ToString(); });                  
                    break;
            }
        }
    }
}
