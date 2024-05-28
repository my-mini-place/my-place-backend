using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Usersinfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62ef3a55-dc73-453a-906b-20362ad01e3e", "AQAAAAIAAYagAAAAEDiM67554EOVp+IpM9dKWfonaQFCMehFxP1OXbHptB0u2/JBirVbQnyLa+cs2OdhFQ==", "68112cf9-9237-46a0-8ed9-c4381d3dcc2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e6b76fd-9f0e-48d6-8272-81a4b84b8e6e", "AQAAAAIAAYagAAAAEK34YN2PoYMcHOiYwsKtOqBntPnmxTbC7J697s1kkd7WZONTVBu0w0lqo6Z/z+655g==", "5e291a0e-b9f6-4d69-ab97-b52a9f597b33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76e761ac-da6a-40f8-b48d-37f938dc0e81", "AQAAAAIAAYagAAAAEFF7DmX3Y4qhq8O8sQ5zNzitPWWulFPmYGljwrJ4+ann7NHO+7jDlMnN8m4ZmA0LMg==", "0efa18d3-e569-45e6-b19f-0c01353058c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "147ed571-cee9-41b7-baf8-7969ccba4caf", "AQAAAAIAAYagAAAAEINyvxmlI8ZdNsk33UgYJaw0OyVxv8cJLC0xWxjdvyQ61YpCQ7CiazFqe8yXw7CrnQ==", "e1d73e90-47bc-4634-846c-68fc371bc14f" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 28, 3, 15, 3, 98, DateTimeKind.Local).AddTicks(6571), "61b68707-a28e-4680-be79-19167ed0bd0d", new DateTime(2024, 5, 28, 1, 15, 3, 98, DateTimeKind.Local).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedAt", "Role" },
                values: new object[] { new DateTime(2024, 5, 28, 1, 15, 3, 95, DateTimeKind.Local).AddTicks(1201), "Resident" });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedAt", "Role" },
                values: new object[] { new DateTime(2024, 5, 28, 1, 15, 3, 90, DateTimeKind.Local).AddTicks(490), "Repairman" });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedAt", "Role" },
                values: new object[] { new DateTime(2024, 5, 28, 1, 15, 3, 95, DateTimeKind.Local).AddTicks(1059), "Manager" });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "Role" },
                values: new object[] { new DateTime(2024, 5, 28, 1, 15, 3, 90, DateTimeKind.Local).AddTicks(212), "Administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usersinfo");

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
        }
    }
}
