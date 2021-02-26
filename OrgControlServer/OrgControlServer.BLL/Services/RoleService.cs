using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using OrgControlServer.BLL.DTOs.Roles;
using OrgControlServer.BLL.Exceptions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services
{
    public class RoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public RoleDTO CreateRole(RoleCreateDTO dto, string currentUserId)
        {
            var myEvent = _unitOfWork.Events.GetById(dto.EventId);

            if (myEvent == null || myEvent.User.Id != currentUserId)
                throw new AppException("Event does not belong to you or does not exist", HttpStatusCode.Forbidden);

            var role = _mapper.Map<Role>(dto);

            _unitOfWork.Roles.Add(role);
            _unitOfWork.Commit();

            return new RoleDTO(role.Id, role.Name);
        }

        public IEnumerable<RoleDTO> GetRolesFromEvent(string eventId, string currentUserId)
        {
            var myEvent = _unitOfWork.Events.GetById(eventId);

            if (myEvent == null || myEvent.User.Id != currentUserId)
                throw new AppException("Event does not belong to you or does not exist", HttpStatusCode.Forbidden);

            return _mapper.Map<IEnumerable<RoleDTO>>(myEvent.Roles);
        }

        public void DeleteRole(string roleId, string currentUserId)
        {
            var role = _unitOfWork.Roles.GetById(roleId);
            
            if (role == null || role.Event.UserId != currentUserId)
                throw new AppException("Role does not belong to you or does not exist", HttpStatusCode.Forbidden);
            
            _unitOfWork.Roles.Remove(role);
        }

        public void AssignRoleToUser(string roleId, string userToAssignId, string currentUserId)
        {
            var role = _unitOfWork.Roles.GetById(roleId);

            if (role == null || role.Event.UserId != currentUserId)
                throw new AppException("Role does not belong to you or does not exist", HttpStatusCode.Forbidden);
            
            role.Users.Add(_unitOfWork.Users.GetById(currentUserId));
            _unitOfWork.Commit();
        }

        public IEnumerable<RoleDTO> GetUserRolesInEvent(string userId, string eventId, string currentUserId)
        {
            var user = _unitOfWork.Users.GetById(userId);

            if (user == null)
                throw new AppException("User not found", HttpStatusCode.NotFound);

            return _mapper.Map<IEnumerable<RoleDTO>>(user.Roles.Where(r => r.EventId == eventId));
        }
    }
}
