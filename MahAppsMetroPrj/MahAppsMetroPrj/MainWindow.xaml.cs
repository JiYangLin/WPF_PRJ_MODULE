using GalaSoft.MvvmLight.Messaging;
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
    public delegate void thrRun();
    public partial class MainWindow
    {
        #region Thr
        public static void RunThrFun(thrRun fun)
        {
            if (obj.isRunning()) return;
            obj.RunThr(fun);
        }


        public ManualResetEvent m_runing = new ManualResetEvent(false);
        bool isRunning()
        {
            if (m_runing.WaitOne(0))
            {
                MSG_SHOWTIP(PromptType.Info, "正在运行,请稍后操作");
                return true;
            }
            return false;
        }
        void RunThr(thrRun fun)
        {
            m_runing.Set();
            Thread thread = new Thread(() =>
            {
                try
                {
                    fun();
                    m_runing.Reset();
                }
                catch (Exception ex)
                {
                    MSG_SHOWTIP(PromptType.Err, ex.ToString());
                    m_runing.Reset();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion


        static MainWindow obj = null;
        log4net.ILog logger = log4net.LogManager.GetLogger("AutoRecCheck_Logger");
        Home m_Home = new Home();
        public MainWindow()
        {
            InitializeComponent();

            obj = this;
            MainPage.Content = m_Home;
            Messenger.Default.Register<MainMessage>(this, OnMessageReceived);
        }



        private void StatusBarItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            FtThemeSetting.IsOpen = true;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = m_Home;
        }
    }
}
