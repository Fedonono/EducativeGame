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
using System.Windows.Threading;

namespace EducationAll.Games
{
    /// <summary>
    /// Logique d'interaction pour Additions1_ce1.xaml
    /// </summary>
    public partial class Additions1_ce1 : UserControl, IGame
    {
        private List<Control> listeTables;
        private int tableDeX;
        private bool chosen;
        private int secondNum, result;
        private int score;
        private DispatcherTimer timer;
        private int time;
        private readonly int END_SCORE = 10;

        private int idUser, idGame, idDefi;

        public Additions1_ce1(int idUser, int idGame, int idDefi)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.idGame = idGame;
            this.idDefi = idDefi;
        }

        private void StartGame()
        {
            this.tableName.Visibility = System.Windows.Visibility.Hidden;
            this.firstNumber.Visibility = System.Windows.Visibility.Hidden;
            this.plus.Visibility = System.Windows.Visibility.Hidden;
            this.secondNumber.Visibility = System.Windows.Visibility.Hidden;
            this.equal.Visibility = System.Windows.Visibility.Hidden;
            this.response.Visibility = System.Windows.Visibility.Hidden;
            this.scoreLabel1.Visibility = System.Windows.Visibility.Hidden;
            this.scoreLabel2.Visibility = System.Windows.Visibility.Hidden;
            this.timerLabel1.Visibility = System.Windows.Visibility.Hidden;
            this.timerLabel2.Visibility = System.Windows.Visibility.Hidden;
            this.descLabel1.Visibility = System.Windows.Visibility.Visible;
            this.descLabel2.Visibility = System.Windows.Visibility.Visible;
            this.descLabel3.Visibility = System.Windows.Visibility.Visible;
            this.button1.Visibility = System.Windows.Visibility.Hidden;
            this.endButton.Visibility = System.Windows.Visibility.Hidden;
            this.vitesseLabel.Visibility = System.Windows.Visibility.Hidden;
            this.gameOverLabel1.Visibility = System.Windows.Visibility.Hidden;
            this.gameOverLabel2.Visibility = System.Windows.Visibility.Hidden;

            this.response.Text = "";
            this.listeTables = new List<Control>();
            this.chosen = false;
            this.score = 0;
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Elapsed);
            this.time = 0;

            for (int i = 1; i < 11; i++)
            {
                Button b = new Button();
                b.Content = "Table de " + i;
                b.Tag = i;
                b.Width = 100;
                b.Height = 50;
                b.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                b.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                if (i <= 4)
                {
                    b.Margin = new Thickness(50 + 150 * i, 380, 0, 0);
                }
                else if (i > 4 && i <= 8)
                {
                    b.Margin = new Thickness(50 + 150 * (i - 4), 480, 0, 0);
                }
                else
                {
                    b.Margin = new Thickness(200 + 150 * (i - 8), 580, 0, 0);
                }
                b.Click += new RoutedEventHandler(B_Click);
                this.contentGrid.Children.Add(b);
                this.listeTables.Add(b);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartGame();
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            if (!this.chosen)
            {
                Button b = sender as Button;
                this.tableDeX = (int)b.Tag;
                this.chosen = true;
                foreach (Control c in this.listeTables)
                {
                    if (this.contentGrid.Children.Contains(c))
                    {
                        this.contentGrid.Children.Remove(c);
                    }
                }
                this.tableName.Content = "Tables de " + this.tableDeX;
                this.tableName.Visibility = System.Windows.Visibility.Visible;
                this.firstNumber.Visibility = System.Windows.Visibility.Visible;
                this.plus.Visibility = System.Windows.Visibility.Visible;
                this.secondNumber.Visibility = System.Windows.Visibility.Visible;
                this.equal.Visibility = System.Windows.Visibility.Visible;
                this.response.Visibility = System.Windows.Visibility.Visible;
                this.scoreLabel1.Visibility = System.Windows.Visibility.Visible;
                this.scoreLabel2.Visibility = System.Windows.Visibility.Visible;
                this.timerLabel1.Visibility = System.Windows.Visibility.Visible;
                this.timerLabel2.Visibility = System.Windows.Visibility.Visible;
                this.descLabel1.Visibility = System.Windows.Visibility.Hidden;
                this.descLabel2.Visibility = System.Windows.Visibility.Hidden;
                this.descLabel3.Visibility = System.Windows.Visibility.Hidden;
                this.response.Focus();
                this.NextCalcul();
            }
        }

        void Timer_Elapsed(object sender, EventArgs e)
        {
            this.timerLabel2.Content = ++this.time + "s";
        }

        private void NextCalcul()
        {
            Random r = new Random();
            int newNum;
            do
            {
                newNum = r.Next(0, 10);
            } while (this.secondNum == newNum);
            this.secondNum = newNum;
            this.result = this.tableDeX + this.secondNum;
            this.firstNumber.Content = this.tableDeX;
            this.secondNumber.Content = this.secondNum;
        }

        private void Response_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && this.response.Text.Length > 0)
            {
                if (this.response.Text == this.result.ToString())
                {
                    this.incorrect.Visibility = System.Windows.Visibility.Hidden;
                    this.score++;
                    this.scoreLabel2.Content = this.score;
                    if (this.score == this.END_SCORE)
                    {
                        this.EndOfAdditionGame();
                        return;
                    }
                    this.NextCalcul();
                }
                else
                {
                    this.incorrect.Visibility = System.Windows.Visibility.Visible;
                }
                this.response.Text = "";
                return;
            }
            if (this.response.Text.Length >= 2)
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.StartGame();
        }

        private void EndOfAdditionGame()
        {
            this.timer.Stop();
            this.firstNumber.Visibility = System.Windows.Visibility.Hidden;
            this.plus.Visibility = System.Windows.Visibility.Hidden;
            this.secondNumber.Visibility = System.Windows.Visibility.Hidden;
            this.equal.Visibility = System.Windows.Visibility.Hidden;
            this.response.Visibility = System.Windows.Visibility.Hidden;
            this.vitesseLabel.Visibility = System.Windows.Visibility.Visible;
            this.gameOverLabel1.Visibility = System.Windows.Visibility.Visible;
            this.gameOverLabel2.Visibility = System.Windows.Visibility.Visible;
            int bonus = 2;
            if (this.time < 5)
            {
                bonus = 300;
            }
            else if (this.time < 10)
            {
                bonus = 100;
            }
            else if (this.time < 15)
            {
                bonus = 50;
            }
            else if (this.time < 20)
            {
                bonus = 30;
            }
            else if (this.time < 25)
            {
                bonus = 20;
            }
            else if (this.time < 30)
            {
                bonus = 10;
            } else if (this.time < 35)
            {
                bonus = 5;
            }

            this.score += bonus;
            this.scoreLabel2.Content = this.score;
            this.vitesseLabel.Content = "Ta vitesse te fais rapporter " + bonus + " points supplémentaires.";
            this.endButton.Visibility = System.Windows.Visibility.Visible;
            this.button1.Visibility = System.Windows.Visibility.Visible;
        }

        private void Response_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.timer.Start();
        }

        public event DelegateEndOfGame EndOfGameEvent;

        public void EndOfGame()
        {
            if (EndOfGameEvent != null)
                EndOfGameEvent(this.idUser, this.idGame, this.idDefi, this.score);
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            this.EndOfGame();
        }
    }
}
