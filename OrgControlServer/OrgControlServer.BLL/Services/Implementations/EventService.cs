using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using OrgControlServer.BLL.DTOs.Events;
using OrgControlServer.BLL.Exceptions;
using OrgControlServer.BLL.Services.Interfaces;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public EventDTO CreateEvent(string name, string currentUserId)
        {
            if (_unitOfWork.Events.SingleOrDefault(e => e.Name == name) != null)
                throw new AppException("Event with such name already exists");

            var myEvent = new Event {Name = name, UserId = currentUserId};

            _unitOfWork.Events.Add(myEvent);
            _unitOfWork.Commit();

            return new EventDTO(myEvent.Id, myEvent.Name);
        }

        public void DeleteEvent(string eventId, string currentUserId)
        {
            var myEvent = _unitOfWork.Events.GetById(eventId);
            
            if (myEvent == null || myEvent.UserId != currentUserId)
                throw new AppException("Event does not belong to you or does not exist", HttpStatusCode.Forbidden);
            
            _unitOfWork.Roles.RemoveRange(_unitOfWork.Roles.GetAll(r => r.EventId == eventId));

            _unitOfWork.Events.Remove(myEvent);
            _unitOfWork.Commit();
        }

        public IEnumerable<EventDTO> GetEventsFromUser(string userId)
        {
            var events = _mapper.Map<List<EventDTO>>(_unitOfWork.Users.GetById(userId).Events);

            foreach (var e in events)
            {
                var assignments = _unitOfWork.Assignments.GetAll(a => a.EventId == e.Id);
                e.AssignmentsNotStarted = assignments.Count(a => a.Status == AssignmentStatus.NotStarted);
                e.AssignmentsInProgress = assignments.Count(a => a.Status == AssignmentStatus.InProgress);
                e.AssignmentsDone = assignments.Count(a => a.Status == AssignmentStatus.Done);
            }

            return events;
        }
    }
}