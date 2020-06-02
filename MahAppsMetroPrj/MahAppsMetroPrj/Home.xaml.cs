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
using System.Windows.Threading;

namespace MahAppsMetroPrj
{
    class TickInfo
    {
        List<string> m_inf = new List<string>();
        int curIndex = 0;
        public string GetInf()
        {
            ++curIndex;
            if (curIndex >= m_inf.Count) curIndex = 0;

            if (curIndex >= m_inf.Count) return "";
            return m_inf[curIndex];
        }
        public void Add(string inf)
        {
            m_inf.Add(inf);
        }
    }


    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : UserControl
    {
        TickInfo m_TickInfoA = new TickInfo();
        TickInfo m_TickInfoB = new TickInfo();
        TickInfo m_TickInfoC = new TickInfo();

        public Home()
        {
            InitializeComponent();

            m_TickInfoA.Add("你懂的...");
            m_TickInfoA.Add("你懂的(●'◡'●)");

            m_TickInfoB.Add("你懂的O(∩_∩)O");
            m_TickInfoB.Add("你懂的(￣▽￣)");

            m_TickInfoC.Add("你懂的┭┮﹏┭┮");
            m_TickInfoC.Add("你懂的w(ﾟДﾟ)w");

            ProcTick();
            var t = new DispatcherTimer(TimeSpan.FromSeconds(2), DispatcherPriority.Normal, Tick, this.Dispatcher);
        }
        void Tick(object sender, EventArgs e)
        {
            if (this.IsVisible == false) return;
            ProcTick();
        }
        void ProcTick()
        {
            infA.Content = new TextBlock { Text = m_TickInfoA.GetInf(), SnapsToDevicePixels = true };
            infB.Content = new TextBlock { Text = m_TickInfoB.GetInf(), SnapsToDevicePixels = true };
            infC.Content = new TextBlock { Text = m_TickInfoC.GetInf(), SnapsToDevicePixels = true };
        }


        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MSG_SHOWTIP(PromptType.TipWnd, "你懂的");
        }

        private void MenuRippleBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MSG(MsgId.HamburgerMenu);
        }
    }
}
