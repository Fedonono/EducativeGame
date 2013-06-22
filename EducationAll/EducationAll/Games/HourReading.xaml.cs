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
using EducationAll.Games;

namespace EducationAll.Games
{
    /// <summary>
    /// Logique d'interaction pour Heure.xaml
    /// </summary>
    public partial class HourReading : UserControl, IGame
    {
        public HourReading(int idUser, int idGame, int idDefi)
        {
            InitializeComponent();

            this.idUser = idUser;
            this.idGame = idGame;
            this.idDefi = idDefi;

            this.score = 90;

            Random r = new Random();
            this.minutes = r.Next(60);
            this.hours = r.Next(12);
            this.minutes = this.minutes - this.minutes % 10;
            
            this.tBAnswerH.Text = ""+this.hours;
            this.tBAnswerM.Text = ""+this.minutes;

            this.initCanvas(this.hours, this.minutes);
        }

        private int minutes, hours;
        private int idUser, idGame, idDefi, score;

        private void initCanvas(int hours, int minutes)
        {
            Line hour = new Line();
            Line minute = new Line();

            hour.Stroke = Brushes.Green;
            minute.Stroke = Brushes.Orange;

            hour.StrokeThickness = 9;
            minute.StrokeThickness = 5;

            hour.X1 = 200;
            hour.Y1 = 200;
            minute.X1 = 200;
            minute.Y1 = 200;
            
            int radius = 150;
            double angle = (Math.PI * this.hours / 6)- Math.PI / 2 ; //+ (Math.PI/60) * this.minutes;
            hour.Y2 = hour.X1 + (radius - 0.4 * radius) * Math.Sin(angle);
            hour.X2 = hour.Y1 + (radius - 0.4 * radius) * Math.Cos(angle);
            angle = (Math.PI * this.minutes / 30) -  Math.PI / 2;
            minute.X2 = minute.X1 + radius * Math.Cos(angle);
            minute.Y2 = minute.Y1 + radius * Math.Sin(angle);

            this.cClock.Children.Add(minute);
            this.cClock.Children.Add(hour);

            Ellipse dot = new Ellipse();
            dot.Height = 20;
            dot.Width = 20;
            dot.Fill = Brushes.Black;
            dot.Margin = new Thickness(200 - dot.Width/2, 200 - dot.Width/2, 0, 0);
            this.cClock.Children.Add(dot);
        }

        public event DelegateEndOfGame EndOfGameEvent;

        public void EndOfGame()
        {
            if (EndOfGameEvent != null)
                EndOfGameEvent(this.idUser, this.idGame, this.idDefi, this.score);
        }

        private void validate(object sender, RoutedEventArgs e)
        {
            int answHours = int.Parse(this.tBAnswerH.Text);
            int answMinuts = int.Parse(this.tBAnswerM.Text);

            if ((this.minutes == answMinuts && this.hours == answHours) || this.hours + answHours == 12 || this.minutes + answMinuts == 60)
            {
                this.EndOfGame();
            }
            else
            {
                this.decreasePoints();
            }
        }

        private void decreasePoints()
        {
            this.score -= 30;
            if (this.score <= 0)
            {
                this.EndOfGame();
            }
        }

    }

}
