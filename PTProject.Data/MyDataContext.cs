using System.Data.Linq;

namespace PTProject.Data
{
    public partial class MyDataContext : DataContext
    {
        public Table<Good> Catalog;
        public Table<User> Users;
        public Table<ProcessState> ProcessStates;
        public Table<Event> Events;

        public MyDataContext(string connection) : base(connection) { }
    }

}
