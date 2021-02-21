using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories.Implementations
{
    public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
