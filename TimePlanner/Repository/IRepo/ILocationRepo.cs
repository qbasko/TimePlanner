using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;

namespace Repository.IRepo
{
    public interface ILocationRepo
    {
        IEnumerable<Location> GetLocations();
        IEnumerable<Location> GetLocations(int page, int itemsPerPage);

        Location GetLocationByName(string name);

        Location GetLocationById(string id);

        void Delete(string id);
        void SaveChanges();

        void Add(Location location);
        void Update(Location location);

    }
}