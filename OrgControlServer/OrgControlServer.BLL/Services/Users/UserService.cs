using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OrgControlServer.BLL.DTOs.Auth;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services.Users
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserDTO> SearchUsers(string searchString, int page, int pageSize = 20)
        {
            var result = _unitOfWork.Users.GetAll(u => u.Name.Contains(searchString))
                .Skip(page * pageSize).Take(pageSize);

            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }
    }
}