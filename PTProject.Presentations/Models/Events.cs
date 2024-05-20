using System;

namespace PTProject.Presentations.Models
{
    public class Events
    {
        public int EventId { get; set; }
        public virtual int ProcessStateId { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
    }
}
