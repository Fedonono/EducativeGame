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
            App.mainWindow.testJeuCalculCe1(sender, e);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }



        private void clickButton(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            IEnumerable<Datas.Game> gamesList = from i in Bdd._db.Games where i.idCourse == id select i;
            this.gamesPanel.Children.Clear();
            foreach (Datas.Game game in gamesList)
            {
                    Button bt = new Button() {Content = game.name , Tag = game.ID , Padding = new Thickness(25), Margin = new Thickness(10)};
                    this.gamesPanel.Children.Add(bt);
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Datas.Course> coursesList = Bdd._db.Courses.ToList();
            foreach (Datas.Course course in coursesList)
            {
                Button bt = new Button() {Content = course.name, Tag = course.ID, Padding = new Thickness(25), Margin = new Thickness(10)};
                bt.Click += new RoutedEventHandler(clickButton);
                this.coursesPanel.Children.Add(bt);
            }
        }
    }
}

