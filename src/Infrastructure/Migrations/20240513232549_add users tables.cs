using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adduserstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInfo",
                table: "UsersInfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40820103-c6af-4be7-aee9-8af11f557b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73727b13-7c97-4b4d-9ea7-5dafb2138cab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d85f1a5-5c6f-4b4f-a61e-813668090b8c");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "UsersInfo");

            migrationBuilder.RenameTable(
                name: "UsersInfo",
                newName: "userinfo");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "userinfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userinfo",
                table: "userinfo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartWorkTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndWorkTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "residences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_residences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_residences_blocks_BlockId1",
                        column: x => x.BlockId1,
                        principalTable: "blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    ResidenceId1 = table.Column<int>(type: "int", nullable: false),
                    ResidenceId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resident_residences_ResidenceId1",
                        column: x => x.ResidenceId1,
                        principalTable: "residences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resident_userinfo_UserId1",
                        column: x => x.UserId1,
                        principalTable: "userinfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11f6f668-ee3c-41cd-99e2-b4c8be5d5020", null, "Manager", "MANAGER" },
                    { "b167f9b2-050f-40f2-8606-f9b62b5d8dd6", null, "Resident", "RESIDENT" },
                    { "cb2ef90c-343d-412e-967a-2618e92cefc4", null, "Repairman", "REPAIRMAN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "730a5be5-ba2d-4eb2-868f-816855a3ef4e", "AQAAAAIAAYagAAAAEBULHiGu04qe2ZgBNwB+jyfMVMnkPeEPodR7ccMwlu0aqO3BS4Xb9lE6raPmkhGHPg==", "c35cbeaa-9d38-44cc-969b-e56e1cb3a9ef" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 14, 3, 25, 48, 689, DateTimeKind.Local).AddTicks(2867), "f4e0ea05-f25c-4e85-b0df-fe93a3e74058", new DateTime(2024, 5, 14, 1, 25, 48, 689, DateTimeKind.Local).AddTicks(2783) });

            migrationBuilder.CreateIndex(
                name: "IX_residences_BlockId1",
                table: "residences",
                column: "BlockId1");

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ResidenceId1",
                table: "Resident",
                column: "ResidenceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Resident_UserId1",
                table: "Resident",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "managers");

            migrationBuilder.DropTable(
                name: "Resident");

            migrationBuilder.DropTable(
                name: "residences");

            migrationBuilder.DropTable(
                name: "blocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userinfo",
                table: "userinfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11f6f668-ee3c-41cd-99e2-b4c8be5d5020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b167f9b2-050f-40f2-8606-f9b62b5d8dd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2ef90c-343d-412e-967a-2618e92cefc4");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "userinfo");

            migrationBuilder.RenameTable(
                name: "userinfo",
                newName: "UsersInfo");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuildingNumber",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "UsersInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInfo",
                table: "UsersInfo",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40820103-c6af-4be7-aee9-8af11f557b14", null, "Manager", "MANAGER" },
                    { "73727b13-7c97-4b4d-9ea7-5dafb2138cab", null, "Repairman", "REPAIRMAN" },
                    { "7d85f1a5-5c6f-4b4f-a61e-813668090b8c", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "561657d3-13fc-4d4b-9154-60fe92b2e2d4", "AQAAAAIAAYagAAAAEG685WZ1bpRQQCHjsSweXPJCh++p2FcUCS/tslrb3SwUNda0A5eBiO4YSwtt+y1RAw==", "8a0e0a54-6b7f-4b37-a9b1-27d883d01f01" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 2, 19, 6, 50, 464, DateTimeKind.Local).AddTicks(4731), "02fca8fa-b3f4-425b-a08a-669f9b94713f", new DateTime(2024, 5, 2, 17, 6, 50, 464, DateTimeKind.Local).AddTicks(4683) });
        }
    }
}
