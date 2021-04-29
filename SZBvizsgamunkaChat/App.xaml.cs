using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SZBvizsgamunkaChat.View.Windows.FirstWindow;
using SZBvizsgamunkaChat.View.Windows.MainWindow;

namespace SZBvizsgamunkaChat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public enum FirstWindowPages { Login, Registration}
        public enum MainWindowPages { Home, Messages, Settings }
        public enum NumberOfWindows { FistWindow, MainWindow }
        public static FirstWindow fwnd = new FirstWindow();
        public static MainWindow mainWindow = new MainWindow();

        private void Application_Startup(object sender, StartupEventArgs e)
		{
            //appinditas
            AppStarter(fwnd, FirstWindowPages.Login);
        }

        

        public static void AppStarter(FirstWindow window, FirstWindowPages firstWindowPage)
        {
            window.Title = "CHAT APP";
            window.FirstWindowPages = FirstWindowPages.Login;
            window.Show();
        }

        public static void AppStarter(MainWindow window, MainWindowPages mainWindowPage,int profileID)
        {

            window.Title = "CHAT APP";
            window.ProfileID = profileID;
            window.MainWindowPages = MainWindowPages.Home;
            window.notifyGR.Visibility = Visibility.Collapsed;
            window.Show();
        }
    }
}
