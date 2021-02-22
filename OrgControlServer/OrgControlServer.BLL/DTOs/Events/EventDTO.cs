using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgControlServer.BLL.DTOs.Events
{
    public class EventDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public EventDTO(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
