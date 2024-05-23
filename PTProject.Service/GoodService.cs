using PTProject.Data;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.Service
{
    public class GoodService : IGoodService
    {
        private IUnitOfWork _unitOfWork;

        public GoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GoodDTO> GetAllGoods()
        {
            return _unitOfWork.GoodRepository.GetAll().Select(good => MapToDTO(good)).ToList();
        }

        public GoodDTO GetGoodById(int id)
        {
            Good good = _unitOfWork.GoodRepository.GetById(id);
            return good != null ? MapToDTO(good) : null;
        }

        public void AddGood(GoodDTO goodDTO)
        {
            Good good = MapToEntity(goodDTO);
            _unitOfWork.GoodRepository.Add(good);
            _unitOfWork.Save();
        }

        public void UpdateGood(GoodDTO goodDTO)
        {
            Good good = MapToEntity(goodDTO);
            _unitOfWork.GoodRepository.Update(good);
            _unitOfWork.Save();
        }

        public void DeleteGood(int id)
        {
            Good good = _unitOfWork.GoodRepository.GetById(id);
            if (good != null)
            {
                _unitOfWork.GoodRepository.Delete(good);
                _unitOfWork.Save();
            }
        }

        public int NumberGood(string name)
        {
            return _unitOfWork.GoodRepository.GetAll().Count(g => g.Name == name);
        }

        private GoodDTO MapToDTO(Good good)
        {
            return new GoodDTO
            {
                GoodId = good.GoodId,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price,
            };
        }

        private Good MapToEntity(GoodDTO goodDTO)
        {
            return new Good
            {
                GoodId = goodDTO.GoodId,
                Name = goodDTO.Name,
                Description = goodDTO.Description,
                Price = goodDTO.Price,
            };
        }
    }

}
