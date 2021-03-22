using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgControlServer.BLL.DTOs.Users;
using OrgControlServer.DAL.Models;

namespace OrgControlServer.BLL.DTOs.Assignments
{
    public class DutyDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PublicUserDTO User { get; set; }
    }
}
