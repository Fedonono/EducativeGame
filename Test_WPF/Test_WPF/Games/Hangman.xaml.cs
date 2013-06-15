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

namespace Test_WPF.Games
{
    /// <summary>
    /// Logique d'interaction pour Hangman.xaml
    /// </summary>
    public partial class Hangman : UserControl
    {
        private List<String> dictionary;
        private String currentWord;
        private List<char> takenLettersList;
        private List<char> hangLettersList;
        private static readonly char HIDDEN = '*';
        private int essais;
        private int score;

        public Hangman()
        {
            InitializeComponent();
        }

        private void hangGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.startGame();
        }

        private void startGame()
        {
            this.label5.Visibility = System.Windows.Visibility.Hidden;
            this.label4.Visibility = System.Windows.Visibility.Hidden;
            this.button1.Visibility = System.Windows.Visibility.Hidden;
            this.label3.Visibility = System.Windows.Visibility.Visible;
            this.label2.Visibility = System.Windows.Visibility.Visible;
            this.label1.Visibility = System.Windows.Visibility.Visible;
            this.takenLetters.Visibility = System.Windows.Visibility.Visible;

            this.hideAllImages();
            this.labelScore.Visibility = System.Windows.Visibility.Hidden;

            this.takenLettersList = new List<char>();
            this.hangLettersList = new List<char>();
            this.essais = 6;
            this.label2.Content = "Il te reste 7 essais";
            this.score = 0;
            this.initDictionary();

            Random r = new Random();
            int randId = r.Next(this.dictionary.Count);
            this.currentWord = this.dictionary[randId].ToUpper();
            this.initLabels();
            this.textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            this.textBox1.Focus();
        }

        private void hideAllImages()
        {
            this.hang6.Visibility = System.Windows.Visibility.Hidden;
            this.hang5.Visibility = System.Windows.Visibility.Hidden;
            this.hang4.Visibility = System.Windows.Visibility.Hidden;
            this.hang3.Visibility = System.Windows.Visibility.Hidden;
            this.hang2.Visibility = System.Windows.Visibility.Hidden;
            this.hang1.Visibility = System.Windows.Visibility.Hidden;
            this.dead.Visibility = System.Windows.Visibility.Hidden;
        }

        private void decreaseLife()
        {
            switch (this.essais)
            {
                case 6:
                    this.hang6.Visibility = Visibility.Visible;
                    break;
                case 5:
                    this.hang6.Visibility = Visibility.Hidden;
                    this.hang5.Visibility = Visibility.Visible;
                    break;
                case 4:
                    this.hang5.Visibility = Visibility.Hidden;
                    this.hang4.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.hang4.Visibility = Visibility.Hidden;
                    this.hang3.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.hang3.Visibility = Visibility.Hidden;
                    this.hang2.Visibility = Visibility.Visible;
                    break;
                case 1:
                    this.hang2.Visibility = Visibility.Hidden;
                    this.hang1.Visibility = Visibility.Visible;
                    break;
                case 0:
                    this.hang1.Visibility = Visibility.Hidden;
                    this.dead.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
            
            this.label2.Content = "Il te reste " + this.essais + " essais";
            this.essais--;
        }

        private void endGame(bool win)
        {
            this.textBox1.KeyDown -= new KeyEventHandler(textBox1_KeyDown);

            if (!win)
            {
                this.label5.Content = "Tu n'as pas réussi à trouver\nle mot qui était :\n" + this.currentWord;
                this.label4.Content = "Perdu !";
            }
            else
            {
                this.label5.Content = "Tu as trouvé le mot !";
                this.label4.Content = "Félicitations !";
            }
            this.label5.Visibility = System.Windows.Visibility.Visible;
            this.label4.Visibility = System.Windows.Visibility.Visible;
            this.label3.Visibility = System.Windows.Visibility.Hidden;
            this.label2.Visibility = System.Windows.Visibility.Hidden;
            this.label1.Visibility = System.Windows.Visibility.Hidden;
            this.takenLetters.Visibility = System.Windows.Visibility.Hidden;
            this.button1.Visibility = System.Windows.Visibility.Visible;

            if (this.essais < 0) { this.essais = 0; }
            this.score = this.currentWord.Length * this.essais;
            this.labelScore.Content = "Ton score : " + this.score;
            this.labelScore.Visibility = System.Windows.Visibility.Visible;
        }

        private void checkEndGame()
        {
            string hang = this.hangLetter.Content.ToString();
            if (this.dead.Visibility == Visibility.Visible)
            {
                this.endGame(false);
            }
            else if (!hang.Contains(HIDDEN))
            {
                this.endGame(true);
            }
        }

        private void initLabels()
        {
            this.updateLetters();
        }

        private void initDictionary()
        {
            this.dictionary = new List<String>();
            this.dictionary.Add("morning");
            this.dictionary.Add("midnight");
            this.dictionary.Add("kangaroo");
            this.dictionary.Add("elephant");
            this.dictionary.Add("sweater");
            this.dictionary.Add("mountain");
            this.dictionary.Add("hamster");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                return;
            }
            string s = e.Key.ToString().ToUpper();
            foreach (char c in s)
            {
                if (this.currentWord.Contains(c) && !this.hangLettersList.Contains(c))
                {
                    this.hangLettersList.Add(c);
                }
                if (!this.currentWord.Contains(c) && !this.takenLettersList.Contains(c))
                {
                    this.decreaseLife();
                }
                if (!this.takenLettersList.Contains(c))
                {
                    this.takenLettersList.Add(c);
                }
            }

            this.updateLetters();
            this.checkEndGame();
        }

        private void updateLetters()
        {
            string s2 = "";
            foreach (char s in this.currentWord)
            {
                if (this.takenLettersList.Contains(s))
                {
                    s2 += s;
                }
                else
                {
                    s2 += HIDDEN;
                }
            }
            this.hangLetter.Content = s2;

            this.takenLetters.Content = "";
            foreach (char item in this.takenLettersList)
            {
                this.takenLetters.Content += item + " ";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.startGame();
        }
    }
}
