using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsMetroPrj
{
    public struct MainMessage
    {
        public MainMessage(MsgId id, object data1 = null, object data2 = null, object data3 = null, object data4 = null)
        {
            Id = id;
            Data1 = data1;
            Data2 = data2;
            Data3 = data3;
            Data4 = data4;
        }
        public object Data1;
        public object Data2;
        public object Data3;
        public object Data4;
        public MsgId Id;
    }

    public enum MsgId
    {
        ShowTips,//PromptType type, string inf
        HamburgerMenu,
    }
    public enum PromptType
    {
        Info,
        Prompt,
        Err,
        TipWnd,
    }


    public partial class MainWindow
    {
        public static void MSG(MsgId id, object data1 = null, object data2 = null, object data3 = null, object data4 = null)
        {
            Messenger.Default.Send<MainMessage, MainWindow>(
                new MainMessage(id, data1, data2, data3, data4));
        }
        public static void MSG_SHOWTIP(PromptType type, string inf)
        {
            Messenger.Default.Send<MainMessage, MainWindow>(
                new MainMessage(MsgId.ShowTips, type, inf));
        }

        void OnMessageReceived(MainMessage message)
        {
            switch (message.Id)
            {
                case MsgId.ShowTips:
                    ShowTipsInfo((PromptType)message.Data1, (string)message.Data2);
                    break;
                case MsgId.HamburgerMenu:
                    MainPage.Content = new MenuRipple();
                    break;
            }
        }



        #region Tips
        void ShowTipsInfo(PromptType type, string inf)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    ShowTipsInfoFun(type, inf);
                });
            }
            catch (Exception) { }
        }
        void ShowTipsInfoFun(PromptType type, string inf)
        {
            if (PromptType.TipWnd == type)
            {

                MetroDialogSettings st = new MetroDialogSettings
                {
                    AffirmativeButtonText = "确定",
                    NegativeButtonText = "确定",
                    AnimateShow = true,
                    AnimateHide = false
                };
                this.ShowMessageAsync("", inf, MessageDialogStyle.Affirmative, st);
            }
            else if (PromptType.Err == type)
            {
                FtTips.Header = "警告";
                FtTips.IsModal = true;
                FtTips_Content.Text = inf;
                FtTips_Content.Foreground = System.Windows.Media.Brushes.Red;
                FtTips.IsOpen = true;
                logger.Error(inf);
            }
            else if (PromptType.Prompt == type)
            {
                FtTips.Header = "提示";
                FtTips.IsModal = false;
                FtTips_Content.Text = inf;
                FtTips_Content.Foreground = System.Windows.Media.Brushes.Green;
                FtTips.IsOpen = true;
            }
            else
            {
                infoshow.Content = inf;
            }

        }
        #endregion

    }
}
