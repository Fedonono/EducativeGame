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
            List<Datas.Relationship> friends = (from r in Bdd.DbAccess.Relationships 
                                                where r.userId1 == App.user.ID 
                                                || r.userId1 == App.user.ID 
                                                select r).ToList();

            foreach (Datas.Relationship friend in friends)
            {
                //affiche les
            }
        }

        public void printAddRequests()
        {
            List<Datas.RelationshipRequest> relationshipRequests = (from ar in Bdd.DbAccess.RelationshipRequests
                                                  where ar.idCalled == App.user.ID
                                                  select ar).ToList();

            foreach (Datas.RelationshipRequest request in relationshipRequests)
            {
                //affiche les
            }
        }

        public void sendFriendshipRequest()
        {
            Datas.User user = (from u in Bdd.DbAccess.Users 
                               where u.username == this.tBPseudo.Text 
                               select u).First();

            Datas.Relationship relationship = (from r in Bdd.DbAccess.Relationships 
                                               where (r.userId1 == App.user.ID && r.userId2 == user.ID)
                                               || (r.userId1 == user.ID && r.userId2 == App.user.ID)
                                               select r).First();

            if (user != null)
            {
                if(relationship == null){
                    Datas.RelationshipRequest addRequest = new Datas.RelationshipRequest()
                    {
                        idCaller = App.user.ID,
                        idCalled = user.ID
                    };

                    Bdd.DbAccess.AddToRelationshipRequests(addRequest);
                    Bdd.DbAccess.SaveChanges();

                }else{
                    //l'amitié existe déjà
                }
            }else{
                //l'utilisateur recherché n'existe pas
            }
        }

        public void acceptFriendshipRequest(int idCaller)
        {
            Datas.RelationshipRequest addRequest = (from ar in Bdd.DbAccess.RelationshipRequests 
                                           where ar.idCaller == idCaller 
                                           select ar).First();

            if(addRequest != null)
            {
                Datas.Relationship relationship = new Datas.Relationship(){
                    userId1 = App.user.ID,
                    userId2 = idCaller
                };

                Bdd.DbAccess.AddToRelationships(relationship);
                Bdd.DbAccess.DeleteObject(addRequest);
                Bdd.DbAccess.SaveChanges();
            }
        }
    }
}
