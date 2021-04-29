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

namespace SZBvizsgamunkaChat.View.Windows.FirstWindow.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationSuccessful.xaml
    /// </summary>
    public partial class RegistrationSuccessful : UserControl
    {
        public RegistrationSuccessful()
        {
            InitializeComponent();
        }

        //todo: navigáld vissza a loginra
        private void Border_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.fwnd.moduls.Children.Add(new LoginUC());
            App.fwnd.moduls.Children.RemoveAt(0);
        }
    }
}
