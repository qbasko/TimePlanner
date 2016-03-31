using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.CompilerServices;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.IRepo;

namespace Repository.Models
{
    public class TimePlannerContext : IdentityDbContext, ITimePlannerContext
    {
        public TimePlannerContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }

        public Database Db => Database;

        public static TimePlannerContext Create()
        {
            return new TimePlannerContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Event>()
                .HasRequired(e => e.User)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}