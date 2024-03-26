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
        void RemoveUser(User user);
        List<User> GetUsers();
    }
}