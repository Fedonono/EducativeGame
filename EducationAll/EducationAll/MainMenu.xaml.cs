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
using EducationAll.Games;
using System.Windows.Threading;

namespace EducationAll
{
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        private UIElement currentCourseInfo;

        private DispatcherTimer timer;
        private int time;
        
        public MainMenu()
        {
            InitializeComponent();
            this.currentCourseInfo = null;
        }

        /// <summary>
        /// Affiche les cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Datas.Course> coursesList = from i in Bdd.DbAccess.Courses where i.idGrade == App.user.idGrade select i;
            foreach (Datas.Course course in coursesList)
            {
                Button bt = new Button() {Content = course.name, Tag = course, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10)};
                bt.Click += new RoutedEventHandler(ClickButton);
                this.coursesPanel.Children.Add(bt);
            }

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.time = 0;
            this.timer.Start();
        }

        /// <summary>
        /// Mets à jour la liste de jeu en fonction du cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton(object sender, EventArgs e)
        {
            Datas.Course tag = ((Button)sender).Tag as Datas.Course;
            int id = (int)tag.ID;
            IEnumerable<Datas.Game> gamesList = from i in Bdd.DbAccess.Games where i.idCourse == id select i;
            this.gamesPanel.Children.Clear();
            foreach (Datas.Game game in gamesList)
            {
                Button bt = new Button() { Content = game.name, Tag = game, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10) };
                int nbPlayed = (from i in Bdd.DbAccess.Scores where i.idGame == game.ID && i.idUser == App.user.ID select i).Count();
                if (nbPlayed > 0)
                {
                    bt.Background = Brushes.LightGreen;
                }
                bt.Click += new RoutedEventHandler(LaunchGame);
                bt.MouseEnter += new MouseEventHandler(Bt_MouseEnter);
                bt.MouseLeave += new MouseEventHandler(Bt_MouseLeave);
                this.gamesPanel.Children.Add(bt);
            }

        }

        /// <summary>
        /// Retire les infos du jeu selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.currentCourseInfo != null && this.mainMenuContentGrid.Children.Contains(this.currentCourseInfo))
            {
                this.mainMenuContentGrid.Children.Remove(this.currentCourseInfo);
            }
        }

        /// <summary>
        /// Affiche des informations sur le jeu selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.currentCourseInfo != null && this.mainMenuContentGrid.Children.Contains(this.currentCourseInfo))
            {
                this.mainMenuContentGrid.Children.Remove(this.currentCourseInfo);
            }
            Button bt = (Button)sender;
            if (bt.Tag != null && bt.Tag is Datas.Game)
            {
                Datas.Game tag = bt.Tag as Datas.Game;
                string courseName = (from i in Bdd.DbAccess.Courses where i.ID == tag.idCourse select i).FirstOrDefault().name;
                int score = 0;
                int nbGame = 0;
                try
                {
                    score = (int)(from i in Bdd.DbAccess.Scores where i.idGame == tag.ID && i.idUser == App.user.ID select i.value).Max();
                    nbGame = (from i in Bdd.DbAccess.Scores where i.idGame == tag.ID && i.idUser == App.user.ID select i).Count();
                }
                catch (Exception)
                {
                }
                
                UIElement cci = new CourseInformations(tag.name, App.user.Grade.name, courseName, tag.description, score, nbGame);
                this.currentCourseInfo = cci;
                this.mainMenuContentGrid.Children.Add(this.currentCourseInfo);
            }
        }

        /// <summary>
        /// Lance un jeu à partir de son nom dans la bdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchGame(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.Tag != null && bt.Tag is Datas.Game)
            {
                Datas.Game tag = bt.Tag as Datas.Game;
                try
                {
                    if (tag.className == "QuestionaryControl")
                    {
                        int id = (int)tag.idQuestionary;
                        App.mainWindow.LaunchGame(new QuestionaryControl(App.user.ID, tag.ID, -1, id));
                    }
                    else
                    {
                        Type game = Type.GetType("EducationAll.Games." + tag.className);
                        object o = Activator.CreateInstance(game, App.user.ID, tag.ID, -1);
                        App.mainWindow.LaunchGame(o as IGame);
                    }
                }
                catch (Exception)
                {
                    ErrorWindow wd = new ErrorWindow(false);
                    wd.Owner = App.mainWindow;
                    wd.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Affiche les popups de nouveaux défis et requetes d'amis après un certain temps pour éviter de tout charger en même temps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Timer_Tick(object sender, EventArgs e)
        {
            if (this.time < 4)
            {
                this.time++;
            }
            if (this.time == 4)
            {
                this.time++;
                if (App.user != null)
                {
                    int newDuals = (from i in Bdd.DbAccess.Duals where i.idChallenged == App.user.ID && i.winner == null select i).Count();
                    if (newDuals > 0)
                    {
                        this.lNewChallenge.Content = string.Format("Tu as {0} nouveau{1} défi{2} en attente !", newDuals, newDuals > 1 ? "x" : "", newDuals > 1 ? "s" : "");
                        this.bnewChallenge.Content = string.Format("Je vais le{0} relever !", newDuals > 1 ? "s" : "");
                        this.lNewChallenge.Visibility = System.Windows.Visibility.Visible;
                        this.inewChallenge.Visibility = System.Windows.Visibility.Visible;
                        this.bnewChallenge.Visibility = System.Windows.Visibility.Visible;
                    }
                }

            }
            
            if (this.time == 6)
            {
                this.time++;
                if (App.user != null)
                {
                    IEnumerable<Datas.RelationshipRequest> relationshipRequests = from ar in Bdd.DbAccess.RelationshipRequests
                                                                                  where ar.idCalled == App.user.ID
                                                                                  select ar;
                    if (relationshipRequests != null && relationshipRequests.Count() > 0)
                    {
                        this.lNewFriend.Content = string.Format("Tu as {0} requête{1} d'ami en attente !", relationshipRequests.Count(), relationshipRequests.Count() > 1 ? "s" : "");
                        this.bNewFriend.Content = string.Format(relationshipRequests.Count() > 1 ? "Je vais les accepter !" : "Je vais l'accepter !");
                        this.lNewFriend.Visibility = System.Windows.Visibility.Visible;
                        this.iNewFriend.Visibility = System.Windows.Visibility.Visible;
                        this.bNewFriend.Visibility = System.Windows.Visibility.Visible;
                    }
                }
                this.timer.Stop();
            }
            if (this.time == 5)
            {
                this.time++;
            }
        }

        private void BnewChallenge_Click(object sender, RoutedEventArgs e)
        {
            this.lNewChallenge.Visibility = System.Windows.Visibility.Hidden;
            this.inewChallenge.Visibility = System.Windows.Visibility.Hidden;
            this.bnewChallenge.Visibility = System.Windows.Visibility.Hidden;
        }

        private void bNewFriend_Click(object sender, RoutedEventArgs e)
        {
            this.lNewFriend.Visibility = System.Windows.Visibility.Hidden;
            this.iNewFriend.Visibility = System.Windows.Visibility.Hidden;
            this.bNewFriend.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Affiche tous les jeux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAllGames_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Datas.Game> gamesList = from i in Bdd.DbAccess.Games 
                                                from course in Bdd.DbAccess.Courses
                                                where i.idCourse == course.ID
                                                && course.idGrade == App.user.idGrade
                                                select i;
            this.gamesPanel.Children.Clear();
            foreach (Datas.Game game in gamesList)
            {
                Button bt = new Button() { Content = game.name, Tag = game, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10) };
                int nbPlayed = (from i in Bdd.DbAccess.Scores where i.idGame == game.ID && i.idUser == App.user.ID select i).Count();
                if (nbPlayed > 0)
                {
                    bt.Background = Brushes.LightGreen;
                }
                bt.Click += new RoutedEventHandler(LaunchGame);
                bt.MouseEnter += new MouseEventHandler(Bt_MouseEnter);
                bt.MouseLeave += new MouseEventHandler(Bt_MouseLeave);
                this.gamesPanel.Children.Add(bt);
            }
        }
    }
}

