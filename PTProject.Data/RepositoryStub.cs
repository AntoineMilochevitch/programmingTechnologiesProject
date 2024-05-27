using System.Collections.Generic;
using System.Linq;

namespace PTProject.Data
{
    public class RepositoryStub<T> : IRepository<T> where T : class
    {
        private readonly List<T> _data;

        public RepositoryStub()
        {
            _data = new List<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _data.AsQueryable();
        }

        public T GetById(int id)
        {
            return _data.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }

        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public void Update(T entity)
        {
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
        }
    }
}
