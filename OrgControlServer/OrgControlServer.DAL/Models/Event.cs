using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgControlServer.DAL.Abstractions;

namespace OrgControlServer.DAL.Models
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Zone> Zones { get; set; }
    }
}
