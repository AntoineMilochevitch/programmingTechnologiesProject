using PTProject.Service;
using PTProject.Presentation.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PTProject.Presentation.Views;
using System.Collections.Generic;
using PTProject.Data;

namespace PTProject.ViewModels
{
    public class UserMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IUserService _userService;
        private ObservableCollection<Presentation.Models.User> _users; // Change type to Presentation.Models.User
        private string _newUserName;
        public ICommand AddUserCommand { get; private set; }
        public ICommand SelectUserCommand { get; private set; }


        public UserDetailView DetailView { get; set; }
        private Presentation.Models.User _selectedUser;
        private List<Presentation.Models.Good> _purchasedGoods;

        public UserMasterViewModel(IUserService userService)
        {
            _userService = userService;
            LoadUsers();
            AddUserCommand = new RelayCommand(AddUser);
            SelectUserCommand = new RelayCommand(ShowUserDetails);

        }

        public void LoadUsers()
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

        public void AddUser(object obj)
        {
            string name = obj as string; // Cast the object to string

            if (!string.IsNullOrEmpty(name)) // Check if the name is not null or empty
            {
                int lastUserId = (_users.Any()) ? _users.Max(u => u.UserId) : 0;
                int newUserId = lastUserId + 1;
                Data.User user = new Data.User()
                {
                    UserId = newUserId,
                    UserName = name,
                };
                _userService.AddUser(user);
                LoadUsers();
            }
            else
            {
                Console.WriteLine("The user name is null or empty.");
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


        private void ShowUserDetails(object obj)
        {
            SelectedUser = obj as Presentation.Models.User;
            UserDetailView detailView = new UserDetailView();
            detailView.DataContext = SelectedUser;
            DetailView = detailView;
            OnPropertyChanged("DetailView");
        }
        public List<Presentation.Models.Good> PurchasedGoods
        {
            get { return _purchasedGoods; }
            set
            {
                _purchasedGoods = value;
                OnPropertyChanged("PurchasedGoods");
            }
        }
        public Presentation.Models.User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");

                // Get the purchased goods when a new user is selected
                if (_selectedUser != null)
                {
                    PurchasedGoods = _userService.GetPurchasedGoods(_selectedUser.UserId)
                        .Select(g => new Presentation.Models.Good
                        {
                            GoodId = g.GoodId,
                            Name = g.Name,
                            Description = g.Description,
                            Price = g.Price
                        }).ToList();
                }
            }
        }
    }
}
