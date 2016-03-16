using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class LocationRepo : ILocationRepo
    {
        private readonly TimePlannerContext _db = new TimePlannerContext();

        public IQueryable<Location> GetLocations()
        {
            _db.Database.Log = msg => Trace.WriteLine(msg);
            return _db.Locations.AsNoTracking();
        }
    }
}