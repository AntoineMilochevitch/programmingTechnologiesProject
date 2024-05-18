using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public partial class MyDataContext : DataContext
    {
        public Table<Good> Catalog;
        public Table<User> Users;
        public Table<ProcessState> ProcessStates;
        public Table<Events> Events;

        public MyDataContext(string connection) : base(connection) { }
    }

}
