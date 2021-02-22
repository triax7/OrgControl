using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgControlServer.BLL.DTOs.Roles
{
    public class RoleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public RoleDTO(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
