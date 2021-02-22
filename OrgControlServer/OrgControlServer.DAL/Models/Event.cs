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
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
