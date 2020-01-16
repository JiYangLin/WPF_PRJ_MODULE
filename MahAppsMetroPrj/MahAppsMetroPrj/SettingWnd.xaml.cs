using Comm;
using System;
using System.Windows;
using System.Windows.Input;
namespace MahAppsMetroPrj
{
    /// <summary>
    /// setcol.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWnd
    {
        public SettingWnd()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            namecol.Text = cfgOpt.namecol.ToString();
            agecol.Text = cfgOpt.agecol.ToString();
        }

        private void SetConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cfgOpt.namecol = Convert.ToInt32(namecol.Text);
                cfgOpt.agecol = Convert.ToInt32(agecol.Text);
                cfgOpt.write();
            }catch(Exception ex)
            {
                
            }
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
