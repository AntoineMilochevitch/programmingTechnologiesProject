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
        /// Return the number of all the users in the database
        int NumberGood(int goodId);
        /// Return the number of all of the unique goods in the catalog 
        void AddPurchase(Purchase purchase);
        /// Add a purchase event in the list of all event when someone buy a good with the user id, good id and date
        bool RemovePurchase(Purchase purchase);
        /// Remove a purchase in the list of all the purchase event 
        List<Purchase> GetPurchases();
        /// List of all of the purchase event

    }
}
