using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrgControlServer.BLL.Services;
using OrgControlServer.BLL.Services.Implementations;
using OrgControlServer.BLL.Services.Interfaces;

namespace OrgControlServer.BLL
{
    public static class RegisterServices
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddTransient<IUserAccountsService, UserAccountsService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAssignmentService, AssignmentService>();

            return services;
        }
    }
}
