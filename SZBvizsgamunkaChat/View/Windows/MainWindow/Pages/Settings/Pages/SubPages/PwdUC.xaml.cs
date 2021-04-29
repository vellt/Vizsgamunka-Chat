using System;
using System.Collections.Generic;
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

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Settings.Pages.SubPages
{
    /// <summary>
    /// Interaction logic for PwdUC.xaml
    /// </summary>
    public partial class PwdUC : UserControl
    {
        public PwdUC(object obj)
        {
            InitializeComponent();
            orig = (Model.ProfileModel)obj;
            this.Loaded += PwdUC_Loaded;
        }

        private void PwdUC_Loaded(object sender, RoutedEventArgs e)
        {
            disableModify();
        }

        Model.ProfileModel orig = null;
       
        
        private void backBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((this as PwdUC).Parent as Grid).Children[0].Visibility = Visibility.Visible;
            ((this as PwdUC).Parent as Grid).Children.RemoveAt(1);
        }

        private void btnKesz_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((btnKesz.Children[1] as ContentControl).Foreground == Brushes.White)
            {
                string uz1 = "A jelenlegi jelszó tévesen van megadnva! Kérjük ellerőrízze annak helyességét!";
                string uz2 = "Az új jelszónak mind a két esetben egyeznie kell!";
                if (checkedMatch(jelenlegiJelszoUC.getPassword(), orig.Password, uz1) && (checkedMatch(ujJelszoUC.getPassword(), ujJelszoUjraUC.getPassword(), uz2)))
                {
                    //minden okés történjen meg a módosítás
                    Model.SettingsModel settingsModel = new Model.SettingsModel(orig.ID);
                    settingsModel.user.Password = ujJelszoUjraUC.getPassword();

                    Nullable<bool> result = settingsModel.user.Update();
                    if (result == true)
                    {
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged;
                        dialogUC.Show("Sikeres Frissítés", "Sikeresen frissítetted a jelszavadat!", Alerts.DialogUC.ButtonType.Ok, "ok", Alerts.DialogUC.ButtonColor.Green);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                    else
                    {
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra!", Alerts.DialogUC.ButtonType.Ok, "ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                }
            }
        }

        private bool checkedMatch(string s1, string s2, string uzenet)
        {
            if (s1 == s2)
            {
                return true;
            }
            else
            {
                Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                dialogUC.Show("Hiba", uzenet, Alerts.DialogUC.ButtonType.Ok, "ok", Alerts.DialogUC.ButtonColor.Red);
                App.mainWindow.alertGR.Children.Clear();
                App.mainWindow.alertGR.Children.Add(dialogUC);
                return false;
            }
        }

        private void DialogUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if((sender as Alerts.DialogUC).Visibility!=Visibility.Visible)
            {
                ((this as PwdUC).Parent as Grid).Children[0].Visibility = Visibility.Visible;
                ((this as PwdUC).Parent as Grid).Children.RemoveAt(1);
            }
            
        }

        private void DataContextChanged1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(jelenlegiJelszoUC.getPassword()) && !string.IsNullOrWhiteSpace(ujJelszoUC.getPassword()) && !string.IsNullOrWhiteSpace(ujJelszoUjraUC.getPassword()))
            {
                enableModify();
            }
            else
            {
                disableModify();
            }
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
