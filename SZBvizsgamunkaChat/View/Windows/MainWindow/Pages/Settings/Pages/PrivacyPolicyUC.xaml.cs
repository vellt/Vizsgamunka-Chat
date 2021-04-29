using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PrivacyPolicyUC.xaml
    /// </summary>
    public partial class PrivacyPolicyUC : UserControl
    {
        public PrivacyPolicyUC(object obj)
        {
            InitializeComponent();
            //(Model.AppModel.PrivacyPolicy.PrivacyPolicyElement) c.Select(x => x.ToString()).ToList();
            privacyPoliciesList =(obj as List<Model.AppModel.PrivacyPolicy.PrivacyPolicyElement>);
            this.Loaded += PrivacyPolicyUC_Loaded;
        }
        List<Model.AppModel.PrivacyPolicy.PrivacyPolicyElement> privacyPoliciesList = new List<Model.AppModel.PrivacyPolicy.PrivacyPolicyElement>();
        private void PrivacyPolicyUC_Loaded(object sender, RoutedEventArgs e)
        {
            loadDatas();
        }

        private void loadDatas()
        {
            if (privacyPoliciesList.Count == 0)
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
                for (int i = 0; i < privacyPoliciesList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(privacyPoliciesList[i].Header))
                    {
                        Controls.PrivacyPolicyHeaderUC header = new Controls.PrivacyPolicyHeaderUC((privacyPoliciesList[i].Header));
                        SpPlace.Children.Add(header);
                    }
                    if (!string.IsNullOrEmpty(privacyPoliciesList[i].Description))
                    {
                        Controls.PrivacyPolicyBodyUC body = new Controls.PrivacyPolicyBodyUC((privacyPoliciesList[i].Description));
                        SpPlace.Children.Add(body);
                    }
                }
            }
        }
    }
}
