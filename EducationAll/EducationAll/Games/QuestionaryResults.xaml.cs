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

namespace EducationAll.Games
{
    /// <summary>
    /// Logique d'interaction pour QuestionaryResults.xaml
    /// </summary>
    public partial class QuestionaryResults : UserControl
    {
        private IEnumerable<Datas.Question> questionsList;
        private List<bool> answers = new List<bool>();
        private int score;

        public QuestionaryResults(IEnumerable<Datas.Question> ql, List<bool> a, int score)
        {
            InitializeComponent();
            this.questionsList = ql;
            this.answers = a;
            this.score = score;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerator<Datas.Question> questionsEnumerator = this.questionsList.GetEnumerator();
            IEnumerator<bool> answersEnumerator = this.answers.GetEnumerator();

            while (questionsEnumerator.MoveNext() && answersEnumerator.MoveNext())
            {
                stackPanelQuestions.Children.Add(new Label() { Content = questionsEnumerator.Current.question1, Height = 35, Margin = new Thickness(0, 0, 0, 10), Background = new BrushConverter().ConvertFromString("#FFAFD6F9") as SolidColorBrush, FontSize = 18 });
                stackPanelAnswers.Children.Add(new Label() { Content = questionsEnumerator.Current.answer, Height = 35, Margin = new Thickness(0, 0, 0, 10), Background = new BrushConverter().ConvertFromString("#FFAFD6F9") as SolidColorBrush, FontSize = 18 });
                Image img = new Image();
                img.Stretch = Stretch.Uniform;
                img.Height = 35;
                img.Margin = new Thickness(0, 0, 0, 10);
                if (answersEnumerator.Current)
                {
                    img.Source = new BitmapImage(new Uri(@"pack://application:,,,/EducationAll;component/Images/1371319301_package-installed-updated.png"));
                    
                }
                else
                {
                    img.Source = new BitmapImage(new Uri(@"pack://application:,,,/EducationAll;component/Images/1371319307_emblem-nowrite.png"));
                }
                stackPanelImg.Children.Add(img);
            }

            this.lScore.Content = this.score;
        }
    }
}
