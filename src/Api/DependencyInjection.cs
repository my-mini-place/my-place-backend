using Api.Interfaces;
using Api.Mappers;
using Api.Services;
using Api.Services.Api.Services;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            var assembly = typeof(SecurityService).Assembly;
            services.AddAutoMapper(assembly);

            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IAccountManagementService, AccountManagementService>();
            services.AddScoped<ICalendarService, CalendarService>();

            return services;
        }
    }
}