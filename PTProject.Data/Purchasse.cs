using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public class Purchase
    {
        public int UserId { get; set; }
        public int GoodId { get; set; }
        public DateTime Date { get; set; }
    }
}
