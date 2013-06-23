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

namespace EducationAll
{
    /// <summary>
    /// Logique d'interaction pour ChallengeButton.xaml
    /// </summary>
    public partial class ChallengeButton : UserControl
    {
        public ChallengeButton(string username, string gameName, DateTime date, int score1, int score2, bool over, bool win)
        {
            InitializeComponent();
            this.lUsername.Content = username;
            this.lGameName.Content = gameName;
            this.lDate.Content = date.ToShortDateString();
            if (over)
            {
                if (win && score1 != score2)//gagné = vert
                {
                    this.grid1.Background = Brushes.YellowGreen;
                }
                else if (!win && score1 != score2)//perdu = orange
                {
                    this.grid1.Background = Brushes.OrangeRed;
                }//égalité = gris
                this.lScore.Content = string.Format("Scores : {0}/{1}", score1, score2);
            }
            else
            {
                this.grid1.Background = Brushes.Yellow;
                this.lScore.Content = string.Format("Scores : {0}/{1}", score1, "?");
            }
        }
    }
}
