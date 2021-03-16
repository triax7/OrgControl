using OrgControlServer.BLL.DTOs.Auth;

namespace OrgControlServer.BLL.Services.Interfaces
{
    public interface IUserAccountsService
    {
        UserDTO RegisterUser(RegisterDTO dto);
        UserDTO LoginUser(LoginDTO dto);
        bool RevokeRefreshToken(string refreshToken);
        UserDTO UpdateAccessToken(string requestAccessToken, string requestRefreshToken);
        bool EmailExists(string email);
        UserDTO GetUserById(string id);
    }
}