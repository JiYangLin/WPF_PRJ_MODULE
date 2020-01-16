using System.Windows.Controls;

namespace MahAppsMetroPrj
{
    using MahApps.Metro.Controls;
    using StarSkyNS;

    public sealed partial class MenuRipple : UserControl
    {
        public MenuRipple()
        {
            this.InitializeComponent();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            HamburgerMenuControl.Content = e.InvokedItem;
        }
    }
}