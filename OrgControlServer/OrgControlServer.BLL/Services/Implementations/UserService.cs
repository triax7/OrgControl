using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OrgControlServer.BLL.DTOs.Auth;
using OrgControlServer.BLL.Services.Interfaces;
using OrgControlServer.DAL.Repositories;

namespace OrgControlServer.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserDTO> SearchUsers(string searchString, int page = 1, int pageSize = 10)
        {
            var result = _unitOfWork.Users.GetAll(u => u.Name.Contains(searchString)).OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize).Take(pageSize);

            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }
    }
}