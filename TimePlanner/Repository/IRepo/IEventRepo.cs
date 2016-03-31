using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IEventRepo
    {
        IEnumerable<Event> GetEvents();
        Event GetEventById(string id);
        bool Delete(string id);
        void SaveChanges();
    }
}
