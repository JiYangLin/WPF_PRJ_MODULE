using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MvvM.ViewModels
{
    public struct MessageData
    {
        public MessageData(MessageId id, object data = null)
        {
            Id = id;
            Data = data;
        }
        public object Data;
        public MessageId Id;
    }

    public enum MessageId
    {
        ValChanged,
        ShowData,
        ThrData,
    }



    class MyModel : ViewModelBase
    {
        public RelayCommand MyCommand => new RelayCommand(fun);
        int val = 0;
        byte alpha = 0;
        private void fun()
        {
            Messenger.Default.Send<MessageData, MyView>(new MessageData(MessageId.ValChanged, val.ToString()));

            TextVal = val.ToString();
            val++;

            BackgroundColor = new SolidColorBrush(Color.FromArgb(alpha, 50, 250, 50));
            alpha += 5;
        }

        private string _TextVal = "abcde";
        public string TextVal
        {
            get { return _TextVal; }
            set
            {
                _TextVal = value;
                RaisePropertyChanged("TextVal");
            }
        }


        private SolidColorBrush _backgroundColor = new SolidColorBrush(Color.FromRgb(250, 50, 50));
        public SolidColorBrush BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                RaisePropertyChanged("BackgroundColor");
            }
        }
    }
}
