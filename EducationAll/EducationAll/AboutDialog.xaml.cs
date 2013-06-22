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

namespace EducationAll
{
    /// <summary>
    /// Logique d'interaction pour AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog : Window
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = "Eric Allard \nArnaud Babol \nAdrien Ecrepont \nMaxence Prevost \nGuillaume Simonneau";
            this.textBox2.Text = "http://lelpel.deviantart.com/art/Dragon-Games-163676871 \n" +
                    "http://lelpel.deviantart.com/art/Lily-in-Oz-167713232 \n" +
                    "http://lelpel.deviantart.com/art/Snow-Day-176723890 \n" +
                    "http://lelpel.deviantart.com/art/Adventure-on-the-high-sea-175026436 \n" +
                    "http://lelpel.deviantart.com/art/Fun-Run-169145999 \n" +
                    "http://lelpel.deviantart.com/art/Who-Sunk-the-boat-178277088 \n" +
                    "http://lelpel.deviantart.com/art/Rainy-days-and-Mondays-176999626 \n" +
                    "http://lelpel.deviantart.com/art/Catching-Butterflies-178113599 \n" +
                    "http://www.deviantart.com/art/Butterfly-26156133 \n" +
                    "http://www.deviantart.com/art/Space-Monkey-91856964 \n" +
                    "http://intergalacticvoo.deviantart.com/art/Television-Education-91856322 \n" +
                    "http://mallardswoodspice.deviantart.com/art/Education-161806140 \n" +
                    "http://petuie.deviantart.com/art/education-176012916 \n" +
                    "http://nerdus.deviantart.com/art/Paper-Wings-356116553 \n" +
                    "http://geminisleviatan.deviantart.com/art/The-Forest-of-Houjie-369049504 \n" +
                    "http://darkmello.deviantart.com/art/Found-a-Moon-306263276 \n" +
                    "http://firatsolhan.deviantart.com/art/Don-Quijote-314834532 \n" +
                    "http://sheepalbinoblack.deviantart.com/art/Education-problems-79831469 \n" +
                    "http://tepasuka.deviantart.com/art/no-education-79368831 \n" +
                    "http://maxplay.deviantart.com/art/Education-52537268 \n" +
                    "http://ilona.deviantart.com/art/New-friends-20959212 \n" +
                    "http://ilona.deviantart.com/art/wind-14822827 \n" +
                    "http://ilona.deviantart.com/art/penquins-request-24531974 \n" +
                    "http://ilona.deviantart.com/art/hm-elephants-13599612 \n" +
                    "http://www.iconpharm.com \n" +
                    "http://paris.eelv.fr/tag/education/";
        }

        private void imgClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
