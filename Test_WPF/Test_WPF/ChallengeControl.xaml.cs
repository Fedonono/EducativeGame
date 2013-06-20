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
using System.Windows.Threading;

namespace Test_WPF
{
    /// <summary>    /// Logique d'interaction pour ChallengeControl.xaml
    /// </summary>
    public partial class ChallengeControl : UserControl
    {
        private DispatcherTimer timer;
        private int time;

        public ChallengeControl()
        {
            InitializeComponent();
        }
        
        void timer_Tick(object sender, EventArgs e)
        {
            if (this.time < 3)
            {
                this.time++;
            }
            if (this.time == 3 && App.user != null)
            {
                this.time++;
                this.timer.Stop();
                this.lload1.Visibility = System.Windows.Visibility.Hidden;
                this.lload2.Visibility = System.Windows.Visibility.Hidden;
                this.display();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.time = 0;
            this.timer.Start();
        }

        private void display()
        {
            App.mainWindow.Cursor = new Cursor(new System.IO.MemoryStream(Test_WPF.Properties.Resources.WaitCursor));
            IEnumerable<Datas.Dual> listNewDuals;
            IEnumerable<Datas.Dual> listPastDuals;
            try
            {
                listNewDuals = from i in Bdd.DbAccess.Duals where i.idChallenged == App.user.ID && i.winner == null select i;
                listPastDuals = from i in Bdd.DbAccess.Duals
                                where (i.idChallenged == App.user.ID || i.idChallenger == App.user.ID)
                                && i.winner != null
                                select i;
            }
            catch (Exception)
            {
                return;
            }

            this.lnew.Content = string.Format("À relever ({0})", listNewDuals.Count());
            this.lpast.Content = string.Format("Passés ({0})", listPastDuals.Count());

            foreach (Datas.Dual item in listNewDuals)
            {
                string username = (from i in Bdd.DbAccess.Users
                                   where i.ID == item.idChallenger
                                   select i.username).FirstOrDefault().ToString();
                string gameName = (from i in Bdd.DbAccess.Games
                                   where i.ID == item.idGame
                                   select i.name).FirstOrDefault().ToString();
                int score1 = (int)(from i in Bdd.DbAccess.Scores where i.ID == item.idScoreChallenger select i.value).FirstOrDefault();
                ChallengeButton cb = new ChallengeButton(username, gameName, item.date, score1, 0, false, false);
                cb.MouseLeftButtonDown += new MouseButtonEventHandler(cb_MouseLeftButtonDown);
                cb.Tag = item;
                this.slistNewDuals.Children.Add(cb);
            }

            foreach (Datas.Dual item in listPastDuals)
            {
                string username = (from i in Bdd.DbAccess.Users
                                   where (i.ID == item.idChallenged && i.ID != App.user.ID) ||
                                   (i.ID == item.idChallenger && i.ID != App.user.ID)
                                   select i.username).FirstOrDefault().ToString();
                string gameName = (from i in Bdd.DbAccess.Games
                                   where i.ID == item.idGame
                                   select i.name).FirstOrDefault().ToString();
                int score1 = (int)(from i in Bdd.DbAccess.Scores where i.ID == item.idScoreChallenger select i.value).FirstOrDefault();
                int score2 = (int)(from i in Bdd.DbAccess.Scores where i.ID == item.idScoreChallenged select i.value).FirstOrDefault();
                bool win = item.winner == App.user.ID;
                this.slistPastDuals.Children.Add(new ChallengeButton(username, gameName, item.date, score1, score2, true, win));
            }

            App.mainWindow.Cursor = Cursors.Arrow;
        }

        void cb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChallengeButton s = sender as ChallengeButton;
            if (s.Tag != null)
            {
                Datas.Dual d = s.Tag as Datas.Dual;
                Datas.Game game = (from i in Bdd.DbAccess.Games where d.idGame == i.ID select i).FirstOrDefault();
                try
                {
                    if (game.className == "QuestionaryControl")
                    {
                        int id = (int)game.idQuestionary;
                        App.mainWindow.launchGame(new QuestionaryControl(App.user.ID, game.ID, d.ID, id));
                    }
                    else
                    {
                        Type game1 = Type.GetType("Test_WPF.Games." + game.className);
                        object o = Activator.CreateInstance(game1, App.user.ID, game.ID, d.ID);
                        App.mainWindow.launchGame(o as IGame);
                    }
                }
                catch (Exception)
                {
                    ErrorWindow wd = new ErrorWindow();
                    wd.Owner = App.mainWindow;
                    wd.ShowDialog();
                }
            }
        }
    }
}
