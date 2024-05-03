using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60947bd2-5c50-4eda-bec9-933124a78c53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a6a861-5898-4080-87a7-24f138e52e0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc810e3a-383e-46bf-b0e5-bf815cb73c71");

            migrationBuilder.AlterColumn<string>(
                name: "EventPublicId",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "CalendarEvents",
                columns: new[] { "EventId", "Description", "EndTime", "EventPublicId", "Month", "Name", "StartTime", "State", "Type", "owner" },
                values: new object[] { 1, "To jest opis przykładowego wydarzenia", new DateTime(2024, 5, 2, 19, 6, 50, 464, DateTimeKind.Local).AddTicks(4731), "02fca8fa-b3f4-425b-a08a-669f9b94713f", "May", "Przykładowe wydarzenie", new DateTime(2024, 5, 2, 17, 6, 50, 464, DateTimeKind.Local).AddTicks(4683), "Created", "Custom", "John Doe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Month",
                table: "CalendarEvents");

            migrationBuilder.AlterColumn<int>(
                name: "EventPublicId",
                table: "CalendarEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60947bd2-5c50-4eda-bec9-933124a78c53", null, "Repairman", "REPAIRMAN" },
                    { "73a6a861-5898-4080-87a7-24f138e52e0e", null, "Manager", "MANAGER" },
                    { "cc810e3a-383e-46bf-b0e5-bf815cb73c71", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4682bf-14d5-48b5-bb02-eff473422a0d", "AQAAAAIAAYagAAAAEOmbxT4OxK1qqVFIUfZ0iv3dNsGknxjpgRsS7U/1PBA+Eskg/DwdoqBhqtODTqO1YQ==", "7543d29d-d434-441d-af98-b6208b991d40" });
        }
    }
}
