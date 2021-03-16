using System.Collections.Generic;
using OrgControlServer.BLL.DTOs.Events;

namespace OrgControlServer.BLL.Services.Interfaces
{
    public interface IEventService
    {
        EventDTO CreateEvent(string name, string currentUserId);
        void DeleteEvent(string eventId, string currentUserId);
        IEnumerable<EventDTO> GetEventsFromUser(string userId);
    }
}