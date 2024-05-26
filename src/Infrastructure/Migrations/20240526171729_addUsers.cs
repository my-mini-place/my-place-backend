using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f60fbde0-537d-4be5-af8d-a0cd9d91de8e", "AQAAAAIAAYagAAAAEB/OHeBjg4BdyNcoz2pRbvHOQYaCRsHuXJrT/l5amxVITrpPy/eCrZjWAOW6bX/eYw==", "f088d3c1-690f-4cdf-9fc5-e92d0a5e8b28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14238e66-5657-4f48-8298-85ffc37bb31e", "AQAAAAIAAYagAAAAELrnmQ+E63//3UqBzW0DZ56oy0CSNXlg3Ap2j+1SGL9M9+miu0f+VmJoeju2u9KyTw==", "b59965b4-8bcd-4852-a817-195b1422eb7d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[,]
                {
                    { "60f8840c-4d51-45df-9abe-1ba4d20fbcdf", 0, "78fbe803-ddaf-490a-8c43-1e7c2d4063dd", "Resident123@gmail.com", true, true, null, null, "RESIDENT123@GMAIL.COM", "RESIDENT123@GMAIL.COM", "AQAAAAIAAYagAAAAENoJLcmPvz+yHpbeESHkxO8U/LwpXhrcRsbJ8odiFtEXyrPmdLGNphmgVNMIC0GDrg==", null, true, "b181a010-2432-4a06-bb87-fafc9e9f73a9", false, new Guid("00000000-0000-0000-0000-000000000000"), "Resident123@gmail.com" },
                    { "84d26d49-da84-46cc-84af-e03f60eddbc1", 0, "cc72fe3f-e6a1-4ae1-9eed-22778c0f7397", "RepairMan123@gmail.com", true, true, null, null, "REPAIRMAN123@GMAIL.COM", "REPAIRMAN123@GMAIL.COM", "AQAAAAIAAYagAAAAEAf/9P1oR13jm9leMKIJiSMnfhzizLyvE6iexl4Mo1OuspuYMyi3Txcq/eb6duvzUA==", null, true, "6c987979-dd4d-470e-a4e2-ca89e6cf0f5c", false, new Guid("00000000-0000-0000-0000-000000000000"), "RepairMan123@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 17, 29, 132, DateTimeKind.Local).AddTicks(3610), "58ee7c3c-038f-4638-8f9c-45a36c742294", new DateTime(2024, 5, 26, 19, 17, 29, 132, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8e4829d4-2a36-4332-b19d-4720c4de64fa", "60f8840c-4d51-45df-9abe-1ba4d20fbcdf" },
                    { "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4", "84d26d49-da84-46cc-84af-e03f60eddbc1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e4829d4-2a36-4332-b19d-4720c4de64fa", "60f8840c-4d51-45df-9abe-1ba4d20fbcdf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4", "84d26d49-da84-46cc-84af-e03f60eddbc1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d583be6-a5ad-4891-8c79-e38ff56a62d9", "AQAAAAIAAYagAAAAEAZlO3xH1cmtadZgzTn6BsUe34FL5dqgaXixT3ZLgpBn1LnT6J600gpEMxCguuysOQ==", "76ac9fab-16fa-4f5c-9774-ba4fec4ded7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eeb3908-f5fe-4210-857c-294511ce0445", "AQAAAAIAAYagAAAAEIN3d1nHftvLxKCXa3aXuKRNSRZXkLbC5u38Ra1I1O55XQ5G1hvswqkpV5VVh7R5/w==", "1e1ca20e-f25d-4343-9ba0-8747fe5f068c" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 26, 21, 6, 58, 449, DateTimeKind.Local).AddTicks(5136), "727e381c-90f3-4030-aaad-1bd72d179cf8", new DateTime(2024, 5, 26, 19, 6, 58, 449, DateTimeKind.Local).AddTicks(5073) });
        }
    }
}
