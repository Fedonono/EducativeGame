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
using System.Runtime.InteropServices;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour WelcomeDialog.xaml
    /// </summary>
    public partial class WelcomeDialog : Window
    {
        private bool connexion;

        public WelcomeDialog(bool connexion)
        {
            InitializeComponent();
            this.connexion = connexion;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.label1.Content = "Bienvenue " + App.user.username + " !";
            if (this.connexion)
            {
                this.lmessage.Margin = new Thickness(140, 260, 0, 0);
                this.lmessage.FontSize = 16;
                this.lmessage.Content = "Tout va bien depuis ta dernière visite ?\n" +
                    "Le " + App.user.Grade.name + " se passe bien ?";

                
                this.button1.Margin = new Thickness(240, 340, 0, 0);
                this.button1.Content = "Oui !";
            }
            else
            {
                this.lmessage.Margin = new Thickness(100, 248, 0, 0);
                this.lmessage.FontSize = 14;
                this.lmessage.Content = "Voici quelques conseils pour bien utiliser EducationAll :\n" +
                    "Ce programme est déstiné à toute personne désirant\napprendre en s'amusant.\n" +
                    "Des mini-jeux et questionnaires sont disponibles par catégories.\n" +
                    "Chaque jeu rapporte des points et peut être jouer contre un adversaire\n sous forme de défi.\n" +
                    "Les défis sont disponibles sur le menu principal et à la fin de chaque jeu.\n" +
                    "Bon apprentissage et amuse toi bien !";

                this.button1.Margin = new Thickness(220, 408, 0, 0);
                this.button1.Content = "J'ai compris !";
            }
        }
    }
}
