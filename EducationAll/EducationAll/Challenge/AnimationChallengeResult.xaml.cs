﻿using System;
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

namespace EducationAll
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
            this.lName1.Content = name1;
            this.lName2.Content = name2;
            this.points1 = points1;
            this.points2 = points2;
            this.currentPoints1 = 0;
            this.currentPoints2 = 0;
            this.endAnim = false;
            this.time = 0;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0.0;//fondu
            myDoubleAnimation.To = 1.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            myDoubleAnimation.AutoReverse = false;

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            this.animationGrid.Loaded += new RoutedEventHandler(AnimationGrid_Loaded);

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Start();
        }

        /// <summary>
        /// Fait défiler les points puis arrete l'animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.currentPoints1 <= this.points1 && !this.endAnim)
            {
                this.lPoints1.Content = this.currentPoints1;
                this.currentPoints1++;
            }
            if (this.currentPoints2 <= this.points2 && !this.endAnim)
            {
                this.lPoints2.Content = this.currentPoints2;
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

        private void AnimationGrid_Loaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
    }
}
