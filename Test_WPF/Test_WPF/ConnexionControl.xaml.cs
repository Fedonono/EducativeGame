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
    /// Logique d'interaction pour ConnexionControl.xaml
    /// </summary>
    public partial class ConnexionControl : UserControl
    {
        public ConnexionControl()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 2012; i > 1930; i--)
            {
                this.comboBoxBirth.Items.Add(i);
            }
            this.comboBoxBirth.SelectedItem = this.comboBoxBirth.Items.GetItemAt(0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.connexionControlClicked(sender,e ,true);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.connexionControlClicked(sender, e, false);
        }

        private void registerUser()
        {
            string passhash = Bdd.SHA1(this.passwordBoxInscr.Password);
            Datas.User u = new Datas.User() { username = this.textBoxInscrPseudo.Text, password = passhash, mail = this.textBoxInscrMail.Text, firstName = this.textBoxInscrPrenom.Text, name = this.textBoxInscrNom.Text, idGrade = 1, idRank = 1 };
            Bdd._db.AddToUsers(u);
            Bdd._db.SaveChanges();
        }
    }
}
