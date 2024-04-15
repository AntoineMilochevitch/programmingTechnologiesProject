using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IDataRepository
    {
        User? GetUser(int id);
        void AddUser(User user);
        void RemoveUser(User user);
        Good? GetGood(int id);
        void AddGood(int id, Good good);
        bool RemoveGood(int id);
        void Purchase(int userId, int goodId);
        void Return(int userId, int goodId);
        int NumberUser();
        int NumberGood(int goodId);
        void AddPurchase(Purchase purchase);
        bool RemovePurchase(Purchase purchase);
        List<Purchase> GetPurchases();
    }
}
