using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class EventRepo : IEventRepo
    {
        private readonly ITimePlannerContext _ctx;

        public EventRepo(ITimePlannerContext ctx)
        {
            _ctx = ctx;
        }

        IEnumerable<Event> IEventRepo.GetEvents()
        {
            _ctx.Db.Log = msg => Trace.WriteLine(msg);
            return _ctx.Events.AsNoTracking().ToList();
        }

        public Event GetEventById(string id)
        {
            return _ctx.Events.Find(id);
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}