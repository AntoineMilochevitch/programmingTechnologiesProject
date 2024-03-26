using System;
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

        public Catalog() 
        { 
            goods = new Dictionary<int, Good>();
        }

        public void AddGood(int id, Good? good)
        {
            if (good == null)
            {
                throw new ArgumentNullException(nameof(good), "Good cannot be null");
            }
            goods[id] = good;
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
    }
}
