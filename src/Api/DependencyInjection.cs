using Api.Interfaces;
using Api.Services;
using Api.Services.Api.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IAccountManagementService, AccountManagementService>();

            return services;
        }
    }
}