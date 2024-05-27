using System;

namespace PTProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PTProjectDataContext _context;
        private IRepository<User> _userRepository;
        private IRepository<Good> _goodRepository;
        private IRepository<Events> _eventRepository;
        private IRepository<ProcessState> _processStateRepository;

        public UnitOfWork(PTProjectDataContext context)
        {
            _context = context;
            _context.Log = Console.Out;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new Repository<User>(_context);
                }
                return _userRepository;
            }
        }

        public IRepository<Good> GoodRepository
        {
            get
            {
                if (_goodRepository == null)
                {
                    _goodRepository = new Repository<Good>(_context);
                }
                return _goodRepository;
            }
        }

        public IRepository<Events> EventRepository
        {
            get
            {
                if (_eventRepository == null)
                {
                    _eventRepository = new Repository<Events>(_context);
                }
                return _eventRepository;
            }
        }

        public IRepository<ProcessState> ProcessStateRepository
        {
            get
            {
                if (_processStateRepository == null)
                {
                    _processStateRepository = new Repository<ProcessState>(_context);
                }
                return _processStateRepository;
            }
        }

        public void Save()
        {
            _context.SubmitChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}

