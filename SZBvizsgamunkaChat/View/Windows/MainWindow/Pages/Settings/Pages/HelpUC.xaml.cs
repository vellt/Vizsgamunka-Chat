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
    /// Interaction logic for HelpUC.xaml
    /// </summary>
    public partial class HelpUC : UserControl
    {
        public HelpUC(object obj)
        {
            InitializeComponent();

            helpElements = (obj as List<Model.AppModel.Help.HelpElement>);
            this.Loaded += HelpUC_Loaded;
        }
        List<Model.AppModel.Help.HelpElement> helpElements = new List<Model.AppModel.Help.HelpElement>();

        private void HelpUC_Loaded(object sender, RoutedEventArgs e)
        {
            loadDatas();
        }

        private void loadDatas()
        {
            if (helpElements.Count == 0)
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
                for (int i = 0; i < helpElements.Count; i++)
                {
                    Controls.HelpButtonUC helpButtonUC = new Controls.HelpButtonUC(helpElements[i]);
                    SpPlace.Children.Add(helpButtonUC);

                }
            }
        }

    }
}
