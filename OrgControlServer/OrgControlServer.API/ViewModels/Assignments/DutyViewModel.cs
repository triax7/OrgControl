using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrgControlServer.API.ViewModels.Users;

namespace OrgControlServer.API.ViewModels.Assignments
{
    public class DutyViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserWithNameViewModel User { get; set; }
    }
}
