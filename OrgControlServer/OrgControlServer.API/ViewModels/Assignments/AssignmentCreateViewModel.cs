using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OrgControlServer.API.ViewModels.Roles;

namespace OrgControlServer.API.ViewModels.Assignments
{
    public class AssignmentCreateViewModel
    {
        [Required] public string EventId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        public IEnumerable<string> AllowedRoleIds { get; set; } = new List<string>();
    }
}