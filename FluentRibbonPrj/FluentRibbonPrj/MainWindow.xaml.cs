using MyAppender;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FluentRibbonPrj.source;
using FluentRibbonPrj.ui;
using System.Windows.Documents;

namespace FluentRibbonPrj
{

    public class Dat
    {
        public string name { get; set; }
        public string age { get; set; }
    }



    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MyLogger.txtBox = LoggerShowRB;

            Cursor cur = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "/curFile.cur");
            this.Cursor = cur;

            cfgOpt.read();

           
        }



        public ManualResetEvent m_runing = new ManualResetEvent(false);

        bool isRunning()
        {
            if (m_runing.WaitOne(0))
            {
                OptWaitWnd wnd = new OptWaitWnd("", "正在运行,请稍后操作");
                wnd.ShowDialog();
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
                    MyLogger.logger.Warn(ex.ToString());
                    OptWaitWnd wnd = new OptWaitWnd("", ex.ToString());
                    wnd.ShowDialog();
                    m_runing.Reset();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }




        private void StartPrj_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning()) return;


            SourceList.DataContext = null;
            ObservableCollection<Dat> dat = new ObservableCollection<Dat>();
            SourceList.DataContext = dat;            
        }
   




        #region 参数设置
        private void SetCol_Click(object sender, RoutedEventArgs e)
        {
            setcol set = new setcol();
            set.ShowDialog();
        }
        #endregion


        #region 帮助
        private void VaildOpt_Loaded(object sender, RoutedEventArgs e)
        {
            string resourceName = MethodBase.GetCurrentMethod().DeclaringType.Namespace + ".embSource.info.png";
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            ImageSourceConverter imgSrcCvt = new ImageSourceConverter();
            vaildOpt.Source = imgSrcCvt.ConvertFrom(stream) as System.Windows.Media.Imaging.BitmapFrame;
        }
        #endregion
    }
}
