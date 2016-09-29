using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public class LocationService : BaseService, ILocationService
    {
        public LocationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Location GetLocationById(string id)
        {
            return UnitOfWork.LocationRepo.GetLocationById(id);
        }

        public IEnumerable<Location> GetLocations()
        {
            return UnitOfWork.LocationRepo.GetLocations();
        }
    }
}