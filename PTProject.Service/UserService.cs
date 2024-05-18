using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Service
{
    public class UserService
    {
        private MyDataContext _context;
        public string UserName { get; set; }
        public UserService()
        {
            // Exemple de valeur par défaut
            UserName = "Jean Dupont";
        }
        public UserService(string connectionString)
        {
            _context = new MyDataContext(connectionString);
        }

        // Create
        public void AddUser(User user)
        {
            _context.Users.InsertOnSubmit(user);
            _context.SubmitChanges();
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
    }
}

