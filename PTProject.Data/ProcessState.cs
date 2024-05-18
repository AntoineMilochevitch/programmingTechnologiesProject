using System;
using System.Collections.Generic;

namespace PTProject.Data
{
    public partial class ProcessState : IProcessState
    {
        public int ProcessStateId { get; set; }
        public int UserId { get; set; }
        public int GoodId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Good Good { get; set; }
        public virtual ICollection<Events> Events { get; set; }
    }
}