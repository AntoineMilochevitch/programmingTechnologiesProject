using System;

namespace PTProject.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Good> GoodRepository { get; }
        IRepository<Event> EventRepository { get; }
        IRepository<ProcessState> ProcessStateRepository { get; }
        void Save();
    }

}
