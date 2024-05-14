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
        private List<IUser> _users;

        public Users()
        {
            _users = new List<IUser>();
        }

        public void AddUser(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            if (_users.Any(u => u.UserId == user.UserId))
            {
                throw new ArgumentException("User already exists");
            }
            _users.Add(user);
        }

        public void RemoveUser(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _users.Remove(user);
        }

        public List<IUser> GetAllUsers()
        {
            return _users;
        }

        public IUser? GetUser(int id)
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
