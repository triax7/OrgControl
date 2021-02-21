using System;
using System.Collections.Generic;
using System.Text;
using OrgControlServer.DAL.Abstractions;
using OrgControlServer.DAL.Models;
using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL.Repositories.Implementations
{
    class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
