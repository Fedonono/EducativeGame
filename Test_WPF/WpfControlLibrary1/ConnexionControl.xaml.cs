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

namespace WpfControlLibrary1
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
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
    }
}
