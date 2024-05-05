using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Repositories;

using Infrastructure.Identity;
using Api.Interfaces;
using Api.Services;
using Infrastructure.EmailServices;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using static Domain.Models.Calendar.CalendarModels;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DockerConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();


            services
                      .AddIdentity<ApplicationUser, IdentityRole>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>();
                       // .AddApiEndpoints();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        ValidIssuer = configuration["Jwt:Issuer"],
            //        ValidAudience = configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            //    };
            //});

            // services.AddSingleton(TimeProvider.System); services.AddTransient<IIdentityService, IdentityService>();

            // services.AddAuthorization(options => options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

            return services;
        }
    }
}