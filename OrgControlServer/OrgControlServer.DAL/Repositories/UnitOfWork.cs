using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IUserRepository Users { get; }
        public IRefreshTokenRepository RefreshTokens { get; }
        public IEventRepository Events { get; }
        public IRoleRepository Roles { get; }
        public IAssignmentRepository Assignments { get; }
        public IZoneRepository Zones { get; }

        public UnitOfWork(ApplicationContext context, IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository, IEventRepository eventRepository, IRoleRepository roleRepository,
            IAssignmentRepository assignmentRepository, IZoneRepository zoneRepository)
        {
            _context = context;
            Users = userRepository;
            RefreshTokens = refreshTokenRepository;
            Events = eventRepository;
            Roles = roleRepository;
            Assignments = assignmentRepository;
            Zones = zoneRepository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}