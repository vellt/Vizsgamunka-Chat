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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Settings.Pages
{
    /// <summary>
    /// Interaction logic for AccountSettingsUC.xaml
    /// </summary>
    public partial class AccountSettingsUC : UserControl
    {
        public AccountSettingsUC(object obj)
        {
            InitializeComponent();
            orig = (Model.ProfileModel)obj;
            this.DataContext= orig;
        }
        Model.ProfileModel orig = null;
        private void emailBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //átnavigálás
            SubPages.EmailUC emailUC = new SubPages.EmailUC(orig);
            ((this as AccountSettingsUC).Parent as Grid).Children.Add(emailUC);
            this.Visibility = Visibility.Collapsed;
        }

        private void PwdBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //átnavigálás
            SubPages.PwdUC pwdUC = new SubPages.PwdUC(orig);
            ((this as AccountSettingsUC).Parent as Grid).Children.Add(pwdUC);
            this.Visibility = Visibility.Collapsed;
        }

        private void AccDelBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
            dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged;
            dialogUC.Show("Fiók Törlése", "Biztos Törlöd fiókod? \nFiókodat nem fogod tudni ezután használni!", Alerts.DialogUC.ButtonType.YesNo, "", Alerts.DialogUC.ButtonColor.Red);
            App.mainWindow.alertGR.Children.Clear();
            App.mainWindow.alertGR.Children.Add(dialogUC);
            
        }

        private void DialogUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if((sender as Alerts.DialogUC).Visibility == Visibility.Collapsed)
            {
                if((sender as Alerts.DialogUC).Result)
                {
                    //fiók törlése
                    Model.SettingsModel settingsModel = new Model.SettingsModel(orig.ID);
                    
                    Nullable<bool> result = settingsModel.user.Delete();
                    if (App.mainWindow.alertGR.Children.Count>0) App.mainWindow.alertGR.Children.Clear();
                    if (result == true)
                    {
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged1;
                        dialogUC.Show("Fiók Törlés", "Fiókodat sikeresen törölted!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Green);
                        
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                    else
                    {
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                }
            }
        }

        private void DialogUC_IsVisibleChanged1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(!(sender as Alerts.DialogUC).IsVisible)
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                configuration.AppSettings.Settings["Username"].Value = String.Empty;
                configuration.AppSettings.Settings["Password"].Value = String.Empty;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");

                App.mainWindow.Hide();
                App.AppStarter(App.fwnd, App.FirstWindowPages.Login);
            }
        }

        private void AccDelBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            ((sender as Grid).Children[0] as ContentControl).Foreground= (SolidColorBrush)new BrushConverter().ConvertFromString("#FFE2747F");
        }

        private void AccDelBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            ((sender as Grid).Children[0] as ContentControl).Foreground = Brushes.Black;
        }
    }
}
