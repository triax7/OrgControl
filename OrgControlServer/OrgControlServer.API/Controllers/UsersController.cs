using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.API.ViewModels.Auth;
using OrgControlServer.BLL.Services.Roles;
using OrgControlServer.BLL.Services.Users;

namespace OrgControlServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UsersController(IMapper mapper, UserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("search/{searchString}/{page}")]
        public ActionResult<IEnumerable<UserViewModel>> SearchUsers([FromRoute] string searchString, [FromRoute] int page)
        {
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(_userService.SearchUsers(searchString, page)));
        }
    }
}
