using PTProject.Service;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.Presentation.Models
{
    public class GoodModel
    {
        private readonly IGoodService _goodService;

        public GoodModel(IGoodService goodService)
        {
            _goodService = goodService;
        }

        public IEnumerable<Good> GetAllGoods()
        {
            return _goodService.GetAllGoods().Select(MapToModel);
        }

        public void AddGood(Good good)
        {
            _goodService.AddGood(MapToDTO(good));
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