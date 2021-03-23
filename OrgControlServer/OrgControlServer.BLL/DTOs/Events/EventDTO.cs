using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgControlServer.BLL.DTOs.Events
{
    public class EventDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AssignmentsNotStarted { get; set; }
        public int AssignmentsInProgress { get; set; }
        public int AssignmentsDone { get; set; }

        public EventDTO(string id, string name, int assignmentsNotStarted = 0, int assignmentsInProgress = 0, int assignmentsDone = 0)
        {
            Id = id;
            Name = name;
            AssignmentsNotStarted = assignmentsNotStarted;
            AssignmentsInProgress = assignmentsInProgress;
            AssignmentsDone = assignmentsDone;
        }
    }
}
