using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrgControlServer.API.ViewModels.Roles
{
    public class AssignRoleToUserViewModel
    {
        [Required] public string UserId { get; set; }
        [Required] public string RoleId { get; set; }
    }
}
