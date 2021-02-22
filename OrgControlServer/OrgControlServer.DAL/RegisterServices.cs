using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrgControlServer.DAL.Repositories;
using OrgControlServer.DAL.Repositories.Implementations;
using OrgControlServer.DAL.Repositories.Interfaces;

namespace OrgControlServer.DAL
{
    public static class RegisterServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
