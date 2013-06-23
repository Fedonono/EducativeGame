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
using EducationAll.Games;

namespace EducationAll
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
        private List<bool> answers = new List<bool>();
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
            this.tWelcome.Text = "Bonjour, je suis l'inspecteur d'Eric.\nJ'aurais quelques questions\nà vous poser.\nCela ne vous dérange pas,\nj'espère ?";
        }

        private void Start()
        {
            int id = this.idQuestionnary;
            this.questionsList = from i in Bdd.DbAccess.Questions where i.idQuestionary == id select i;
            this.questionItr = this.questionsList.GetEnumerator();
            if (this.questionItr.MoveNext())
                this.PrintQuestion(this.questionItr.Current);
        }

        private void PrintQuestion(Datas.Question question)
        {
            this.QuestionLabel.Content = question.question1;
            this.AnswerPanel.Children.Clear();
            if (question.Choices.Count != 0)
            {
                foreach (Datas.Choice choice in question.Choices)
                {
                    Button bt = new Button() { Content = choice.choice1, Tag = choice, FontSize = 20, Padding = new Thickness(20), Margin = new Thickness(10) };
                    bt.Click += new RoutedEventHandler(ClickChoice);
                    this.AnswerPanel.Children.Add(bt);
                }
            }
            else
            {
                TextBox tb = new TextBox() { Name = "AnswerTextBox", Padding = new Thickness(20), FontSize = 20 };
                tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                this.AnswerPanel.Children.Add(tb);
                Button bt = new Button() { Content = "Valider", FontSize = 20, Padding = new Thickness(20), Tag = tb, Margin = new Thickness(10) };
                bt.Click += new RoutedEventHandler(ClickValider);
                tb.Tag = bt;
                tb.Focus();
                this.AnswerPanel.Children.Add(bt);
            }
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && sender is TextBox)
            {
                TextBox tb = sender as TextBox;
                this.ClickValider(tb.Tag, null);
            }
        }

        /// <summary>
        /// Question à choix multiple
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickChoice(object sender, RoutedEventArgs e)
        {
            Button bt = (Button) sender;
            Datas.Choice choice = (Datas.Choice) bt.Tag;
            if (choice.Question.answer.Equals(choice.choice1))
            {
                this.scoreLabel.Content = "+10";
                this.AddPoint(10);
                this.answers.Add(true);
                this.tick.Visibility = System.Windows.Visibility.Visible;
                bt.Background = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            }
            else
            {
                this.wrong.Visibility = System.Windows.Visibility.Visible;
                this.answers.Add(false);
                bt.Background = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            }

            foreach (Button item in this.AnswerPanel.Children)
            {
                item.Click -= new RoutedEventHandler(ClickChoice);
            }

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Start();
            this.time = 0;
        }

        void Timer_Tick(object sender, EventArgs e)
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
                    this.PrintQuestion(this.questionItr.Current);
                }
                else
                {
                    this.showResults();
                }
            }
        }

        /// <summary>
        /// Question avec une entrée utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickValider(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            TextBox tb = (TextBox) bt.Tag;
            String answer = this.questionItr.Current.answer;
            if (tb.Text.ToUpper().Equals(answer.ToUpper()))
            {
                this.scoreLabel.Content = "+20";
                this.AddPoint(20);
                this.answers.Add(true);
                this.tick.Visibility = System.Windows.Visibility.Visible;
                tb.Background = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            }
            else
            {
                this.wrong.Visibility = System.Windows.Visibility.Visible;
                this.answers.Add(false);
                tb.Background = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            }

            foreach (Control item in this.AnswerPanel.Children)
            {
                if (item is Button)
                {
                    Button b = item as Button;
                    b.Click -= new RoutedEventHandler(ClickChoice);
                }
            }

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Start();
            this.time = 0;
        }

        private void AddPoint(int p)
        {
            this.score += p;
        }

        public event DelegateEndOfGame EndOfGameEvent;

        public void EndOfGame()
        {
            if (EndOfGameEvent != null)
                EndOfGameEvent(this.idUser, this.idGame, this.idDefi, this.score);
        }

        private void BWelcome_Click(object sender, RoutedEventArgs e)
        {
            this.tWelcome.Visibility = System.Windows.Visibility.Hidden;
            this.iWelcome.Visibility = System.Windows.Visibility.Hidden;
            this.rWelcome.Visibility = System.Windows.Visibility.Hidden;
            this.bWelcome.Visibility = System.Windows.Visibility.Hidden;
            this.rWelcomeBack.Visibility = System.Windows.Visibility.Hidden;
            this.Start();
        }

        private void showResults()
        {
            this.questionaryGrid.Children.Clear();
            Button continueButton = new Button() { Content = "Continuer", Margin = new Thickness(716, 93, 59, 573), Name = "closeButton", FontSize = 25, Padding = new Thickness(20) };
            continueButton.Click += new RoutedEventHandler(continueButton_Click);
            this.questionaryGrid.Children.Add(new QuestionaryResults(this.questionsList,this.answers, this.score));
            this.questionaryGrid.Children.Add(continueButton);
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            this.EndOfGame();
        }
    }
}
