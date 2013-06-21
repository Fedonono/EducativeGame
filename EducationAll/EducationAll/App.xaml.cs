using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace EducationAll
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow mainWindow;
        public static Games.TestGames testGames;
        public static Datas.User user = null;
        public static int RankStudent = getConfigValue("idRankStudent");
        public static int RankTeacher = getConfigValue("idRankTeacher");
        public static int RankAdmin = getConfigValue("idRankAdmin");
        public static App CurrentApp { get { return currentApp; }}
        private static App currentApp = null;

        public void App_Startup(object sender, StartupEventArgs e)
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

        // source http://stackoverflow.com/questions/2536410/app-config-best-practices
        public static int getConfigValue(string key)
        {
            int result = 60; //Some default value
            string str = ConfigurationManager.AppSettings[key];
            if (!String.IsNullOrEmpty(str))
            {
                Int32.TryParse(str, out result);
            }
            return result;
        }
    }
}
