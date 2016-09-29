using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public EventTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<EventType> GetEventTypes()
        {
            return UnitOfWork.EventTypeRepo.GetEventTypes();
        }

    }
}