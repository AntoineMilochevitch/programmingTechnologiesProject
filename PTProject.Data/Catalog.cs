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
        private Dictionary<int, IGood> goods;
        public List<ProcessState>? ProcessStates { get; set; }

        public Catalog()
        {
            goods = new Dictionary<int, IGood>();
            ProcessStates = new List<ProcessState>();
        }

        public void AddGood(int id, IGood? good)
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

        public IGood? GetGood(int id)
        {
            goods.TryGetValue(id, out IGood? good);
            return good;
        }

        public Dictionary<int, IGood> GetCatalog()
        {
            return goods;
        }
    }
}
