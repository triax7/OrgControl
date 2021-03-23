using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using OrgControlServer.BLL.DTOs.Assignments;
using OrgControlServer.BLL.Exceptions;
using OrgControlServer.BLL.Services.Interfaces;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AssignmentDTO CreateAssignment(AssignmentCreateDTO dto, string currentUserId)
        {
            var currentUser = _unitOfWork.Users.GetById(currentUserId);
            var currentEvent = _unitOfWork.Events.GetById(dto.EventId);

            if (currentUser.Roles.Where(r => r.EventId == dto.EventId).Any(r => !r.CanCreateAssignments) &&
                currentUserId != currentEvent.UserId)
                throw new AppException("You can't create assignments in this event.", HttpStatusCode.Forbidden);

            var newAssignment = _mapper.Map<Assignment>(dto);

            newAssignment.AllowedRoles = dto.AllowedRoleIds.Select(id => _unitOfWork.Roles.GetById(id)).ToList();

            _unitOfWork.Assignments.Add(newAssignment);
            _unitOfWork.Commit();

            return _mapper.Map<AssignmentDTO>(newAssignment);
        }

        public void AssignDutyToUser(string assignmentId, string userId, string currentUserId)
        {
            var assignment = _unitOfWork.Assignments.GetById(assignmentId);
            var user = _unitOfWork.Users.GetById(userId);

            if (assignment.Status != AssignmentStatus.NotStarted)
                throw new AppException("Assignment is already in progress or completed.");
            if (assignment.Event.UserId != currentUserId)
                throw new AppException("You are not the creator of the event.", HttpStatusCode.Forbidden);

            assignment.User = user;
            assignment.Status = AssignmentStatus.InProgress;
            _unitOfWork.Commit();
        }

        public IEnumerable<DutyDTO> AutoAssignDuties(IEnumerable<string> assignmentIds, string currentUserId)
        {
            var assignedDuties = new List<DutyDTO>();

            foreach (var assignmentId in assignmentIds)
            {
                var assignment = _unitOfWork.Assignments.GetById(assignmentId);

                if (assignment.Status != AssignmentStatus.NotStarted) continue;

                var userToAssign = assignment.AllowedRoles
                    .SelectMany(r => r.Users).Distinct().OrderBy(u => u.Duties.Count).FirstOrDefault();

                assignment.User = userToAssign;
                assignment.Status = AssignmentStatus.InProgress;

                _unitOfWork.Commit();
                
                assignedDuties.Add(_mapper.Map<DutyDTO>(assignment));
            }

            return assignedDuties;
        }

        public IEnumerable<AssignmentDTO> GetAssignmentsFromEvent(string eventId)
        {
            return _mapper.Map<IEnumerable<AssignmentDTO>>(
                _unitOfWork.Assignments.GetAll(a => a.EventId == eventId).ToList());
        }

        public IEnumerable<AssignmentDTO> GetAssignmentsForRole(string roleId)
        {
            var role = _unitOfWork.Roles.GetById(roleId);

            return _mapper.Map<IEnumerable<AssignmentDTO>>(
                role.AllowedAssignments.Where(a => a.Status == AssignmentStatus.NotStarted).ToList());
        }

        public IEnumerable<AssignmentDTO> GetAssignmentsForUserInEvent(string userId, string eventId)
        {
            var userRolesInEvent = _unitOfWork.Roles.GetAll(r => r.EventId == eventId && r.Users.Any(u => u.Id == userId));

            return _mapper.Map<IEnumerable<AssignmentDTO>>(userRolesInEvent
                .SelectMany(r => r.AllowedAssignments.Where(a => a.Status == AssignmentStatus.NotStarted)).Distinct().ToList());
        }

        public IEnumerable<AssignmentDTO> GetDutiesForUserInEvent(string userId, string eventId)
        {
            var user = _unitOfWork.Users.GetById(userId);

            return _mapper.Map<IEnumerable<AssignmentDTO>>(user.Duties.Where(a => a.EventId == eventId));
        }
    }
}