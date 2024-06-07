using Domain.Entities;
using Domain.Models;
using Domain.Models.Identity;
using Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Domain.Models.Calendar.CalendarModels;
using static Domain.Models.Document.DocumentModels;


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
        public DbSet<Document> Documents { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurationUserAndRole();
            builder.AddTestCalendarData();
            builder.addTestDocumentData();

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