using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;
using Domain.Models.Identity;
using Domain.Entities;

namespace Infrastructure.Data.Configuration
{
    public static class AddRoleToAdmin
    {
        public static void ConfigurationUserAndRole(this ModelBuilder modelBuilder)
        {

            #region IdentityRole
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

            #endregion


            #region UsersIdentity
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser()
               {
                   Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                   UserId = "6ae40b13-20a8-462c-9364-a455ef2d3908",
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
                   UserId = "36df4b07-2984-4182-a57c-de26516670cc",
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
                   UserId = "de40243b-e960-425b-a980-5c6e8e1895dc",
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
                   UserId = "f805f338-2c36-4e94-a574-6021cc0a2431",
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

            #endregion


            #region UsersInfos
            modelBuilder.Entity<User>().HasData(
                               new User()
                               {
                                   Role = Roles.Administrator,
                                   Id = -1,
                                   UserId = "6ae40b13-20a8-462c-9364-a455ef2d3908",
                                   CreatedAt = System.DateTime.Now,
                                   Email = "Admin123@gmail.com",
                                   IsActive = true,
                                   PhoneNumber = "123456789",
                                   Name = "Admin",
                                   Surname = "amin",
                                   Status = AccountStatus.Active,




                               }
                                  ); ;

            modelBuilder.Entity<Administrator>().HasData(new Administrator()
            {
                Id = -1,
                UserId = "6ae40b13-20a8-462c-9364-a455ef2d3908",
                Guid = "e2865b47-dabd-4984-ad52-e42e3e875a44",
            });
            modelBuilder.Entity<User>().HasData(
                               new User()
                               {
                                   Role = Roles.Repairman,
                                   Id = -3,
                                   UserId = "f805f338-2c36-4e94-a574-6021cc0a2431",
                                   CreatedAt = System.DateTime.Now,
                                   Email = "RepairMan123@gmail.com",
                                   IsActive = true,
                                   PhoneNumber = "123456789",
                                   Name = "RepairMan",
                                   Surname = "Repairowski",
                                   Status = AccountStatus.Active,




                               }
                                  ); ;

            modelBuilder.Entity<Repairman>().HasData(new Repairman()
            {
                Id = -1,
                UserId = "f805f338-2c36-4e94-a574-6021cc0a2431",
                Guid = "21ee064d-3c9b-4fa0-9cf6-7a5387c3c9fc",
            });


            modelBuilder.Entity<User>().HasData(
                              new User()
                              {
                                  Role= Roles.Manager,
                                  Id = -2,
                                  UserId = "36df4b07-2984-4182-a57c-de26516670cc",
                                  CreatedAt = System.DateTime.Now,
                                  Email = "Manager123@gmail.com",
                                  IsActive = true,
                                  PhoneNumber = "123456789",
                                  Name = "Menager",
                                  Surname = "Menadzerski",
                                  Status = AccountStatus.Active,




                              }
                                 ); ;

            modelBuilder.Entity<Manager>().HasData(new Manager()
            {
                EndWorkTime = new System.TimeSpan(16, 0, 0),
                StartWorkTime = new System.TimeSpan(8, 0, 0),
                
                Id = -1,
                UserId = "36df4b07-2984-4182-a57c-de26516670cc",
                Guid = "f84ee215-a41f-4e35-bb5a-e8dee5fc7d83\r\n",
               
            });


            modelBuilder.Entity<User>().HasData(
                              new User()
                              {
                                  Role = Roles.Resident,
                                  Id = -4,
                                  UserId = "de40243b-e960-425b-a980-5c6e8e1895dc",
                                  CreatedAt = System.DateTime.Now,
                                  Email = "Resident123@gmail.com",
                                  IsActive = true,
                                  PhoneNumber = "123456789",
                                  Name = "Resident",
                                  Surname = "Cucolkt",
                                  Status = AccountStatus.Active,




                              }
                                 ); ;



            modelBuilder.Entity<Block>().HasData(new Block()
            {
                BlockId = "1",
                Floors = 5,
                Name = "BRUDNY",
                Id = -1,
                PostalCode = "12-345",
            });

            modelBuilder.Entity<Residence>().HasData(new Residence()
            {
                Id = -1,
                Floor = 5,
                
                ApartmentNumber = "18",
                BuildingNumber = "1",
                Street = "Kwiatowa",
                BlockId = "1",
                ResidenceId = "1",

            }); ;


            modelBuilder.Entity<Resident>().HasData(new Resident()
            {
                
                Id = -1,
                UserId = "de40243b-e960-425b-a980-5c6e8e1895dc",
                Guid = "a1748a86-481f-4a39-893a-42c5e6ca980b",
               ResidenceId="1"
          

            });
            #endregion


        }
    }
}