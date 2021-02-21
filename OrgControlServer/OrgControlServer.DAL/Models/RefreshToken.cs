using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;

namespace OrgControlServer.DAL.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
