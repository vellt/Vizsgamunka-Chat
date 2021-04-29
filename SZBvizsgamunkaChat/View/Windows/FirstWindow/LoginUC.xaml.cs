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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SZBvizsgamunkaChat.View.Controls;

namespace SZBvizsgamunkaChat.View.Windows.FirstWindow
{
    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        private bool isLoginSaved=true;

        public bool IsLoginSaved
        {
            get { return isLoginSaved=false; }
            set { isLoginSaved= value; }
        }

        public LoginUC()
        {
            InitializeComponent();
            this.Loaded += LoginUI_Loaded;
        }

        private void LoginUI_Loaded(object sender, RoutedEventArgs e)
        {
            usernameOrEmailTXT.TextBoxContent.Focus();
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            if (configuration.AppSettings.Settings["Username"].Value != String.Empty && configuration.AppSettings.Settings["Password"].Value != String.Empty)
            {
                this.usernameOrEmailTXT.TextBoxContent.Text = configuration.AppSettings.Settings["Username"].Value;
                this.passwordTXT.pwdBoxContent.Password = configuration.AppSettings.Settings["Password"].Value;
                login(this.usernameOrEmailTXT.TextBoxContent.Text, this.passwordTXT.pwdBoxContent.Password);
            }
        }

        private void login(string usernameOrEmail, string password)
        {
            Model.LoginModel loginModel = new Model.LoginModel();
            loginModel.UsernameOrEmail = usernameOrEmail;
            loginModel.Password = password;
            int result = loginModel.Select();
            switch (result)
            {
                case -1: 
                    dialogUC.Show("Nincs internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    usernameOrEmailTXT.BorderColor = Brushes.Red;
                    passwordTXT.BorderColor = Brushes.Red;
                    usernameOrEmailTXT.TextBoxContent.Focus();
                    break;
                case 0: 
                    dialogUC.Show("Hiba", "Hibás bejelentkezési adatok!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    usernameOrEmailTXT.BorderColor = Brushes.Red;
                    passwordTXT.BorderColor = Brushes.Red;
                    usernameOrEmailTXT.TextBoxContent.Focus();
                    break;
                default:
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                    configuration.AppSettings.Settings["Username"].Value = (isLoginSaved) ? usernameOrEmail : String.Empty;
                    configuration.AppSettings.Settings["Password"].Value = (isLoginSaved) ? password : String.Empty;
                    configuration.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                    App.fwnd.Hide();
                    App.AppStarter(App.mainWindow, App.MainWindowPages.Home, result);

                    break;
            }
        }

        private void usernameOrEmailTXT_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            textBoxFormChecker(ref usernameOrEmailTXT,false);
        }

        private void passwordTXT_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            pwdBoxFormChecker(ref passwordTXT,false);
        }

        private void BigButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!textBoxFormChecker(ref usernameOrEmailTXT,true) && !pwdBoxFormChecker(ref passwordTXT,true))
            {
                login(usernameOrEmailTXT.TxbContent.Trim(), passwordTXT.PwdContent.Trim());
            }
        }
        private bool pwdBoxFormChecker(ref PwdBoxUC pwdBoxControl, bool showDialog)
        {
            if (string.IsNullOrWhiteSpace(pwdBoxControl.PwdContent.Trim()))
            {
                pwdBoxControl.BorderColor = Brushes.Red;
                if (showDialog) dialogUC.Show("Hiányzó adat", "Kérem adja meg a fiókjához tartozó jelszavát!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                pwdBoxControl.pwdBoxContent.Focus();
                return true;
            }
            else
            {
                pwdBoxControl.BorderColor = Brushes.Gray;
                return false;
            }
        }

        private bool textBoxFormChecker(ref TextBoxUC textBoxControl, bool showDialog)
        {
            if (string.IsNullOrWhiteSpace(textBoxControl.TxbContent.Trim()))
            {
                textBoxControl.BorderColor = Brushes.Red;
                if(showDialog) dialogUC.Show("Hiányzó adat", "Kérem adja meg a fiókjához tartozó felhasználónevét vagy az email címét!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                textBoxControl.TextBoxContent.Focus();
                return true;
            }
            else
            {
                textBoxControl.BorderColor = Brushes.Gray;
                return false;
            }
        }

        private void regGrid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.fwnd.moduls.Children.Add(new RegistrationUC());
            App.fwnd.moduls.Children.RemoveAt(0);
        }

        private void CheckBoxControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            IsLoginSaved=(Convert.ToInt32(e.NewValue) == 1) ? true : false;
        }

        private void termsBTN_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ShowTerms(1);
        }

        private void privacyBTN_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ShowTerms(2);
        }

        public void ShowTerms(int index)
        {

            if (index == 1)
            {
                termsDialogUC.SetTerms();
            }
            else
            {
                termsDialogUC.SetPrivacy();
            }

            Storyboard sb = this.FindResource("termsVisibleSB") as Storyboard;
            if (sb != null) { BeginStoryboard(sb); }
        }

        public void HideTerms()
        {
            Storyboard sb = this.FindResource("termsCloseSB") as Storyboard;
            if (sb != null) { BeginStoryboard(sb); }
        }
    }
}
