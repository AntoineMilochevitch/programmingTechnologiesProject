using PTProject.Data;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
            };
        }

        private User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                UserId = userDTO.UserId,
                UserName = userDTO.UserName,
            };
        }
        public virtual void AddUser(UserDTO userDTO)
        {
            User user = MapToEntity(userDTO);
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
        }

        // Read
        public UserDTO GetUser(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            return user != null ? MapToDTO(user) : null;
        }

        // Update
        public void UpdateUser(UserDTO userDTO)
        {
            User user = MapToEntity(userDTO);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }

        // Delete
        public void DeleteUser(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            if (user != null)
            {
                _unitOfWork.UserRepository.Delete(user);
                _unitOfWork.Save();
            }
        }

        public int NumberUser()
        {
            return _unitOfWork.UserRepository.GetAll().Count();
        }

        public virtual List<UserDTO> GetAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll().Select(user => MapToDTO(user)).ToList();
        }

        private GoodDTO MapGoodToDTO(Good good)
        {
            return new GoodDTO
            {
                GoodId = good.GoodId,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price,
            };
        }
        public List<GoodDTO> GetPurchasedGoods(int userId)
        {
            List<GoodDTO> purchasedGoods = new List<GoodDTO>();

            var processStates = _unitOfWork.ProcessStateRepository.GetAll().Where(ps => ps.UserId == userId && ps.Description == "BUY");
            foreach (var processState in processStates)
            {
                Good good = _unitOfWork.GoodRepository.GetById(processState.GoodId);
                if (good != null)
                {
                    purchasedGoods.Add(MapGoodToDTO(good));
                }
            }

            return purchasedGoods;
        }
    }
}
