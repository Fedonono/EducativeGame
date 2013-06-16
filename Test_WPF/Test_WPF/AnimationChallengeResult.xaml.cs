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

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour AnimationChallengeResult.xaml
    /// </summary>
    public partial class AnimationChallengeResult : UserControl
    {
        private Storyboard myStoryboard;
        public AnimationChallengeResult(string name1, string name2)
        {
            InitializeComponent();
            this.label1.Content = name1;
            this.label3.Content = name2;
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(7));
            myDoubleAnimation.AutoReverse = false;

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            this.animationGrid.Loaded += new RoutedEventHandler(animationGrid_Loaded);
        }

        void animationGrid_Loaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
    }
}
