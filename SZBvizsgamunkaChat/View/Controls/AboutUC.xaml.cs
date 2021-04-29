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
    /// Interaction logic for AboutUC.xaml
    /// </summary>
    public partial class AboutUC : UserControl
    {
        public AboutUC(object obj)
        {
            InitializeComponent();
            aboutElement = (obj as Model.AppModel.About.AboutElement);
            this.Loaded += AboutUC_Loaded;
        }

        private void AboutUC_Loaded(object sender, RoutedEventArgs e)
        {
            this.headerCC.Content = aboutElement.Header;
            this.bodyCC.Content = aboutElement.Description; 
        }

        Model.AppModel.About.AboutElement aboutElement = null;
    }
}
