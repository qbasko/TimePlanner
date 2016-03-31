using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class EventTypeRepo : IEventTypeRepo
    {
        private readonly ITimePlannerContext _ctx;

        public EventTypeRepo(ITimePlannerContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<EventType> GetEventTypes()
        {
            return _ctx.EventTypes.AsNoTracking().ToList();
        }
    }
}