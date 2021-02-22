using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrgControlServer.API.ViewModels.Events
{
    public class EventCreateViewModel
    {
        [Required] public string Name { get; set; }
    }
}