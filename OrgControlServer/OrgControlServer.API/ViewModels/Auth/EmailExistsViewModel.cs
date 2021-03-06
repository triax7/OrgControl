﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrgControlServer.API.ViewModels.Auth
{
    public class EmailExistsViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}