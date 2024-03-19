using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public class Users
    {
        private List<User> userList;

        public Users()
        {
            userList = new List<User>();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            userList.Add(user);
        }

        public bool RemoveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            return userList.Remove(user);
        }

        public List<User> GetUsers()
        {
            return userList;
        }

        public class User
        {
            public int UserId { get; set; }
            public string? UserName { get; set; }
            public string? UserEmail { get; set; }
        }

    }
}
