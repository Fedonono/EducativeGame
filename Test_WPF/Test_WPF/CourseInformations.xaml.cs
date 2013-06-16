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
    /// Logique d'interaction pour CourseInformations.xaml
    /// </summary>
    public partial class CourseInformations : UserControl
    {
        private Storyboard myStoryboard;

        public CourseInformations(string gameName, string gradeName, string courseName, string gameDesc, int score, int nbGame)
        {
            InitializeComponent();
            this.gameNameLabel.Content = gameName;
            this.gradeLabel.Content = gradeName;
            this.courseLabel.Content = courseName;
            this.descriptionTextBlock.Text = gameDesc;
            this.scoreLabel.Content = score;
            this.numberGameLabel.Content = nbGame;
            
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0.0;
            myDoubleAnimation.To = 1.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
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
