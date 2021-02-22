﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using OrgControlServer.API.ViewModels.Roles;
using OrgControlServer.BLL.DTOs.Roles;
using OrgControlServer.BLL.Services.Auth;
using OrgControlServer.BLL.Services.Roles;

namespace OrgControlServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserAccountsService _userAccountsService;
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(UserAccountsService userAccountsService, RoleService roleService, IMapper mapper)
        {
            _userAccountsService = userAccountsService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public ActionResult<RoleViewModel> Create([FromBody] RoleCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return _mapper.Map<RoleViewModel>(_roleService.CreateRole(_mapper.Map<RoleCreateDTO>(model), userId));
        }

        [HttpGet("GetFromEvent/{eventId}")]
        public ActionResult<IEnumerable<RoleViewModel>> GetRoles([FromRoute] string eventId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return Ok(_mapper.Map<IEnumerable<RoleViewModel>>(_roleService.GetRolesFromEvent(eventId, userId)));
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete([FromRoute] string id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            _roleService.DeleteRole(id, userId);

            return Ok();
        }
    }
}