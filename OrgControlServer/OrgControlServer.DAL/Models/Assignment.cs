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
        public virtual AssignmentStatus Status { get; set; }
        public virtual ICollection<Role> AllowedRoles { get; set; }
        public virtual Event Event { get; set; }
    }

    public enum AssignmentStatus
    {
        NotStarted,
        InProgress,
        Done
    }
}
