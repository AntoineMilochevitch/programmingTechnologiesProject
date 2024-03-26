using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public class Events
    {
        private ICatalog _catalog;
        private IUsers _users;
        public Events(ICatalog catalog, IUsers users)
        {
            _catalog = catalog;
            _users = users;
        }
    }
}