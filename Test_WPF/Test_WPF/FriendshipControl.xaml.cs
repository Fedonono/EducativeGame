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
            List<Datas.Relationship> friends = (from r in Bdd.DbAccess.Relationships where r.userId1 == App.user.ID || r.userId1 == App.user.ID select r).ToList();

            foreach (Datas.Relationship friend in friends)
            {
                //affiche les
            }
        }

        public void printAddRequests()
        {
            List<Datas.AddRequest> addRequests = (from ar in Bdd.DbAccess.AddRequests  where ar.idCalled == App.user.ID).ToList();

            foreach (Datas.AddRequest request in addRequests)
            {
                //affiche les
            }
        }

        public void sendFriendshipRequest()
        {
            Datas.User user = (from u in Bdd.DbAccess.Users where u.username == this.tBPseudo.Text select u).First();
            Datas.Relationship relationship = (from r in Bdd.DbAccess.Relationships 
                                               where (r.userId1 == App.user.ID && r.userId2 == user.ID)
                                               || (r.userId1 == user.ID && r.userId2 == App.user.ID));

            if (user != null)
            {
                if(relationship == null){
                    Datas.AddRequest addRequest = new Datas.AddRequest()
                    {
                        idCaller = App.user.ID,
                        idCalled = user.ID
                    };

                    Bdd.DbAccess.AddToAddRequests(addRequest);
                    Bdd.DbAccess.SaveChanges();

                }else{
                    //l'amitié existe déjà
                }
            }else{
                //l'utilisateur n'existe pas
            }
        }

        public void acceptFriendshipRequest(int idCaller)
        {
            Datas.AddRequest addRequest = (from ar in Bdd.DbAccess.AddRequests where ar.idCaller == idCaller select ar).First(

            if(addRequest != null)
            {
                Datas.Relationship relationship = new Datas.Relationship(){
                    userId1 = App.user.ID,
                    userId2 = idCaller
                };

                Bdd.DbAccess.AddToRelationships(relationship);
                // supprimer la addRequest
                Bdd.DbAccess.SaveChanges();
            }
        }
    }
}
