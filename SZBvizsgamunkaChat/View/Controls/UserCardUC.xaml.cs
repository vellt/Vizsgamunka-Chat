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
    /// Interaction logic for UserCardUC.xaml
    /// </summary>
    public partial class UserCardUC : UserControl
    {
        public UserCardUC(object obj)
        {
            InitializeComponent();
            this.DataContext = (Model.HomeModel.User)obj;
        }

        private void grid2_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
            if (sb != null) { BeginStoryboard(sb); }
        }

        private void grid2_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
            if (sb != null) { BeginStoryboard(sb); }
        }
    }
}
