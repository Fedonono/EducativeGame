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
    /// <summary>    /// Logique d'interaction pour ChallengeControl.xaml
    /// </summary>
    public partial class ChallengeControl : UserControl
    {
        public ChallengeControl()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Datas.Dual> listNewDuals = from i in Bdd.DbAccess.Duals where i.idChallenged == App.user.ID && i.winner == null select i;
            IEnumerable<Datas.Dual> listPastDuals = from i in Bdd.DbAccess.Duals 
                                                     where (i.idChallenged == App.user.ID || i.idChallenger == App.user.ID)
                                                     && i.winner != null select i;

            foreach (Datas.Dual item in listNewDuals)
            {
                string username = (from i in Bdd.DbAccess.Users
                                   where i.ID == item.idChallenger
                                   select i.username).FirstOrDefault().ToString();
                string gameName = (from i in Bdd.DbAccess.Games
                                   where i.ID == item.idGame
                                   select i.name).FirstOrDefault().ToString();
                ChallengeButton cb = new ChallengeButton(username, gameName, false, false);
                cb.MouseLeftButtonDown += new MouseButtonEventHandler(cb_MouseLeftButtonDown);
                cb.Tag = item;
                this.listPastDuals.Children.Add(cb);
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
                bool win = item.winner == App.user.ID;
                this.listPastDuals.Children.Add(new ChallengeButton(username, gameName, true, win));
            }
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
