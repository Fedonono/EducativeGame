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
            List<Datas.Relationship> friends = (from r in Bdd.DbAccess.Relationships where r.userId1 == 1 || r.userId1 == 1 select r).ToList();

            foreach (Datas.Relationship friend in friends)
            {
                //affiche les
            }
        }

        public void printAddRequests()
        {
            List<Datas.AddRequest> addRequests = (from ar in Bdd.DbAccess.AddRequests  where ar.idCalled == 1).ToList();

            foreach (Datas.AddRequest request in addRequests)
            {
                //affiche les
            }
        }

        public void addFriend()
        {
            Datas.User users = (from u in Bdd.DbAccess.Users where u.username == this.tBPseudo.Text select u).First();

            //TODO
        }
    }
}
