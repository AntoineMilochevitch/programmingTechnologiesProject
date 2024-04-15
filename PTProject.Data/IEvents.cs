using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IEvents
    {
        void Purchase(int userId, int goodId);
        /// Add a new instance of purchase with the user id, good id and date
        /// Print a message if the good is not found or out of stock
        void Return(int userId, int goodId);
        /// Remove an instance of purchase
    }
}