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
    /// Interaction logic for SwitchUC.xaml
    /// </summary>
    public partial class SwitchUC : UserControl
    {
        public SwitchUC()
        {
            InitializeComponent();
            this.DataContextChanged += SwitchUC_DataContextChanged;

            
            
        }

        private int kiold = 0;

        private void SwitchUC_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((int)this.DataContext == 2)
            {
                colorBackground(false);
            }
            else
            {
                colorBackground(true);
            }
        }

        private void switchGrid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //HandlesScrolling a hattert zolddel egyenlőő akkor false;
            kiold = 1;
            if ((int)this.DataContext==2)
            {
                this.DataContext = 1;
            }
            else
            {
                this.DataContext = 2;
            }
        }

        private void colorBackground(Boolean boolean)
        {
            if (boolean)
            {
                if (kiold==0)
                {
                    ball.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    Storyboard sb = this.FindResource("moveAnimation") as Storyboard;
                    if (sb != null) { BeginStoryboard(sb); }
                }
                background.Fill = (Brush)new BrushConverter().ConvertFrom("#96CBA4");
            }
            else
            {
                
                if (kiold==0)
                {
                    ball.HorizontalAlignment = HorizontalAlignment.Left;
                }
                else
                {
                    Storyboard sb = this.FindResource("moveAnimation2") as Storyboard;
                    if (sb != null) { BeginStoryboard(sb); }
                }
                background.Fill = (Brush)new BrushConverter().ConvertFrom("#E1E1E1");
            }
        }
    }
}
