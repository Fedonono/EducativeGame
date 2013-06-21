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
using Test_WPF.Friendship;

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
            this.printFriendsList();
            this.printRelationshipRequests();
        }

        public void printFriendsList()
        {
            IEnumerable<Datas.Relationship> relationships = from r in Bdd.DbAccess.Relationships
                                                             where r.userId1 == App.user.ID
                                                             select r;

            this.sPRelationship.Children.Clear();
            foreach (Datas.Relationship relationship in relationships)
            {
                Datas.User friend = (from u in Bdd.DbAccess.Users
                              where u.ID == relationship.userId2
                              select u).FirstOrDefault();

                if (friend == null) { return; }
                Datas.Grade grade = (from g in Bdd.DbAccess.Grades
                           where g.ID == friend.idGrade
                           select g).FirstOrDefault();
                if (grade == null) { return; }

                FriendLine line = new FriendLine();
                line.setName(friend.username, friend.ID);
                line.setGrade(grade.name);

                this.sPRelationship.Children.Add(line);
            }
        }

        public void printRelationshipRequests()
        {
            IEnumerable<Datas.RelationshipRequest> relationshipRequests = from ar in Bdd.DbAccess.RelationshipRequests
                                                                           where ar.idCalled == App.user.ID
                                                                           select ar;


            this.sPRelationshipRequest.Children.Clear();
            foreach (Datas.RelationshipRequest request in relationshipRequests)
            {
                Datas.User caller = (from u in Bdd.DbAccess.Users
                                     where u.ID == request.idCaller
                                     select u).FirstOrDefault();
                if (caller == null) { return; }
                Datas.Grade grade = (from g in Bdd.DbAccess.Grades
                                     where g.ID == caller.idGrade
                                     select g).FirstOrDefault();
                if (grade == null) { return; }

                RequestLine line = new RequestLine();
                line.setName(caller.username, caller.ID);
                line.setGrade(grade.name);
                this.sPRelationshipRequest.Children.Add(line);
            }
        }

        public void sendFriendshipRequest()
        {

            this.lInvitationSent.Visibility = System.Windows.Visibility.Hidden;
            this.lUnexistingUser.Visibility = System.Windows.Visibility.Hidden;
            this.lAlreadyExistingRelationshipRequest.Visibility = System.Windows.Visibility.Hidden;
            this.lAlreadyExistingRelationship.Visibility = System.Windows.Visibility.Hidden;
            this.lInvitationToMe.Visibility = System.Windows.Visibility.Hidden;

            string pseudo = this.tBPseudo.Text;

            Datas.User user = (from u in Bdd.DbAccess.Users
                        where u.username.ToUpper() == pseudo.ToUpper()
                        select u).FirstOrDefault();
            if (user == null) { 
                this.lUnexistingUser.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            if (user.ID == App.user.ID)
            {
                this.lInvitationToMe.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            
            
            Datas.Relationship relationship = (from r in Bdd.DbAccess.Relationships
                                where (r.userId1 == App.user.ID && r.userId2 == user.ID)
                                || (r.userId1 == user.ID && r.userId2 == App.user.ID)
                                select r).FirstOrDefault();
            if (relationship != null) { 
                this.lAlreadyExistingRelationship.Visibility = System.Windows.Visibility.Visible;
                return;
            }


            Datas.RelationshipRequest relationshipRequest = (from rr in Bdd.DbAccess.RelationshipRequests
                                       where (rr.idCaller == App.user.ID && rr.idCalled == user.ID)
                                       || (rr.idCalled == App.user.ID && rr.idCaller == user.ID)
                                       select rr).FirstOrDefault();
            if (relationshipRequest != null) { 
                this.lAlreadyExistingRelationshipRequest.Visibility = System.Windows.Visibility.Visible;
                return;
            }

            Datas.RelationshipRequest addRequest = new Datas.RelationshipRequest()
            {
                idCaller = App.user.ID,
                idCalled = user.ID
            };

            Bdd.DbAccess.AddToRelationshipRequests(addRequest);
            Bdd.DbAccess.SaveChanges();

            this.lInvitationSent.Visibility = System.Windows.Visibility.Visible;
        }

        private void bSendRequest_Click(object sender, EventArgs e)
        {
            this.sendFriendshipRequest();
        }
    }
}
