using PTProject.Data;
using System;

namespace PTProject.Service
{
    public class ProcessStateService : IProcessStateService
    {
        private IUnitOfWork _unitOfWork;
        private IGoodService _goodService;

        public ProcessStateService(IUnitOfWork unitOfWork, IGoodService goodService)
        {
            _unitOfWork = unitOfWork;
            _goodService = goodService;
        }

        // Create
        public void AddProcessState(ProcessState processState)
        {
            _unitOfWork.ProcessStateRepository.Add(processState);
            _unitOfWork.Save();
        }

        // Read
        public ProcessState GetProcessState(int id)
        {
            return _unitOfWork.ProcessStateRepository.GetById(id);
        }

        // Update
        public void UpdateProcessState(ProcessState updatedProcessState, string eventType)
        {
            ProcessState processState = _unitOfWork.ProcessStateRepository.GetById(updatedProcessState.ProcessStateId);
            if (processState != null)
            {
                // Get the associated Good
                Good good = _unitOfWork.GoodRepository.GetById(processState.GoodId);

                if (good != null)
                {
                    // Adjust the description and create the event based on the event type
                    if (eventType == "Purchase")
                    {
                        if (_goodService.GetGoodById(good.GoodId) != null)
                        {
                            processState.Description = "Buy";
                            CreateEvent(updatedProcessState, "Purchase");

                            // Remove the Good from the Catalog
                            _unitOfWork.GoodRepository.Delete(good);
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
                        _unitOfWork.GoodRepository.Add(newGood);
                    }

                    _unitOfWork.Save();
                }
            }
        }

        private void CreateEvent(ProcessState processState, string eventType)
        {
            // Create a new event
            Event evt = new Event
            {
                Description = $"ProcessState with ID {processState.ProcessStateId} was updated to {eventType}",
                EventType = eventType,
            };

            // Use the EventsService to add the new event
            EventsService eventsService = new EventsService(_unitOfWork);
            eventsService.AddEvent(evt);
        }

        // Delete
        public void DeleteProcessState(int id)
        {
            ProcessState processState = _unitOfWork.ProcessStateRepository.GetById(id);
            if (processState != null)
            {
                _unitOfWork.ProcessStateRepository.Delete(processState);
                _unitOfWork.Save();
            }
        }
    }
}
