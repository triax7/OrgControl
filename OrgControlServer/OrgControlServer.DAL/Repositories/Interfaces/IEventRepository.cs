using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgControlServer.DAL.Abstractions;
using OrgControlServer.DAL.Models;

namespace OrgControlServer.DAL.Repositories.Interfaces
{
    interface IEventRepository : IBaseRepository<Event>
    {
    }
}
