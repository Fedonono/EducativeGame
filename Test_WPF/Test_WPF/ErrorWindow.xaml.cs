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

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        private bool connexionError;

        public ErrorWindow(bool connexionError)
        {
            InitializeComponent();
            this.connexionError = connexionError;
            if (connexionError)
            {
                this.label1.Content = "Accès à la base de données impossible !";
                this.label2.Content = "Le programme doit se fermer.";
            }
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.connexionError)
            {
                Application.Current.Shutdown();
            }
            else
            {
                this.Close();
            }
        }
    }
}
