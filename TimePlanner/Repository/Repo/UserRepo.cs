using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly ITimePlannerContext _ctx;

        public UserRepo(ITimePlannerContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetUsers()
        {
            return _ctx.ApplicationUsers.AsNoTracking().ToList();
        }

        public IEnumerable<User> GetUsers(int page, int itemsPerPage)
        {
            return
               _ctx.ApplicationUsers.AsNoTracking()
                   .OrderBy(l => l.Name)
                   .Skip(itemsPerPage * (page - 1))
                   .Take(itemsPerPage)
                   .ToList();
        }

        public User GetUserById(string id)
        {
            return _ctx.ApplicationUsers.Find(id);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
        }
    }
}