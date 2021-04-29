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

namespace SZBvizsgamunkaChat.View.Alerts
{
    /// <summary>
    /// Interaction logic for DialogUC.xaml
    /// </summary>
    public partial class DialogUC : UserControl
    {
        private bool result;

        public bool Result
        {
            get { return result; }
            set { result = value; }
        }

        SolidColorBrush green = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF96CBA4");
        SolidColorBrush gray = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFEFEFEF");
        SolidColorBrush red = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFE2747F");

        public enum ButtonType
        {
            Ok,
            YesNo
        }

        public enum ButtonColor
        {
            Gray,
            Green,
            Red,
        }
        
        public DialogUC()
        {
            InitializeComponent();
        }

        public void Show(string header, string body, ButtonType buttonType, string buttonContent, ButtonColor buttonColor)
        {
            this.Visibility = Visibility.Visible;
            this.header.Content = header;
            this.body.Text = body;
            switch (buttonType)
            {
                case ButtonType.Ok:
                    okGrid.Visibility = Visibility.Visible;
                    yesNoGrid.Visibility = Visibility.Collapsed;
                    break;
                case ButtonType.YesNo:
                    okGrid.Visibility = Visibility.Collapsed;
                    yesNoGrid.Visibility = Visibility.Visible;
                    break;
            }
            if (buttonType==ButtonType.Ok) okButton.Content = buttonContent;
            switch (buttonColor)
            {
                case ButtonColor.Green:
                    (okButton.Parent as Grid).Background = green;
                    (noButton.Parent as Grid).Background = green;
                    break;
                case ButtonColor.Red:
                    (okButton.Parent as Grid).Background = red;
                    (noButton.Parent as Grid).Background = red;
                    break;
                case ButtonColor.Gray:
                    (okButton.Parent as Grid).Background = gray;
                    (noButton.Parent as Grid).Background = gray;
                    break;
            }
        }

        private void close_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Result = false;
            this.Visibility = Visibility.Collapsed;
        }

        private void okButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Result = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void yesButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Result = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void noButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Result = false;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
