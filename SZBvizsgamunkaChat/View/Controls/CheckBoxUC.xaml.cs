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
    /// Interaction logic for CheckBoxUC.xaml
    /// </summary>
    public partial class CheckBoxUC : UserControl
    {
        public CheckBoxUC()
        {
            InitializeComponent();
        }

        private void UserControl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            (sender as CheckBoxUC).DataContext= ((((sender as CheckBoxUC).Content as Border).Child as UserControl).Visibility == Visibility.Visible) ? 0 : 1;
        }

        private void checkBoxControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (((sender as CheckBoxUC).Content as Border).Child as UserControl).Visibility = (Convert.ToInt32((sender as CheckBoxUC).DataContext) == 0) ? Visibility.Collapsed : Visibility.Visible;
            //0==unselected
            //1==selected
        }
    }
}
