using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using OrgControlServer.API.ViewModels.Auth;
using OrgControlServer.BLL.DTOs.Auth;
using OrgControlServer.BLL.Services;

namespace OrgControlServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserAccountsService _userAccountsService;

        public AccountsController(IMapper mapper, UserAccountsService userAccountsService)
        {
            _mapper = mapper;
            _userAccountsService = userAccountsService;
        }

        [HttpPost("Register")]
        public ActionResult<UserViewModel> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userAccountsService.RegisterUser(_mapper.Map<RegisterDTO>(model));
            SetTokenCookies(user.AccessToken, user.RefreshToken);

            return Ok(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost("Login")]
        public ActionResult<UserViewModel> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userAccountsService.LoginUser(_mapper.Map<LoginDTO>(model));
            SetTokenCookies(user.AccessToken, user.RefreshToken);

            return Ok(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost("UpdateAccessToken")]
        public ActionResult<UserViewModel> UpdateAccessToken()
        {
            if (!Request.Cookies.TryGetValue("access-token", out var accessToken) ||
                !Request.Cookies.TryGetValue("refresh-token", out var refreshToken))
            {
                return BadRequest("No tokens provided");
            }

            var userWithTokens = _userAccountsService.UpdateAccessToken(accessToken, refreshToken);

            SetTokenCookies(userWithTokens.AccessToken, userWithTokens.RefreshToken);

            return Ok(_mapper.Map<UserViewModel>(userWithTokens));
        }

        [Authorize]
        [HttpPost("Logout")]
        public ActionResult RevokeRefreshToken()
        {
            if (Request.Cookies.TryGetValue("refresh-token", out var refreshToken))
                _userAccountsService.RevokeRefreshToken(refreshToken);

            Response.Cookies.Delete("access-token");
            Response.Cookies.Delete("refresh-token");

            return Ok();
        }

        [HttpPost("Exists")]
        public ActionResult<bool> EmailExists([FromBody] EmailExistsViewModel model)
        {
            return Ok(_userAccountsService.EmailExists(model.Email));
        }

        [Authorize]
        [HttpGet("Current")]
        public ActionResult<UserViewModel> GetCurrentUser()
        {
            var user = _userAccountsService.GetUserById(User.Claims
                .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value);

            return Ok(_mapper.Map<UserViewModel>(user));
        }

        private void SetTokenCookies(string accessToken, string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("access-token", accessToken, cookieOptions);
            Response.Cookies.Append("refresh-token", refreshToken, cookieOptions);

            //revoke current refresh token when we get a new one
            if (Request.Cookies.TryGetValue("refresh-token", out var currentRefreshToken))
                _userAccountsService.RevokeRefreshToken(currentRefreshToken);
        }
    }
}