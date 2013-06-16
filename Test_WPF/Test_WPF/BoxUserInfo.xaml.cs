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
using System.Collections;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour BoxUserInfo.xaml
    /// </summary>
    public partial class BoxUserInfo : UserControl
    {
        public BoxUserInfo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.user != null)
            {
                this.pseudoLabel.Content = App.user.username;
                this.nameLabel.Content = App.user.firstName + " " + App.user.name;
                this.gradeLabel.Content = App.user.Grade.name;
                int score = (int)(from i in Bdd.DbAccess.Scores where i.idUser == App.user.ID select i.value).Sum();
                this.scoreLabel.Content = "Score global : " + score;
            }
        }
    }
}
