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
        void AddGood(int id, IGood good);
        /// Add a new good in the catalog with an id and a name good
        bool RemoveGood(int id);
        /// Remove the good of the associated id of the catalog
        IGood? GetGood(int id);
        /// Return the name of the good associated with this id
        Dictionary<int, IGood> GetCatalog();
        /// List of all the id and the good's name of the catalog 
        List<ProcessState>? ProcessStates { get; set; }
    }
}
