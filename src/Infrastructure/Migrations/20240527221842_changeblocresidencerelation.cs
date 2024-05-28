using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeblocresidencerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Residences_BlockId",
                table: "Residences");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c62ebc8-c7a8-4657-9791-6b7b5af1fc34", "AQAAAAIAAYagAAAAEOOhJlcNPEnNsdRCyhHoUzq3S253cehpMwa6rwAtl6XWZA2fJkmZlVDAtlWOWWGiFw==", "73acc456-9bbb-44bb-8421-764cd141adae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "639b8998-04e0-42a3-abc7-53f71714ecd7", "AQAAAAIAAYagAAAAEMECTPXdE1lQdRv6cIXOn/Gt4rf4vo044vjPy90siQKioXRkAG008/bUPMsiOo2/AQ==", "75c504e6-d42f-4128-8f14-7c30009c3310" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09f6ec4-96c0-4c58-9a39-c2d99b6fbcc5", "AQAAAAIAAYagAAAAECm0BTAw+tr39ihS1e+hbweAkgiquCfj7ODmltZ+g4uytcJ9rDlIw5f8lZ1R/u0Veg==", "bfb1085f-753f-4507-948e-f61831a6d18c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1abeee29-666b-4a87-8600-c0fe08631f3a", "AQAAAAIAAYagAAAAENfhellPdZac0VT/QT3bg371/g0HM2evhQPUuHZS30rX7q0IQy6mR9N/HDxNUU2OXg==", "0c11e906-06c5-4d09-a389-f127fe323bc9" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 28, 2, 18, 42, 373, DateTimeKind.Local).AddTicks(9030), "61c1615f-9617-416b-b32b-9e488fa140d7", new DateTime(2024, 5, 28, 0, 18, 42, 373, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 0, 18, 42, 371, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 0, 18, 42, 367, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 0, 18, 42, 371, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 0, 18, 42, 367, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.CreateIndex(
                name: "IX_Residences_BlockId",
                table: "Residences",
                column: "BlockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Residences_BlockId",
                table: "Residences");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "612a552a-84b7-483c-852b-9c9f6c4b2ba0", "AQAAAAIAAYagAAAAEC15YyU7VYp186cR1mJaLtLEAqY7ugNRz4/EVlmeheeFF1hT2j4cORKl8nrFVUJKgg==", "157d878c-9d7d-4c23-a2c9-adae075aab41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "811c315b-cb75-4ba9-a10d-f903ec1e4a94", "AQAAAAIAAYagAAAAEMGj5SLKmcNAqiaZy95rPwg0t8OtgzwgP28JsE1O3KcAeaQAxyrmiPp2kiByNF6GHw==", "af020fcc-f821-4055-a4ed-7d4a4d5b4b14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a8e8a99-719f-48f7-9ce7-aca0c961e806", "AQAAAAIAAYagAAAAEF+Ccs17KGk2zUi3L46hTo6Txdp/a96hiTPTs9t51ZzNd6Gx1OQokFb5ZRt7g7xlKw==", "7988ed2c-16b4-4967-876a-a46d3b553b2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e63e13d2-9ed9-40da-a6d3-beaecbc9b126", "AQAAAAIAAYagAAAAEHLtC85TCcxx6Fk8bbBsJjvIEQNGftkxjspXAOd43Pz0HWmp6C/K+/+V38yY7RCUdQ==", "2cd6af47-1296-48ed-b819-4b9817711fdd" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 28, 0, 51, 37, 618, DateTimeKind.Local).AddTicks(3340), "214921ca-e1b0-4e75-a83c-e40c01ac4934", new DateTime(2024, 5, 27, 22, 51, 37, 618, DateTimeKind.Local).AddTicks(3276) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 22, 51, 37, 609, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 22, 51, 37, 605, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 22, 51, 37, 609, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 22, 51, 37, 605, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.CreateIndex(
                name: "IX_Residences_BlockId",
                table: "Residences",
                column: "BlockId",
                unique: true);
        }
    }
}
