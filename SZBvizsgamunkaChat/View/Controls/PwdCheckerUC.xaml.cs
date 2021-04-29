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

namespace SZBvizsgamunkaChat.View.Controls
{
    /// <summary>
    /// Interaction logic for PwdCheckerUC.xaml
    /// </summary>
    public partial class PwdCheckerUC : UserControl
    {
        public PwdCheckerUC()
        {
            InitializeComponent();
        }




        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PwdCheckerUC), new PropertyMetadata("jelszó"));




        private void eyeBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                passwordBox.Visibility = Visibility.Collapsed;
                string szoveg = passwordBox.Password;
                textBox.Text = szoveg;
                textBox.Visibility = Visibility.Visible;
                textBox.SelectionStart = szoveg.Length;
                textBox.Focus();
                if (string.IsNullOrEmpty(szoveg.Trim())) Keyboard.ClearFocus();
            }
            else
            {
                textBox.Visibility = Visibility.Collapsed;
                string szoveg = textBox.Text;
                passwordBox.Password = szoveg;
                passwordBox.Visibility = Visibility.Visible;
                SetSelection(passwordBox, szoveg.Length, 0);
                passwordBox.Focus();
                if (string.IsNullOrEmpty(szoveg.Trim())) Keyboard.ClearFocus();
            }
        }

        private void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(passwordBox, new object[] { start, length });
        }

        private void currentPwdCC_MouseUp(object sender, MouseButtonEventArgs e)
        {
            currentPwdCC.Visibility = Visibility.Collapsed;
            if (textBox.Visibility==Visibility.Visible) textBox.Focus();
            if (passwordBox.Visibility == Visibility.Visible) passwordBox.Focus();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox.Tag = DateTime.Now;
            this.DataContext = textBox.Text;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordBox.Tag = DateTime.Now;
            this.DataContext = passwordBox.Password;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text)) currentPwdCC.Visibility = Visibility.Visible;
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Password)) currentPwdCC.Visibility = Visibility.Visible;
        }

        public string getPassword()
        {
            int egy = ((passwordBox.Tag == null) ? 0 : ((DateTime)passwordBox.Tag).Second);
            int ketto = ((textBox.Tag == null) ? 0 : ((DateTime)textBox.Tag).Second);
            return String.Format((egy > ketto) ? passwordBox.Password.ToString() : textBox.Text.ToString());
        }
    }
}
