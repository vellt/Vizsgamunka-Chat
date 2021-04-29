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

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Settings
{
    /// <summary>
    /// Interaction logic for SettingsUC.xaml
    /// </summary>
    public partial class SettingsUC : UserControl
    {
        public SettingsUC(object obj)
        {
            InitializeComponent();
            profileModel = (Model.ProfileModel)obj;
            Loaded += SettingsUC_Loaded;
        }

        Model.ProfileModel profileModel = null;

        private void SettingsUC_Loaded(object sender, RoutedEventArgs e)
        {
            SelectSubPage(0);
        }

        private void navigation_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SelectSubPage(beallitasokBox.Children.IndexOf((sender as Grid)));
        }

        private void SelectSubPage(int index)
        {
            beallitasokSubPage.Children.Clear();
            changeBackgroundByIndex(index);
            switch (index)
            {
                case 0: beallitasokSubPage.Children.Add(new Pages.ProfileUpadeUC(profileModel)); break;
                case 1: beallitasokSubPage.Children.Add(new Pages.AccountSettingsUC(profileModel)); break;
                case 2: beallitasokSubPage.Children.Add(new Pages.PrivacyPolicyUC((List<Model.AppModel.PrivacyPolicy.PrivacyPolicyElement>)App.fwnd.GetPrivacy())); break;
                case 3: beallitasokSubPage.Children.Add(new Pages.TermsUC((List<Model.AppModel.Terms.TermsElement>)App.fwnd.GetTerms())); break;
                case 4: beallitasokSubPage.Children.Add(new Pages.HelpUC((List<Model.AppModel.Help.HelpElement>)App.fwnd.GetHelp())); break;
                case 5: beallitasokSubPage.Children.Add(new Pages.AboutUC((List<Model.AppModel.About.AboutElement>)App.fwnd.GetAbout())); break;
            }
        }

        private void changeBackgroundByIndex(int index)
        {
            for (int i = 0; i < beallitasokBox.Children.Count; i++)
            {
                (beallitasokBox.Children[i] as Grid).Background = Brushes.White;
            }
            (beallitasokBox.Children[index] as Grid).Background = Brushes.WhiteSmoke;
        }
    }
}
