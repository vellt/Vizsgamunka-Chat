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

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Settings.Pages
{
    /// <summary>
    /// Interaction logic for TermsUC.xaml
    /// </summary>
    public partial class TermsUC : UserControl
    {
        public TermsUC(object obj)
        {
            InitializeComponent();
            //(Model.AppModel.PrivacyPolicy.PrivacyPolicyElement) c.Select(x => x.ToString()).ToList();
            termsList = (obj as List<Model.AppModel.Terms.TermsElement>);
            this.Loaded += TermsUC_Loaded;
        }

        List<Model.AppModel.Terms.TermsElement> termsList = new List<Model.AppModel.Terms.TermsElement>();
        private void TermsUC_Loaded(object sender, RoutedEventArgs e)
        {
            loadDatas();
        }

        private void loadDatas()
        {
            if (termsList.Count == 0)
            {
                if (App.fwnd.AppModelSynch())
                {
                    loadDatas();
                }
                else
                {
                    Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                    dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra.", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    App.mainWindow.alertGR.Children.Clear();
                    App.mainWindow.alertGR.Children.Add(dialogUC);
                }
            }
            else
            {
                for (int i = 0; i < termsList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(termsList[i].Header))
                    {
                        Controls.PrivacyPolicyHeaderUC header = new Controls.PrivacyPolicyHeaderUC((termsList[i].Header));
                        SpPlace.Children.Add(header);
                    }
                    if (!string.IsNullOrEmpty(termsList[i].Description))
                    {
                        Controls.PrivacyPolicyBodyUC body = new Controls.PrivacyPolicyBodyUC((termsList[i].Description));
                        SpPlace.Children.Add(body);
                    }
                }
            }
        }

    }
}
