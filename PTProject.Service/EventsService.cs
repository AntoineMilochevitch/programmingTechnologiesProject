using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

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
        public void AddEvent(Events evt)
        {
            _context.Events.InsertOnSubmit(evt);
            _context.SubmitChanges();
        }

        // Read
        public Events GetEvent(int id)
        {
            return _context.Events.SingleOrDefault(e => e.EventId == id);
        }

        // Delete
        public void DeleteEvent(int id)
        {
            Events evt = _context.Events.SingleOrDefault(e => e.EventId == id);
            if (evt != null)
                {
                _context.Events.DeleteOnSubmit(evt);
                _context.SubmitChanges();
            }
        }
    }
}


