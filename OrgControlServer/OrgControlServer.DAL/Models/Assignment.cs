using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;

namespace OrgControlServer.DAL.Models
{
    public class Assignment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentStatus Status { get; set; } = AssignmentStatus.NotStarted;
        public virtual ICollection<Role> AllowedRoles { get; set; }
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }

    public enum AssignmentStatus
    {
        NotStarted,
        InProgress,
        Done
    }
}
