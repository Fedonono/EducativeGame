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

namespace EducationAll
{
    /// <summary>
    /// Logique d'interaction pour AdminControl.xaml
    /// </summary>
    public partial class AdminControl : UserControl
    {
        public AdminControl()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Datas.Rank> ranks = new List<Datas.Rank>();
            try
            {
                ranks = Bdd.DbAccess.Ranks.ToList();
            }
            catch (Exception)
            {
                App.mainWindow.Close();
                ErrorWindow wd = new ErrorWindow(true);
                wd.ShowDialog();
            }
            foreach (Datas.Rank rank in ranks)
            {
                this.cBRank.Items.Add(rank);
            }
            if (ranks.Count > 0)
            {
                this.cBRank.SelectedItem = this.cBRank.Items.GetItemAt(0);
            }
        }

        private void bModifRank_Click(object sender, RoutedEventArgs e)
        {
            this.lUnexistingUser.Visibility = System.Windows.Visibility.Hidden;
            this.lModRankSuccess.Visibility = System.Windows.Visibility.Hidden;
            string pseudo = this.tBPseudo.Text;

            Datas.User user = (from u in Bdd.DbAccess.Users
                               where u.username.ToUpper() == pseudo.ToUpper()
                               select u).FirstOrDefault();
            if (user == null)
            {
                this.lUnexistingUser.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            
            Datas.Rank rank = (Datas.Rank)this.cBRank.SelectedItem;
            user.idRank = rank.ID;
            Bdd.DbAccess.SaveChanges();
            this.lModRankSuccess.Visibility = System.Windows.Visibility.Visible;
        }

        private void BMainMenu_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.GotoHome();
        }
    }
}
