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
        void AddUser(IUser user);
        /// Add a new user in  the list of all users.
        /// each user have a user Id and an user name
        void RemoveUser(IUser user);
        /// Remove an user of the list of all users.
        List<IUser> GetAllUsers();
        /// Return the list of all the users
        IUser? GetUser(int id);
        /// Return the name of the user associated with the id
    }
}