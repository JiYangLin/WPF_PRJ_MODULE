using MahApps.Metro;
using StarSkyNS;
using System.Windows.Controls;

namespace Theme
{
    /// <summary>
    /// ThemeSetting.xaml 的交互逻辑
    /// </summary>
    public partial class ThemeSetting
    {
        public ThemeSetting()
        {
            InitializeComponent();
            InitClr();
        }

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


        #region 装饰星星
        private void startNumSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.starObj) return;
            StarSky.starObj._starCount = (int)startNumSL.Value;
            StarSky.starObj.Flush();
        }
        private void startSizeSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.starObj) return;
            StarSky.starObj._starSizeMax = (int)startSizeSL.Value;
            StarSky.starObj.Flush();
        }
        private void startSpeedSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.starObj) return;
            StarSky.starObj._starVMax = (int)startSpeedSL.Value;
            StarSky.starObj.Flush();
        }
        private void startRotateSL_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (null == StarSky.starObj) return;
            StarSky.starObj.SetRotateSpeed((int)startRotateSL.Value);
            StarSky.starObj.Flush();
        }
        #endregion
    }
}
