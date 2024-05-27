using PTProject.Data;


namespace PTProject.Service
{
    public class UnitOfWorkStub : IUnitOfWork
    {
        public IRepository<User> UserRepository { get; }
        public IRepository<Good> GoodRepository { get; }
        public IRepository<Events> EventRepository { get; }
        public IRepository<ProcessState> ProcessStateRepository { get; }

        public UnitOfWorkStub()
        {
            UserRepository = new RepositoryStub<User>();
            GoodRepository = new RepositoryStub<Good>();
            EventRepository = new RepositoryStub<Events>();
            ProcessStateRepository = new RepositoryStub<ProcessState>();
        }

        public void Save() { 
        }

        public void Dispose()
        {
        }
    }
}