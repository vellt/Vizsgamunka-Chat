using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SZBvizsgamunkaChat.View.Controls;

namespace SZBvizsgamunkaChat.View.Windows.FirstWindow.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationForm1.xaml
    /// </summary>
    public partial class RegistrationForm1 : UserControl
    {
        public RegistrationForm1()
        {
            InitializeComponent();
            this.Loaded += RegistrationForm1_Loaded;
        }

        private void RegistrationForm1_Loaded(object sender, RoutedEventArgs e)
        {
            emailTXT.TextBoxContent.Focus();
            if ((this.DataContext as Model.RegistrationModel.UserData).Email!=null) emailTXT.TextBoxContent.Text = (this.DataContext as Model.RegistrationModel.UserData).Email;
            if ((this.DataContext as Model.RegistrationModel.UserData).Username!=null) usernameTXT.TextBoxContent.Text = (this.DataContext as Model.RegistrationModel.UserData).Username;
            if ((this.DataContext as Model.RegistrationModel.UserData).Password!=null) passwordTXT.pwdBoxContent.Password = (this.DataContext as Model.RegistrationModel.UserData).Password;
        }


        private void BigButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if ( isEmailValid(ref emailTXT) && isNameCorrect(ref usernameTXT) && isPwdCorrect(ref passwordTXT) && isPwdCorrect(ref passwordConfirmationTXT))
            {
                if(isPasswordsEquals(passwordTXT,passwordConfirmationTXT))
                {
                    (App.fwnd.moduls.Children[0] as RegistrationUC).SetUserData(emailTXT.TxbContent.Trim(), usernameTXT.TxbContent.Trim(), passwordTXT.PwdContent.Trim());
                }
            }
        }

        private bool isPasswordsEquals(PwdBoxUC passwordTXT, PwdBoxUC passwordConfirmationTXT)
        {
            if (passwordTXT.PwdContent.Equals(passwordConfirmationTXT.PwdContent))
            {
                return true;
            }
            else
            {
                (App.fwnd.moduls.Children[0] as RegistrationUC).ErrorMessage("Hibás Adat", "A jelszópáros nem egyezik!");
                return false;
            }
        }

        private bool isEmailValid(ref TextBoxUC textBoxControl)
        {
            string email = textBoxControl.TxbContent.Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            ;
            if (match.Success)
            {
                return true;
            }
            else
            {
                textBoxControl.BorderColor = Brushes.Red;
                textBoxControl.TextBoxContent.Focus();
                (App.fwnd.moduls.Children[0] as RegistrationUC).ErrorMessage("Hibás Adat", "Nem feglelelő az email formátuma!");
                return false;
            }
        }

        private bool isPwdCorrect(ref PwdBoxUC pwdBoxControl)
        {
            if (string.IsNullOrWhiteSpace(pwdBoxControl.PwdContent.Trim()))
            {
                pwdBoxControl.BorderColor = Brushes.Red;
                pwdBoxControl.pwdBoxContent.Focus();
                (App.fwnd.moduls.Children[0] as RegistrationUC).ErrorMessage("Hibás Adat", "A jelszó mező kitöltése kötelező!");
                return false;
            }
            else
            {
                pwdBoxControl.BorderColor = Brushes.Gray;
                return true;
            }
        }

        private bool isNameCorrect(ref TextBoxUC textBoxControl)
        {
            if (string.IsNullOrWhiteSpace(textBoxControl.TxbContent.Trim()))
            {
                textBoxControl.BorderColor = Brushes.Red;
                textBoxControl.TextBoxContent.Focus();
                (App.fwnd.moduls.Children[0] as RegistrationUC).ErrorMessage("Hibás Adat", "A felhasználónév mező kitöltése kötelező!");
                return false;
            }
            else
            {
                textBoxControl.BorderColor = Brushes.Gray;
                return true;
            }
        }

        private void emailTXT_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as TextBoxUC).BorderColor = Brushes.Gray;
        }

        private void usernameTXT_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as TextBoxUC).BorderColor = Brushes.Gray;
        }
    }
}
