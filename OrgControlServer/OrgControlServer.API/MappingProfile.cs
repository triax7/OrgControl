using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.API.ViewModels.Auth;
using OrgControlServer.API.ViewModels.Events;
using OrgControlServer.API.ViewModels.Roles;
using OrgControlServer.BLL.DTOs.Auth;
using OrgControlServer.BLL.DTOs.Events;
using OrgControlServer.BLL.DTOs.Roles;
using OrgControlServer.DAL.Models;

namespace OrgControlServer.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, RegisterDTO>();
            CreateMap<LoginViewModel, LoginDTO>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<User, UserDTO>();

            CreateMap<EventDTO, EventViewModel>();
            CreateMap<Event, EventDTO>();

            CreateMap<RoleDTO, RoleViewModel>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleCreateViewModel, RoleCreateDTO>();
            CreateMap<RoleCreateDTO, Role>();
        }
    }
}
