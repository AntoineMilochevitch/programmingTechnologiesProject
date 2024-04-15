using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTProject.Data.Users;

namespace PTProject.Data
{
    public interface IUsers
    {
        void AddUser(User user);
        /// Add a new user in  the list of all users.
        /// each user have a user Id and an user name
        void RemoveUser(User user);
        /// Remove an user of the list of all users.
        List<User> GetAllUsers();
        /// Return the list of all the users
        User? GetUser(int id);
        /// Return the name of the user associated with the id
    }
}