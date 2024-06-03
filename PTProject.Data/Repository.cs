using System;
using System.Data.Linq;
using System.Linq;

namespace PTProject.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PTProjectDataContext _context;
        private readonly Table<T> _table;

        public Repository(PTProjectDataContext context)
        {
            _context = context;
            _table = _context.GetTable<T>();
        }

        public IQueryable<T> GetAll()
        {
            var query = from item in _table
                        select item;
            return query;
        }

        public T GetById(int id)
        {
            return _table.SingleOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }


        public void Add(T entity)
        {
            try
            {
                _table.InsertOnSubmit(entity);
                _context.SubmitChanges();
                Console.WriteLine("Entity added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding entity: " + ex.Message);
                throw;
            }
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Refresh(RefreshMode.KeepCurrentValues, entity);
        }

        public void Delete(T entity)
        {
            _table.DeleteOnSubmit(entity);
            _context.SubmitChanges();
        }
    }

}
