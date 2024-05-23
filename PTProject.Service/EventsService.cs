using PTProject.Data;

namespace PTProject.Service
{
    public class EventsService
    {
        private IUnitOfWork _unitOfWork;

        public EventsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Create
        public void AddEvent(Event evt)
        {
            _unitOfWork.EventRepository.Add(evt);
            _unitOfWork.Save();
        }

        // Read
        public Event GetEvent(int id)
        {
            return _unitOfWork.EventRepository.GetById(id);
        }

        // Delete
        public void DeleteEvent(int id)
        {
            Event evt = _unitOfWork.EventRepository.GetById(id);
            if (evt != null)
            {
                _unitOfWork.EventRepository.Delete(evt);
                _unitOfWork.Save();
            }
        }
    }
}
