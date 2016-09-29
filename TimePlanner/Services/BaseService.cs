using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}