using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
