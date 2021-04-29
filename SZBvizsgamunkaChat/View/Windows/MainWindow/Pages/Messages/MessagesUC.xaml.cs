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

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Messages
{
    /// <summary>
    /// Interaction logic for MessagesUC.xaml
    /// </summary>
    public partial class MessagesUC : UserControl
    {
        public MessagesUC(object obj, int isEncryptsID)
        {
            InitializeComponent();
            messagesModel = obj as Model.MessagesModel;
            this.currentMessageID = 0;
            this.encryptsID = isEncryptsID;
            this.Loaded += MessagesUC_Loaded;
        }

        Model.MessagesModel messagesModel = null;
        Model.HomeModel.User user = null;
        int encryptsID = -1;
        int currentMessageID = -1;
        public void Synch(object obj)
        {
            this.messagesModel = obj as Model.MessagesModel;

        }

        public void SynchAndScrollBottom(object obj)
        {
            this.messagesModel = obj as Model.MessagesModel;
            loadDatas();
            (messagesHolderSP.Parent as ScrollViewer).ScrollToEnd();
        }

        public void NewMessageStarter(object obj)
        {
            user = obj as Model.HomeModel.User;

            this.currentMessageID = findMIDfromUID(user.UID);
            if (currentMessageID == -1)
            {
                NewMessageBox.Children.Clear();
                Controls.NewMessageTempUC newMessageTempUC = new Controls.NewMessageTempUC();
                newMessageTempUC.DataContext = user;
                NewMessageBox.Children.Add(newMessageTempUC);
                currentMessageID = -1;
                messagesHolderSP.Children.Clear();
                loadDatas();
                this.headerGR.DataContext = user;
            }
            else
            {
                loadDatas();
            }
        }

        private int findMIDfromUID(int uID)
        {
            for (int i = 0; i < messagesModel.messagesList.Count; i++)
            {
                if (messagesModel.messagesList[i].UID == uID)
                {
                    return messagesModel.messagesList[i].MID;
                }
            }
            return -1;
        }

        private void MessagesUC_Loaded(object sender, RoutedEventArgs e)
        {
            loadDatas();
            TextBoxUzenet.Focus();
            (messagesHolderSP.Parent as ScrollViewer).ScrollToEnd();
        }



        public void loadDatas()
        {
            if (messagesModel.messagesList.Count != 0)
            {
                //eltünteti azt a lapot
                uzenetContainerGR.Visibility = Visibility.Visible;
                fedlapGR.Visibility = Visibility.Collapsed;
                MessageBox.Children.Clear();
                SortMessagesTemp();
                for (int i = 0; i < messagesModel.messagesList.Count; i++)
                {
                    Controls.MessageTempUC messageTempUC = new Controls.MessageTempUC(messagesModel.messagesList[i]);
                    messageTempUC.PreviewMouseUp += MessageTempUC_PreviewMouseUp;
                    MessageBox.Children.Add(messageTempUC);
                }
                int index = findIndexFromMID(currentMessageID);
                if (index != -1)
                {
                    changeBackgroundByIndex(index);
                    loadContentDatas(index);

                }

            }
            else
            {
                if (NewMessageBox.Children.Count == 0)
                {
                    fedlapGR.Visibility = Visibility.Visible;
                    uzenetContainerGR.Visibility = Visibility.Collapsed;
                }
                else
                {
                    uzenetContainerGR.Visibility = Visibility.Visible;
                    fedlapGR.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SortMessagesTemp()
        {
            messagesModel.messagesList.Sort((emp1, emp2) => emp2.ContentList[emp2.ContentList.Count - 1].UnformatedDateTime.CompareTo(emp1.ContentList[emp1.ContentList.Count - 1].UnformatedDateTime));
        }

        private void loadContentDatas(int index)
        {
            messagesHolderSP.Children.Clear();
            this.headerGR.DataContext = messagesModel.messagesList[index];
            for (int i = 0; i < messagesModel.messagesList[index].ContentList.Count; i++)
            {
                if (messagesModel.messagesList[index].ContentList[i].IsMy) messagesHolderSP.Children.Add(new Controls.ReceiverMessageUC(messagesModel.messagesList[index].ContentList[i]));
                else messagesHolderSP.Children.Add(new Controls.SenderMessageUC(messagesModel.messagesList[index].ContentList[i], messagesModel.messagesList[index]));
            }

        }

        private int findIndexFromMID(int currentMID)
        {
            for (int i = 0; i < messagesModel.messagesList.Count; i++)
            {
                if (messagesModel.messagesList[i].MID == currentMID)
                {
                    return i;
                }
            }
            if (currentMID == -1)
            {
                return -1;
            }
            this.currentMessageID = messagesModel.messagesList[0].MID;
            return findIndexFromMID(currentMessageID);
        }

        private void MessageTempUC_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (menuBTN.Margin.Right == 90)
            {
                Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
            }
            NewMessageBox.Children.Clear();
            if (messagesModel.CurrentMID != ((sender as Controls.MessageTempUC).DataContext as Model.MessagesModel.Messages).MID)
            {
                TextBoxUzenet.Text = String.Empty;
            }
            this.currentMessageID = ((sender as Controls.MessageTempUC).DataContext as Model.MessagesModel.Messages).MID;
            loadDatas();
            (messagesHolderSP.Parent as ScrollViewer).ScrollToEnd();
        }

        private void changeBackgroundByIndex(int index)
        {
            for (int i = 0; i < MessageBox.Children.Count; i++) ((MessageBox.Children[i] as Controls.MessageTempUC).Content as Grid).Background = Brushes.White;
            ((MessageBox.Children[index] as Controls.MessageTempUC).Content as Grid).Background = Brushes.WhiteSmoke;
        }


        private void plusButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.SelectPage(0);
        }

        private void SearchBarUC_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            normalListaSP.Visibility = Visibility.Collapsed;
            this.szurtListaSP.Children.Clear();
            string finderText = ((sender as Controls.SearchBarUC).DataContext == null) ? string.Empty : ((sender as Controls.SearchBarUC).DataContext as String);
            if (!string.IsNullOrEmpty(finderText))
            {
                for (int i = 0; i < messagesModel.messagesList.Count; i++)
                {
                    //if (messagesModel.messagesList[i].Fullname.ToUpper().StartsWith(finderText.ToUpper()))
                    if(startWithOwn(messagesModel.messagesList[i].Fullname.ToUpper(), finderText.ToUpper()))
                    {
                        Controls.MessageTempUC messageTempUC = new Controls.MessageTempUC(messagesModel.messagesList[i]);
                        messageTempUC.PreviewMouseUp += MessageTempUC_PreviewMouseUp;
                        messageTempUC.PreviewMouseUp += MessageTempUC_PreviewMouseUp2;
                        this.szurtListaSP.Children.Add(messageTempUC);
                    }
                }
            }
            else
            {
                this.szurtListaSP.Children.Clear();
                normalListaSP.Visibility = Visibility.Visible;
                loadDatas();
            }
        }

        private bool startWithOwn(string stringliteral, string value)
        {
            string temp = String.Empty;
            for (int i = 0; i < value.Length; i++) temp += stringliteral[i];
            return temp.Equals(value);
        }

        private void MessageTempUC_PreviewMouseUp2(object sender, MouseButtonEventArgs e)
        {
            SearchBar.keresoContent.Text = String.Empty; //ennek hatására a meghívja az eseméynt "datacontextcahnged"-nek az else ágát
        }

        private void TextBoxUzenet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxUzenet.Text == String.Empty) uzenetHatter.Visibility = Visibility.Visible;
            else uzenetHatter.Visibility = Visibility.Collapsed;
        }

        private void menuBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            ((sender as Grid).Children[0] as Rectangle).Visibility = Visibility.Visible;
        }

        private void menuBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            ((sender as Grid).Children[0] as Rectangle).Visibility = Visibility.Collapsed;
        }

        private void menuBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((sender as Grid).Margin.Right == 90)
            {
                Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
            }
            else
            {
                Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
            }
        }

        private void sendButtonGR_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            sendMessage();
        }

        private void sendMessage()
        {
            if (!string.IsNullOrEmpty(TextBoxUzenet.Text.Trim()))
            {
                messagesModel.CurrentMID = this.currentMessageID;
                if (messagesModel.CurrentMID == -1)
                {
                    messagesModel.CurrentMID = messagesModel.Add(user.UID);
                    if (messagesModel.CurrentMID != -1)
                    {
                        if (messagesModel.Insert(TextBoxUzenet.Text, encryptsID))
                        {
                            TextBoxUzenet.Text = String.Empty;
                            NewMessageBox.Children.Clear();
                            this.currentMessageID = 0;
                        }
                        else
                        {
                            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                            dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra.", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                            App.mainWindow.alertGR.Children.Clear();
                            App.mainWindow.alertGR.Children.Add(dialogUC);
                        }
                    }
                }
                else
                {
                    if (messagesModel.Insert(TextBoxUzenet.Text, encryptsID)) TextBoxUzenet.Text = String.Empty;
                    else
                    {
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Nincs Internetkapcsolat", "Kérjük ellenőrízze az internetkapcsolatát, majd próbálja újra.", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                }
            }
        }

        private void TextBoxUzenet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) sendMessage();
        }

        private void deleteMessageBTN_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Alerts.DialogUC dialogUC = new Alerts.DialogUC();
            dialogUC.IsVisibleChanged += Dialog_UC_uznetTorlese;
            dialogUC.Show("Üzenet törlése", "Az eddigi beszélgetésed tartalma eltűnik, amely nem állítható vissza. Ha biztos vagy a döntésedbe, véglegesítsd.", Alerts.DialogUC.ButtonType.YesNo, "Ok", Alerts.DialogUC.ButtonColor.Red);
            App.mainWindow.alertGR.Children.Clear();
            App.mainWindow.alertGR.Children.Add(dialogUC);
        }

        private void Dialog_UC_uznetTorlese(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((App.mainWindow.alertGR.Children[0] as Alerts.DialogUC).Result)
            {
                //TÖRÖLNI AZ aktuális UZNETET
                if (currentMessageID == -1) //csak egy megkezdetten beszélgetés
                {
                    NewMessageBox.Children.Clear();
                }
                else
                {
                    messagesModel.CurrentMID = this.currentMessageID;
                    if (!messagesModel.Delete())
                    {
                        //sikertelen uzenet tolres
                        Alerts.DialogUC dialogUC = new Alerts.DialogUC();
                        dialogUC.Show("Hiba", "Sajnos nem sikerult tötölni a beszélgetést, kérem ellenőrízze az internetkapcsolatát, majd próbálja újra.", Alerts.DialogUC.ButtonType.Ok, "Ok", Alerts.DialogUC.ButtonColor.Red);
                        App.mainWindow.alertGR.Children.Clear();
                        App.mainWindow.alertGR.Children.Add(dialogUC);
                    }
                }
                this.currentMessageID = 0;
                loadDatas();

                Storyboard sb = this.FindResource("Storyboard2") as Storyboard;
                if (sb != null) { BeginStoryboard(sb); }
            }
        }

        private void titkositasBeallBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.SelectPage(2);
        }

        private void csevegesKezdeseBTN_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.SelectPage(0);
        }
    }
}
