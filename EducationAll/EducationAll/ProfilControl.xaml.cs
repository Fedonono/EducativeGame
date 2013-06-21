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
    /// Logique d'interaction pour ProfilControl.xaml
    /// </summary>
    public partial class ProfilControl : UserControl
    {
        public ProfilControl()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Datas.Grade> grades = Bdd.DbAccess.Grades.ToList();
            foreach (Datas.Grade grade in grades)
            {
                this.cbLevel.Items.Add(grade);
                if (grade.ID == App.user.idGrade)
                {
                    this.cbLevel.SelectedItem = grade;
                }
            }
        }

        private void BValidateLevel_Click(object sender, RoutedEventArgs e)
        {
            Datas.Grade grade = (Datas.Grade)this.cbLevel.SelectedItem;
            App.user.idGrade = grade.ID;
            Bdd.DbAccess.SaveChanges();
            this.lLevel.Content = "Changement validé !";
        }

        private void CbLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lLevel.Content = String.Empty;
        }

        private void BValidatePass_Click(object sender, RoutedEventArgs e)
        {
            if (CheckChangePass())
            {
                App.user.password = Bdd.SHA1(this.tNewPass.Password);
                Bdd.DbAccess.SaveChanges();
                this.lPass.Content = "Changement de mot de passe effectué !";
            }
        }

        private bool CheckChangePass()
        {
            string newPass = Bdd.SHA1(this.tNewPass.Password);
            bool check = true;
            this.lOldPass.Content = String.Empty;
            this.lNewPass.Content = String.Empty;
            this.lNotCorrespond.Content = String.Empty;
            this.lPass.Content = String.Empty;
            if (!Bdd.SHA1(this.tOldPass.Password).Equals(App.user.password))
            {
                this.lOldPass.Content = "Mot de Passe incorrect";
                check = false;
            }
            if (newPass.Equals(App.user.password))
            {
                this.lNewPass.Content = "Le nouveau mot de passe doit être différent de l'ancien !";
                check = false;
            }
            if (!this.tNewPass.Password.Equals(this.tNewPassBis.Password))
            {
                this.lNotCorrespond.Content = "Les mots de passe ne correspondent pas";
                check = false;
            }
            return check;
        }

        private void BMainMenu_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.GotoHome();
        }
    }
}
