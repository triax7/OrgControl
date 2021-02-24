using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using OrgControlServer.API.ViewModels.Events;
using OrgControlServer.BLL.DTOs.Events;
using OrgControlServer.BLL.Services;

namespace OrgControlServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly UserAccountsService _userAccountsService;
        private readonly EventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(UserAccountsService userAccountsService, EventService eventService, IMapper mapper)
        {
            _userAccountsService = userAccountsService;
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public ActionResult<EventViewModel> Create([FromBody] EventCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return _mapper.Map<EventViewModel>(_eventService.CreateEvent(model.Name, userId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventViewModel>> GetOwnEvents()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return Ok(_mapper.Map<IEnumerable<EventViewModel>>(_eventService.GetEventsFromUser(userId)));
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete([FromRoute] string id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
            
            _eventService.DeleteEvent(id, userId);

            return Ok();
        }
    }
}
