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
using System.Windows.Shapes;

namespace SZBvizsgamunkaChat.View.Windows.FirstWindow
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        private App.FirstWindowPages firstWindowPages;

        public App.FirstWindowPages FirstWindowPages
        {
            get { return firstWindowPages; }
            set
            {
                firstWindowPages = value;

                switch (firstWindowPages)
                {
                    case App.FirstWindowPages.Registration: moduls.Children.Add(new RegistrationUC()); break;
                    case App.FirstWindowPages.Login:
                        moduls.Children.Clear();
                        moduls.Children.Add(new LoginUC());
                        break;
                }
            }
        }

        public FirstWindow()
        {
            InitializeComponent();
            this.Loaded += FirstWindow_Loaded;
        }

        Model.AppModel appModel = null;

        private void FirstWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AppModelSynch();
        }

        public object GetTerms()
        {
            return appModel.terms.List;
        }

        public object GetPrivacy()
        {
            return appModel.privacyPolicy.List;
        }

        public object GetHelp()
        {
            return appModel.help.List;
        }

        public object GetAbout()
        {
            return appModel.about.List;
        }

        public bool AppModelSynch()
        {
            appModel = new Model.AppModel();
            return appModel.Synch();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
