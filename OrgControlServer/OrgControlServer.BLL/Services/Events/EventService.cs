using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.BLL.DTOs.Events;
using OrgControlServer.BLL.Exceptions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services.Events
{
    public class EventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public EventDTO CreateEvent(string name, string userId)
        {
            if (_unitOfWork.Events.SingleOrDefault(e => e.Name == name) != null)
                throw new AppException("Event with such name already exists");

            var myEvent = new Event {Name = name, UserId = userId};

            _unitOfWork.Events.Add(myEvent);
            _unitOfWork.Commit();

            return new EventDTO(myEvent.Id, myEvent.Name);
        }

        public void DeleteEvent(string id, string userId)
        {
            if (_unitOfWork.Events.GetById(id) == null || _unitOfWork.Events.GetById(id).User.Id != userId)
                throw new AppException("Event does not belong to you or does not exist", HttpStatusCode.Forbidden);
            
            _unitOfWork.Events.DeleteById(id);
        }

        public IEnumerable<EventDTO> GetEventsFromUser(string userId)
        {
            return _mapper.Map<IEnumerable<EventDTO>>(_unitOfWork.Users.GetById(userId).Events);
        }
    }
}