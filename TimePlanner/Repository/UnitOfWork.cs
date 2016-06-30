using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public class UnitOfWork
    {
        private readonly IEventRepo _eventRepo;
        private readonly IEventTypeRepo _eventTypeRepo;
        private readonly ILocationRepo _locationRepo;
        private readonly IUserRepo _userRepo;

        private readonly ITimePlannerContext _ctx;

        public UnitOfWork(ITimePlannerContext ctx)
        {
            _ctx = ctx;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

    }
}