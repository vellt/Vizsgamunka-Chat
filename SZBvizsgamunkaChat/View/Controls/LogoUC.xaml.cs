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
    /// Interaction logic for LogoUC.xaml
    /// </summary>
    public partial class LogoUC : UserControl
    {
        public LogoUC()
        {
            InitializeComponent();
        }



        public string LogoName
        {
            get { return (string)GetValue(LogoNameProperty); }
            set { SetValue(LogoNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LogoName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogoNameProperty =
            DependencyProperty.Register("LogoName", typeof(string), typeof(LogoUC), new PropertyMetadata("CHAT APP"));



        public string SubName
        {
            get { return (string)GetValue(SubNameProperty); }
            set { SetValue(SubNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubNameProperty =
            DependencyProperty.Register("SubName", typeof(string), typeof(LogoUC), new PropertyMetadata("Éld át a közösség erejét"));


    }
}
