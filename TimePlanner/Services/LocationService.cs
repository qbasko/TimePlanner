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

        public void Add(Location location)
        {
            UnitOfWork.LocationRepo.Add(location);
            UnitOfWork.SaveChanges();
        }

        public void Delete(string id)
        {
            UnitOfWork.LocationRepo.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public Location GetLocationById(string id)
        {
            return UnitOfWork.LocationRepo.GetLocationById(id);
        }

        public IEnumerable<Location> GetLocations()
        {
            return UnitOfWork.LocationRepo.GetLocations();
        }

        public void Update(Location location)
        {
            UnitOfWork.LocationRepo.Update(location);
            UnitOfWork.SaveChanges();
        }
    }
}