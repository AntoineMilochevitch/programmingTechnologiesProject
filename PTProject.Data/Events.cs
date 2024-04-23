﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public class Events : IEvents
    {
        private ICatalog _catalog;
        private IUsers _users;
        private List<Purchase> _purchases;

        public ProcessState _processState;


        public Events(ICatalog catalog, IUsers users, ProcessState processState)
        {
            _catalog = catalog;
            _users = users;
            _purchases = new List<Purchase>();
            _processState = processState;
        }

        public void Purchase(int userId, int goodId)
        {
            var user = _users.GetUser(userId);
            var good = _catalog.GetGood(goodId);

            if (user == null || good == null)
            {
                throw new ArgumentException("User or good not found");
            }

            if (good.Quantity <= 0)
            {
                throw new ArgumentException("Good is out of stock");
            }

            good.Quantity--;

            _purchases.Add(new Purchase { UserId = userId, GoodId = goodId, Date = DateTime.Now });
            if (user.Events == null)
            {
                user.Events = new List<Events>();
            }
            user.Events.Add(this);
            if (_processState.Events == null)
            {
                _processState.Events = new List<Events>();
            }
            _processState.Events.Add(this);
        }

        public void Return(int userId, int goodId)
        {
            Purchase? purchase = null;
            for (int i = 0; i < _purchases.Count; i++)
            {
                if (_purchases[i].UserId == userId && _purchases[i].GoodId == goodId)
                {
                    purchase = _purchases[i];
                    break;
                }
            }

            if (purchase == null)
            {
                throw new ArgumentException("Purchase not found");
            }

            _purchases.Remove(purchase);

            var good = _catalog.GetGood(goodId);
            if (good != null)
            {
                good.Quantity++;
                _purchases.Remove(purchase);
                _processState.Events.Remove(this);
            }
        }
    }
}