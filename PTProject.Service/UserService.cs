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
        private UserDTO MapToDTO(User User)
        {
            return new UserDTO
            {
                Id = User.Id,
                UserName = User.UserName,
            };
        }

        private User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
            };
        }
        public virtual void AddUser(UserDTO userDTO)
        {
            User User = MapToEntity(userDTO);
            _unitOfWork.UserRepository.Add(User);
            _unitOfWork.Save();
        }

        // Read
        public UserDTO GetUser(int id)
        {
            User User = _unitOfWork.UserRepository.GetById(id);
            return User != null ? MapToDTO(User) : null;
        }

        // Update
        public void UpdateUser(UserDTO userDTO)
        {
            User User = MapToEntity(userDTO);
            _unitOfWork.UserRepository.Update(User);
            _unitOfWork.Save();
        }

        // Delete
        public void DeleteUser(int id)
        {
            User User = _unitOfWork.UserRepository.GetById(id);
            if (User != null)
            {
                _unitOfWork.UserRepository.Delete(User);
                _unitOfWork.Save();
            }
        }

        public int NumberUser()
        {
            return _unitOfWork.UserRepository.GetAll().Count();
        }

        public virtual List<UserDTO> GetAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll().Select(User => MapToDTO(User)).ToList();
        }

        private GoodDTO MapGoodToDTO(Good good)
        {
            return new GoodDTO
            {
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price,
            };
        }
        public List<GoodDTO> GetPurchasedGoods(int userId)
        {
            List<GoodDTO> purchasedGoods = new List<GoodDTO>();

            var processStates = _unitOfWork.ProcessStateRepository.GetAll().Where(ps => ps.Id == userId && ps.Description == "BUY");
            foreach (var processState in processStates)
            {
                Good good = _unitOfWork.GoodRepository.GetById(processState.Id);
                if (good != null)
                {
                    purchasedGoods.Add(MapGoodToDTO(good));
                }
            }

            return purchasedGoods;
        }
    }
}
