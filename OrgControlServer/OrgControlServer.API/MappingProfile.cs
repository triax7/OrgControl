using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.API.ViewModels.Auth;
using OrgControlServer.BLL.DTOs.Auth;

namespace OrgControlServer.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, RegisterDTO>();
            CreateMap<LoginViewModel, LoginDTO>();
            CreateMap<UserDTO, UserViewModel>();
        }
    }
}
