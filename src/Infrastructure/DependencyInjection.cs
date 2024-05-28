﻿using Api.Interfaces;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using Domain.ValueObjects;
using Infrastructure.Data;
using Infrastructure.EmailServices;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IBlockRepository, BlockRepository>();
            services.AddScoped<IResidenceRepository, ResidenceRepository>();

            services
                      .AddIdentity<ApplicationUser, IdentityRole>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            // .AddApiEndpoints();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("IsAdmin", policy => policy.RequireClaim("role", Roles.Administrator));
                config.AddPolicy("IsAny", policy => policy.RequireClaim("role", Roles.Manager, Roles.Administrator, Roles.Repairman, Roles.User));
                config.AddPolicy("IsUserOrAdmin", policy => policy.RequireClaim("role", "User", Roles.Administrator));
                config.AddPolicy("IsResident", policy => policy.RequireClaim("role", Roles.Resident));
                config.AddPolicy("isRepairMan", policy => policy.RequireClaim("role", Roles.Repairman));
                config.AddPolicy("IsUserOrAdmin", policy => policy.RequireClaim("role", Roles.User));
                // config.AddPolicy("IsUser", policy => policy.RequireClaim("roles", Roles.));
            });

            // services.AddSingleton(TimeProvider.System); services.AddTransient<IIdentityService, IdentityService>();

            // services.AddAuthorization(options => options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

            return services;
        }
    }
}