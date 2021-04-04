using System.Collections.Generic;
using OrgControlServer.BLL.DTOs.Assignments;

namespace OrgControlServer.BLL.Services.Interfaces
{
    public interface IAssignmentService
    {
        AssignmentDTO CreateAssignment(AssignmentCreateDTO dto, string currentUserId);
        void AssignDutyToUser(string assignmentId, string userId, string currentUserId);
        IEnumerable<AssignmentDTO> AutoAssignDuties(IEnumerable<string> assignmentIds, string currentUserId);
        IEnumerable<AssignmentDTO> GetAssignmentsFromEvent(string eventId);
        IEnumerable<AssignmentDTO> GetAssignmentsForRole(string roleId);
        IEnumerable<AssignmentDTO> GetAssignmentsForUserInEvent(string userId, string eventId);
        IEnumerable<AssignmentDTO> GetDutiesForUserInEvent(string userId, string eventId);
    }
}