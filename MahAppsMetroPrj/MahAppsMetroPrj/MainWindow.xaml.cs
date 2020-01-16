using Comm;
using MahApps.Metro.Controls.Dialogs;
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

namespace MahAppsMetroPrj
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public static MainWindow _UIMAIN = null;
        public static void ShowTips(string title, string inf)
        {
            if (null == _UIMAIN) return;
            _UIMAIN.Dispatcher.Invoke(() =>
            {
                _UIMAIN.ShowMessageAsync(title, inf,
                    MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings
                    {
                        AffirmativeButtonText = "关闭",
                        NegativeButtonText = "确定",
                        AnimateShow = true,
                        AnimateHide = false
                    });

            });
        }
        public ManualResetEvent m_runing = new ManualResetEvent(false);

        bool isRunning()
        {
            if (m_runing.WaitOne(0))
            {
                ShowTips("", "正在运行,请稍后操作");
                return true;
            }
            return false;
        }
        delegate void thrRun();
        void Run(thrRun fun)
        {
            m_runing.Set();
            Thread thread = new Thread(() => {
                try
                {
                    fun();
                    m_runing.Reset();
                }
                catch (Exception ex)
                {
                    ShowTips("", ex.ToString());
                    m_runing.Reset();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        public MainWindow()
        {
            InitializeComponent();
            _UIMAIN = this;
            cfgOpt.read();
        }







        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowTips("帮助","XXX");
        }
        private void settingBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingWnd dlg = new SettingWnd();
            dlg.ShowDialog();
        }
        private void StatusBarItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            FtThemeSetting.IsOpen = true;
        }

    }
}
