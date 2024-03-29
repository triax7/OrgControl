﻿using System.Collections.Generic;
using OrgControlServer.BLL.DTOs.Auth;

namespace OrgControlServer.BLL.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> SearchUsers(string searchString, int page = 1, int pageSize = 10);
    }
}