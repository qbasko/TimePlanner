using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
    }
}