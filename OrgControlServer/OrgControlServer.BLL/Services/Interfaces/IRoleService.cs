using System.Collections.Generic;
using OrgControlServer.BLL.DTOs.Roles;

namespace OrgControlServer.BLL.Services.Interfaces
{
    public interface IRoleService
    {
        RoleDTO CreateRole(RoleCreateDTO dto, string currentUserId);
        IEnumerable<RoleDTO> GetRolesFromEvent(string eventId, string currentUserId);
        void DeleteRole(string roleId, string currentUserId);
        void AssignRoleToUser(string roleId, string userToAssignId, string currentUserId);
        void RemoveRoleFromUser(string roleId, string userToRemoveId, string currentUserId);
        IEnumerable<RoleDTO> GetUserRolesInEvent(string userId, string eventId, string currentUserId);
    }
}