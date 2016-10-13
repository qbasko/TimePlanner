using Repository.IRepo;
using Repository.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEventRepo _eventRepo;
        private IEventTypeRepo _eventTypeRepo;
        private ILocationRepo _locationRepo;
        private IUserRepo _userRepo;

        public IEventRepo EventRepo { get { return _eventRepo ?? (_eventRepo = new EventRepo(_ctx)); } }

        public IEventTypeRepo EventTypeRepo { get { return _eventTypeRepo ?? (_eventTypeRepo = new EventTypeRepo(_ctx)); } }

        public ILocationRepo LocationRepo { get { return _locationRepo ?? (_locationRepo = new LocationRepo(_ctx)); } }

        public IUserRepo UserRepo { get { return _userRepo ?? (_userRepo = new UserRepo(_ctx)); } }

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