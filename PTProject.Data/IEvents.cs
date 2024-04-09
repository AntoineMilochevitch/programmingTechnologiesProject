using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IEvents
    {
        void Purchase(int userId, int goodId);
        void Return(int userId, int goodId);
        List<Purchase> GetPurchases();
    }
}