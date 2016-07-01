using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Repository.Models;

namespace Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _unitOfWork.EventRepo.GetEvents();
        } 
    }
}