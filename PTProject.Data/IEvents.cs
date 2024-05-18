using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IEvents
    {
        int EventId { get; set; }
        int ProcessStateId { get; set; }
        DateTime EventDate { get; set; }
        string Description { get; set; }
        string EventType { get; set; }

        ProcessState ProcessState { get; set; }
    }
}