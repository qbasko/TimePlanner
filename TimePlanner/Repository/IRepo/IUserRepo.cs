using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(int page, int itemsPerPage);
        User GetUserById(string id);
        void Delete(string id);
        void SaveChanges();
        void Add(User user);
        void Update(User user);
    }
}
