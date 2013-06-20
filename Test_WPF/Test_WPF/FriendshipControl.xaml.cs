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
    /// Interaction logic for FriendshipControl.xaml
    /// </summary>
    public partial class FriendshipControl : UserControl
    {
        public FriendshipControl()
        {
            InitializeComponent();
        }

        public void printFriendsList()
        {
            IEnumerable<Datas.Relationship> relationships = (from r in Bdd.DbAccess.Relationships
                                                             where r.userId1 == App.user.ID
                                                             || r.userId1 == App.user.ID
                                                             select r).ToList();

            this.sPRelationship.Children.Clear();
            foreach (Datas.Relationship relationship in relationships)
            {
                Datas.User friend;
                if (relationship.userId1 == App.user.ID)
                {
                    friend = (from u in Bdd.DbAccess.Users
                              where u.ID == relationship.userId2
                              select u).First();
                }
                else
                {
                    friend = (from u in Bdd.DbAccess.Users
                              where u.ID == relationship.userId1
                              select u).First();
                }
                Label friendName = new Label();
                friendName.Content = friend.username + ", ";
                this.sPRelationship.Children.Add(friendName);
            }
        }

        public void printAddRequests()
        {
            IEnumerable<Datas.RelationshipRequest> relationshipRequests = (from ar in Bdd.DbAccess.RelationshipRequests
                                                                           where ar.idCalled == App.user.ID
                                                                           select ar).ToList();


            this.sPRelationshipRequest.Children.Clear();
            foreach (Datas.RelationshipRequest request in relationshipRequests)
            {
                Datas.User caller = (from u in Bdd.DbAccess.Users
                                     where u.ID == request.idCaller
                                     select u).First();

                Label callerName = new Label();
                callerName.Content = caller.username;
                
                Button accept = new Button();
                accept.Name = caller.username;
                accept.Content = "+";

                this.sPRelationshipRequest.Children.Add(callerName);
                this.sPRelationshipRequest.Children.Add(accept);
            }
        }

        public void sendFriendshipRequest()
        {
            string pseudo = this.tBPseudo.Text;

            Datas.User user = (from u in Bdd.DbAccess.Users
                               where u.username == pseudo
                               select u).First();

            Datas.Relationship relationship = (from r in Bdd.DbAccess.Relationships
                                               where (r.userId1 == App.user.ID && r.userId2 == user.ID)
                                               || (r.userId1 == user.ID && r.userId2 == App.user.ID)
                                               select r).First();

            Datas.RelationshipRequest relationshipRequest = (from rr in Bdd.DbAccess.RelationshipRequests
                                                             where rr.idCaller == App.user.ID && rr.idCalled == user.ID
                                                             select rr).First();

            if (user != null)
            {
                if (relationship == null)
                {
                    if (relationshipRequest == null)
                    {

                        Datas.RelationshipRequest addRequest = new Datas.RelationshipRequest()
                        {
                            idCaller = App.user.ID,
                            idCalled = user.ID
                        };

                        Bdd.DbAccess.AddToRelationshipRequests(addRequest);
                        Bdd.DbAccess.SaveChanges();

                    }
                    else
                    {
                        //une demande à déjà été envoyé
                    }
                }
                else
                {
                    //l'amitié existe déjà
                }
            }
            else
            {
                //l'utilisateur recherché n'existe pas
            }
        }

        public void acceptFriendshipRequest(int idCaller)
        {
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



        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
    }
}
