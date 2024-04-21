using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;

using Infrastructure.Data;
using Infrastructure.Repositories;
using Domain;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DockerConnection");
            // var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IRepository<WeatherForecast>, Repository<WeatherForecast>>();
            //#if (UseApiOnly)
            //        services.AddAuthentication()
            //            .AddBearerToken(IdentityConstants.BearerScheme);

            // services.AddAuthorizationBuilder();

            //        services
            //            .AddIdentityCore<ApplicationUser>()
            //            .AddRoles<IdentityRole>()
            //            .AddEntityFrameworkStores<ApplicationDbContext>()
            //            .AddApiEndpoints();
            //#else
            //            services
            //                .AddDefaultIdentity<ApplicationUser>()
            //                .AddRoles<IdentityRole>()
            //                .AddEntityFrameworkStores<ApplicationDbContext>();
            //#endif

            // services.AddSingleton(TimeProvider.System); services.AddTransient<IIdentityService, IdentityService>();

            // services.AddAuthorization(options => options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

            return services;
        }
    }
}