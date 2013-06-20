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
        private int idUser, points, idGame, idScore;

        public ChallengeResults(int idUser, int idGame, int idDefi, int idScore)
        {
            InitializeComponent();
            this.idGame = idGame;
            this.idUser = idUser;
            this.idScore = idScore;
            if (idDefi == -1)//il n'y a pas de défi donc on redirige directement vers la liste d'amis pour prochain défi
            {
                this.Bcontinue_Click(null, null);
                return;
            }
            try
            {
                this.dual = (from i in Bdd.DbAccess.Duals where i.ID == idDefi select i).FirstOrDefault();
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
            this.points = (int)(from i in Bdd.DbAccess.Scores where i.ID == idScore select i.value).FirstOrDefault(); ;
            this.lGameName.Content = (from i in Bdd.DbAccess.Games where i.ID == idGame select i.name).FirstOrDefault();
            string nameWinner = (from i in Bdd.DbAccess.Users where i.ID == this.dual.winner select i.username).FirstOrDefault();
            string nameLoser;
            if (this.dual.idChallenged == this.dual.winner)
            {
                nameLoser = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenger select i.username).FirstOrDefault();
            }
            else
            {
                nameLoser = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenged select i.username).FirstOrDefault();
            }
            int pointsChallenger;
            int.TryParse(((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenger select i.value).FirstOrDefault()).ToString(), out pointsChallenger);
            this.lResultWin.Content = nameWinner + " gagne !";
            if (this.dual.winner == idUser && pointsChallenger != points)
            {
                this.lResult.Content = "Félicitations !";
            }
            else if(this.dual.winner != idUser && pointsChallenger != points)
            {
                this.lResult.Content = "Dommage !";
            } else if(pointsChallenger == points)
            {
                this.lResult.Content = "Bien joué !";
                this.lResultWin.Content = "Egalité";
            }
            this.Display();
        }

        private void Error()
        {
            ErrorWindow wd = new ErrorWindow(false);
            wd.Owner = App.mainWindow;
            wd.ShowDialog();
            this.Bcontinue_Click(null, null);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.time == 0 && this.endAnim)
            {
                this.lResultWin.Visibility = System.Windows.Visibility.Visible;
                this.itrophy.Visibility = System.Windows.Visibility.Visible;
                this.lResult.Visibility = System.Windows.Visibility.Visible;
                this.lGameName.Visibility = System.Windows.Visibility.Visible;
                int pointsChallenger;
                int.TryParse(((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenger select i.value).FirstOrDefault()).ToString(), out pointsChallenger);
                if (this.dual.winner == this.idUser && pointsChallenger != this.points)
                {
                    this.iwin.Visibility = System.Windows.Visibility.Visible;
                    this.igirl.Visibility = System.Windows.Visibility.Visible;
                }
                else if (this.dual.winner != this.idUser && pointsChallenger != this.points)
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

        private void Display()
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.time = 0;
            this.timer.Start();
            this.endAnim = false;
            string name1 = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenged select i.username).FirstOrDefault();
            string name2 = (from i in Bdd.DbAccess.Users where i.ID == this.dual.idChallenger select i.username).FirstOrDefault();
            int points1;
            int.TryParse(((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenged select i.value).FirstOrDefault()).ToString(),out points1);
            int points2;
            int.TryParse(((from i in Bdd.DbAccess.Scores where i.ID == this.dual.idScoreChallenger select i.value).FirstOrDefault()).ToString(), out points2);
            this.acr = new AnimationChallengeResult(name1, name2, points1, points2);
            acr.EndOfAnimEvent += new AnimationChallengeResult.DelegateEndOfAnim(Acr_EndOfAnimEvent);
            this.mainGrid.Children.Add(acr);
        }

        private void Acr_EndOfAnimEvent()
        {
            this.endAnim = true;
            this.mainGrid.Children.Remove(this.acr);
        }

        private void Bcontinue_Click(object sender, RoutedEventArgs e)
        {
            this.mainGrid.Children.Clear();
            NewChallenge nc = new NewChallenge(this.idUser, this.idGame, this.idScore);
            nc.EndOfNewChallengeEvent += new NewChallenge.DelegateEndOfNewChallenge(Nc_EndOfNewChallengeEvent);
            this.mainGrid.Children.Add(nc);
        }

        void Nc_EndOfNewChallengeEvent()
        {
            this.mainGrid.Children.Clear();
            App.mainWindow.GotoHome();
        }
    }
}
