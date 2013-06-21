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

namespace EducationAll
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
                int score = 0;
                try
                {
                    score = (int)(from i in Bdd.DbAccess.Scores where i.idUser == App.user.ID select i.value).Sum();
                }
                catch (Exception)
                {
                }
                this.scoreLabel.Content = "Score global : " + score;

                int nbFriends = 0;
                try
                {
                    nbFriends = (int)(from i in Bdd.DbAccess.Relationships where i.userId1 == App.user.ID select i).Count();
                }
                catch (Exception)
                {
                }
                this.friendsLabel.Content = nbFriends + " amis";

                this.ChangeImage();
            }
        }

        private void ChangeImage()
        {
            int img = new Random().Next(1,7);

            ImageSource imageSource = new BitmapImage(new Uri(@"pack://application:,,,/EducationAll;component/Images/ImageProfil/" + img + ".png"));

            this.image1.Source = imageSource;
        }
    }
}
