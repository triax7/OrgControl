using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories
{
    internal interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        int Commit();
    }
}