﻿using System;
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
using EducationAll.Games;

namespace EducationAll
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

        /// <summary>
        /// Drag fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Bdd.DbAccess.Connection.Close();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Minimise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
        public void LoadControlClicked()
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
        public void ConnexionControlClicked(bool connexion)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.SetToMainWindow();
            this.currentUIElement = new MainMenu();
            this.contentGrid.Children.Add(this.currentUIElement);
            WelcomeDialog wd = new WelcomeDialog(connexion);
            wd.Owner = this;
            wd.ShowDialog();
        }

        /// <summary>
        /// Transforme la fenetre pour obtenir le thème du menu principal
        /// </summary>
        private void SetToMainWindow()
        {
            this.DefaultBackground();
            this.programName.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.programName.FontSize = 40;
            this.programName.Margin = new Thickness(20, 10, 0, 0);
            this.imgLogoutIcon.Visibility = System.Windows.Visibility.Visible;
            this.imgHomeIcon.Visibility = System.Windows.Visibility.Visible;
            this.imgFriendIcon.Visibility = System.Windows.Visibility.Visible;
            this.imgUserIcon.Visibility = System.Windows.Visibility.Visible;
            if (App.user.isAdmin())
            {
                this.imgAdminIcon.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        /// Change le fond d'écran en fonction du grade de l'utilisateur
        /// </summary>
        private void DefaultBackground()
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
                Uri uri = new Uri(@"pack://application:,,,/EducationAll;component/Images/Backgrounds/Education_by_mallardswoodspice.jpg");
                switch (grade)
                {
                    case 1:
                        uri = new Uri(@"pack://application:,,,/EducationAll;component/Images/Backgrounds/wind_by_ilona.jpg");
                        break;
                    case 2:
                        uri = new Uri(@"pack://application:,,,/EducationAll;component/Images/Backgrounds/Butterfly_by_ilona.jpg");
                        break;
                    case 3:
                        uri = new Uri(@"pack://application:,,,/EducationAll;component/Images/Backgrounds/catching_butterflies_by_lelpel-d2y1lbz.jpg");
                        break;
                    default:
                        
                        break;
                }
                ib.ImageSource = new BitmapImage(uri);
                ib.Stretch = Stretch.UniformToFill;
                this.Background = ib;
            }
        }

        /// <summary>
        /// Affiche la fenetre A propos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutDialog wd = new AboutDialog();
            wd.Owner = this;
            wd.ShowDialog();
        }

        /// <summary>
        /// Go to Admin Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Admin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.GoToAdmin();
        }

        public void GoToAdmin()
        {
            this.contentGrid.Children.Clear();
            this.currentUIElement = new AdminControl();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        /// <summary>
        /// Go to home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.GotoHome();
        }

        private void Friend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.GoToFriendship();
        }

        public void GoToFriendship()
        {
            this.contentGrid.Children.Clear();
            this.currentUIElement = new FriendshipControl();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        /// <summary>
        /// Déconnexion utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.user = null;
            App.CurrentApp.App_Startup(null,null);
            this.Close();
        }

        /// <summary>
        /// Affichage profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = new ProfilControl();
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        /// <summary>
        /// Lance un jeu et écoute son évenement d'arret
        /// </summary>
        /// <param name="gamePanel"></param>
        public void LaunchGame(IGame gamePanel)
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = gamePanel as UIElement;
            gamePanel.EndOfGameEvent += new DelegateEndOfGame(GamePanel_EndOfGameEvent);
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        /// <summary>
        /// Evenement d'arret du jeu en cours
        /// Enregistre le score et lance la fenetre de défi
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idGame"></param>
        /// <param name="idDefi"></param>
        /// <param name="points"></param>
        void GamePanel_EndOfGameEvent(int idUser, int idGame, int idDefi, int points)
        {
            Datas.Score s = new Datas.Score() { idGame = idGame, idUser = idUser, value = points };
            Bdd.DbAccess.AddToScores(s);
            Bdd.DbAccess.SaveChanges();
            if (idDefi != -1)
            {
                if (s != null)
                {
                    Datas.Dual d = (from i in Bdd.DbAccess.Duals where i.ID == idDefi select i).FirstOrDefault();
                    if (d != null)
                    {
                        d.idScoreChallenged = s.ID;
                        Bdd.DbAccess.SaveChanges();
                        int idChallenger = d.idChallenger;
                        int scoreChallenger = (int)(from i in Bdd.DbAccess.Scores where d.idScoreChallenger == i.ID select i.value).FirstOrDefault();
                        if (s.value >= scoreChallenger)
                        {
                            d.winner = App.user.ID;
                        }
                        else
                        {
                            d.winner = idChallenger;
                        }
                        Bdd.DbAccess.SaveChanges();
                    }
                }
            }
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = new ChallengeResults(idUser, idGame, idDefi, s.ID);
            this.contentGrid.Children.Add(this.currentUIElement);
        }

        public void GotoHome()
        {
            this.contentGrid.Children.Remove(this.currentUIElement);
            this.currentUIElement = new MainMenu();
            this.contentGrid.Children.Add(this.currentUIElement);
        }
    }
}
