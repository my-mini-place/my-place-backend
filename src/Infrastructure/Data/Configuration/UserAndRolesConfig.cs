using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;

namespace Infrastructure.Data.Configuration
{
    public static class AddRoleToAdmin
    {
        public static void ConfigurationUserAndRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                }
                );

            Guid ManagerGuid = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = ManagerGuid.ToString(),
                    Name = Roles.Manager,
                    NormalizedName = Roles.Manager.ToUpper()
                }
                );

            Guid ResidentGuid = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = ResidentGuid.ToString(),
                    Name = Roles.Resident,
                    NormalizedName = Roles.Resident.ToUpper()
                }
                );

            Guid RepairManGuid = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = RepairManGuid.ToString(),
                    Name = Roles.Repairman,
                    NormalizedName = Roles.Repairman.ToUpper()
                }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser()
               {
                   Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                   UserName = "Admin123@gmail.com",
                   Email = "Admin123@gmail.com",
                   NormalizedUserName = "Admin123@gmail.com".ToUpper(),
                   NormalizedEmail = "Admin123@gmail.com".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin123"),
                   EmailConfirmed = true,
                   LockoutEnabled = true,
                   PhoneNumberConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString()
               }
                );

            // zaleznosc między rolami i kontem admina
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
                );
        }
    }
}