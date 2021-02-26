using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrgControlServer.API.ViewModels.Roles;

namespace OrgControlServer.API.ViewModels.Assignments
{
    public class AssignmentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<RoleViewModel> AllowedRoles { get; set; }
    }
}
