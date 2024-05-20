using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTProject.Service
{


    public class UserService : IUserService
    {
        protected PTProjectDataContext _context;
        public UserService(PTProjectDataContext context)
        {
            _context = context;
            _context.Log = Console.Out;
        }

        public virtual void AddUser(User user)
        {
            try
            {
                _context.Users.InsertOnSubmit(user);
                _context.SubmitChanges();
                Console.WriteLine($"User added: ID = {user.UserId}, Name = {user.UserName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        // Read
        public User GetUser(int id)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == id);
        }

        // Update
        public void UpdateUser(User updatedUser)
        {
            User user = _context.Users.SingleOrDefault(u => u.UserId == updatedUser.UserId);
            if (user != null)
            {
                user.UserName = updatedUser.UserName;
                _context.SubmitChanges();
            }
        }

        // Delete
        public void DeleteUser(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.DeleteOnSubmit(user);
                _context.SubmitChanges();
            }
        }

        public int NumberUser()
        {
            return _context.Users.Count();
        }

        public virtual List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach (var user in _context.Users)
            {
                users.Add(user);
            }
            return users;
        }


        public List<Good> GetPurchasedGoods(int userId)
        {
            List<Good> purchasedGoods = new List<Good>();

            var processStates = _context.ProcessStates.Where(ps => ps.UserId == userId && ps.Description == "BUY");
            foreach (var processState in processStates)
            {
                Good good = _context.Goods.SingleOrDefault(g => g.GoodId == processState.GoodId);
                if (good != null)
                {
                    purchasedGoods.Add(good);
                }
            }

            return purchasedGoods;
        }
    }
}
