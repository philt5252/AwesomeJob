using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LdarDataDisplay.Foundation.Views;

namespace LdarDataDisplay.Core.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            WindowStyle= WindowStyle.None;
            WindowState=WindowState.Maximized;
            mainMenu.Visibility=Visibility.Hidden;
        }
    }
}
