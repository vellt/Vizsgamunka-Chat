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
    /// Interaction logic for AboutUC.xaml
    /// </summary>
    public partial class AboutUC : UserControl
    {
        public AboutUC(object obj)
        {
            InitializeComponent();
            aboutElementsList= (obj as List<Model.AppModel.About.AboutElement>);
            this.Loaded += AboutUC_Loaded;
        }

        List<Model.AppModel.About.AboutElement> aboutElementsList = new List<Model.AppModel.About.AboutElement>();
        private void AboutUC_Loaded(object sender, RoutedEventArgs e)
        {
            loadDatas();
        }

        private void loadDatas()
        {
            if (aboutElementsList.Count == 0)
            {
                if (!App.fwnd.AppModelSynch())
                {
                    Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                    dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra.", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                    App.mainWindow.alertGR.Children.Clear();
                    App.mainWindow.alertGR.Children.Add(dialogUC);
                    dialogUC.IsVisibleChanged += DialogUC_IsVisibleChanged;
                }
                else
                {
                    loadDatas();
                }
            }
            else
            {
                for (int i = 0; i < aboutElementsList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(aboutElementsList[i].Header))
                    {
                        Controls.AboutUC about = new Controls.AboutUC(aboutElementsList[i]);
                        SpPlace.Children.Add(about);
                    }
                }
            }
        }

        private void DialogUC_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender as Alerts.DialogUC).IsVisible)
            {
                loadDatas();
            }
        }
    }
}
