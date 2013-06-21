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

namespace EducationAll
{
    /// <summary>
    /// Logique d'interaction pour LoadControl.xaml
    /// </summary>
    public partial class LoadControl : UserControl
    {
        private DispatcherTimer timer;
        private int time;

        public LoadControl()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.lawsLabel.Content = "Ce programme est protégé par les lois \n" +
                "françaises et internationales comme \n" +
                "indiqué dans la fenêtre À propos.";
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 1);
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Start();
            this.time = 1;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.time--;
            this.label4.Content = this.time;
            if (this.time <= 0)
            {
                this.timer.Stop();
                App.mainWindow.LoadControlClicked();
            }
        }
    }
}
