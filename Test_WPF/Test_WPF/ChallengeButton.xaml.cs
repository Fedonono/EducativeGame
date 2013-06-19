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
    /// Logique d'interaction pour ChallengeButton.xaml
    /// </summary>
    public partial class ChallengeButton : UserControl
    {
        public ChallengeButton(string username, string gameName, bool over, bool win)
        {
            InitializeComponent();
            this.lusername.Content = username;
            this.lgameName.Content = gameName;
            if (over)
            {
                if (win)
                {
                    this.grid1.Background = Brushes.LightGreen;
                }
                else
                {
                    this.grid1.Background = Brushes.OrangeRed;
                }
            }
        }
    }
}
