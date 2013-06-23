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

namespace EducationAll.Games
{
    /// <summary>
    /// Logique d'interaction pour Colouring.xaml
    /// </summary>
    public partial class Colouring : UserControl, IGame
    {
        private int idUser, idGame, idDefi, score, img;

        public Colouring(int idUser, int idGame, int idDefi)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.idGame = idGame;
            this.idDefi = idDefi;
            this.score = 0;
            this.img = 1;
        }

        /// <summary>
        /// impression de l'image et ajout de point si imprime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { 
                dialog.PrintVisual(this.iColouring, "Coloriage");
                this.score += 5;
                this.lScore.Content = "Score : " + this.score;
            }
        }

        private void BContinue_Click(object sender, RoutedEventArgs e)
        {
            this.EndOfGame();
        }

        /// <summary>
        /// Affiche l'image suivante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            if (this.img == 4)
            {
                this.img = 1;
            }
            else
            {
                this.img++;
            }
            Uri uri = new Uri(@"pack://application:,,,/EducationAll;component/Images/Colouring/" + this.img + ".PNG");
            this.iColouring.Source = new BitmapImage(uri);
        }

        public event DelegateEndOfGame EndOfGameEvent;

        public void EndOfGame()
        {
            if (EndOfGameEvent != null)
                EndOfGameEvent(this.idUser, this.idGame, this.idDefi, this.score);
        }
    }
}
