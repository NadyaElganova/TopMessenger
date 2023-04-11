using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopMessenger.Infastructure.Services;
using TopMessenger.Models;
using TopMessenger.ViewModels.Commands;


namespace TopMessenger.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Commands
        public ActionCommand WindowMinimizeCommand => new ActionCommand(x => WindowMinimize());
        public ActionCommand WindowMaximizeCommand => new ActionCommand(x => WindowMaximize());
        public ActionCommand SendMessageCommand => new ActionCommand(x => MessageBox.Show(NewText));
        public ActionCommand AppCloseCommand => new ActionCommand(x => Application.Current.Shutdown());

        #endregion

        #region Property
        private string newText;
        public string NewText
        {
            get => newText;
            set 
            {
                newText = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<User> friends;
        public ObservableCollection<User> Friends
        {
            get { return friends; }
            set 
            {
                friends = value;
                OnPropertyChanged();
            }
        }
        private event Action Chat;
        private User selectedFriend;
        public User SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                selectedFriend = value;
                Chat();
                OnPropertyChanged();
            }
        }
        private User mainUserTemp;
        private ObservableCollection<Message> chatWhithUser;
        public ObservableCollection<Message> ChatWhithUser
        {
            get => chatWhithUser;
            set 
            {
                chatWhithUser = value;
                OnPropertyChanged();
            }
       }
        #endregion
        private UserService userService;
        public MainViewModel()
        {
            Chat += ChatWN;
            LoadMeth().GetAwaiter();
        }
        private async void ChatWN()
        {
            ChatWhithUser = await userService.GetMessageWithUser(mainUserTemp, SelectedFriend);
        }
        private async Task LoadMeth()
        {
            userService = new UserService();
            mainUserTemp = await userService.GetUser(1);
            //ChatWhithUser = await userService.GetMessageWithUser(await userService.GetUser(1), await userService.GetUser(2));
            //var user1 = new User
            //{
            //    FirstName = "first"
            //};
            //var user2 = new User
            //{
            //    FirstName = "second",
            //};
            //var user3 = new User
            //{
            //    FirstName = "third",
            //};

            //userService = new UserService();

            //await userService.AddPhotoSource(await userService.GetUser(2));
            
            ObservableCollection<User> tempUsers = await userService.GetFriendList(await userService.GetUser(1));
            foreach (var item in tempUsers)
            {
                var tempMessages = await userService.GetMessageWithUser(mainUserTemp, item);
                item.LastMessage = tempMessages.LastOrDefault()?.Text;
            }
            Friends = tempUsers;

            //Message mes = new Message
            //{
            //    Text = "Asdasdasd",
            //    DateOfSend = DateTime.Now,
            //    Dender = await userService.GetUser(1),
            //    Receiver = await userService.GetUser(2)
            //};
            //await userService.SendMessage(mes);

            //var res = await userService.GetMessageWithUser(await userService.GetUser(2), await userService.GetUser(1));

            //string text = " ";
            //foreach (var item in res)
            //{
            //    text += item.Text + "\n";
            //}
            //MessageBox.Show(text);

            //await userService.AddNewUser(user1);
            //await userService.AddNewUser(user2);
            //await userService.AddNewFriend(await userService.GetUser(1),
            //await userService.GetUser(2));
            //Friends = await userService.GetFriendList(await userService.GetUser(1));
        }
        private void WindowMinimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void WindowMaximize()
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }


        public void OnPropertyChanged([CallerMemberName] string propery = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propery));
        }
    }
}
