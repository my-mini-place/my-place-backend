using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeCalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Day_DayId",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "CalendarByMonth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_DayId",
                table: "Event");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74854f50-47b2-46b9-880f-65425d62075d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78360bc9-93f5-46aa-9ba8-3eef2c602250");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b8d3d91-7ef2-49b7-8f35-5c54f182d4a1");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "CalendarEvents");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "CalendarEvents",
                newName: "EventPublicId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEvents",
                table: "CalendarEvents",
                column: "EventId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEvents",
                table: "CalendarEvents");

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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "State",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "owner",
                table: "CalendarEvents");

            migrationBuilder.RenameTable(
                name: "CalendarEvents",
                newName: "Event");

            migrationBuilder.RenameColumn(
                name: "EventPublicId",
                table: "Event",
                newName: "DayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.CreateTable(
                name: "CalendarByMonth",
                columns: table => new
                {
                    MonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarByMonth", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.DayId);
                    table.ForeignKey(
                        name: "FK_Day_CalendarByMonth_MonthId",
                        column: x => x.MonthId,
                        principalTable: "CalendarByMonth",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74854f50-47b2-46b9-880f-65425d62075d", null, "Manager", "MANAGER" },
                    { "78360bc9-93f5-46aa-9ba8-3eef2c602250", null, "Repairman", "REPAIRMAN" },
                    { "7b8d3d91-7ef2-49b7-8f35-5c54f182d4a1", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afaf3640-91c5-4c8c-84a0-a8958be624fc", "AQAAAAIAAYagAAAAEPsuLV4CL3zJcsnf0gY+NJ5Uwwqz2qGY5iEtwo0P+lC/a3UeqxiYH9wMIpuktRMblQ==", "b07ed5d8-3fbe-4fce-8b18-b63ff4fa5f57" });

            migrationBuilder.CreateIndex(
                name: "IX_Event_DayId",
                table: "Event",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_MonthId",
                table: "Day",
                column: "MonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Day_DayId",
                table: "Event",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
