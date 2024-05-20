using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class EnsureMigration
    {
        public static async Task EnsureMigrationOfContext(this IApplicationBuilder app)
        {
                using var scope = app.ApplicationServices.CreateScope();

                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();

                await context.Database.MigrateAsync();
        }
    }
}