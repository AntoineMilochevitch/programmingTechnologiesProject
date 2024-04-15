using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IProcessState
    {
        int NumberUser();

        int NumberGood(int goodId);
        void AddPurchase(Purchase purchase);
        bool RemovePurchase(Purchase purchase);
        List<Purchase> GetPurchases();

    }
}
