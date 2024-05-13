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

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> userinfo { get; set; }

        public DbSet<Block> blocks { get; set; }

        public DbSet<Residence> residences { get; set; }
        public DbSet<Manager> managers { get; set; }
        public DbSet<Administrator> administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurationUserAndRole();

            builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}