using PTProject.Service;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.ViewModelsTest
{
    public class UserServiceStub : IUserService
    {
        private List<UserDTO> _users;

        public UserServiceStub()
        {
            _users = new List<UserDTO>();
        }

        public void AddUser(UserDTO userDTO)
        {
            _users.Add(userDTO);
        }

        public UserDTO GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var user = _users.FirstOrDefault(u => u.Id == userDTO.Id);
            if (user != null)
            {
                user.UserName = userDTO.UserName;
            }
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public int NumberUser()
        {
            return _users.Count;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _users;
        }

        public List<GoodDTO> GetPurchasedGoods(int userId)
        {
            return new List<GoodDTO>();
        }
    }
}
