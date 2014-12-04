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
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace LdarDataDisplay.Core.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private IRegionManager regionManager;
        private bool isFullScreen = false;

        public MainWindow()
        {
            regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            RegionManager.SetRegionManager(this, regionManager);
            
            InitializeComponent();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (!isFullScreen)
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                mainMenu.Visibility = Visibility.Hidden;
                fullScreenMenuItem.Header = "Exit Full Screen";
                isFullScreen = true;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                mainMenu.Visibility = Visibility.Visible;
                fullScreenMenuItem.Header = "Full Screen";
                isFullScreen = false;
            }
            
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            mainMenu.Visibility = Visibility.Visible;
        }
    }
}
