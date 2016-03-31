using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Event> GetEvents(int page, int itemsPerPage)
        {
            return
               _ctx.Events.AsNoTracking()
                   .OrderBy(l => l.Name)
                   .Skip(itemsPerPage * (page - 1))
                   .Take(itemsPerPage)
                   .ToList();
        }

        public Event GetEventById(string id)
        {
            return _ctx.Events.Find(id);
        }

        public void Delete(string id)
        {
            Event @event = _ctx.Events.Find(id);
            _ctx.Events.Remove(@event);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Add(Event @event)
        {
            _ctx.Events.Add(@event);
        }

        public void Update(Event @event)
        {
            _ctx.Entry(@event).State = EntityState.Modified;
        }
    }
}