using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgControlServer.BLL.DTOs.Roles;
using OrgControlServer.DAL.Models;

namespace OrgControlServer.BLL.DTOs.Assignments
{
    public class AssignmentDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentStatus Status { get; set; }
        public IEnumerable<RoleDTO> AllowedRoles { get; set; }
    }
}
