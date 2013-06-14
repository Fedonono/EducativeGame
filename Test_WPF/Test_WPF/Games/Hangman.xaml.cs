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
        public Hangman()
        {
            InitializeComponent();
        }

        private List<String> dictionary;
        private String currentWord;
        private List<String> takenLettersList;
        private String currentGuess;
        private static char hidden = '*';

        private void hangGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.initDictionary();

            Random r = new Random();
            int randId = r.Next(this.dictionary.Count);
            this.currentWord = this.dictionary[randId];
            this.initLabels();
            this.takenLettersList = new List<String>();
            this.textBox1.Focus();
        }

        private void decreaseLife()
        {
            this.hang6.Visibility = Visibility.Visible;
        }

        private void reveal(String a)
        {
            int i = 0;
            var temp = this.currentGuess.ToCharArray();
            
            while ((i = this.currentWord.IndexOf(a, i)) != -1)
            {
                temp[i] = a[0];
                i++;
            }
            this.currentGuess = new String(temp);
        }

        private void endGame(bool win)
        {
            this.textBox1.KeyDown -= new KeyEventHandler(textBox1_KeyDown);
            /*
             * Plus gros score si peu de hang man
             */ 
        }

        private void checkEndGame()
        {
            if (this.dead.Visibility == Visibility.Visible)
            {
                this.endGame(false);
            }
            else if(this.currentGuess.IndexOf(hidden) == -1)
            {
                this.endGame(true);
            }
        }

        private void initLabels()
        {
            this.hangLetter.FontSize = 70;
            this.hangLetter.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;

            this.takenLetters.FontSize = 15;

            for(int i = 0; i < currentWord.Length; i++) {
                this.currentGuess += hidden;
            }

            this.hangLetter.Content = this.currentGuess;
            this.takenLetters.Content = "...";
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
            this.takenLetters.Content = "zerjoert";
            String s = e.Key.ToString();
            if (!this.takenLettersList.Contains(s))
            {
                this.takenLettersList.Add(s);
                this.takenLetters.Content = this.takenLettersList;
                if (this.currentWord.Contains(s))
                {
                    this.reveal(s);
                }
            }
            else
            {
                this.takenLettersList.Add(s);
                this.decreaseLife();
            }
            this.checkEndGame();
        }
    }
}
