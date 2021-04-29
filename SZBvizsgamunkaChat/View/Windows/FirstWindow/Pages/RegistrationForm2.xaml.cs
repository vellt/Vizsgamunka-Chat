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
using SZBvizsgamunkaChat.View.Controls;

namespace SZBvizsgamunkaChat.View.Windows.FirstWindow.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationForm2.xaml
    /// </summary>
    public partial class RegistrationForm2 : UserControl
    {
        public RegistrationForm2()
        {
            InitializeComponent();

            Loaded += RegistrationForm2_Loaded;
        }
        private byte[] pictureArray;

        private void RegistrationForm2_Loaded(object sender, RoutedEventArgs e)
        {
            firstnameTXT.TextBoxContent.Focus();
            if ((this.DataContext as Model.RegistrationModel.ProfileData).Firstname != null) firstnameTXT.TextBoxContent.Text = (this.DataContext as Model.RegistrationModel.ProfileData).Firstname;
            if ((this.DataContext as Model.RegistrationModel.ProfileData).Lastname != null) lastnameTXT.TextBoxContent.Text = (this.DataContext as Model.RegistrationModel.ProfileData).Lastname;
            pictureArray= (this.DataContext as Model.RegistrationModel.ProfileData).Picture;
            imageHolder.ImageSource = ConvertToBitMapImage((pictureArray == null) ? ImageToByteArray(Properties.Resources.defaultPicture) : pictureArray);
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }


        /// <summary>
        /// regisztráció befejezése
        /// </summary>
        private void BigButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!textBoxFormChecker(ref firstnameTXT) && !textBoxFormChecker(ref lastnameTXT))
            {
                (App.fwnd.moduls.Children[0] as RegistrationUC).SetProfileData(firstnameTXT.TxbContent.Trim(), lastnameTXT.TxbContent.Trim(), pictureArray);
            }
        }

        private void editButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Title = "Select an image file.";
            dlg.Filter = "Jpeg Images(*.jpg)|*.jpg";
            if (dlg.ShowDialog() == true)
            {
                ImageCompressor.Resizer resizer = new ImageCompressor.Resizer(100, 100, dlg.FileName);
                pictureArray = resizer.GetByteArray();
                imageHolder.ImageSource = ConvertToBitMapImage(pictureArray);
                (App.fwnd.moduls.Children[0] as RegistrationUC).SetPicture(pictureArray);
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

        

        private bool textBoxFormChecker(ref TextBoxUC textBoxControl)
        {
            if (string.IsNullOrWhiteSpace(textBoxControl.TxbContent.Trim()))
            {
                textBoxControl.BorderColor = Brushes.Red;
                textBoxControl.TextBoxContent.Focus();
                return true;
            }
            else
            {
                textBoxControl.BorderColor = Brushes.Gray;
                return false;
            }
        }

        private void firstnameTXT_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ;
            if (!string.IsNullOrEmpty((sender as TextBoxUC).TextBoxContent.Text.Trim())) (App.fwnd.moduls.Children[0] as RegistrationUC).SetFirstname((sender as TextBoxUC).TextBoxContent.Text.Trim());

        }

        private void lastnameTXT_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBoxUC).TextBoxContent.Text.Trim())) (App.fwnd.moduls.Children[0] as RegistrationUC).SetLastname((sender as TextBoxUC).TextBoxContent.Text.Trim());
        }

       

        private void termsBTN_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (App.fwnd.moduls.Children[0] as RegistrationUC).ShowTerms(1);
        }

        private void privacyBTN_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (App.fwnd.moduls.Children[0] as RegistrationUC).ShowTerms(2);
        }
    }
}
