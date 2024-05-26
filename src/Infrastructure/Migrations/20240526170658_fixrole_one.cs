using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixrole_one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b7f293a-adf1-456c-85eb-83ec89c4d43c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13326ef7-1cf5-4332-94cc-6c89c91a59f6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9f5f518-c349-49c8-bdec-a25d24b89d9b", "ff248134-06c8-4f19-b904-56a88d0392d1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9f5f518-c349-49c8-bdec-a25d24b89d9b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff248134-06c8-4f19-b904-56a88d0392d1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64ac29e2-753c-4a05-9ba4-d4d61bad421f", null, "Manager", "MANAGER" },
                    { "8e4829d4-2a36-4332-b19d-4720c4de64fa", null, "Resident", "RESIDENT" },
                    { "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4", null, "Repairman", "REPAIRMAN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d583be6-a5ad-4891-8c79-e38ff56a62d9", "AQAAAAIAAYagAAAAEAZlO3xH1cmtadZgzTn6BsUe34FL5dqgaXixT3ZLgpBn1LnT6J600gpEMxCguuysOQ==", "76ac9fab-16fa-4f5c-9774-ba4fec4ded7b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "921f97ca-b7e2-4b88-8917-d4f2ff820a70", 0, "4eeb3908-f5fe-4210-857c-294511ce0445", "Manager123@gmail.com", true, true, null, null, "MANAGER123@GMAIL.COM", "MANAGER123@GMAIL.COM", "AQAAAAIAAYagAAAAEIN3d1nHftvLxKCXa3aXuKRNSRZXkLbC5u38Ra1I1O55XQ5G1hvswqkpV5VVh7R5/w==", null, true, "1e1ca20e-f25d-4343-9ba0-8747fe5f068c", false, new Guid("00000000-0000-0000-0000-000000000000"), "Manager123@gmail.com" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 6, 58, 449, DateTimeKind.Local).AddTicks(5136), "727e381c-90f3-4030-aaad-1bd72d179cf8", new DateTime(2024, 5, 26, 19, 6, 58, 449, DateTimeKind.Local).AddTicks(5073) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "64ac29e2-753c-4a05-9ba4-d4d61bad421f", "921f97ca-b7e2-4b88-8917-d4f2ff820a70" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4829d4-2a36-4332-b19d-4720c4de64fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64ac29e2-753c-4a05-9ba4-d4d61bad421f", "921f97ca-b7e2-4b88-8917-d4f2ff820a70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64ac29e2-753c-4a05-9ba4-d4d61bad421f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b7f293a-adf1-456c-85eb-83ec89c4d43c", null, "Resident", "RESIDENT" },
                    { "13326ef7-1cf5-4332-94cc-6c89c91a59f6", null, "Repairman", "REPAIRMAN" },
                    { "c9f5f518-c349-49c8-bdec-a25d24b89d9b", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53f63e36-ad5a-465c-b6ff-cfd5e742318d", "AQAAAAIAAYagAAAAEHgCZgvOeHYPSjKozy43vIq4tNHzowADUBrwMckXxBzYB1/vVYHQCo4eWkVpCxmWaQ==", "b059829e-a046-48bb-bbd8-8721d9bcfe3b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "ff248134-06c8-4f19-b904-56a88d0392d1", 0, "97411c94-9c28-4fbc-b0b1-dcf9012878f1", "Manager123@gmail.com", true, true, null, null, "MANAGER123@GMAIL.COM", "MANAGER123@GMAIL.COM", "AQAAAAIAAYagAAAAEF9EU/ck5tz2hROysVUBfC23bOO72L1D/QVSaFYE90ezR48KVlhyrFpHw70K0MVS1w==", null, true, "58c34e91-d280-4626-a547-4429e010c5d4", false, new Guid("00000000-0000-0000-0000-000000000000"), "Manager123@gmail.com" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 26, 20, 51, 28, 384, DateTimeKind.Local).AddTicks(3190), "73c66c72-2fab-4a1e-9e2d-f11deb92357d", new DateTime(2024, 5, 26, 18, 51, 28, 384, DateTimeKind.Local).AddTicks(3121) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9f5f518-c349-49c8-bdec-a25d24b89d9b", "ff248134-06c8-4f19-b904-56a88d0392d1" });
        }
    }
}
