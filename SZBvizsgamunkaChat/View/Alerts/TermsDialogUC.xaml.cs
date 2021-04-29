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
using SZBvizsgamunkaChat.View.Windows.FirstWindow;

namespace SZBvizsgamunkaChat.View.Alerts
{
    /// <summary>
    /// Interaction logic for TermsDialogUC.xaml
    /// </summary>
    public partial class TermsDialogUC : UserControl
    {
        public TermsDialogUC()
        {
            InitializeComponent();
        }

        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (App.fwnd.moduls.Children[0] is RegistrationUC) (App.fwnd.moduls.Children[0] as RegistrationUC).HideTerms();
            else (App.fwnd.moduls.Children[0] as LoginUC).HideTerms();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gombHatter.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gombHatter.Visibility = Visibility.Collapsed;
        }

        public void SetTerms()
        {
            termsPlaceSP.Children.Clear();
            List<Model.AppModel.Terms.TermsElement> list = (App.fwnd.GetTerms() as List<Model.AppModel.Terms.TermsElement>);
            halozatiHibaGR.Visibility = Visibility.Collapsed;



            if (list.Count==0)
            {
                if (App.fwnd.AppModelSynch())
                {
                    SetTerms();
                }
                else
                {
                    halozatiHibaGR.Visibility = Visibility.Visible;
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!string.IsNullOrEmpty(list[i].Header))
                    {
                        Controls.PrivacyPolicyHeaderUC header = new Controls.PrivacyPolicyHeaderUC((list[i].Header));
                        termsPlaceSP.Children.Add(header);
                    }
                    if (!string.IsNullOrEmpty(list[i].Description))
                    {
                        Controls.PrivacyPolicyBodyUC body = new Controls.PrivacyPolicyBodyUC((list[i].Description));
                        termsPlaceSP.Children.Add(body);
                    }
                }
            }
            (termsPlaceSP.Parent as ScrollViewer).ScrollToHome();
        }


        public void SetPrivacy()
        {
            termsPlaceSP.Children.Clear();
            List<Model.AppModel.PrivacyPolicy.PrivacyPolicyElement> list = (App.fwnd.GetPrivacy() as List<Model.AppModel.PrivacyPolicy.PrivacyPolicyElement>);
            halozatiHibaGR.Visibility = Visibility.Collapsed;
            if (list.Count == 0)
            {
                if (App.fwnd.AppModelSynch())
                {
                    SetPrivacy();
                }
                else
                {
                    halozatiHibaGR.Visibility = Visibility.Visible;
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!string.IsNullOrEmpty(list[i].Header))
                    {
                        Controls.PrivacyPolicyHeaderUC header = new Controls.PrivacyPolicyHeaderUC((list[i].Header));
                        termsPlaceSP.Children.Add(header);
                    }
                    if (!string.IsNullOrEmpty(list[i].Description))
                    {
                        Controls.PrivacyPolicyBodyUC body = new Controls.PrivacyPolicyBodyUC((list[i].Description));
                        termsPlaceSP.Children.Add(body);
                    }
                }
            }
            (termsPlaceSP.Parent as ScrollViewer).ScrollToHome();
        }
    }
}
