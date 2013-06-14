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

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour QuestionaryControl.xaml
    /// </summary>
    public partial class QuestionaryControl : UserControl
    {
        private IEnumerable<Datas.Question> questionsList;
        private IEnumerator<Datas.Question> questionItr;
        public QuestionaryControl(int id)
        {
            InitializeComponent();
            this.questionsList = from i in Bdd._db.Questions where i.idQuestionary == id select i;
            this.questionItr = this.questionsList.GetEnumerator();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
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
                    Button bt = new Button() { Content = choice.choice1, Tag = choice, Padding = new Thickness(25), Margin = new Thickness(10) };
                    bt.Click += new RoutedEventHandler(clickChoice);
                    this.AnswerPanel.Children.Add(bt);
                }
            }
            else
            {
                this.AnswerPanel.Children.Add(new TextBox() { Name = "AnswerTextBox" });
                Button bt = new Button() { Content = "valider", Padding = new Thickness(25), Margin = new Thickness(10) };
                //bt.Click += new RoutedEventHandler(launchGame);
                this.AnswerPanel.Children.Add(bt);
            }
        }

        private void clickChoice(object sender, RoutedEventArgs e)
        {
            Button bt = (Button) sender;
            Datas.Choice choice = (Datas.Choice) bt.Tag;
            if (choice.Question.answer == choice.choice1)
            {
                bt.Background = new SolidColorBrush(Color.FromRgb(0,255,0));
            }
        }
    }
}
