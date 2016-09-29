using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;

namespace Services
{
    public class UserService: BaseService, IUserService
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork) { }

        public User GetUserById(string id)
        {
            return UnitOfWork.UserRepo.GetUserById(id);
        }

        public void Update(User user)
        {
            UnitOfWork.UserRepo.Update(user);
        }
    }
}