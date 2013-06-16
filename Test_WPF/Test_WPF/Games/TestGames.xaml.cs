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
using System.Windows.Shapes;

namespace Test_WPF.Games
{
    /// <summary>
    /// Logique d'interaction pour TestGames.xaml
    /// </summary>
    public partial class TestGames : Window
    {
        public TestGames()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Transforme la fenetre pour obtenir le thème du menu principal
        /// </summary>
        private void setToMainWindow()
        {
            this.defaultBackground();
            this.programName.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.programName.FontSize = 30;
            this.programName.Margin = new Thickness(20, 10, 0, 0);
        }

        private void defaultBackground()
        {
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromRgb(254, 255, 211), 0.0));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromRgb(254, 243, 179), 0.4));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromRgb(255, 236, 167), 0.7));
            this.Background = myLinearGradientBrush;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.setToMainWindow();
            this.contentGrid.Children.Add(new Hangman(0, 0, -1));
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
