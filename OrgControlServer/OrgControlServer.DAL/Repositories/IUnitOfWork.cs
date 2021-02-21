using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        int Commit();
    }
}