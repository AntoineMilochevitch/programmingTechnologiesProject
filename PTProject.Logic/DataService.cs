using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTProject.Data;


namespace PTProject.Logic
{
    public class DataService
    {
        private IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public User GetUser(int id)
        {
            var user = _dataRepository.GetUser(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found.");
            }
            return user;
        }

        public void AddUser(User user)
        {
            _dataRepository.AddUser(user);
        }

        public void RemoveUser(User user)
        {
            _dataRepository.RemoveUser(user);
        }

        public Good GetGood(int id)
        {
            var good = _dataRepository.GetGood(id);
            if (good == null)
            {
                throw new Exception($"Good with id {id} not found.");
            }
            return good;
        }

        public void AddGood(int id, Good good)
        {
            _dataRepository.AddGood(id, good);
        }

        public bool RemoveGood(int id)
        {
            return _dataRepository.RemoveGood(id);
        }

        public void Purchase(int userId, int goodId)
        {
            _dataRepository.Purchase(userId, goodId);
        }

        public void Return(int userId, int goodId)
        {
            _dataRepository.Return(userId, goodId);
        }

        public int NumberUser()
        {
            return _dataRepository.NumberUser();
        }

        public int NumberGood(int goodId)
        {
            return _dataRepository.NumberGood(goodId);
        }

        public void AddPurchase(Purchase purchase)
        {
            _dataRepository.AddPurchase(purchase);
        }

        public bool RemovePurchase(Purchase purchase)
        {
            return _dataRepository.RemovePurchase(purchase);
        }

        public List<Purchase> GetPurchases()
        {
            return _dataRepository.GetPurchases();
        }
    }
}
