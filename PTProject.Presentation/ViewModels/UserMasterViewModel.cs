// UserMasterViewModel.cs
using PTProject.Data;
using PTProject.Service;
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
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
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
                int userId = _users.Count + 1;
                PTProject.Data.User user = new PTProject.Data.User()
                {
                    UserId = userId,
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

        private bool CanAddUser(object parameter)
        {
            // Code to determine whether a user can be added
            return true;
        }

        public class RelayCommand : ICommand
        {
            private Action<object> execute;
            private Predicate<object> canExecute;

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return canExecute == null ? true : canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                execute(parameter);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
    }
}
