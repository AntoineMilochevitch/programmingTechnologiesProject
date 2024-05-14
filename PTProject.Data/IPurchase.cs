using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IPurchase
    {
        int UserId { get; set; }
        int GoodId { get; set; }
        DateTime Date { get; set; }
    }
}
