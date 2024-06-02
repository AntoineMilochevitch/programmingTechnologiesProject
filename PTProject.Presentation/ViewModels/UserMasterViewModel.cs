using PTProject.Presentation.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace PTProject.Presentation.ViewModels
{
    public class UserMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private UserModel _userModel;
        private ObservableCollection<User> _users;
        private string _newUserName;

        public ICommand AddUserCommand { get; private set; }

        private UserDetailViewModel _detailViewModel;
        public UserDetailViewModel DetailViewModel
        {
            get { return _detailViewModel; }
            set
            {
                _detailViewModel = value;
                OnPropertyChanged("DetailViewModel");
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
                ShowUserDetails();
            }
        }

        public UserMasterViewModel(UserModel userModel)
        {
            _userModel = userModel;
            LoadUsers();
            AddUserCommand = new RelayCommand(AddUser);
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<User>(_userModel.GetAllUsers());
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
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

        public void AddUser(object obj)
        {
            string name = obj as string;

            if (!string.IsNullOrEmpty(name))
            {
                int lastUserId = (_users.Any()) ? _users.Max(u => u.Id) : 0;
                int newUserId = lastUserId + 1;
                User user = new User
                {
                    Id = newUserId,
                    UserName = name
                };
                _userModel.AddUser(user);
                LoadUsers();
            }
        }

        private void ShowUserDetails()
        {
            if (SelectedUser != null)
            {
                var purchasedGoods = _userModel.GetPurchasedGoods(SelectedUser.Id);
                DetailViewModel = new UserDetailViewModel(SelectedUser, purchasedGoods);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
