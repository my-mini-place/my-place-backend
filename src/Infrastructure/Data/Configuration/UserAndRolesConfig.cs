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

            string ManagerRoleGuid = "64ac29e2-753c-4a05-9ba4-d4d61bad421f";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    
                    Id = ManagerRoleGuid,
                    Name = Roles.Manager,
                    NormalizedName = Roles.Manager.ToUpper()
                }
                );

            string ResidentRoleGuid = "8e4829d4-2a36-4332-b19d-4720c4de64fa";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = ResidentRoleGuid.ToString(),
                    Name = Roles.Resident,
                    NormalizedName = Roles.Resident.ToUpper()
                }
                );

            string RepairManRoleGuid = "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = RepairManRoleGuid.ToString(),
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
                   PasswordHash = hasher.HashPassword(null!, "Admin123"),
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
            string ManagerId = "921f97ca-b7e2-4b88-8917-d4f2ff820a70";

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser()
               {
                   Id = ManagerId,
                   UserName = "Manager123@gmail.com",
                   Email = "Manager123@gmail.com",
                   NormalizedUserName = "Manager123@gmail.com".ToUpper(),
                   NormalizedEmail = "Manager123@gmail.com".ToUpper(),
                   PasswordHash = hasher.HashPassword(null!, "Manager123"),
                   EmailConfirmed = true,
                   LockoutEnabled = true,
                   PhoneNumberConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString()
               }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ManagerRoleGuid,
                    UserId = ManagerId

                }
                );
            string ResidentId = "60f8840c-4d51-45df-9abe-1ba4d20fbcdf";

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser()
               {
                   Id = ResidentId,
                   UserName = "Resident123@gmail.com",
                   Email = "Resident123@gmail.com",
                   NormalizedUserName = "Resident123@gmail.com".ToUpper(),
                   NormalizedEmail = "Resident123@gmail.com".ToUpper(),
                   PasswordHash = hasher.HashPassword(null!, "Resident123"),
                   EmailConfirmed = true,
                   LockoutEnabled = true,
                   PhoneNumberConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString()
               }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ResidentRoleGuid,
                    UserId = ResidentId,

                }
                );

            string RepairManId = "84d26d49-da84-46cc-84af-e03f60eddbc1";

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser()
               {
                   Id = RepairManId,
                   UserName = "RepairMan123@gmail.com",
                   Email = "RepairMan123@gmail.com",
                   NormalizedUserName = "RepairMan123@gmail.com".ToUpper(),
                   NormalizedEmail = "RepairMan123@gmail.com".ToUpper(),
                   PasswordHash = hasher.HashPassword(null!, "RepairMan123"),
                   EmailConfirmed = true,
                   LockoutEnabled = true,
                   PhoneNumberConfirmed = true,
                   SecurityStamp = Guid.NewGuid().ToString()
               }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = RepairManRoleGuid,
                    UserId = RepairManId

                }
                );




        }
    }
}