using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Repository.Models;

namespace Repository.IRepo
{
    public interface ITimePlannerContext
    {
        DbSet<Event> Events { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<User> ApplicationUsers { get; set; }
        Database Db { get;}
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}