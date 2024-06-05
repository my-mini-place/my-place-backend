using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class postsfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dcf6ab8-e6e0-4911-8aec-86f3591e414c", "AQAAAAIAAYagAAAAENN6QOK0hXK/fG4yKtPrOmbjZ3m+GCjkX5uMjZcBjjOeEZxh4vRHwmOTpn9e57ejPg==", "5719dfba-b523-4c95-b083-d0fe07799112" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11ebf6be-9741-40cd-a77b-521c04376b63", "AQAAAAIAAYagAAAAED0ZaezvmleJHKGx4GFoqHK+3PdWzM1B83wUOaFygHRHcbKx4ROIp/Dh4kD6+Iuqpg==", "feb13fe6-5bf7-4bd5-9859-d289ed1a27db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae77eb17-5c6e-47a2-a69d-b84f9c5edf4e", "AQAAAAIAAYagAAAAEDHKNoeEVsNYeum2SYvtRmLMYfVDRvOGtS7fp6tAZaC1gPsAgVbr5+UpNj6NN9fEmw==", "9430f015-d642-4dd2-9dd7-056e122acf99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2ea5f8f-baf9-425a-88e2-6a10e4770248", "AQAAAAIAAYagAAAAENE7FIVh6rVoUb8p8oGLHV4LfEJxh21l1L8Vm4bdOS62amC41uxU5/0zg/0tUJNQ5Q==", "c3df9d2e-47a0-46f2-9ec2-d71010332a18" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 5, 4, 30, 27, 916, DateTimeKind.Local).AddTicks(1711), "1f011af9-dfe1-444b-a29b-c6ceb3bffb38", new DateTime(2024, 6, 5, 2, 30, 27, 916, DateTimeKind.Local).AddTicks(1682) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 30, 27, 913, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 30, 27, 911, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 30, 27, 913, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 30, 27, 911, DateTimeKind.Local).AddTicks(1113));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da671bf0-4525-47f7-a9de-affc56b2ad67", "AQAAAAIAAYagAAAAEEBxy8YIMplKDHkg7A0e8mQIlWLT17hve9SV0Arke0K+2LGrd9s7/BFNILI5RLgbsw==", "3f8d434d-a6df-4268-8c32-e12592bf2ad3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b544d82-8cb2-4609-9879-d3f4999eac69", "AQAAAAIAAYagAAAAEKdRnzWADLba+WZKQo/7wWKTgg9FHgJSiv/1c/zcEJdSCq2ONhPdMxIo4y7rc8lVyg==", "dafaab34-2824-46ba-8b86-179deec75766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea086588-943f-49ac-9cfb-c289d3b623d6", "AQAAAAIAAYagAAAAEDOdlNnAEjNG2WKLysiaz9/UhyGvSSKhua/2UsH6jjnJCLz/gN3hzIFlK/+JVrQlVg==", "54423d84-7af1-4768-8538-dadac059ae1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd451f40-d06c-4a2a-a454-5f290a74ca02", "AQAAAAIAAYagAAAAEGB27Oc8KR3PeUCZ3RF+Wrah+zoSYmYp/WX5bySE5rVrFnQ4HjUMfdfjpRZmCuzTFw==", "8e459a6f-4209-4894-ba99-c8f2defb1f99" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 5, 4, 14, 50, 908, DateTimeKind.Local).AddTicks(8081), "76a93b90-e19f-4f8b-bb41-b72e674ef5d8", new DateTime(2024, 6, 5, 2, 14, 50, 908, DateTimeKind.Local).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 905, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 901, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 905, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 900, DateTimeKind.Local).AddTicks(9903));
        }
    }
}
