using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletenickname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39847c19-091c-4726-ae98-9521db53261c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c42fcc2b-8300-483f-a522-b65b65b34d84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fef06791-e89c-45f1-a2dd-94f3b92fbd42");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Usersinfo");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0604be80-a8b8-4488-94a1-4d09d4e48548", null, "Repairman", "REPAIRMAN" },
                    { "1c3e255a-c333-4b15-b899-e134c03db16c", null, "Resident", "RESIDENT" },
                    { "206bf01e-bc92-4649-b090-5e6c6e7531fc", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b672f3d-585b-4269-999d-8e147d8e9533", "AQAAAAIAAYagAAAAEKeXoQbV/7bysLRKcLf3D6pytrSlRVhWoGJZxzP626/fSYQ2xjq26t7CjGnZvKqrNw==", "e6dcd45f-5fcc-49ee-8c4c-d885eec908d6" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 24, 22, 39, 50, 539, DateTimeKind.Local).AddTicks(1228), "8da19701-71d7-4a52-a821-7789be8f6285", new DateTime(2024, 5, 24, 20, 39, 50, 539, DateTimeKind.Local).AddTicks(1164) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0604be80-a8b8-4488-94a1-4d09d4e48548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3e255a-c333-4b15-b899-e134c03db16c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "206bf01e-bc92-4649-b090-5e6c6e7531fc");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Usersinfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39847c19-091c-4726-ae98-9521db53261c", null, "Repairman", "REPAIRMAN" },
                    { "c42fcc2b-8300-483f-a522-b65b65b34d84", null, "Resident", "RESIDENT" },
                    { "fef06791-e89c-45f1-a2dd-94f3b92fbd42", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b688dd83-147e-4ba2-b7ad-11e942ac41bc", "AQAAAAIAAYagAAAAEMZQfUqoIZx1Sx+IlSIOETyy+2IS0e3ZAAO5eAXZYJlkb+WBcnnE5J7H3286fE/+NQ==", "14709905-5b29-403f-bc50-b01ae7d1f1c3" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 24, 22, 32, 8, 121, DateTimeKind.Local).AddTicks(4255), "6d7018e0-2656-4a19-91f4-4a55012a2962", new DateTime(2024, 5, 24, 20, 32, 8, 121, DateTimeKind.Local).AddTicks(4195) });
        }
    }
}
