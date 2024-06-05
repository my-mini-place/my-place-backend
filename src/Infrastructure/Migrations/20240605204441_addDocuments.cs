using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signed = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c9bdd4d-9791-4ede-9ab5-d1153e34313b", "AQAAAAIAAYagAAAAEM0RuQlPeSIkq6oDvZJO9kezEEgd1YrqoF4oF09IaytC/ek7zniax/b+QDadGYoAZg==", "f1984cf7-9bec-46fb-a4f4-2a65ef713eec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50401964-f923-44a4-a78c-3c410b9bc93a", "AQAAAAIAAYagAAAAEBV8qOOHOOE+lrhhbLVtTFh6UVV5bI2ETOblDwBsZlxvvyZsjnO1BQSARFcUCmw6HQ==", "0c669fb0-7710-4886-8095-73eefe40fc9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "199798ab-f3fc-49bd-9747-2163fab8f323", "AQAAAAIAAYagAAAAEG4WQxTOT51KwoqRMUBux3iRvoiFNjGdJwS6MQm1/lLmgXKBzoDMbLDsio2T72jDHg==", "57e63e4d-62e3-4cba-80b5-3f68542195f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d87b3eb-b822-41b8-b780-1dbf9426b5b6", "AQAAAAIAAYagAAAAEKiZfV+FPs9EB8KQk8f8sItTC4NJwkyhO9l+TQU9J7QEzVGNuuTq13zT32P7poIdXg==", "e63a3a72-9645-414e-93cd-3316d011a4b4" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 6, 0, 44, 41, 349, DateTimeKind.Local).AddTicks(2111), "28ce910d-c475-4084-b221-e948e10a2f83", new DateTime(2024, 6, 5, 22, 44, 41, 349, DateTimeKind.Local).AddTicks(2051) });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentId", "content", "creation_date", "description", "name", "signed" },
                values: new object[,]
                {
                    { 10, "Plik formatu pdf: Prosimy o wyrażenie zgody o zorganizowanie wydarzenia", new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pozwolenie na zorganizowanie pikniku", "Organizacja pikniku", false },
                    { 15, "Plik formatu pdf: Prosimy o wyrażenie zgody na wymianę drzwi frontowych", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pozwolenie na wymianę drzwi", "Wymiana drzwi", false },
                    { 20, "Plik formatu pdf: Przykładowe", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pozwolenie na Przykładowe", "Przykład ", false }
                });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 22, 44, 41, 339, DateTimeKind.Local).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 22, 44, 41, 332, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 22, 44, 41, 339, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 22, 44, 41, 332, DateTimeKind.Local).AddTicks(7322));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

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
    }
}
