using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Test_WPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow mainWindow;
        public static Games.TestGames testGames;
        public static Datas.User user = null;
        public static App CurrentApp { get { return currentApp; }}
        private static App currentApp = null;

        public void app_Startup(object sender, StartupEventArgs e)
        {
            // Create a window
            mainWindow = new MainWindow();
            testGames = new Games.TestGames();
            //this.MainWindow = testGames;
            this.MainWindow = mainWindow;

            // Open a window
            this.MainWindow.Show();
            currentApp = this;
        }
    }
}
