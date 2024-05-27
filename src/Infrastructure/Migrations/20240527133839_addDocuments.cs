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
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40820103-c6af-4be7-aee9-8af11f557b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73727b13-7c97-4b4d-9ea7-5dafb2138cab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d85f1a5-5c6f-4b4f-a61e-813668090b8c");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5705bd62-9d02-43cb-ab97-d19e6c7d278a", null, "Repairman", "REPAIRMAN" },
                    { "a6e39a53-0728-40c9-8de0-bf8e56f69533", null, "Manager", "MANAGER" },
                    { "d99eb0c1-1b68-4bf9-a97b-3c386e78fa8e", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4a8f065-87dd-47d7-b010-d91f8b831729", "AQAAAAIAAYagAAAAEAXJxKDPgIFFzUhjMIjj+feYmtdDxRZhRHWAyoOkNB1mXLqmPYTBPX96Lt3Mm6KZVg==", "d08ea7af-246c-4205-a4c8-beaa74bd40f3" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 38, 39, 234, DateTimeKind.Local).AddTicks(3118), "5d56089e-213b-410d-930b-28731f91500a", new DateTime(2024, 5, 27, 15, 38, 39, 234, DateTimeKind.Local).AddTicks(3073) });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentId", "content", "creation_date", "description", "name", "signed" },
                values: new object[,]
                {
                    { 10, "Plik formatu pdf: Prosimy o wyrażenie zgody o zorganizowanie wydarzenia", new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pozwolenie na zorganizowanie pikniku", "Organizacja pikniku", false },
                    { 15, "Plik formatu pdf: Prosimy o wyrażenie zgody na wymianę drzwi frontowych", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pozwolenie na wymianę drzwi", "Wymiana drzwi", false },
                    { 20, "Plik formatu pdf: Przykładowe", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pozwolenie na Przykładowe", "Przykład ", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5705bd62-9d02-43cb-ab97-d19e6c7d278a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6e39a53-0728-40c9-8de0-bf8e56f69533");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d99eb0c1-1b68-4bf9-a97b-3c386e78fa8e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40820103-c6af-4be7-aee9-8af11f557b14", null, "Manager", "MANAGER" },
                    { "73727b13-7c97-4b4d-9ea7-5dafb2138cab", null, "Repairman", "REPAIRMAN" },
                    { "7d85f1a5-5c6f-4b4f-a61e-813668090b8c", null, "Resident", "RESIDENT" }
                });

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
