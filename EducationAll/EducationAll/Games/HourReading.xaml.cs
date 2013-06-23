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
using System.Windows.Threading;

namespace EducationAll.Games
{
    /// <summary>
    /// Logique d'interaction pour Heure.xaml
    /// </summary>
    public partial class HourReading : UserControl, IGame
    {
        private int minutes, hours, left;
        private int idUser, idGame, idDefi, score;
        private DispatcherTimer timer;
        private int time;

        public HourReading(int idUser, int idGame, int idDefi)
        {
            InitializeComponent();

            this.idUser = idUser;
            this.idGame = idGame;
            this.idDefi = idDefi;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.startGame();
        }

        private void startGame()
        {
            this.score = 90;
            this.left = 6;
            this.lLeft.Content = "Heures restantes : " + this.left;
            this.lScore.Content = "Ton score : " + this.score;
            this.lGameOver.Visibility = System.Windows.Visibility.Hidden;
            this.tBAnswerH.Visibility = System.Windows.Visibility.Visible;
            this.tBAnswerM.Visibility = System.Windows.Visibility.Visible;
            this.label1.Visibility = System.Windows.Visibility.Visible;
            this.label2.Visibility = System.Windows.Visibility.Visible;
            this.bValidate.Visibility = System.Windows.Visibility.Visible;
            this.bRe.Visibility = System.Windows.Visibility.Hidden;
            this.bContinue.Visibility = System.Windows.Visibility.Hidden;
            this.lEndMessage.Visibility = System.Windows.Visibility.Hidden;
            this.nextHour();
        }

        /// <summary>
        /// heure aléatoire
        /// </summary>
        private void nextHour()
        {
            Random r = new Random();
            this.minutes = r.Next(60);
            this.hours = r.Next(12);
            this.minutes = this.minutes - this.minutes % 10;

            this.tBAnswerH.Text = "";
            this.tBAnswerM.Text = "";
            this.initCanvas(this.hours, this.minutes);
        }

        /// <summary>
        /// affiche les aiguilles
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        private void initCanvas(int hours, int minutes)
        {
            this.cClock.Children.Clear();
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
            double angle = (Math.PI * this.hours / 6) - Math.PI / 2;
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
            this.tBAnswerH.Focus();
        }

        public event DelegateEndOfGame EndOfGameEvent;

        public void EndOfGame()
        {
            this.lGameOver.Visibility = System.Windows.Visibility.Visible;
            this.tBAnswerH.Visibility = System.Windows.Visibility.Hidden;
            this.tBAnswerM.Visibility = System.Windows.Visibility.Hidden;
            this.label1.Visibility = System.Windows.Visibility.Hidden;
            this.label2.Visibility = System.Windows.Visibility.Hidden;
            this.bValidate.Visibility = System.Windows.Visibility.Hidden;
            this.bRe.Visibility = System.Windows.Visibility.Visible;
            this.bContinue.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// vérifie l'heure entrée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validate(object sender, RoutedEventArgs e)
        {
            int answHours = -1;
            int answMinuts = -1;
            try
            {
                answHours = int.Parse(this.tBAnswerH.Text);
                answMinuts = int.Parse(this.tBAnswerM.Text);
            }
            catch (Exception)
            {
            }

            if ((this.minutes == answMinuts && this.hours == answHours) || this.hours + answHours == 12 || this.minutes + answMinuts == 60)
            {
                this.left--;
                this.lLeft.Content = "Heures restantes : " + this.left;
                if(this.left == 0)
                {
                    this.lEndMessage.Content = "Bravo !";
                    this.lEndMessage.Visibility = System.Windows.Visibility.Visible;
                    this.EndOfGame();
                    return;
                }
            }
            else
            {
                if (this.decreasePoints())
                {
                    return;
                }
            }
            this.nextHour();
        }

        private bool decreasePoints()
        {
            this.lFalse.Visibility = System.Windows.Visibility.Visible;
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Elapsed);
            this.time = 0;
            this.timer.Start();
            this.score -= 30;
            if (this.score <= 0)
            {
                this.score = 0;
                this.lScore.Content = "Ton score : " + this.score;
                this.lEndMessage.Content = "Dommage !";
                this.lEndMessage.Visibility = System.Windows.Visibility.Visible;
                this.EndOfGame();
                return true;
            }
            this.lScore.Content = "Ton score : " + this.score;
            return false;
        }

        void Timer_Elapsed(object sender, EventArgs e)
        {
            if (this.time < 1)
            {
                this.time++;
            }
            if (this.time == 1)
            {
                this.time++;
                this.lFalse.Visibility = System.Windows.Visibility.Hidden;
                this.timer.Stop();
            }
        }

        private void bContinue_Click(object sender, RoutedEventArgs e)
        {
            if (EndOfGameEvent != null)
                EndOfGameEvent(this.idUser, this.idGame, this.idDefi, this.score);
        }

        private void bRe_Click(object sender, RoutedEventArgs e)
        {
            this.startGame();
        }
    }

}
