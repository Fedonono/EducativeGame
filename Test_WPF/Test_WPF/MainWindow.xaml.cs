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
using WpfConnexionControlLibrary;
using WpfLoadControlLibrary;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UIElement currentUIElement;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.currentUIElement = new LoadControl();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void contentGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.currentUIElement is LoadControl)
            {
                this.contentGrid.Children.Remove(this.currentUIElement);
                this.currentUIElement = new ConnexionControl();
                this.contentGrid.Children.Add(this.currentUIElement);
            }
        }
    }
}
