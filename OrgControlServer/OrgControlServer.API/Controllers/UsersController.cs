using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using OrgControlServer.API.ViewModels.Auth;
using OrgControlServer.BLL.Services;
using OrgControlServer.BLL.Services.Interfaces;

namespace OrgControlServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<UserViewModel>> SearchUsers([FromQuery] string searchString, [FromQuery] int page)
        {
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(_userService.SearchUsers(searchString, page)));
        }
    }
}
