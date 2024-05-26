using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class user_info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58653e52-8c28-4041-bb40-5c3fb134e865");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e2ae89-985c-4635-99f8-bc1daf6c72a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c93e3ab0-495c-4f39-8082-86ec7287fcd3");

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Usersinfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Usersinfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58653e52-8c28-4041-bb40-5c3fb134e865", null, "Repairman", "REPAIRMAN" },
                    { "73e2ae89-985c-4635-99f8-bc1daf6c72a6", null, "Resident", "RESIDENT" },
                    { "c93e3ab0-495c-4f39-8082-86ec7287fcd3", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d5e6dc4-a6c1-4681-ac63-ef0ef90a10d8", "AQAAAAIAAYagAAAAEHO/6g0b3IW2L/gkv6HXBDL1jftWfgkzDNfYc0PFHz8sxc2Y+O12O1LxrV/76RvQ0A==", "baf07c77-d46f-4c06-b9f9-d7d549907fd4" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 20, 20, 27, 46, 303, DateTimeKind.Local).AddTicks(8780), "81219c56-6a31-46a6-a2ab-ba8eccacc8c9", new DateTime(2024, 5, 20, 18, 27, 46, 303, DateTimeKind.Local).AddTicks(8730) });
        }
    }
}
