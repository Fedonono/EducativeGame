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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour ChallengeResults.xaml
    /// </summary>
    public partial class ChallengeResults : UserControl
    {
        private DispatcherTimer timer;
        private int time;

        public ChallengeResults()
        {
            InitializeComponent();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.time++;
            if (this.time == 5)
            {
                this.label4.Visibility = System.Windows.Visibility.Visible;
                this.image2.Visibility = System.Windows.Visibility.Visible;
            }
            if (this.time == 8)
            {
                App.mainWindow.gotoHome();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.time = 0;
            this.timer.Start();
            this.mainGrid.Children.Add(new AnimationChallengeResult("Eric","Arnaud"));
        }
    }
}
