using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.API.ViewModels.Assignments;
using OrgControlServer.BLL.DTOs.Assignments;
using OrgControlServer.BLL.Services;

namespace OrgControlServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AssignmentService _assignmentService;

        public AssignmentsController(IMapper mapper, AssignmentService assignmentService)
        {
            _mapper = mapper;
            _assignmentService = assignmentService;
        }

        [HttpPost("Create")]
        public ActionResult<AssignmentViewModel> CreateAssignment([FromBody] AssignmentCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return _mapper.Map<AssignmentViewModel>(
                _assignmentService.CreateAssignment(_mapper.Map<AssignmentCreateDTO>(model), userId));
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
    }
}