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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour ChallengeResults.xaml
    /// </summary>
    public partial class ChallengeResults : UserControl
    {
        private DispatcherTimer timer;
        private int time;
        private bool endAnim;
        private AnimationChallengeResult acr;
        private Datas.Dual dual;
        private int idUser, points;

        public ChallengeResults(int idUser, int idGame, int idDefi, int points)
        {
            InitializeComponent();
            if (idDefi == -1)//il n'y a pas de défi donc on redirige directement vers la liste d'amis pour prochain défi
            {
                this.bcontinue_Click(null, null);
            }
            try
            {
                this.dual = ((from i in Bdd.DbAccess.Duals where i.ID == idDefi select i).FirstOrDefault()) as Datas.Dual;
            }
            catch (Exception)
            {
                this.Error();
                return;
            }
            if (this.dual == null)
            {
                this.Error();
                return;
            }
            this.idUser = idUser;
            this.points = points;
            this.lgameName.Content = from i in Bdd.DbAccess.Games where i.ID == idGame select i.name;
            string nameWinner = (from i in Bdd.DbAccess.Users where i.ID == this.dual.winner select i.username).ToString();
            string nameLoser;
            if (this.dual.idChallenged == this.dual.winner)
            {
                nameLoser = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenger select i.username).ToString();
            }
            else
            {
                nameLoser = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenged select i.username).ToString();
            }
            int pointsChallenger;
            int.TryParse((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenger select i.value).ToString(), out pointsChallenger);
            this.lresultWin.Content = nameWinner + " gagne !";
            if (this.dual.winner == idUser && pointsChallenger != points)
            {
                this.lresult.Content = "Félicitations !";
            }
            else if(this.dual.winner != idUser && pointsChallenger != points)
            {
                this.lresult.Content = "Dommage !";
            } else if(pointsChallenger == points)
            {
                this.lresult.Content = "Bien joué !";
            }
        }

        private void Error()
        {
            ErrorWindow wd = new ErrorWindow();
            wd.Owner = App.mainWindow;
            wd.ShowDialog();
            this.bcontinue_Click(null, null);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.time == 0 && this.endAnim)
            {
                this.lresultWin.Visibility = System.Windows.Visibility.Visible;
                this.igirl.Visibility = System.Windows.Visibility.Visible;
                this.itrophy.Visibility = System.Windows.Visibility.Visible;
                this.iwin.Visibility = System.Windows.Visibility.Visible;
                this.lresult.Visibility = System.Windows.Visibility.Visible;
                int pointsChallenger;
                int.TryParse((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenger select i.value).ToString(), out pointsChallenger);
                if (this.dual.winner == this.idUser && pointsChallenger != this.points)
                {
                    this.iwin.Visibility = System.Windows.Visibility.Visible;
                }
                else if (this.dual.winner != idUser && pointsChallenger != this.points)
                {
                    this.ifail.Visibility = System.Windows.Visibility.Visible;
                }
                else if (pointsChallenger == points)
                {
                    this.iequality.Visibility = System.Windows.Visibility.Visible;
                }
                this.time++;
            }
            if (this.time > 0 && this.time < 5)
            {
                this.time++;
            }
            if (this.time == 5)
            {
                this.bcontinue.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.time = 0;
            this.timer.Start();
            this.endAnim = false;
            string name1 = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenged select i.username).ToString();
            string name2 = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenger select i.username).ToString();
            int points1;
            int.TryParse((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenged select i.value).ToString(),out points1);
            int points2;
            int.TryParse((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenger select i.value).ToString(), out points2);
            this.acr = new AnimationChallengeResult(name1, name2, points1, points2);
            acr.EndOfAnimEvent += new AnimationChallengeResult.DelegateEndOfAnim(acr_EndOfAnimEvent);
            this.mainGrid.Children.Add(acr);
        }

        private void acr_EndOfAnimEvent()
        {
            this.endAnim = true;
            this.mainGrid.Children.Remove(this.acr);
        }

        private void bcontinue_Click(object sender, RoutedEventArgs e)
        {
            //vers le défi d'un autre ami
        }
    }
}
