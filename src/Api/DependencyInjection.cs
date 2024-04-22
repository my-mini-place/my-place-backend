using Api.Interfaces;
using Api.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ISecurityService, SecurityService>();
            return services;
        }
    }
}