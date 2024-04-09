using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTProject.Data.User;

namespace PTProject.Data
{
    public class Users : IUsers
    {
        private List<User> _users;

        public Users()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetUser(int id)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].UserId == id)
                {
                    return _users[i];
                }
            }

            return null;
        }

    }
}
