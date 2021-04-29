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

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Settings.Pages.SubPages
{
    /// <summary>
    /// Interaction logic for EmailUC.xaml
    /// </summary>
    public partial class EmailUC : UserControl
    {
        public EmailUC(object obj)
        {
            InitializeComponent();

            temp = new Model.ProfileModel();
            orig=(Model.ProfileModel)obj;
            Clone(ref temp, ref orig);
            this.DataContext = temp;

            this.Loaded += EmailUC_Loaded;
        }

        private void EmailUC_Loaded(object sender, RoutedEventArgs e)
        {
            disableModify(); 
        }

        Model.ProfileModel orig = null;
        Model.ProfileModel temp = null;

        private void Clone(ref Model.ProfileModel newObj, ref Model.ProfileModel oldObj)
        {
            newObj.Email = oldObj.Email;
            newObj.FirstName = oldObj.FirstName;
            newObj.ID = oldObj.ID;
            newObj.IsEncryptsID = oldObj.IsEncryptsID;
            newObj.LastName = oldObj.LastName;
            newObj.Password = oldObj.Password;
            newObj.Picture = oldObj.Picture;
        }

        private void btnKesz_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((btnKesz.Children[1] as ContentControl).Foreground == Brushes.White)
            {
                //módosítsa az eredeti paramétereket és az adatbáziba is történjen meg a változás
                //adatbázis update
                Model.SettingsModel settingsModel = new Model.SettingsModel(temp.ID);
                if (orig.Email != temp.Email)
                {
                    if (EmailIsValid(temp.Email))
                    {
                        settingsModel.user.Email = temp.Email;
                        Nullable<bool> result = settingsModel.user.Update();
                        if (result == true)
                        {
                            Clone(ref orig, ref temp);
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged;
                            dialogUC.Show("Sikeres Frissítés", "Sikeresen frissítetted az E-mail címed!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Green);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                        }
                        else if (result == null)
                        {
                            //kapcsolarti hibaAlerts.DialogUC dialogUC = new Alerts.DialogUC();
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                        }
                        else
                        {
                            //a mailcimmel már regisztráltak
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.Show("Foglalt E-mail Cím", "Ezt az E-mail címet nem állíthatja be sajátjának, mert már regisztráltak vele oldalunkra!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                        }
                    }
                    else
                    {
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Hibás Adat", "Nem feglelelő az email formátuma!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                }
                else
                {
                    //nincs frissiteni való adat;
                    Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                    dialogUC.Show("Nincs Frissitendő Adat", "Az adatbázis naprakész, nincs frissítendő adat!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Green);
                    App.mainWindow.alertGR.Children.Clear();
                    App.mainWindow.alertGR.Children.Add(dialogUC);
                }
                
            }
        }

        private bool EmailIsValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) return true;
            else return false;
        }

        private void DialogUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as Alerts.DialogUC).Visibility != Visibility.Visible)
            {
                ((this as EmailUC).Parent as Grid).Children[0].Visibility = Visibility.Visible;
                ((this as EmailUC).Parent as Grid).Children.RemoveAt(1);
            }
        }

        private void backBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((this as EmailUC).Parent as Grid).Children[0].Visibility = Visibility.Visible;
            ((this as EmailUC).Parent as Grid).Children.RemoveAt(1);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp.Email = (sender as TextBox).Text;
            enableModify();
        }

        private void enableModify()
        {
            (btnKesz.Children[0] as Rectangle).Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#96CBA4");
            (btnKesz.Children[1] as ContentControl).Foreground = Brushes.White;
            btnKesz.Cursor = Cursors.Hand;
        }

        private void disableModify()
        {
            (btnKesz.Children[0] as Rectangle).Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#E6E6E6");
            (btnKesz.Children[1] as ContentControl).Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#585858");
            btnKesz.Cursor = Cursors.Arrow;
        }
    }
}
