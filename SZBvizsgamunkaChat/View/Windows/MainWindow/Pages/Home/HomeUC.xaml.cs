using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace SZBvizsgamunkaChat.View.Windows.MainWindow.Pages.Home
{
    /// <summary>
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        public HomeUC(object obj)
        {
            InitializeComponent();
            homeModel = (Model.HomeModel)obj;
            usersList = homeModel.UsersList;
            this.Loaded += HomeUC_Loaded;
        }
        Model.HomeModel homeModel = null;
        List<Model.HomeModel.User> usersList = new List<Model.HomeModel.User>();
        private void HomeUC_Loaded(object sender, RoutedEventArgs e)
        {
            homeModel.Synch();
            loadUsers();
        }

        private void loadUsers()
        {
            this.wrapPanelContent.Children.Clear();
            for (int i = 0; i < usersList.Count; i++)
            {
                Controls.UserCardUC userCard = new Controls.UserCardUC(usersList[i]);
                userCard.PreviewMouseUp += UserCard_PreviewMouseUp;
                this.wrapPanelContent.Children.Add(userCard);
            }
        }

        private void UserCard_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.SelectPage(1);
            (App.mainWindow.mainContent.Children[0] as Pages.Messages.MessagesUC).NewMessageStarter(((sender as Controls.UserCardUC).DataContext as Model.HomeModel.User));
        }

        private void grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void SearchBarUC_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.wrapPanelContent.Children.Clear();
            string finderText = ((sender as Controls.SearchBarUC).DataContext == null) ? string.Empty : ((sender as Controls.SearchBarUC).DataContext as String);
            if (!string.IsNullOrEmpty(finderText))
            {
                for (int i = 0; i < usersList.Count; i++)
                {
                    //if (usersList[i].Name.ToLower().StartsWith(finderText.ToLower())==true) nem működött jól s betűknél
                    if(startWithOwn(usersList[i].Name.ToLower(), finderText.ToLower()))
                    {
                        Controls.UserCardUC userCard = new Controls.UserCardUC(usersList[i]);
                        userCard.PreviewMouseUp += UserCard_PreviewMouseUp;
                        this.wrapPanelContent.Children.Add(userCard);
                    }
                }
            }
            else
            {
                loadUsers();
            }
        }

        private bool startWithOwn(string stringliteral, string value)
        {
            string temp = String.Empty;
            for (int i = 0; i < value.Length; i++) temp += stringliteral[i];
            return temp.Equals(value);
        }
    }
}
