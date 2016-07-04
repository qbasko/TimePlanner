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
        public IEventRepo EventRepo { get; set; }
        public IEventTypeRepo EventTypeRepo { get; set; }
        public ILocationRepo LocationRepo { get; set; }
        public IUserRepo UserRepo { get; set; }

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