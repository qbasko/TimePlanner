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

        public void Add(Event @event)
        {
            UnitOfWork.EventRepo.Add(@event);
            UnitOfWork.EventRepo.SaveChanges();
        }

        public void Delete(string id)
        {
            UnitOfWork.EventRepo.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return UnitOfWork.EventRepo.GetEvents();
        }

        public Event GetEventById(string id)
        {
            return UnitOfWork.EventRepo.GetEventById(id);
        }

        public void Update(Event @event)
        {
            UnitOfWork.EventRepo.Update(@event);
        }
    }
}