using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using OrgControlServer.BLL.DTOs.Auth;
using OrgControlServer.BLL.Exceptions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services
{
    public class UserAccountsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenService _tokenService;

        public UserAccountsService(IUnitOfWork unitOfWork, TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public UserDTO RegisterUser(RegisterDTO dto)
        {
            if (_unitOfWork.Users.GetAll(u => u.Email == dto.Email).SingleOrDefault() != null)
                throw new AppException("User already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _unitOfWork.Users.Add(user);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _unitOfWork.RefreshTokens.Add(new RefreshToken { Token = refreshToken, User = user });

            _unitOfWork.Commit();

            return new UserDTO(user.Id, user.Name, user.Email, accessToken, refreshToken);
        }

        public UserDTO LoginUser(LoginDTO dto)
        {
            var user = _unitOfWork.Users.GetAll().SingleOrDefault(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new AppException("User not found", HttpStatusCode.NotFound);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _unitOfWork.RefreshTokens.Add(new RefreshToken { Token = refreshToken, User = user });

            _unitOfWork.Commit();

            return new UserDTO(user.Id, user.Name, user.Email, accessToken, refreshToken);
        }

        public bool RevokeRefreshToken(string refreshToken)
        {
            var token = _unitOfWork.RefreshTokens.GetAll().FirstOrDefault(t => t.Token == refreshToken);
            if (token == null) return false;

            _unitOfWork.RefreshTokens.Remove(token);

            _unitOfWork.Commit();

            return true;
        }

        public UserDTO UpdateAccessToken(string requestAccessToken, string requestRefreshToken)
        {
            var accessToken = new JwtSecurityTokenHandler().ReadToken(requestAccessToken) as JwtSecurityToken;
            if (accessToken == null)
                throw new AppException("Invalid access token", HttpStatusCode.Unauthorized);

            var userId = accessToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
            var user = _unitOfWork.Users.GetById(userId);

            if (user == null)
                throw new AppException("User not found", HttpStatusCode.NotFound);

            if (!_unitOfWork.RefreshTokens.GetAll().Any(t => t.Token == requestRefreshToken))
                throw new AppException("Invalid refresh token", HttpStatusCode.Unauthorized);

            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            _unitOfWork.RefreshTokens.Add(new RefreshToken { Token = newRefreshToken, User = user });

            _unitOfWork.Commit();

            return new UserDTO(user.Id, user.Name, user.Email, newAccessToken, newRefreshToken);
        }

        public bool EmailExists(string email)
        {
            return _unitOfWork.Users.SingleOrDefault(u => u.Email == email) != null;
        }

        public UserDTO GetUserById(string id)
        {
            var user = _unitOfWork.Users.GetById(id);
            return new UserDTO(user.Id, user.Name, user.Email);
        }
    }
}
