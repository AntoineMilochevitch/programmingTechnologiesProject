using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTProject.Data.Catalog;

namespace PTProject.Data
{
    public class ProcessState : IProcessState
    {
        private ICatalog _catalog;
        private IUsers _users;
        public List<Events>? _events { get; set; }
        private List<Purchase> _purchases;

        public List<Events> Events { get; set; }

        public ProcessState(ICatalog catalog, IUsers users)
        {
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            _users = users ?? throw new ArgumentNullException(nameof(users));
            _purchases = new List<Purchase>();
            _catalog.ProcessStates?.Add(this);
            Events = new List<Events>();
        }

        public int NumberUser()
        {
            return _users.GetAllUsers().Count;
        }

        public int NumberGood(int goodId)
        {
            return _catalog.GetCatalog().Values.Count(good => good.GoodId == goodId);
        }

        public void AddPurchase(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }
            _purchases.Add(purchase);
        }

        public bool RemovePurchase(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }
            return _purchases.Remove(purchase);
        }

        public List<Purchase> GetPurchases()
        {
            return _purchases;
        }
    }
}
