using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using OrgControlServer.API.ViewModels.Assignments;
using OrgControlServer.BLL.DTOs.Assignments;
using OrgControlServer.BLL.Services;
using OrgControlServer.BLL.Services.Interfaces;

namespace OrgControlServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IMapper mapper, IAssignmentService assignmentService)
        {
            _mapper = mapper;
            _assignmentService = assignmentService;
        }

        [HttpPost("Create")]
        public ActionResult<AssignmentViewModel> CreateAssignment([FromBody] AssignmentCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentUserId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return _mapper.Map<AssignmentViewModel>(
                _assignmentService.CreateAssignment(_mapper.Map<AssignmentCreateDTO>(model), currentUserId));
        }

        [HttpPost("AssignDuty")]
        public ActionResult AssignDuty([FromBody] DutyAssignViewModel model)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
            
            _assignmentService.AssignDutyToUser(model.AssignmentId, model.UserId, currentUserId);

            return Ok();
        }

        [HttpPost("AutoAssignDuties")]
        public ActionResult AutoAssignDuties([FromBody] AutoAssignViewModel model)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return Ok(_mapper.Map<IEnumerable<DutyViewModel>>(
                _assignmentService.AutoAssignDuties(model.AssignmentIds, currentUserId)));
        }

        [HttpGet("GetFromEvent/{eventId}")]
        public ActionResult<IEnumerable<AssignmentViewModel>> GetAssignmentsFromEvent([FromRoute] string eventId)
        {
            return Ok(_mapper.Map<IEnumerable<AssignmentViewModel>>(
                _assignmentService.GetAssignmentsFromEvent(eventId)));
        }

        [HttpGet("GetForRole/{roleId}")]
        public ActionResult<IEnumerable<AssignmentViewModel>> GetAssignmentsForRole([FromRoute] string roleId)
        {
            return Ok(_mapper.Map<IEnumerable<AssignmentViewModel>>(
                _assignmentService.GetAssignmentsForRole(roleId)));
        }
        
        [HttpGet("GetDutiesInEvent/{userId}/{eventId}")]
        public ActionResult<IEnumerable<AssignmentViewModel>> GetDutiesInEvent([FromRoute] string userId, [FromRoute] string eventId)
        {
            return Ok(_mapper.Map<IEnumerable<AssignmentViewModel>>(
                _assignmentService.GetDutiesForUserInEvent(userId, eventId)));
        }

        [HttpGet("GetAssignmentsInEvent/{userId}/{eventId}")]
        public ActionResult<IEnumerable<AssignmentViewModel>> GetAssignmentsInEvent([FromRoute] string userId, [FromRoute] string eventId)
        {
            return Ok(_mapper.Map<IEnumerable<AssignmentViewModel>>(
                _assignmentService.GetAssignmentsForUserInEvent(userId, eventId)));
        }
    }
}