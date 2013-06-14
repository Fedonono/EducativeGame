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
            List<Datas.Grade> grades = Bdd._db.Grades.ToList();
            foreach (Datas.Grade grade in grades)
            {
                this.comboBoxInscrForm.Items.Add(grade);
            }
            if (grades.Count > 0)
            {
                this.comboBoxInscrForm.SelectedItem = this.comboBoxInscrForm.Items.GetItemAt(0);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.login(sender, e);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (this.RegisterUser())
            {
                App.mainWindow.connexionControlClicked(sender, e, false);
            }
        }

        private void login(object sender, RoutedEventArgs e)
        {
            string shaPass = Bdd.SHA1(this.passwordBoxConn.Password);
            Datas.User user = (from u in Bdd._db.Users where u.username == this.textBoxConn.Text && u.password == shaPass select u).FirstOrDefault();
            if (user != null)
            {
                App.User = user;
                App.mainWindow.connexionControlClicked(sender,e ,true);
            }
        }

        private bool RegisterUser()
        {
            // todo gerer exception pour savoir si pas de doublon au niveau de l'username
            string uName = this.textBoxInscrPseudo.Text;
            DateTime uDate = this.dateBirth.DisplayDate;
            string uPass = this.passwordBoxInscr.Password;
            bool check = true;

            if (uName == "")
            {
                this.lUsername.Content = "Veuillez saisir un nom d'utilisateur";
                check = false;
            }
            if (uPass == "")
            {
                this.lPass.Content = "Veuillez saisir un mot de passe";
                check = false;
            }
            if (!check)
            {
                return false;
            }
            string passhash = Bdd.SHA1(uPass);
            try
            {
                Datas.Grade grade = (Datas.Grade)this.comboBoxInscrForm.SelectedItem;
                Datas.User u = new Datas.User() { username = this.textBoxInscrPseudo.Text, password = passhash, mail = this.textBoxInscrMail.Text, firstName = this.textBoxInscrPrenom.Text, name = this.textBoxInscrNom.Text, birthDate = uDate, idRank = 10, idGrade = grade.ID };
                Bdd._db.AddToUsers(u);
                Bdd._db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                this.lError.Content = "Erreur lors de l'ajout de l'inscription dans la BDD, veuillez réesayer ou contacter un administrateur.";
                return false;
            }
        }
    }
}
