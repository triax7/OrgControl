using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IEventRepository Events { get; }
        IRoleRepository Roles { get; }
        IAssignmentRepository Assignments { get; }
        IZoneRepository Zones { get; }
        int Commit();
    }
}