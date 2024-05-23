using PTProject.Data;
using System.Collections.Generic;

namespace PTProject.Service
{
    public interface IGoodService
    {
        IEnumerable<GoodDTO> GetAllGoods();
        GoodDTO GetGoodById(int id);
        void AddGood(GoodDTO good);
        void UpdateGood(GoodDTO good);
        void DeleteGood(int id);
        int NumberGood(string name);
    }


}
