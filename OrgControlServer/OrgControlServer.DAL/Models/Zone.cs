using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;

namespace OrgControlServer.DAL.Models
{
    public class Zone : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Role> AllowedRoles { get; set; }
        public virtual Event Event { get; set; }
    }
}
