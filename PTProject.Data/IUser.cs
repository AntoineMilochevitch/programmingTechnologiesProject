using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IUser
    {
        int UserId { get; set; }
        string? UserName { get; set; }
        List<Events>? Events { get; set; }
    }
}
