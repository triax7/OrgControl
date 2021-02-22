using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrgControlServer.API.ViewModels.Roles
{
    public class RoleCreateViewModel
    {
        [Required] public string Name { get; set; }
        [Required] public string EventId { get; set; }
        [Required] public bool CanCreateAssignments { get; set; }
    }
}