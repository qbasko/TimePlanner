using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}