using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTProject.Data.Catalog;

namespace PTProject.Data
{
    public interface ICatalog
    {
        void AddGood(int id, Good good);
        bool RemoveGood(int id);
        Good? GetGood(int id);
        Dictionary<int, Good> GetCatalog();
    }
}
