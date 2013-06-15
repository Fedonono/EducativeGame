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
    /// <summary>
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
         public MainMenu()
        {
            InitializeComponent();
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
            List<Datas.Course> coursesList = Bdd.DbAccess.Courses.ToList();
            foreach (Datas.Course course in coursesList)
            {
                Button bt = new Button() {Content = course.name, Tag = course.ID, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10)};
                bt.Click += new RoutedEventHandler(clickButton);
                this.coursesPanel.Children.Add(bt);
            }
        }

        private void clickButton(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            IEnumerable<Datas.Game> gamesList = from i in Bdd.DbAccess.Games where i.idCourse == id select i;
            this.gamesPanel.Children.Clear();
            foreach (Datas.Game game in gamesList)
            {
                Button bt = new Button() { Content = game.name, Tag = game.idQuestionary, FontSize = 20, Padding = new Thickness(25), Margin = new Thickness(10) };
                bt.Click += new RoutedEventHandler(launchGame);
                this.gamesPanel.Children.Add(bt);
            }

        }
        private void launchGame(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.Tag != null)
            {
                int id = (int)bt.Tag;
                App.mainWindow.launchGame(new QuestionaryControl(id));
            }
        }
    }
}

