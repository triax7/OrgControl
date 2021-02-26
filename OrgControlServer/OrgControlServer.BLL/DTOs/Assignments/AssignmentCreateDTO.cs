using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgControlServer.BLL.DTOs.Roles;

namespace OrgControlServer.BLL.DTOs.Assignments
{
    public class AssignmentCreateDTO
    {
        public string EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> AllowedRoleIds { get; set; }
    }
}
