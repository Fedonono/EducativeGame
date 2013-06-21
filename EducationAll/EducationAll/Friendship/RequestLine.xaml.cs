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

namespace EducationAll.Friendship
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

        public void setName(string name, int id)
        {
            this.lUsername.Content= name;
            this.lUsername.Tag = id;
        }

        public void setGrade(string grade)
        {
            this.lGrade.Content = grade;
        }


        public void acceptFriendshipRequest()
        {
            int search = (int)this.lUsername.Tag;
            Datas.User caller = (from u in Bdd.DbAccess.Users
                                 where u.ID == search
                                 select u).FirstOrDefault();

            if (caller != null)
            {
                Datas.RelationshipRequest addRequest = (from ar in Bdd.DbAccess.RelationshipRequests
                                                        where ar.idCaller == caller.ID
                                                        select ar).FirstOrDefault();

                if (addRequest != null)
                {
                    Datas.Relationship relationship1 = new Datas.Relationship()
                    {
                        userId1 = App.user.ID,
                        userId2 = caller.ID
                    };

                    Datas.Relationship relationship2 = new Datas.Relationship()
                    {
                        userId2 = App.user.ID,
                        userId1 = caller.ID
                    };

                    Datas.Relationship relationship1Exists = (from i in Bdd.DbAccess.Relationships
                                                              where i.userId1 == App.user.ID
                                                              && i.userId2 == caller.ID
                                                              select i).FirstOrDefault();
                    Datas.Relationship relationship2Exists = (from i in Bdd.DbAccess.Relationships
                                                              where i.userId2 == App.user.ID
                                                              && i.userId1 == caller.ID
                                                              select i).FirstOrDefault();
                    if (relationship1Exists == null)
                    {
                        Bdd.DbAccess.AddToRelationships(relationship1);
                    }
                    if (relationship2Exists == null)
                    {
                        Bdd.DbAccess.AddToRelationships(relationship2);
                    }
                    Bdd.DbAccess.DeleteObject(addRequest);
                    Bdd.DbAccess.SaveChanges();
                }
            }
        }

        private void bAccept_Click(object sender, RoutedEventArgs e)
        {
            this.acceptFriendshipRequest();
            App.mainWindow.GoToFriendship();
        }

        private void bRefus_Click(object sender, RoutedEventArgs e)
        {
            this.refusFriendshipRequest();
            App.mainWindow.GoToFriendship();
        }

        private void refusFriendshipRequest()
        {
            int search = (int)this.lUsername.Tag;
            Datas.User caller = (from u in Bdd.DbAccess.Users
                                 where u.ID == search
                                 select u).FirstOrDefault();

            if (caller != null)
            {
                Datas.RelationshipRequest addRequest = (from ar in Bdd.DbAccess.RelationshipRequests
                                                        where ar.idCaller == caller.ID
                                                        select ar).FirstOrDefault();

                if (addRequest != null)
                {
                    Datas.Relationship relationship1Exists = (from i in Bdd.DbAccess.Relationships
                                                              where i.userId1 == App.user.ID
                                                              && i.userId2 == caller.ID
                                                              select i).FirstOrDefault();
                    Datas.Relationship relationship2Exists = (from i in Bdd.DbAccess.Relationships
                                                              where i.userId2 == App.user.ID
                                                              && i.userId1 == caller.ID
                                                              select i).FirstOrDefault();
                    if (relationship1Exists != null)
                    {
                        Bdd.DbAccess.DeleteObject(relationship1Exists);
                    }
                    if (relationship2Exists != null)
                    {
                        Bdd.DbAccess.DeleteObject(relationship2Exists);
                    }
                    Bdd.DbAccess.DeleteObject(addRequest);
                    Bdd.DbAccess.SaveChanges();
                }
            }
        }
    }
}
