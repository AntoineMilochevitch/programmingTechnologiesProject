using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTProject.Data.Catalog;

namespace PTProject.Data
{
    public class ProcessState
    {
        private ICatalog _catalog;
        private IUsers _users;
        private List<Purchase> _purchases;

        public int numberUser(List<User>)
        {
            return User.Count;
        }

        public int numberGood(Catalog)
        {
            return Catalog.Count;
        }
    }
}
