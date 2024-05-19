using PTProject.Data;
using System.Linq;

namespace PTProject.Service
{
    public class GoodService
    {
        private MyDataContext _context;

        public GoodService(string connectionString)
        {
            _context = new MyDataContext(connectionString);
        }

        // Create
        public void AddGood(Good good)
        {
            _context.Catalog.InsertOnSubmit(good);
            _context.SubmitChanges();
        }

        // Read
        public Good GetGood(int id)
        {
            return _context.Catalog.SingleOrDefault(g => g.GoodId == id);
        }

        // Update
        public void UpdateGood(Good updatedGood)
        {
            Good good = _context.Catalog.SingleOrDefault(g => g.GoodId == updatedGood.GoodId);
            if (good != null)
            {
                good.Description = updatedGood.Description;
                good.Name = updatedGood.Name;
                good.Price = updatedGood.Price;
                _context.SubmitChanges();
            }
        }

        // Delete
        public void DeleteGood(int id)
        {
            Good good = _context.Catalog.SingleOrDefault(g => g.GoodId == id);
            if (good != null)
            {
                _context.Catalog.DeleteOnSubmit(good);
                _context.SubmitChanges();
            }
        }

        public int NumberGood(int goodId)
        {
            // Get the name of the good with the given ID
            string goodName = _context.Catalog.SingleOrDefault(g => g.GoodId == goodId)?.Name;

            // Count all goods with the same name
            return _context.Catalog.Count(g => g.Name == goodName);
        }
    }

}
