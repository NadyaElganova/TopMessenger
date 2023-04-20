using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopMessenger.Infastructure.Services;
using TopMessenger.ModelShells;
using TopMessenger.ViewModels.Commands;


namespace TopMessenger.ViewModels
{
    class AuthorizationViewModel : BaseViewModel
    {
        #region Properties
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; UpdateValue<string>(ref name, value); }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; UpdateValue<string>(ref lastName, value); }
        }
        private ObservableCollection<UserAddFriendShell> allUsers;

        public ObservableCollection<UserAddFriendShell> AllUsers
        {
            get { return allUsers; }
            set { UpdateValue(ref allUsers, value); }
        }
        private readonly UserService _userService;

        #endregion
        public ActionCommand CloseWindowCommand => new ActionCommand(x => Application.Current.Windows[Application.Current.Windows.Count-1].Close());
        public ActionCommand WindowMinimizeCommand => new ActionCommand(x => WindowMinimize());
        public ActionCommand WindowMaximizeCommand => new ActionCommand(x => WindowMaximize());
        private void WindowMinimize()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].WindowState = WindowState.Minimized;
        }
        private void WindowMaximize()
        {
            if (Application.Current.Windows[Application.Current.Windows.Count - 1].WindowState != WindowState.Maximized)
            {
                Application.Current.Windows[Application.Current.Windows.Count - 1].WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.Windows[Application.Current.Windows.Count - 1].WindowState = WindowState.Normal;
            }
        }
    }
}
