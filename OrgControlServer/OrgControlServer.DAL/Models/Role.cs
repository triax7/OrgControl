using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;

namespace OrgControlServer.DAL.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public bool CanCreateAssignments { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Assignment> AllowedAssignments { get; set; }
        public virtual ICollection<Zone> AllowedZones { get; set; }
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
