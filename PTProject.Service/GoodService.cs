using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.Service
{
    public class GoodService : IGoodService
    {
        private PTProjectDataContext _context;

        public GoodService(PTProjectDataContext context)
        {
            _context = context;
            _context.Log = Console.Out;
        }

        // Create
        public void AddGood(Good good)
        {
            _context.Goods.InsertOnSubmit(good);
            _context.SubmitChanges();
        }

        // Read
        public Good GetGood(int id)
        {
            return _context.Goods.SingleOrDefault(g => g.GoodId == id);
        }

        // Update
        public void UpdateGood(Good updatedGood)
        {
            Good good = _context.Goods.SingleOrDefault(g => g.GoodId == updatedGood.GoodId);
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
            Good good = _context.Goods.SingleOrDefault(g => g.GoodId == id);
            if (good != null)
            {
                _context.Goods.DeleteOnSubmit(good);
                _context.SubmitChanges();
            }
        }

        public int NumberGood(int goodId)
        {
            // Get the name of the good with the given ID
            string goodName = _context.Goods.SingleOrDefault(g => g.GoodId == goodId)?.Name;

            // Count all goods with the same name
            return _context.Goods.Count(g => g.Name == goodName);


        }
        public List<Good> GetAllGoods()
        {
            List<Good> goods = new List<Good>();
            foreach (var good in _context.Goods)
            {
                goods.Add(good);
            }
            return goods;
        }
    }
}
