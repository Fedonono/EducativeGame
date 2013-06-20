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

namespace Test_WPF.Friendship
{
    /// <summary>
    /// Interaction logic for RequestLine.xaml
    /// </summary>
    public partial class RequestLine : UserControl
    {
        public RequestLine()
        {
            InitializeComponent();
        }

        public void setName(string name)
        {
            this.lUsername.Content= name;
        }

        public void setGrade(string grade)
        {
            this.lGrade.Content = grade;
        }


        public void acceptFriendshipRequest()
        {
            Datas.User caller = (from u in Bdd.DbAccess.Users
                                 where u.username == this.lUsername.Content.ToString()
                                 select u).First();

            int idCaller = caller.ID;

            Datas.RelationshipRequest addRequest = (from ar in Bdd.DbAccess.RelationshipRequests
                                                    where ar.idCaller == idCaller
                                                    select ar).First();

            if (addRequest != null)
            {
                Datas.Relationship relationship = new Datas.Relationship()
                {
                    userId1 = App.user.ID,
                    userId2 = idCaller
                };

                Bdd.DbAccess.AddToRelationships(relationship);
                Bdd.DbAccess.DeleteObject(addRequest);
                Bdd.DbAccess.SaveChanges();
            }
        }

        private void bAccept_Click(object sender, RoutedEventArgs e)
        {
            this.acceptFriendshipRequest();
            App.mainWindow.GoToFriendship();
        }
    }
}
