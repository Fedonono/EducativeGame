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
    /// Logique d'interaction pour AnimationChallengeResult.xaml
    /// </summary>
    public partial class AnimationChallengeResult : UserControl
    {
        private DispatcherTimer timer;
        private Storyboard myStoryboard;
        private int points1, points2, currentPoints1, currentPoints2;
        private bool endAnim;
        private int time;

        public delegate void DelegateEndOfAnim();
        public event DelegateEndOfAnim EndOfAnimEvent;

        public AnimationChallengeResult(string name1, string name2, int points1, int points2)
        {
            InitializeComponent();
            this.lname1.Content = name1;
            this.lname2.Content = name2;
            this.points1 = points1;
            this.points2 = points2;
            this.currentPoints1 = 0;
            this.currentPoints2 = 0;
            this.endAnim = false;
            this.time = 0;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0.0;
            myDoubleAnimation.To = 1.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            myDoubleAnimation.AutoReverse = false;

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            this.animationGrid.Loaded += new RoutedEventHandler(animationGrid_Loaded);

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.currentPoints1 <= this.points1 && !this.endAnim)
            {
                this.lpoints1.Content = this.currentPoints1;
                this.currentPoints1++;
            }
            if (this.currentPoints2 <= this.points2 && !this.endAnim)
            {
                this.lpoints2.Content = this.currentPoints2;
                this.currentPoints2++;
            }
            if (this.currentPoints1 == this.points1+1 && this.currentPoints2 == this.points2+1 && !this.endAnim)
            {
                this.endAnim = true;
                this.timer.Stop();
                this.timer.Interval = new TimeSpan(0, 0, 0, 1);
                this.timer.Start();
                this.time++;
            }
            if (this.endAnim && this.time > 0 && this.time < 4)
            {
                this.time++;
            }
            if (this.endAnim && this.time == 4)
            {
                if (EndOfAnimEvent != null)
                    EndOfAnimEvent();
            }
        }

        private void animationGrid_Loaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
    }
}
