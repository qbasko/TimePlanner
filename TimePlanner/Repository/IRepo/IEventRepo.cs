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
        IEnumerable<Event> GetEvents(int page, int itemsPerPage);
        Event GetEventById(string id);
        void Delete(string id);
        void SaveChanges();
        void Add(Event @event);
        void Update(Event @event);

    }
}
