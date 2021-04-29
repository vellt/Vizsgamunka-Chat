using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SZBvizsgamunkaChat.View.Windows.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bool result = messagesModel.HasChange();
            if (result) messagesModel.Synch();

            #region olvasatlan uzeneteket jeleniti meg ha van

            int szamlalo = 0;
            for (int i = 0; i < messagesModel.messagesList.Count; i++)
            {
                if (messagesModel.messagesList[i].ContentList[messagesModel.messagesList[i].ContentList.Count - 1].IsMy == false) szamlalo++;
            }
            if (szamlalo > 0)
            {
                (messagesButton.Children[1] as Grid).Visibility = Visibility.Visible;
                ((messagesButton.Children[1] as Grid).Children[1] as ContentControl).Content = szamlalo;
            }
            else (messagesButton.Children[1] as Grid).Visibility = Visibility.Collapsed;
            #endregion

            #region frissiti az elemeket ha megvan nyitva az uznetetek ablak
            if (mainContent.Children[0] is Pages.Messages.MessagesUC)
            {
                if (result) (mainContent.Children[0] as Pages.Messages.MessagesUC).SynchAndScrollBottom(messagesModel);
                else (mainContent.Children[0] as Pages.Messages.MessagesUC).Synch(messagesModel);
            }
            #endregion
        }

        DispatcherTimer timer = new DispatcherTimer();

        private int profileID;

        public int ProfileID
        {
            get { return profileID; }
            set
            {
                profileID = value;
                profileModel = new Model.ProfileModel(profileID: ProfileID);
                homeModel = new Model.HomeModel();
                messagesModel = new Model.MessagesModel(ProfileID);

                bool result1 = profileModel.Synch();
                bool result2 = homeModel.Synch();
                bool result3 = messagesModel.Synch();
                ;
                if (result1 && result2 && result3)
                {
                    this.DataContext = profileModel;
                }
                else
                {
                    //hibnaüzenet nincs internet
                }
                SelectPage(0);
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }
        Model.ProfileModel profileModel = null;
        Model.HomeModel homeModel = null;
        Model.MessagesModel messagesModel = null;

        private App.MainWindowPages mainWindowPages;

        public App.MainWindowPages MainWindowPages
        {
            get { return mainWindowPages; }
            set
            {
                mainWindowPages = value;
                switch (mainWindowPages)
                {
                    case App.MainWindowPages.Home:; break;
                    case App.MainWindowPages.Messages:; break;
                    case App.MainWindowPages.Settings:; break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void profilPicture_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectPage(2);
        }

        private void navigationBtns_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectPage(navigationBtns.Children.IndexOf(sender as Grid));
        }

        public void SelectPage(int index)
        {
            mainContent.Children.Clear();
            changeBackgroundByIndex(index);
            switch (index)
            {
                case 0: mainContent.Children.Add(new Pages.Home.HomeUC(homeModel)); break;
                case 1: mainContent.Children.Add(new Pages.Messages.MessagesUC(messagesModel, profileModel.IsEncryptsID)); break;
                case 2: mainContent.Children.Add(new Pages.Settings.SettingsUC(profileModel)); break;
            }
        }

        private void changeBackgroundByIndex(int index)
        {
            for (int i = 0; i < navigationBtns.Children.Count; i++)
            {
                ((navigationBtns.Children[i] as Grid).Children[0] as Rectangle).Visibility = Visibility.Collapsed;
            }
            ((navigationBtns.Children[index] as Grid).Children[0] as Rectangle).Visibility = Visibility.Visible;
        }



        private void logOut_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
            dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged;
            dialogUC.Show("Kijelentkezés", "Biztos ki szeretnél jelentkezni?", Alerts.DialogUC.ButtonType.YesNo, "ok", Alerts.DialogUC.ButtonColor.Red);
            App.mainWindow.alertGR.Children.Clear();
            App.mainWindow.alertGR.Children.Add(dialogUC);
        }

        private void DialogUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((App.mainWindow.alertGR.Children[0] as Alerts.DialogUC).Result)
            {
                //jelentkezzen ki!, állítsa le a háttérszálat
                timer.Stop();
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                configuration.AppSettings.Settings["Username"].Value = String.Empty;
                configuration.AppSettings.Settings["Password"].Value = String.Empty;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");

                App.mainWindow.Hide();
                App.AppStarter(App.fwnd, App.FirstWindowPages.Login);
            }
        }

        private void logOut_MouseEnter(object sender, MouseEventArgs e)
        {
            ((View.Icons.ExitUC)logOut.Children[0]).Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#E2747F");
        }

        private void logOut_MouseLeave(object sender, MouseEventArgs e)
        {
            ((View.Icons.ExitUC)logOut.Children[0]).Fill = Brushes.Black;
        }
    }
}
