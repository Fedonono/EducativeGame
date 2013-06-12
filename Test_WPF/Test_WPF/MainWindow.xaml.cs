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
using Test_WPF.Games;

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
            Application.Current.Shutdown();
        }

        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.currentUIElement = new LoadControl();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        /// <summary>
        /// Affiche le menu de connexion après avoir cliqué sur l'image d'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void loadControlClicked(object sender, MouseButtonEventArgs e)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = new ConnexionControl();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        /// <summary>
        /// Affiche le menu principal après avoir été connecté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void connexionControlClicked(object sender, RoutedEventArgs e, bool connexion)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.setToMainWindow();
            this.currentUIElement = new MainMenu();
            this.contentGrid.Children.Add(this.currentUIElement);
            WelcomeDialog wd = new WelcomeDialog(connexion);
            wd.Owner = this;
            wd.ShowDialog();
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
                new GradientStop(Color.FromRgb(231, 255, 255), 0.0));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromRgb(228, 255, 255), 0.4));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromRgb(239, 255, 255), 0.7));
            this.Background = myLinearGradientBrush;
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {

        }

        public void testJeuCalculCe1(object sender, RoutedEventArgs e)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = new Additions1_ce1();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        private void image3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutDialog wd = new AboutDialog();
            wd.Owner = this;
            wd.ShowDialog();
        }
    }
}
