using GalaSoft.MvvmLight.Messaging;
using MvvM.ViewModels;
using System;
using System.Collections.Generic;
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

namespace MvvM.View
{
    /// <summary>
    /// MyView.xaml 的交互逻辑
    /// </summary>
    public partial class MyView : UserControl
    {
        public MyView()
        {
            InitializeComponent();

            Messenger.Default.Register<MessageData>(this, OnMessageReceived);
        }

        private void OnMessageReceived(MessageData message)
        {
            switch (message.Id)
            {
                case MessageId.ValChanged:
                    ll.Content = message.Data.ToString();
                    break;
            }
        }


        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<MessageData, MainWindow>(new MessageData(MessageId.ShowData, "vvv"));
        }

        int thrVal = 0;
        private void Thr_Click(object sender, RoutedEventArgs e)
        {
            if (0 < thrVal) return;

            thrVal++;
            Thread th = new Thread(() =>
            {
                while(true)
                {
                    Messenger.Default.Send<MessageData, MainWindow>(new MessageData(MessageId.ThrData, thrVal.ToString()));
                    thrVal++;
                    Thread.Sleep(100);
                }

            });
            th.IsBackground = true;
            th.Start();

        }
    }
}
