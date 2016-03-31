using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class LocationRepo : ILocationRepo
    {
        private readonly ITimePlannerContext _ctx;

        public LocationRepo(ITimePlannerContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Location> GetLocations()
        {
            _ctx.Db.Log = msg => Trace.WriteLine(msg);
            return _ctx.Locations.AsNoTracking().ToList();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _ctx.Locations.AsNoTracking().ToList();
        }

        public IEnumerable<Location> GetLocations(int page, int itemsPerPage)
        {
            return
                _ctx.Locations.AsNoTracking()
                    .OrderBy(l => l.Name)
                    .Skip(itemsPerPage*(page - 1))
                    .Take(itemsPerPage)
                    .ToList();
        }

        public Location GetLocationByName(string name)
        {
            return _ctx.Locations.SingleOrDefault(l => l.Name == name);
        }

        public Location GetLocationById(string id)
        {
            return _ctx.Locations.Find(id);
        }

        public void Delete(string id)
        {
            Location location = _ctx.Locations.Find(id);
            _ctx.Locations.Remove(location);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Add(Location location)
        {
            _ctx.Locations.Add(location);
        }

        public void Update(Location location)
        {
            _ctx.Entry(location).State = EntityState.Modified;
        }
    }
}