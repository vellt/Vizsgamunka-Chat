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
    /// Interaction logic for SearchBarUC.xaml
    /// </summary>
    public partial class SearchBarUC : UserControl
    {
        public SearchBarUC()
        {
            InitializeComponent();
        }

        

        private void keresoContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keresoContent.Text == String.Empty) keresoHatter.Visibility = Visibility.Visible;
            else keresoHatter.Visibility = Visibility.Collapsed;
            changeDataContent();

        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            keresoContent.Focus();
        }


        private void changeDataContent()
        {
            this.DataContext = keresoContent.Text;
        }
    }
}
