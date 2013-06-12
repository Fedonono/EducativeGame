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
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour WelcomeDialog.xaml
    /// </summary>
    public partial class WelcomeDialog : Window
    {
        private bool connexion;

        public WelcomeDialog(bool connexion)
        {
            InitializeComponent();
            this.connexion = connexion;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.connexion)
            {
                this.label2.Margin = new Thickness(140,260,0,0);
                this.label2.FontSize = 16;
                this.label2.Content = "Tout va bien depuis ta dernière visite ?";
                
                this.button1.Margin = new Thickness(240, 321, 0, 0);
                this.button1.Content = "Oui !";
            }
        }
    }
}
