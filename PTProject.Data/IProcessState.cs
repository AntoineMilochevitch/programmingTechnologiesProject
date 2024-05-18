using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IProcessState
    {
        int UserId { get; set; }
        int GoodId { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }

        User User { get; set; }
        Good Good { get; set; }
        ICollection<Events> Events { get; set; }
    }
}
