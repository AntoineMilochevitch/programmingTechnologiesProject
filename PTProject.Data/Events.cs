﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public partial class Events: IEvents
    {
        public int EventId { get; set; }
        public int ProcessStateId { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }

        public virtual ProcessState ProcessState { get; set; }
        
    }
}