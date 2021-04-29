using System;
using System.Collections.Generic;
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
    /// Interaction logic for PwdBoxUC.xaml
    /// </summary>
    public partial class PwdBoxUC : UserControl
    {
        public PwdBoxUC()
        {
            InitializeComponent();
        }

        private string pwdContent="";

        public string PwdContent
        {
            get { return pwdContent; }
            set { pwdContent = value; }
        }

        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Brush), typeof(PwdBoxUC), new PropertyMetadata(Brushes.Gray));

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(PwdBoxUC), new PropertyMetadata("Place holder"));

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceHolderContent.Visibility = (String.IsNullOrWhiteSpace(pwdBoxContent.Password.Trim())) ? Visibility.Visible : Visibility.Collapsed;
            PwdContent = pwdBoxContent.Password.Trim();
            pwdBoxControl.DataContext = PwdContent;
        }

        private void PlaceHolderContent_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdBoxContent.Focus();
        }
    }
}
