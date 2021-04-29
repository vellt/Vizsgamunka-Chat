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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SZBvizsgamunkaChat.Model;

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Settings.Pages
{
    /// <summary>
    /// Interaction logic for ProfileUpadeUC.xaml
    /// </summary>
    public partial class ProfileUpadeUC : UserControl
    {
        public ProfileUpadeUC(object obj)
        {
            InitializeComponent();

            orig = (Model.ProfileModel)obj;

            temp = new Model.ProfileModel();
            Clone(ref temp,ref orig);
            this.DataContext = temp;

            this.Loaded += ProfileUpadeUC_Loaded;
        }

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

        private void ProfileUpadeUC_Loaded(object sender, RoutedEventArgs e)
        {
            disableModify();
        }

        Model.ProfileModel orig = null;
        Model.ProfileModel temp = null;

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

        private void editButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Title = "Select an image file.";
            dlg.Filter = "Jpeg Images(*.jpg)|*.jpg";
            if (dlg.ShowDialog()==true)
            {
                //a kiválasztott képet beolvassuk byte tömbbe és azt bitmappá convertáljuk a megjelenítéshez
                ImageCompressor.Resizer resizer = new ImageCompressor.Resizer(100,100, dlg.FileName);
                temp.Picture = ConvertToBitMapImage(resizer.GetByteArray());
                enableModify();
            }
        }
        private static BitmapImage ConvertToBitMapImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(bytes))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            return image;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp.FirstName = (sender as TextBox).Text;
            enableModify();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            temp.LastName = (sender as TextBox).Text;
            enableModify();
        }

        private void btnKesz_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((btnKesz.Children[1] as ContentControl).Foreground == Brushes.White)
            {
                //módosítsa az eredeti paramétereket és az adatbáziba is történjen meg a változás
                //adatbázis update
                Model.SettingsModel settingsModel = new Model.SettingsModel(temp.ID);
                if (orig.IsEncryptsID != temp.IsEncryptsID) settingsModel.profile.IsEncryptsID = temp.IsEncryptsID;
                if (orig.LastName != temp.LastName) settingsModel.profile.LastName = temp.LastName.Trim();
                if (orig.FirstName != temp.FirstName) settingsModel.profile.FirstName = temp.FirstName.Trim();
                if (orig.Picture != temp.Picture) settingsModel.profile.Picture = byteArrayConverter(temp.Picture);

                if (isDataChanged(settingsModel.profile))
                {
                    if (settingsModel.profile.FirstName == null && settingsModel.profile.LastName == String.Empty)
                    {
                        //firstanwm ures!
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Hibás Adat", "Kérem állíton be a Keresztnevet!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                    else if (settingsModel.profile.FirstName == String.Empty && settingsModel.profile.LastName == null)
                    {
                        //lastname ures!
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Hibás Adat", "Kérem állíton be a Vezeteknevet!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                    else if (settingsModel.profile.FirstName == String.Empty && settingsModel.profile.LastName == String.Empty)
                    {
                        //lastname és a firstanem ures!
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Hibás Adatok", "Kérem állítsa be a Vezetéknevét és a Keresztnevét!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                    else
                    {
                        bool? result = settingsModel.profile.Update();
                        ;
                        if (result == null)
                        {
                            //nincs frissiteni való adat;
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.Show("Nincs Frissitendő Adat", "Az adatbázis naprakész, nincs frissítendő adat!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Green);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                        }
                        else if (result == true)
                        {
                            Clone(ref orig, ref temp);
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.Show("Sikeres Frissítés", "Sikeresen frissült a profilod!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Green);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                            disableModify();
                        }
                        else
                        {
                            //kapcsolarti hiba
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                        }
                    }

                }
                else
                {
                    Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                    dialogUC.Show("Nincs frissítendő adat", "Nincs frissítendő adat, az adatbázis naprakész!", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Green);
                    App.mainWindow.alertGR.Children.Clear();
                    App.mainWindow.alertGR.Children.Add(dialogUC);
                }
            }
        }

        private bool isDataChanged(SettingsModel.Profile profile)
        {
            if (profile.FirstName == null && profile.LastName == null && profile.Picture == null && profile.IsEncryptsID == null) return false;
            return true;
        }

        private byte[] byteArrayConverter(ImageSource imageSource)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.QualityLevel = 100;
            // byte[] bit = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create((imageSource as BitmapSource)));
                encoder.Save(stream);
                byte[] bit = stream.ToArray();
                stream.Close();

                return bit;
            }
        }

        private void SwitchUC_MouseUp(object sender, MouseButtonEventArgs e)
        {
            temp.IsEncryptsID = (int)(sender as Controls.SwitchUC).DataContext;
            enableModify();
        }
    }
}
