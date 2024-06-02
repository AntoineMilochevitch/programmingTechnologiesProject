using PTProject.Service;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.Presentation.Models
{
    public class UserModel
    {
        private readonly IUserService _userService;

        public UserModel(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAllUsers().Select(MapToModel);
        }

        public void AddUser(User user)
        {
            _userService.AddUser(MapToDTO(user));
        }

        public List<Good> GetPurchasedGoods(int userId)
        {
            return _userService.GetPurchasedGoods(userId).Select(MapToModel).ToList();
        }

        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        private User MapToModel(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName
            };
        }

        private GoodDTO MapToDTO(Good good)
        {
            return new GoodDTO
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price
            };
        }

        private Good MapToModel(GoodDTO goodDTO)
        {
            return new Good
            {
                Id = goodDTO.Id,
                Name = goodDTO.Name,
                Description = goodDTO.Description,
                Price = goodDTO.Price
            };
        }
    }
}
