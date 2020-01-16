using MyAppender;
using System;
using System.Windows;
using System.Windows.Input;
using FluentRibbonPrj.source;
namespace FluentRibbonPrj.ui
{
    /// <summary>
    /// setcol.xaml 的交互逻辑
    /// </summary>
    public partial class setcol
    {
        public setcol()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            namecol.Text = cfgOpt.namecol.ToString();
            agecol.Text = cfgOpt.agecol.ToString();

            Cursor cur = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "/curFile.cur");
            this.Cursor = cur;
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
                MyLogger.logger.Error(ex);
            }
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
