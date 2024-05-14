using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IDataRepository
    {

        IUser? GetUser(int id);
        void AddUser(IUser user);
        void RemoveUser(IUser user);
        IGood? GetGood(int id);
        void AddGood(int id, IGood good);
        bool RemoveGood(int id);
        void Purchase(int userId, int goodId);
        void Return(int userId, int goodId);
        int NumberUser();
        int NumberGood(int goodId);
        void AddPurchase(IPurchase purchase);
        bool RemovePurchase(IPurchase purchase);
        List<IPurchase> GetPurchases();
    }
}
