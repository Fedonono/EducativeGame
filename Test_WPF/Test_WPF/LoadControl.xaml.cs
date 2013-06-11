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
    /// Logique d'interaction pour LoadControl.xaml
    /// </summary>
    public partial class LoadControl : UserControl
    {
        public LoadControl()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.lawsLabel.Content = "Ce programme est protégé par les lois \n" +
                "françaises et internationales comme \n" +
                "indiqué dans la fenêtre À propos.";
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.loadControlClicked(sender,e);
        }
    }
}
