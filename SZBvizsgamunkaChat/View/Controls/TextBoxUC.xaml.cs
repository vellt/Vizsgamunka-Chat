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
    /// Interaction logic for TextBoxUC.xaml
    /// </summary>
    public partial class TextBoxUC : UserControl
    {
        public TextBoxUC()
        {
            InitializeComponent();
        }

        private string txbContent="";

        public string TxbContent
        {
            get { return txbContent; }
            set { txbContent = value; }
        }

        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Brush), typeof(TextBoxUC), new PropertyMetadata(Brushes.Gray));

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextBoxUC), new PropertyMetadata("placeholder"));

        private void PlaceHolderContent_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxContent.Focus();
        }

        private void TextBoxContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceHolderContent.Visibility = (String.IsNullOrWhiteSpace(TextBoxContent.Text.Trim())) ? Visibility.Visible : Visibility.Collapsed;
            TxbContent = TextBoxContent.Text.Trim();
            TextBoxCntr.DataContext = TxbContent;
        }

    }
}
