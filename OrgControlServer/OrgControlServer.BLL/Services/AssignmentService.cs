using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.BLL.DTOs.Assignments;
using OrgControlServer.BLL.Exceptions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services
{
    public class AssignmentService
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

            return _mapper.Map<AssignmentDTO>(newAssignment);
        }

        public IEnumerable<AssignmentDTO> GetAssignmentsFromEvent(string eventId)
        {
            return _mapper.Map<IEnumerable<AssignmentDTO>>(
                _unitOfWork.Assignments.GetAll(a => a.EventId == eventId));
        }

        public IEnumerable<AssignmentDTO> GetAssignmentsForRole(string roleId)
        {
            var role = _unitOfWork.Roles.GetById(roleId);

            return _mapper.Map<IEnumerable<AssignmentDTO>>(
                role.AllowedAssignments.Where(a => a.Status == AssignmentStatus.NotStarted));
        }
    }
}