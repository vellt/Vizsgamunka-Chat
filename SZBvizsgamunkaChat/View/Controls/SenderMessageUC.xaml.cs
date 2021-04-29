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
    /// Interaction logic for SenderMessageUC.xaml
    /// </summary>
    public partial class SenderMessageUC : UserControl
    {
        public SenderMessageUC(object obj1, object obj2)
        {
            InitializeComponent();

            this.DataContext = (Model.MessagesModel.Messages.Content)obj1;
            this.profilepicGR.DataContext = (Model.MessagesModel.Messages)obj2;
        }
    }
}
