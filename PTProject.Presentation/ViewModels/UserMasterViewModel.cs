using PTProject.Service;
using PTProject.Presentation.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace PTProject.ViewModels
{
    public class UserMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private UserService _userService;
        private ObservableCollection<Presentation.Models.User> _users; // Change type to Presentation.Models.User
        private string _newUserName;
        public ICommand AddUserCommand { get; private set; }

        public UserMasterViewModel(UserService userService)
        {
            _userService = userService;
            LoadUsers();
            AddUserCommand = new RelayCommand(AddUser);
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<Presentation.Models.User>(
                _userService.GetAllUsers().Select(u => new Presentation.Models.User
                {
                    UserId = u.UserId,
                    UserName = u.UserName
                }));
        }
        public string NewUserName
        {
            get { return _newUserName; }
            set
            {
                _newUserName = value;
                OnPropertyChanged("NewUserName");
            }
        }

        private void AddUser(object obj)
        {
            string name = obj as string; // Cast the object to string

            if (!string.IsNullOrEmpty(name)) // Check if the name is not null or empty
            {
                int lastUserId = (_users.Any()) ? _users.Max(u => u.UserId) : 0;
                int newUserId = lastUserId + 1;
                PTProject.Data.User user = new PTProject.Data.User()
                {
                    UserId = newUserId,
                    UserName = name,
                };
                _userService.AddUser(user);
                LoadUsers();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Presentation.Models.User> Users // Change type to ObservableCollection<Presentation.Models.User>
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
       
    }
}
