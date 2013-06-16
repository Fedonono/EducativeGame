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
using Test_WPF.Games;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        private UIElement currentCourseInfo;
        
        public MainMenu()
        {
            InitializeComponent();
            this.currentCourseInfo = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.launchGame(new Additions1_ce1());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.launchGame(new Hangman());
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Datas.Course> coursesList = from i in Bdd.DbAccess.Courses where i.idGrade == App.user.idGrade select i;
            foreach (Datas.Course course in coursesList)
            {
                Button bt = new Button() {Content = course.name, Tag = course, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10)};
                bt.Click += new RoutedEventHandler(clickButton);
                this.coursesPanel.Children.Add(bt);
            }
        }

        private void clickButton(object sender, EventArgs e)
        {
            Datas.Course tag = ((Button)sender).Tag as Datas.Course;
            int id = (int)tag.ID;
            IEnumerable<Datas.Game> gamesList = from i in Bdd.DbAccess.Games where i.idCourse == id select i;
            this.gamesPanel.Children.Clear();
            foreach (Datas.Game game in gamesList)
            {
                Button bt = new Button() { Content = game.name, Tag = game, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10) };
                bt.Click += new RoutedEventHandler(launchGame);
                bt.MouseEnter += new MouseEventHandler(bt_MouseEnter);
                bt.MouseLeave += new MouseEventHandler(bt_MouseLeave);
                this.gamesPanel.Children.Add(bt);
            }

        }

        void bt_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.currentCourseInfo != null && this.mainMenuContentGrid.Children.Contains(this.currentCourseInfo))
            {
                this.mainMenuContentGrid.Children.Remove(this.currentCourseInfo);
            }
        }

        void bt_MouseEnter(object sender, MouseEventArgs e)
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
                    nbGame = (int)(from i in Bdd.DbAccess.Scores where i.idGame == tag.ID && i.idUser == App.user.ID select i.value).Count();
                }
                catch (Exception)
                {
                }
                
                UIElement cci = new CourseInformations(tag.name, App.user.Grade.name, courseName, "description", score, nbGame);
                this.currentCourseInfo = cci;
                this.mainMenuContentGrid.Children.Add(this.currentCourseInfo);
            }
        }

        private void launchGame(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.Tag != null)
            {
                Datas.Game tag = bt.Tag as Datas.Game;
                int id = (int)tag.idQuestionary;
                App.mainWindow.launchGame(new QuestionaryControl(id));
            }
        }
    }
}

