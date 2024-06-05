using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class examplemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
