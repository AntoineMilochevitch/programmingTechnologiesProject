using PTProject.Presentation.Models;
using PTProject.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PTProject.Presentation.Views;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Markup;
using System;

namespace PTProject.Presentation.ViewModels
{
    public class UserMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IUserService _userService;
        private ObservableCollection<User> _users; // Change type to Presentation.Models.User
        private string _newUserName;
        public ICommand AddUserCommand { get; private set; }
        public ICommand SelectUserCommand { get; private set; }


        public UserDetailView DetailView { get; set; }
        private User _selectedUser;
        private List<Good> _purchasedGoods;


        public UserMasterViewModel(IUserService userService)
        {
            _userService = userService;
            LoadUsers();
            AddUserCommand = new RelayCommand(AddUser);
            SelectUserCommand = new RelayCommand(ShowUserDetails);

        }

        public void LoadUsers()
        {
            Users = new ObservableCollection<User>(
                _userService.GetAllUsers().Select(u => new User
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
                User user = new User()
                {
                    UserId = newUserId,
                    UserName = name,
                };
                _userService.AddUser(MapToDTO(user));
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
        public ObservableCollection<User> Users // Change type to ObservableCollection<Presentation.Models.User>
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
            SelectedUser = obj as User;
            UserDetailView detailView = new UserDetailView();
            detailView.DataContext = SelectedUser;
            DetailView = detailView;
            OnPropertyChanged("DetailView");
        }
        public List<Good> PurchasedGoods
        {
            get { return _purchasedGoods; }
            set
            {
                _purchasedGoods = value;
                OnPropertyChanged("PurchasedGoods");
            }
        }
        public User SelectedUser
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
                        .Select(g => new Good
                        {
                            GoodId = g.GoodId,
                            Name = g.Name,
                            Description = g.Description,
                            Price = g.Price
                        }).ToList();
                }
            }
        }

        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
            };
        }

        private User MapToPresentationModel(UserDTO userDTO)
        {
            return new User
            {
                UserId = userDTO.UserId,
                UserName = userDTO.UserName,
            };
        }
    }
}
