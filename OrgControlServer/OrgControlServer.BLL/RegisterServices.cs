using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OrgControlServer.BLL.Services.Auth;
using OrgControlServer.BLL.Services.Events;
using OrgControlServer.BLL.Services.Roles;

namespace OrgControlServer.BLL
{
    public static class RegisterServices
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddTransient<UserAccountsService>();
            services.AddTransient<TokenService>();
            services.AddTransient<EventService>();
            services.AddTransient<RoleService>();

            return services;
        }
    }
}
