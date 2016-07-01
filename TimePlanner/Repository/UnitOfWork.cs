using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEventRepo _eventRepo;
        private readonly IEventTypeRepo _eventTypeRepo;
        private readonly ILocationRepo _locationRepo;
        private readonly IUserRepo _userRepo;

        public IEventRepo EventRepo => _eventRepo;
        public IEventTypeRepo EventTypeRepo => _eventTypeRepo;
        public ILocationRepo LocationRepo => _locationRepo;
        public IUserRepo UserRepo => _userRepo;

        private readonly ITimePlannerContext _ctx;

        public UnitOfWork(ITimePlannerContext ctx)
        {
            _ctx = ctx;
        }

        public void SaveChanges()
        {
            try
            {
                _ctx.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //TODO log exception
            }
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}