using Repository.Models;

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Models.TimePlannerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository.Models.TimePlannerContext context)
        {
            //uncomment for debugging
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            PopulateEventTypes(context);
       
        }

        private static void PopulateEventTypes(TimePlannerContext context)
        {
            context.EventTypes.AddOrUpdate(new EventType()
            {
                Id = "1",
                Name = "Meeting"
            });

            context.EventTypes.AddOrUpdate(new EventType()
            {
                Id = "2",
                Name = "Party"
            });

            context.EventTypes.AddOrUpdate(new EventType()
            {
                Id = "3",
                Name = "Beer"
            });

            context.EventTypes.AddOrUpdate(new EventType()
            {
                Id = "4",
                Name = "Lunch"
            });

            context.EventTypes.AddOrUpdate(new EventType()
            {
                Id = "5",
                Name = "Sighseeing"
            });
        }
    }
}
