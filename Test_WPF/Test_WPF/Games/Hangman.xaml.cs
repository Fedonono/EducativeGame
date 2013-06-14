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
        private List<Image> hangDisplay;

        private void hangGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.initDictionary();

            Random r = new Random();
            int randId = r.Next(this.dictionary.Count);
            this.currentWord = this.dictionary[randId];
            this.initLabels();
            this.takenLettersList = new List<String>();
            this.textBox1.Focus();
            this.initHangDisplay();
        }

        private void onKeyPress(object sender, KeyEventArgs e)
        {
            String s = e.Key.ToString().ToUpper();
            if (!this.takenLettersList.Contains(s))
            {
                this.takenLettersList.Add(s);
                this.takenLetters.Content += this.takenLettersList[this.takenLettersList.Count - 1];
                if (this.currentWord.Contains(s))
                {
                    this.reveal(s);
                }
                else
                {
                    this.decreaseLife();
                }
            }
            else
            {
                this.takenLettersList.Add(s);
                this.decreaseLife();
            }
            
            if(this.currentGuess.IndexOf(hidden) == -1)
            {
                this.endGame(true);
            }
        }

        private void decreaseLife()
        {
            if (this.hangDisplay.Count == 2)
            {
                this.endGame(false);
            }
            this.hangDisplay[0].Visibility = Visibility.Hidden;
            this.hangDisplay.Remove(this.hangDisplay[0]);
            this.hangDisplay[0].Visibility = Visibility.Visible;
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
            this.hangLetter.Content = this.currentGuess;
        }

        private void endGame(bool win)
        {
            this.textBox1.KeyDown -= new KeyEventHandler(onKeyPress);
            /*
             * Plus gros score si peu de hang man
             */ 
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
            this.takenLetters.Content = "";
        }

        private void initDictionary()
        {
            this.dictionary = new List<String>();
            this.dictionary.Add("morning".ToUpper());
            this.dictionary.Add("midnight".ToUpper());
            this.dictionary.Add("kangaroo".ToUpper());
            this.dictionary.Add("elephant".ToUpper());
            this.dictionary.Add("sweater".ToUpper());
            this.dictionary.Add("mountain".ToUpper());
            this.dictionary.Add("hamster".ToUpper());
        }

        private void initHangDisplay()
        {
            this.hangDisplay = new List<Image>();
            this.hangDisplay.Add(this.hang6);
            this.hangDisplay.Add(this.hang5);
            this.hangDisplay.Add(this.hang4);
            this.hangDisplay.Add(this.hang3);
            this.hangDisplay.Add(this.hang2);
            this.hangDisplay.Add(this.hang1);
            this.hangDisplay.Add(this.dead);
        }
    }
}
