using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZBvizsgamunkaChat.View.Controls
{
    /// <summary>
    /// Interaction logic for HelpButtonUC.xaml
    /// </summary>
    public partial class HelpButtonUC : UserControl
    {
        public HelpButtonUC(object obj)
        {
            InitializeComponent();
            helpElement = (Model.AppModel.Help.HelpElement)obj;
            this.Loaded += HelpButtonUC_Loaded;
        }

        Model.AppModel.Help.HelpElement helpElement = null;


        private void HelpButtonUC_Loaded(object sender, RoutedEventArgs e)
        {
            groupNameCC.Content = helpElement.GroupName;
            for (int i = 0; i < helpElement.ContentList.Count; i++)
            {
                if (!string.IsNullOrEmpty(helpElement.ContentList[i].Header))
                {
                    Controls.PrivacyPolicyHeaderUC header = new Controls.PrivacyPolicyHeaderUC((helpElement.ContentList[i].Header));
                    SPplace.Children.Add(header);
                }
                if (!string.IsNullOrEmpty(helpElement.ContentList[i].Description))
                {
                    Controls.PrivacyPolicyBodyUC body = new Controls.PrivacyPolicyBodyUC((helpElement.ContentList[i].Description));
                    SPplace.Children.Add(body);
                }
            }
        }

        private void ClickGR_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SPplace.Visibility==Visibility.Visible)
            {
                SPplace.Visibility = Visibility.Collapsed;
                lineGR.Visibility = Visibility.Collapsed;
                Storyboard sb = this.FindResource("arrowAnimatin2") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
                
            }
            else
            {
                SPplace.Visibility = Visibility.Visible;
                lineGR.Visibility = Visibility.Visible;
                Storyboard sb = this.FindResource("arrowAnimation") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
            }
        }
    }
}
