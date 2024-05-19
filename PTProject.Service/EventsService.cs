using PTProject.Data;
using System.Linq;

namespace PTProject.Service
{
    public class EventsService
    {
        private MyDataContext _context;

        public EventsService(string connectionString)
        {
            _context = new MyDataContext(connectionString);
        }

        // Create
        public void AddEvent(Event evt)
        {
            _context.Events.InsertOnSubmit(evt);
            _context.SubmitChanges();
        }

        // Read
        public Event GetEvent(int id)
        {
            return _context.Events.SingleOrDefault(e => e.EventId == id);
        }

        // Delete
        public void DeleteEvent(int id)
        {
            Event evt = _context.Events.SingleOrDefault(e => e.EventId == id);
            if (evt != null)
                {
                _context.Events.DeleteOnSubmit(evt);
                _context.SubmitChanges();
            }
        }
    }
}


