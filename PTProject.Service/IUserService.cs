using PTProject.Data;
using System.Collections.Generic;

namespace PTProject.Service
{
    public interface IUserService
    {
        void AddUser(UserDTO userDTO);
        UserDTO GetUser(int id);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(int id);
        int NumberUser();
        List<UserDTO> GetAllUsers();
        List<GoodDTO> GetPurchasedGoods(int userId);
    }
}
