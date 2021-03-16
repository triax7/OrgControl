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
using OrgControlServer.BLL.Services.Interfaces;

namespace OrgControlServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public ActionResult<EventViewModel> Create([FromBody] EventCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentUserId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return _mapper.Map<EventViewModel>(_eventService.CreateEvent(model.Name, currentUserId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventViewModel>> GetOwnEvents()
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            return Ok(_mapper.Map<IEnumerable<EventViewModel>>(_eventService.GetEventsFromUser(currentUserId)));
        }

        [HttpDelete("Delete/{eventId}")]
        public ActionResult Delete([FromRoute] string eventId)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
            
            _eventService.DeleteEvent(eventId, currentUserId);

            return Ok();
        }
    }
}
