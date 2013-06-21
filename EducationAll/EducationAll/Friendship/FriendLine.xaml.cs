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
    /// Interaction logic for FriendLine.xaml
    /// </summary>
    public partial class FriendLine : UserControl
    {
        public FriendLine()
        {
            InitializeComponent();
        }

        public void setName(string name, int id)
        {
            this.lUsername.Content = name;
            this.lUsername.Tag = id;
        }

        public void setGrade(string grade)
        {
            this.lGrade.Content = grade;
        }

        private void bDel_Click(object sender, RoutedEventArgs e)
        {
            this.delFriend();
            App.mainWindow.GoToFriendship();
        }

        private void delFriend()
        {
            int search = (int)this.lUsername.Tag;
            Datas.User caller = (from u in Bdd.DbAccess.Users
                                 where u.ID == search
                                 select u).FirstOrDefault();

            if (caller != null)
            {
                Datas.Relationship relationship1 = (from ar in Bdd.DbAccess.Relationships
                                                        where ar.userId1 == caller.ID && ar.userId2 == App.user.ID
                                                        select ar).FirstOrDefault();
                Datas.Relationship relationship2 = (from ar in Bdd.DbAccess.Relationships
                                                    where ar.userId2 == caller.ID && ar.userId1 == App.user.ID
                                                    select ar).FirstOrDefault();

                if (relationship1 != null && relationship2 != null)
                {
                    Bdd.DbAccess.DeleteObject(relationship1);
                    Bdd.DbAccess.DeleteObject(relationship2);
                    Bdd.DbAccess.SaveChanges();
                }
            }
        }
    }
}
