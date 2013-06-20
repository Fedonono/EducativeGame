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
using Test_WPF.Games;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour QuestionaryControl.xaml
    /// </summary>
    public partial class QuestionaryControl : UserControl, IGame
    {
        private IEnumerable<Datas.Question> questionsList;
        private IEnumerator<Datas.Question> questionItr;
        private int idQuestionnary;
        private DispatcherTimer timer;
        private int time;
        private int score;

        private int idUser, idGame, idDefi;

        public QuestionaryControl(int idUser, int idGame, int idDefi, int idQuestionnary)
        {
            InitializeComponent();
            this.idQuestionnary = idQuestionnary;
            this.idUser = idUser;
            this.idGame = idGame;
            this.idDefi = idDefi;
            this.score = 0;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int id = this.idQuestionnary;
            this.questionsList = from i in Bdd.DbAccess.Questions where i.idQuestionary == id select i;
            this.questionItr = this.questionsList.GetEnumerator();
            if (this.questionItr.MoveNext())
                this.printQuestion(this.questionItr.Current);
        }

        private void printQuestion(Datas.Question question)
        {
            this.QuestionLabel.Content = question.question1;
            this.AnswerPanel.Children.Clear();
            if (question.Choices.Count != 0)
            {
                foreach (Datas.Choice choice in question.Choices)
                {
                    Button bt = new Button() { Content = choice.choice1, Tag = choice, FontSize = 20, Padding = new Thickness(20), Margin = new Thickness(10) };
                    bt.Click += new RoutedEventHandler(clickChoice);
                    this.AnswerPanel.Children.Add(bt);
                }
            }
            else
            {
                TextBox tb = new TextBox() { Name = "AnswerTextBox", Padding = new Thickness(20), FontSize = 20 };
                this.AnswerPanel.Children.Add(tb);
                Button bt = new Button() { Content = "Valider", FontSize = 20, Padding = new Thickness(20), Tag = tb, Margin = new Thickness(10) };
                bt.Click += new RoutedEventHandler(clickValider);
                this.AnswerPanel.Children.Add(bt);
            }
        }

        private void clickChoice(object sender, RoutedEventArgs e)
        {
            Button bt = (Button) sender;
            Datas.Choice choice = (Datas.Choice) bt.Tag;
            if (choice.Question.answer.Equals(choice.choice1))
            {
                this.scoreLabel.Content = "+10";
                this.addPoint(10);
                this.tick.Visibility = System.Windows.Visibility.Visible;
                bt.Background = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            }
            else
            {
                this.wrong.Visibility = System.Windows.Visibility.Visible;
                bt.Background = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            }

            foreach (Button item in this.AnswerPanel.Children)
            {
                item.Click -= new RoutedEventHandler(clickChoice);
            }

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
            this.time = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.time++;
            if (this.time == 1 && this.tick.Visibility == System.Windows.Visibility.Visible)
            {
                this.tick.Visibility = System.Windows.Visibility.Hidden;
                this.scoreLabel.Visibility = System.Windows.Visibility.Visible;
            }
            if(this.time == 2)
            {
                this.timer.Stop();
                this.tick.Visibility = System.Windows.Visibility.Hidden;
                this.scoreLabel.Visibility = System.Windows.Visibility.Hidden;
                this.wrong.Visibility = System.Windows.Visibility.Hidden;
                if (this.questionItr.MoveNext())
                {
                    this.printQuestion(this.questionItr.Current);
                }
                else
                {
                    this.EndOfGame();
                }
            }
        }

        private void clickValider(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            TextBox tb = (TextBox) bt.Tag;
            String answer = this.questionItr.Current.answer;
            if (tb.Text.ToUpper().Equals(answer.ToUpper())
            {
                this.scoreLabel.Content = "+20";
                this.addPoint(20);
                this.tick.Visibility = System.Windows.Visibility.Visible;
                tb.Background = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            }
            else
            {
                this.wrong.Visibility = System.Windows.Visibility.Visible;
                tb.Background = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            }

            foreach (Control item in this.AnswerPanel.Children)
            {
                if (item is Button)
                {
                    Button b = item as Button;
                    b.Click -= new RoutedEventHandler(clickChoice);
                }
            }

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
            this.time = 0;
        }

        private void addPoint(int p)
        {
            this.score += p;
        }

        public event DelegateEndOfGame EndOfGameEvent;

        public void EndOfGame()
        {
            if (EndOfGameEvent != null)
                EndOfGameEvent(this.idUser, this.idGame, this.idDefi, this.score);
        }
    }
}
