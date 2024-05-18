using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Service
{
    public class ProcessStateService
    {
        private MyDataContext _context;
        private GoodService _goodService;
        private string _connectionString;

        public ProcessStateService(string connectionString)
        {
            _context = new MyDataContext(connectionString);
            _goodService = new GoodService(connectionString);
            _connectionString = connectionString;
        }

        // Create
        public void AddProcessState(ProcessState processState)
        {
            _context.ProcessStates.InsertOnSubmit(processState);
            _context.SubmitChanges();
        }

        // Read
        public ProcessState GetProcessState(int id)
        {
            return _context.ProcessStates.SingleOrDefault(ps => ps.ProcessStateId == id);
        }

        // Update
        public void UpdateProcessState(ProcessState updatedProcessState, string eventType)
        {
            ProcessState processState = _context.ProcessStates.SingleOrDefault(ps => ps.ProcessStateId == updatedProcessState.ProcessStateId);
            if (processState != null)
            {
                // Get the associated Good
                Good good = _context.Catalog.SingleOrDefault(g => g.GoodId == processState.GoodId);

                if (good != null)
                {
                    // Adjust the description and create the event based on the event type
                    if (eventType == "Purchase")
                    {
                        if (_goodService.NumberGood(good.GoodId) > 0)
                        {
                            processState.Description = "Buy";
                            CreateEvent(updatedProcessState, "Purchase");

                            // Remove the Good from the Catalog
                            _context.Catalog.DeleteOnSubmit(good);
                        }
                        else
                        {
                            throw new Exception("Not enough quantity for purchase");
                        }
                    }
                    else if (eventType == "Return")
                    {
                        processState.Description = "Stock";
                        CreateEvent(updatedProcessState, "Return");

                        // Add a new Good to the Catalog
                        Good newGood = new Good
                        {
                            // Set the properties of the new Good here. For example:
                            Name = good.Name,
                            Description = good.Description,
                            Price = good.Price,

                        };
                        _context.Catalog.InsertOnSubmit(newGood);
                    }

                    _context.SubmitChanges();
                }
            }
        }


        private void CreateEvent(ProcessState processState, string eventType)
        {
            // Create a new event
            Events evt = new Events
            {
                Description = $"ProcessState with ID {processState.ProcessStateId} was updated to {eventType}",
                EventType = eventType,
            };

            // Use the EventsService to add the new event
            EventsService eventsService = new EventsService(_connectionString);
            eventsService.AddEvent(evt);
        }



        // Delete
        public void DeleteProcessState(int id)
        {
            ProcessState processState = _context.ProcessStates.SingleOrDefault(ps => ps.ProcessStateId == id);
            if (processState != null)
            {
                _context.ProcessStates.DeleteOnSubmit(processState);
                _context.SubmitChanges();
            }
        }
    }
}


