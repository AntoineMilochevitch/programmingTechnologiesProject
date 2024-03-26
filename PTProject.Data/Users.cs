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

        public void RemoveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            userList.Remove(user);
        }

        public List<User> GetUsers()
        {
            return userList;
        }

    }
}
