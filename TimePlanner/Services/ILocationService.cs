using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface ILocationService
    {
        IEnumerable<Location> GetLocations();
        Location GetLocationById(string id);
        void Add(Location location);
        void Update(Location location);
        void Delete(string id);
    }
}
