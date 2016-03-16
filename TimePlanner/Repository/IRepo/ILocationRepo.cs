using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;

namespace Repository.IRepo
{
    public interface ILocationRepo
    {
       IQueryable<Location> GetLocations();
    }
}