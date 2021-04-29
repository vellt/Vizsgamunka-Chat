using System;
using System.Collections.Generic;
using System.IO;
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

namespace SZBvizsgamunkaChat.View.Windows.FirstWindow
{
    /// <summary>
    /// Interaction logic for RegistrationUC.xaml
    /// </summary>
    public partial class RegistrationUC : UserControl
    {
        Model.RegistrationModel registrationModel = new Model.RegistrationModel();

        public RegistrationUC()
        {
            InitializeComponent();
        }

        public void ShowTerms(int index)
        {
           
            if (index==1)
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

        public void SetFirstname(string firstname)
        {
            registrationModel.profileData.Firstname = firstname;
        }

        public void SetLastname(string lastname)
        {
            registrationModel.profileData.Lastname = lastname;
        }

        public void SetPicture(byte[] picture)
        {
            registrationModel.profileData.Picture = picture;
        }

        public void insert()
        {
            byte?[] result = registrationModel.CanBeRegistered(registrationModel.userData.Email, registrationModel.userData.Username);

            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
            switch (String.Join(",", result))
            {
                case ",":
                    dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
                    break; //nincs internet
                case "0,1":
                    dialogUC.Show("Regisztrációs hiba", "Ezzel a felhasználónévvel már regisztráltak!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
                    indicatorUI.Reset();
                    break; //foglalt username
                case "1,0":
                    dialogUC.Show("Regisztrációs hiba", "Ezzel az E-mail címmel már regisztráltak!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
                    indicatorUI.Reset();
                    break; //foglalt email
                case "0,0":
                    if(registrationModel.Insert()) indicatorUI.Tovabb2();
                    else
                    {
                        dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra.", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
                        (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
                    }
                    break; //mehet a regisztráció
                case "1,1":
                    dialogUC.Show("Regisztrációs hiba", "Ezzel a felhasználónévvel és az E-mail címmel már regisztráltak!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
                    (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
                    indicatorUI.Reset();
                    break; //foglalt az email és a felhasználónév is
            }
        }

        public void SetUserData(string email,string username, string password)
        {
            ;
            registrationModel.userData.Email = email;
            registrationModel.userData.Username = username;
            registrationModel.userData.Password = password;
            indicatorUI.Tovabb1();
        }

        public void SetProfileData(string firstname,string lastname,byte[]picture)
        {
            registrationModel.profileData.Firstname = firstname;
            registrationModel.profileData.Lastname = lastname;
            registrationModel.profileData.Picture = picture;
            insert();
        }

        private void IndicatorControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Controls.IndicatorUC).DataContext is Int32)
            {
                oldalBetoltese(Convert.ToInt32((sender as Controls.IndicatorUC).DataContext));
                //(sender as Controls.IndicatorUC).Error();
            }
        }

        /// <summary>
        /// 0-első-userdata
        /// 1-masodik-profildata
        /// 2-harmadik-kész
        /// 3-negyedik-hiba
        /// </summary>
        private void oldalBetoltese(int oldalIndex)
        {
            formsGrid.Children.Clear();
            UserControl uc = new UserControl();
            switch (oldalIndex)
            {
                case 0: 
                    uc = new Pages.RegistrationForm1();
                    uc.DataContext = registrationModel.userData;
                    break;
                case 1: 
                    uc = new Pages.RegistrationForm2();
                    uc.DataContext = registrationModel.profileData;
                    break;
                case 2: 
                    uc = new Pages.RegistrationSuccessful(); 
                    break;
            }
            formsGrid.Children.Add(uc);
        }

        public void SetPageSite(int index)
        {
            this.indicatorUI.DataContext = index;
        }

        private void IndicatorControl_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as View.Controls.IndicatorUC).Reset();
        }

        private void logo_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
            dialogUC.Show("Regisztráció megszakítása", "Biztos kilépsz a regisztrációs felületről? Ha igen, akkor az eddig felvitt adataid eltűnnek.", Alerts.DialogUC.ButtonType.YesNo, String.Empty, Alerts.DialogUC.ButtonColor.Red);
            dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged;
            (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
            (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
        }

        private void DialogUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Alerts.DialogUC).Visibility == Visibility.Collapsed)
            {
                if ((sender as Alerts.DialogUC).Result)
                {
                    //lépjen be a loginba
                    App.fwnd.moduls.Children.Add(new LoginUC());
                    App.fwnd.moduls.Children.RemoveAt(0);
                }
            }
        }


        public void ErrorMessage(string title, string description)
        {
            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
            dialogUC.Show(title, description, Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
            (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Clear();
            (App.fwnd.moduls.Children[0] as RegistrationUC).DialogGR.Children.Add(dialogUC);
        }
    }
}
