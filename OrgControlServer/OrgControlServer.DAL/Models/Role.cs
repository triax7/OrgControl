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
        public bool CanCreateRoles { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Assignment> AllowedAssignments { get; set; }
        public ICollection<Zone> AllowedZones { get; set; }
        public Event Event { get; set; }
    }
}
