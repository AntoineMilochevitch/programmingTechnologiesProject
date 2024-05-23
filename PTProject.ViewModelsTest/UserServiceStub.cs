/*using PTProject.Data;
using PTProject.Service;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

public class UserServiceStub : IUserService
{
    private List<User> _users;

    public UserServiceStub(List<PTProject.Presentation.Models.User> modelUsers)
    {
        _users = modelUsers.Select(ConvertToDataUser).ToList();
    }

    private User ConvertToDataUser(PTProject.Presentation.Models.User modelUser)
    {
        return new User { UserId = modelUser.UserId, UserName = modelUser.UserName };
    }

    private PTProject.Presentation.Models.User ConvertToModelUser(User dataUser)
    {
        return new PTProject.Presentation.Models.User { UserId = dataUser.UserId, UserName = dataUser.UserName };
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUser(int id)
    {
        return _users.FirstOrDefault(u => u.UserId == id);
    }

    public void UpdateUser(User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.UserId == updatedUser.UserId);
        if (user != null)
        {
            user.UserName = updatedUser.UserName;
        }
    }

    public void DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.UserId == id);
        if (user != null)
        {
            _users.Remove(user);
        }
    }

    public int NumberUser()
    {
        return _users.Count;
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public List<Good> GetPurchasedGoods(int userId)
    {
        List<Good> purchasedGoods = new List<Good>();
        return purchasedGoods;
    }
}*/
