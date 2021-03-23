using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgControlServer.API.ViewModels.Events
{
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AssignmentsNotStarted { get; set; }
        public int AssignmentsInProgress { get; set; }
        public int AssignmentsDone { get; set; }
    }
}
