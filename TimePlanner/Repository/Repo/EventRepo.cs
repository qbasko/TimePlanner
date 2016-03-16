using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class EventRepo : IEventRepo
    {
        private TimePlannerContext _db = new TimePlannerContext();

        public IQueryable<Event> GetEvents()
        {
            return _db.Events.AsNoTracking();
        }
    }
}