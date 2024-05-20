using PTProject.Data;
using System.Collections.Generic;

namespace PTProject.Service
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(int id);
        void UpdateUser(User updatedUser);
        void DeleteUser(int id);
        int NumberUser();
        List<User> GetAllUsers();
        List<Good> GetPurchasedGoods(int userId);
    }
}
