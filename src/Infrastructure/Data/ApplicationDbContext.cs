using Domain;
using Domain.Entities;
using Domain.Models.Identity;
using Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.CalendarModels;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Usersinfo { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<Residence> Residences { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Event> CalendarEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurationUserAndRole();
            builder.AddTestCalendarData();
            // It is possible to apply all configuration specified in types implementing
            // IEntityTypeConfiguration in a given assembly.
            //The order in which the configurations will be applied is undefined, therefore this method should only be used when the order doesn't matter.
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}