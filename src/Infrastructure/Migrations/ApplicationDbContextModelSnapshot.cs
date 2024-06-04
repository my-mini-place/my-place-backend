﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Guid = "e2865b47-dabd-4984-ad52-e42e3e875a44",
                            UserId = "6ae40b13-20a8-462c-9364-a455ef2d3908"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BlockId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Floors")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blocks");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            BlockId = "1",
                            Floors = 5,
                            Name = "BRUDNY",
                            PostalCode = "12-345"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("EndWorkTime")
                        .HasColumnType("time");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartWorkTime")
                        .HasColumnType("time");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            EndWorkTime = new TimeSpan(0, 16, 0, 0, 0),
                            Guid = "f84ee215-a41f-4e35-bb5a-e8dee5fc7d83\r\n",
                            StartWorkTime = new TimeSpan(0, 8, 0, 0, 0),
                            UserId = "36df4b07-2984-4182-a57c-de26516670cc"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Repairman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("EndWorkTime")
                        .HasColumnType("time");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartWorkTime")
                        .HasColumnType("time");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Repairman");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            EndWorkTime = new TimeSpan(0, 0, 0, 0, 0),
                            Guid = "21ee064d-3c9b-4fa0-9cf6-7a5387c3c9fc",
                            StartWorkTime = new TimeSpan(0, 0, 0, 0, 0),
                            UserId = "f805f338-2c36-4e94-a574-6021cc0a2431"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Residence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlockId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("ResidenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Residences");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ApartmentNumber = "18",
                            BlockId = "1",
                            BuildingNumber = "1",
                            Floor = 5,
                            ResidenceId = "1",
                            Street = "Kwiatowa"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Resident");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Guid = "a1748a86-481f-4a39-893a-42c5e6ca980b",
                            ResidenceId = "1",
                            UserId = "de40243b-e960-425b-a980-5c6e8e1895dc"
                        });
                });

            modelBuilder.Entity("Domain.Models.CalendarModels+Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventPublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Invited")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("CalendarEvents");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Description = "To jest opis przykładowego wydarzenia",
                            EndTime = new DateTime(2024, 5, 28, 3, 15, 3, 98, DateTimeKind.Local).AddTicks(6571),
                            EventPublicId = "61b68707-a28e-4680-be79-19167ed0bd0d",
                            Month = "May",
                            Name = "Przykładowe wydarzenie",
                            StartTime = new DateTime(2024, 5, 28, 1, 15, 3, 98, DateTimeKind.Local).AddTicks(6515),
                            State = "Created",
                            Type = "Custom",
                            owner = "John Doe"
                        });
                });

            modelBuilder.Entity("Domain.Models.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Usersinfo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedAt = new DateTime(2024, 5, 28, 1, 15, 3, 90, DateTimeKind.Local).AddTicks(212),
                            Email = "Admin123@gmail.com",
                            IsActive = true,
                            Name = "Admin",
                            PhoneNumber = "123456789",
                            Role = "Administrator",
                            Status = 0,
                            Surname = "amin",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "6ae40b13-20a8-462c-9364-a455ef2d3908"
                        },
                        new
                        {
                            Id = -3,
                            CreatedAt = new DateTime(2024, 5, 28, 1, 15, 3, 90, DateTimeKind.Local).AddTicks(490),
                            Email = "RepairMan123@gmail.com",
                            IsActive = true,
                            Name = "RepairMan",
                            PhoneNumber = "123456789",
                            Role = "Repairman",
                            Status = 0,
                            Surname = "Repairowski",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "f805f338-2c36-4e94-a574-6021cc0a2431"
                        },
                        new
                        {
                            Id = -2,
                            CreatedAt = new DateTime(2024, 5, 28, 1, 15, 3, 95, DateTimeKind.Local).AddTicks(1059),
                            Email = "Manager123@gmail.com",
                            IsActive = true,
                            Name = "Menager",
                            PhoneNumber = "123456789",
                            Role = "Manager",
                            Status = 0,
                            Surname = "Menadzerski",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "36df4b07-2984-4182-a57c-de26516670cc"
                        },
                        new
                        {
                            Id = -4,
                            CreatedAt = new DateTime(2024, 5, 28, 1, 15, 3, 95, DateTimeKind.Local).AddTicks(1201),
                            Email = "Resident123@gmail.com",
                            IsActive = true,
                            Name = "Resident",
                            PhoneNumber = "123456789",
                            Role = "Resident",
                            Status = 0,
                            Surname = "Cucolkt",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "de40243b-e960-425b-a980-5c6e8e1895dc"
                        });
                });

            modelBuilder.Entity("Domain.Models.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSurvey")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SurveyClosureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Models.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Infrastructure.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
<<<<<<< HEAD
                            ConcurrencyStamp = "76e761ac-da6a-40f8-b48d-37f938dc0e81",
=======
                            ConcurrencyStamp = "02237237-070d-45bc-9bd9-d915318730ea",
>>>>>>> features/calendarApi
                            Email = "Admin123@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN123@GMAIL.COM",
                            NormalizedUserName = "ADMIN123@GMAIL.COM",
<<<<<<< HEAD
                            PasswordHash = "AQAAAAIAAYagAAAAEFF7DmX3Y4qhq8O8sQ5zNzitPWWulFPmYGljwrJ4+ann7NHO+7jDlMnN8m4ZmA0LMg==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "0efa18d3-e569-45e6-b19f-0c01353058c7",
=======
                            PasswordHash = "AQAAAAIAAYagAAAAEImCWux23ADm2S4xD4qtfs/BFDiUQE15ygwRfyXlu/Aqh5z67OaVsDjOqtsMLTH4eQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "8e44f1f5-bb3a-46b1-a6ce-fe3b359bed6c",
>>>>>>> features/calendarApi
                            TwoFactorEnabled = false,
                            UserId = "6ae40b13-20a8-462c-9364-a455ef2d3908",
                            UserName = "Admin123@gmail.com"
                        },
                        new
                        {
                            Id = "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "147ed571-cee9-41b7-baf8-7969ccba4caf",
                            Email = "Manager123@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "MANAGER123@GMAIL.COM",
                            NormalizedUserName = "MANAGER123@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEINyvxmlI8ZdNsk33UgYJaw0OyVxv8cJLC0xWxjdvyQ61YpCQ7CiazFqe8yXw7CrnQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "e1d73e90-47bc-4634-846c-68fc371bc14f",
                            TwoFactorEnabled = false,
                            UserId = "36df4b07-2984-4182-a57c-de26516670cc",
                            UserName = "Manager123@gmail.com"
                        },
                        new
                        {
                            Id = "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "62ef3a55-dc73-453a-906b-20362ad01e3e",
                            Email = "Resident123@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "RESIDENT123@GMAIL.COM",
                            NormalizedUserName = "RESIDENT123@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDiM67554EOVp+IpM9dKWfonaQFCMehFxP1OXbHptB0u2/JBirVbQnyLa+cs2OdhFQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "68112cf9-9237-46a0-8ed9-c4381d3dcc2f",
                            TwoFactorEnabled = false,
                            UserId = "de40243b-e960-425b-a980-5c6e8e1895dc",
                            UserName = "Resident123@gmail.com"
                        },
                        new
                        {
                            Id = "84d26d49-da84-46cc-84af-e03f60eddbc1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5e6b76fd-9f0e-48d6-8272-81a4b84b8e6e",
                            Email = "RepairMan123@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "REPAIRMAN123@GMAIL.COM",
                            NormalizedUserName = "REPAIRMAN123@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEK34YN2PoYMcHOiYwsKtOqBntPnmxTbC7J697s1kkd7WZONTVBu0w0lqo6Z/z+655g==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "5e291a0e-b9f6-4d69-ab97-b52a9f597b33",
                            TwoFactorEnabled = false,
                            UserId = "f805f338-2c36-4e94-a574-6021cc0a2431",
                            UserName = "RepairMan123@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
<<<<<<< HEAD
                            Id = "64ac29e2-753c-4a05-9ba4-d4d61bad421f",
=======
                            Id = "559fe26a-6b81-462c-a7fd-7a8539975123",
>>>>>>> features/calendarApi
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
<<<<<<< HEAD
                            Id = "8e4829d4-2a36-4332-b19d-4720c4de64fa",
=======
                            Id = "3e822dd0-26ca-49e3-9ab6-e4ee24f41f73",
>>>>>>> features/calendarApi
                            Name = "Resident",
                            NormalizedName = "RESIDENT"
                        },
                        new
                        {
<<<<<<< HEAD
                            Id = "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4",
=======
                            Id = "53cc1f82-5fe4-4355-a41e-05b06c429ad6",
>>>>>>> features/calendarApi
                            Name = "Repairman",
                            NormalizedName = "REPAIRMAN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                            RoleId = "64ac29e2-753c-4a05-9ba4-d4d61bad421f"
                        },
                        new
                        {
                            UserId = "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                            RoleId = "8e4829d4-2a36-4332-b19d-4720c4de64fa"
                        },
                        new
                        {
                            UserId = "84d26d49-da84-46cc-84af-e03f60eddbc1",
                            RoleId = "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Administrator", b =>
                {
                    b.HasOne("Domain.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Administrator", "UserId")
                        .HasPrincipalKey("Domain.Models.Identity.User", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Manager", b =>
                {
                    b.HasOne("Domain.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Manager", "UserId")
                        .HasPrincipalKey("Domain.Models.Identity.User", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Repairman", b =>
                {
                    b.HasOne("Domain.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Repairman", "UserId")
                        .HasPrincipalKey("Domain.Models.Identity.User", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Residence", b =>
                {
                    b.HasOne("Domain.Entities.Block", "Block")
                        .WithMany()
                        .HasForeignKey("BlockId")
                        .HasPrincipalKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("Domain.Entities.Resident", b =>
                {
                    b.HasOne("Domain.Entities.Residence", "Residence")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Resident", "ResidenceId")
                        .HasPrincipalKey("Domain.Entities.Residence", "ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Resident", "UserId")
                        .HasPrincipalKey("Domain.Models.Identity.User", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Option", b =>
                {
                    b.HasOne("Domain.Models.Post", null)
                        .WithMany("Options")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Vote", b =>
                {
                    b.HasOne("Domain.Models.Option", null)
                        .WithMany("Votes")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Option", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
