using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IGood
    {
        int GoodId { get; set; }
        string? Description { get; set; }
        int Quantity { get; set; }
        int Price { get; set; }
    }
}
