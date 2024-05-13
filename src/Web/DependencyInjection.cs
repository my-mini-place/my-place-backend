using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;

using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        // services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        // to sie moze przydac badanie
        //services.AddHealthChecks()
        //    .AddDbContextCheck<ApplicationDbContext>();

        // przyda sie przy custom handlerach bledów services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Write your JWT. }.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
             {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },

                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
        });

        // Add JWT

        return services;
    }
}