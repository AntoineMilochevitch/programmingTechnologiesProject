﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTProject.Data.Good;

namespace PTProject.Data
{
    public class Catalog : ICatalog
    {
        private Dictionary<int, Good> goods;
        public List<ProcessState>? ProcessStates { get; set; }

        public Catalog()
        {
            goods = new Dictionary<int, Good>();
            ProcessStates = new List<ProcessState>();
        }

        public void AddGood(int id, Good? good)
        {
            if (good == null)
            {
                throw new ArgumentNullException(nameof(good), "Good cannot be null");
            }
            if (goods.ContainsKey(id))
            {

                goods[id].Quantity++; 
            }
            else
            {
                goods[id] = good;
            }
        }

        public bool RemoveGood(int id)
        {
            return goods.Remove(id);
        }

        public Good? GetGood(int id)
        {
            goods.TryGetValue(id, out Good? good);
            return good;
        }

        public Dictionary<int, Good> GetCatalog()
        {
            return goods;
        }
    }
}
