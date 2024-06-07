using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc/>
    public partial class addCalendar : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85d555c2-cdb1-4322-95a1-31933c2fd183");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1d0bc99-43cd-47d9-8d46-a093c5e11809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de34ec20-2c29-4cb2-a3a0-e24cf385fbb0");

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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "DayId",
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
                name: "IX_Day_MonthId",
                table: "Day",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_DayId",
                table: "Event",
                column: "DayId");
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "CalendarByMonth");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85d555c2-cdb1-4322-95a1-31933c2fd183", null, "Repairman", "REPAIRMAN" },
                    { "c1d0bc99-43cd-47d9-8d46-a093c5e11809", null, "Manager", "MANAGER" },
                    { "de34ec20-2c29-4cb2-a3a0-e24cf385fbb0", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6695ad05-c991-44ca-91ad-267e4cb8384a", "AQAAAAIAAYagAAAAEM5foZXXvPA7ffNPbz6axu4+JkNlU94TNSR0SdCiE3iMNkAbulQDmVTv3XezztxXzA==", "e436a069-fe8a-4c4e-b51a-93b3f4502c4c" });
        }
    }
}