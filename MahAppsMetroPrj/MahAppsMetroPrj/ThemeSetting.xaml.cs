using Comm;
using MahApps.Metro;
using StarSkyNS;
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

namespace MahAppsMetroPrj
{
    /// <summary>
    /// ThemeSetting.xaml 的交互逻辑
    /// </summary>
    public partial class ThemeSetting : UserControl
    {
        public ThemeSetting()
        {
            InitializeComponent();
            InitClr();
        }

        #region 主题
        void InitClr()
        {
            foreach (var clr in ThemeManager.ColorSchemes)
            {
                RadioButton btn = new RadioButton();
                btn.Content = clr.Name;
                btn.Margin = new System.Windows.Thickness(10, 4, 10, 4);
                btn.Background = clr.ShowcaseBrush;
                btn.Checked += Clr_Checked;
                ColorPanel.Children.Add(btn);
            }
        }
        private void Clr_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (null == btn) return;
            ThemeManagerUsr.ChangeThemeColorScheme(System.Windows.Application.Current, btn.Content.ToString());
        }
        private void DarkTheme_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ThemeManagerUsr.ChangeThemeBaseColor(System.Windows.Application.Current, ThemeManager.BaseColorDark);
        }
        private void LightTheme_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ThemeManagerUsr.ChangeThemeBaseColor(System.Windows.Application.Current, ThemeManager.BaseColorLight);

        }
        #endregion


        #region 装饰星星
        private void startNumSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.startObj) return;
            StarSky.startObj._starCount = (int)startNumSL.Value;
            StarSky.startObj.Flush();
        }
        private void startSizeSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.startObj) return;
            StarSky.startObj._starSizeMax = (int)startSizeSL.Value;
            StarSky.startObj.Flush();
        }
        private void startSpeedSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.startObj) return;
            StarSky.startObj._starVMax = (int)startSpeedSL.Value;
            StarSky.startObj.Flush();
        }
        private void startRotateSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.startObj) return;
            StarSky.startObj.SetRotateSpeed((int)startRotateSL.Value);
            StarSky.startObj.Flush();

        }


        #endregion
    }
}
