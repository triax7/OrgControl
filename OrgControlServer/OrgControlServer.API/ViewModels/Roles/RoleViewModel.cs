using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrgControlServer.DAL.Models;

namespace OrgControlServer.API.ViewModels.Roles
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool CanCreateAssignments { get; set; }
    }
}
