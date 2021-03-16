using OrgControlServer.DAL.Models;

namespace OrgControlServer.BLL.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}