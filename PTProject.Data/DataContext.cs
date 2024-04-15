using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public class DataContext : IDataRepository
    {
        private IUsers _users;
        private ICatalog _catalog;
        private IEvents _events;
        private IProcessState _processState;

        public DataContext(IUsers users, ICatalog catalog, IEvents events, IProcessState processState)
        {
            _users = users;
            _catalog = catalog;
            _events = events;
            _processState = processState;
        }

        public User? GetUser(int id) => _users.GetUser(id);
        public void AddUser(User user) => _users.AddUser(user);
        public void RemoveUser(User user) => _users.RemoveUser(user);
        public Good? GetGood(int id) => _catalog.GetGood(id);
        public void AddGood(int id, Good good) => _catalog.AddGood(id, good);
        public bool RemoveGood(int id) => _catalog.RemoveGood(id);
        public void Purchase(int userId, int goodId) => _events.Purchase(userId, goodId);
        public void Return(int userId, int goodId) => _events.Return(userId, goodId);
        public int NumberUser() => _processState.NumberUser();
        public int NumberGood(int goodId) => _processState.NumberGood(goodId);
        public void AddPurchase(Purchase purchase) => _processState.AddPurchase(purchase);
        public bool RemovePurchase(Purchase purchase) => _processState.RemovePurchase(purchase);
        public List<Purchase> GetPurchases() => _processState.GetPurchases();
    }
}
