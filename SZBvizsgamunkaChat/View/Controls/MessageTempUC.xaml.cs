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
    /// Interaction logic for MessageTempUC.xaml
    /// </summary>
    public partial class MessageTempUC : UserControl
    {
        public MessageTempUC(object obj)
        {
            InitializeComponent();
            this.DataContext = obj as Model.MessagesModel.Messages;
            lastMessageTXBK.Text = (obj as Model.MessagesModel.Messages).ContentList[(obj as Model.MessagesModel.Messages).ContentList.Count - 1].Message;
            messageDateTXBK.Text = (obj as Model.MessagesModel.Messages).ContentList[(obj as Model.MessagesModel.Messages).ContentList.Count - 1].MessageDate;
            if ((obj as Model.MessagesModel.Messages).ContentList[(obj as Model.MessagesModel.Messages).ContentList.Count - 1].IsMy==false)
            {
                lastMessageTXBK.FontWeight = FontWeights.Bold;
                messageDateTXBK.FontWeight = FontWeights.Bold;
            }
        }
    }
}
