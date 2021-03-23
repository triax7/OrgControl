using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgControlServer.API.ViewModels.Assignments
{
    public class AutoAssignViewModel
    {
        public IEnumerable<string> AssignmentIds { get; set; }
    }
}
