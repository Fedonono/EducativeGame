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
            Bdd.DbAccess.Connection.Close();
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
        public void loadControlClicked()
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
        public void connexionControlClicked(bool connexion)
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
            this.programName.FontSize = 35;
            this.programName.Margin = new Thickness(20, 10, 0, 0);
            this.image4.Visibility = System.Windows.Visibility.Visible;
            this.image5.Visibility = System.Windows.Visibility.Visible;
            this.image6.Visibility = System.Windows.Visibility.Visible;
        }

        private void defaultBackground()
        {
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop((Color)ColorConverter.ConvertFromString("#FFD4E7FF"), 0.0));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop((Color)ColorConverter.ConvertFromString("#FFC7E4FF"), 0.1));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop((Color)ColorConverter.ConvertFromString("#FFEFFFFF"), 0.2));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop((Color)ColorConverter.ConvertFromString("#FFC7E4FF"), 0.3));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop((Color)ColorConverter.ConvertFromString("#FFC7E4FF"), 0.7));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop((Color)ColorConverter.ConvertFromString("#FFEFFFFF"), 0.9));
            this.Background = myLinearGradientBrush;

            if (App.user != null)
            {
                int grade = App.user.Grade.ID;

                ImageBrush ib = new ImageBrush();
                Uri uri = new Uri(@"pack://application:,,,/Test_WPF;component/Images/Backgrounds/Ubuntu_wp_b_3_1600.jpg");
                switch (grade)
                {
                    case 5:
                        uri = new Uri(@"pack://application:,,,/Test_WPF;component/Images/Backgrounds/paper_wings_by_nerdus-d5w0tah.jpg");
                        break;
                    case 7:
                        uri = new Uri(@"pack://application:,,,/Test_WPF;component/Images/Backgrounds/catching_butterflies_by_lelpel-d2y1lbz.jpg");
                        break;
                    default:
                        
                        break;
                }
                ib.ImageSource = new BitmapImage(uri);
                ib.Stretch = Stretch.UniformToFill;
                this.Background = ib;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {

        }

        private void image3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutDialog wd = new AboutDialog();
            wd.Owner = this;
            wd.ShowDialog();
        }

        private void image6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.gotoHome();
        }

        private void image4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.user = null;
            App.CurrentApp.app_Startup(null,null);
        }

        private void image5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //AboutDialog wd = new AboutDialog();
            //wd.Owner = this;
            //wd.ShowDialog();
        }

        public void launchGame(UIElement gamePanel)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = gamePanel;
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        public void gotoHome()
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = new MainMenu();
            this.contentGrid.Children.Add(this.currentUIElement);
        }
    }
}
