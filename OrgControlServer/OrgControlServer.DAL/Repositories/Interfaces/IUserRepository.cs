using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;
using OrgControlServer.DAL.Models;

namespace OrgControlServer.DAL.Repositories.Interfaces
{
    interface IUserRepository : IBaseRepository<User>
    {
    }
}
