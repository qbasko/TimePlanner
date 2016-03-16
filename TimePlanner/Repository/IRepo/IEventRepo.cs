using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    interface IEventRepo
    {
        IQueryable<Event> GetEvents(); 
    }
}
