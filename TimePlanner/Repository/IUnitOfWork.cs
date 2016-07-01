using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public interface IUnitOfWork : IDisposable
    {
        IEventRepo EventRepo { get; }
        IEventTypeRepo EventTypeRepo { get; }
        ILocationRepo LocationRepo { get; }
        IUserRepo UserRepo { get; }
        void SaveChanges();
    }
}
