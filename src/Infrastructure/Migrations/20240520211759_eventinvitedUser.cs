using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class eventinvitedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "161bcaa4-5edb-477f-a5d6-8179db2a60ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9306f3aa-9684-488a-a05d-f0840fe438cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b95d564d-83d7-478b-880b-868f2713e5a2");

            migrationBuilder.AddColumn<string>(
                name: "Invited",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e822dd0-26ca-49e3-9ab6-e4ee24f41f73", null, "Resident", "RESIDENT" },
                    { "53cc1f82-5fe4-4355-a41e-05b06c429ad6", null, "Repairman", "REPAIRMAN" },
                    { "559fe26a-6b81-462c-a7fd-7a8539975123", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02237237-070d-45bc-9bd9-d915318730ea", "AQAAAAIAAYagAAAAEImCWux23ADm2S4xD4qtfs/BFDiUQE15ygwRfyXlu/Aqh5z67OaVsDjOqtsMLTH4eQ==", "8e44f1f5-bb3a-46b1-a6ce-fe3b359bed6c" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "Invited", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 17, 57, 617, DateTimeKind.Local).AddTicks(8712), "df7d46ff-a134-43ea-8955-5d70e8698250", "8e445865-a24d-4543-a6c6-9443d048cdb9,id2", new DateTime(2024, 5, 20, 23, 17, 57, 617, DateTimeKind.Local).AddTicks(8572) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e822dd0-26ca-49e3-9ab6-e4ee24f41f73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53cc1f82-5fe4-4355-a41e-05b06c429ad6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "559fe26a-6b81-462c-a7fd-7a8539975123");

            migrationBuilder.DropColumn(
                name: "Invited",
                table: "CalendarEvents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "161bcaa4-5edb-477f-a5d6-8179db2a60ee", null, "Repairman", "REPAIRMAN" },
                    { "9306f3aa-9684-488a-a05d-f0840fe438cf", null, "Manager", "MANAGER" },
                    { "b95d564d-83d7-478b-880b-868f2713e5a2", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b5ce61d-5ae6-48a9-b98f-2ba7839747f9", "AQAAAAIAAYagAAAAEALFwS1WxR9heCAO5eT2yZqed9YEgGrbqSGyaKnYybvMHVN3VM8GJw3sZD00FJ3NNA==", "d8d0231f-8be5-4500-97a4-44d35cb6fd44" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 20, 19, 41, 38, 628, DateTimeKind.Local).AddTicks(8398), "3bc062b8-f276-473d-9e7f-a1c7480cf41e", new DateTime(2024, 5, 20, 17, 41, 38, 628, DateTimeKind.Local).AddTicks(8350) });
        }
    }
}
