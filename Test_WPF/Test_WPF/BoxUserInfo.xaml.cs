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
    /// Logique d'interaction pour BoxUserInfo.xaml
    /// </summary>
    public partial class BoxUserInfo : UserControl
    {
        public BoxUserInfo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.pseudoLabel.Content = App.User.username;
            this.nameLabel.Content = App.User.firstName + " " + App.User.name;
            this.gradeLabel.Content = App.User.Grade.name;
        }
    }
}
