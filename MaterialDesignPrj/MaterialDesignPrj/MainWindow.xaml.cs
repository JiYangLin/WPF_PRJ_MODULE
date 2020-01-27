using MaterialDesignThemes.Wpf;
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

namespace MaterialDesignPrj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ItemCount
        {
            public Brush Color { get; private set; }
            public int Value { get; private set; }

            public ItemCount(Brush color, int value)
            {
                Color = color;
                Value = value;
            }
        }
        public class MenuItem
        {
            public String Name { get; private set; }
            public PackIconKind Icon { get; private set; }
            public ItemCount Count { get; private set; }

            public MenuItem(String name, PackIconKind icon, ItemCount count)
            {
                Name = name;
                Icon = icon;
                Count = count;
            }
        }
        List<MenuItem> Menus = new List<MenuItem>();
        public MainWindow()
        {
            InitializeComponent();

            Menus.Add(new MenuItem("图片", PackIconKind.Image, new ItemCount(Brushes.Black, 2)));
            Menus.Add(new MenuItem("音乐", PackIconKind.Music, new ItemCount(Brushes.DarkBlue, 4)));
            Menus.Add(new MenuItem("视频", PackIconKind.Video, new ItemCount(Brushes.DarkGreen, 7)));
            Menus.Add(new MenuItem("文档", PackIconKind.Folder, new ItemCount(Brushes.DarkOrange, 9)));
            menu.ItemsSource = Menus;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = menu.SelectedIndex;
            if (index < 0) return;
            if (index >= Menus.Count) return;
            lb.Content = Menus[index].Name + Menus[index].Count.Value;
        }
    }
}
