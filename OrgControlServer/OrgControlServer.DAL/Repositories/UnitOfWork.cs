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

        public UnitOfWork(ApplicationContext context, IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _context = context;
            Users = userRepository;
            RefreshTokens = refreshTokenRepository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
