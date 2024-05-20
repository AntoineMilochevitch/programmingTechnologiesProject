using PTProject.Data;
using System.Collections.Generic;

namespace PTProject.Service
{
    public interface IGoodService
    {
        void AddGood(Good good);
        Good GetGood(int id);
        void UpdateGood(Good updatedGood);
        void DeleteGood(int id);
        int NumberGood(int goodId);
        List<Good> GetAllGoods();
    }
}
