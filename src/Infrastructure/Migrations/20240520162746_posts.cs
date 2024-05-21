using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9275e636-7dc0-4931-bcf3-f86b63cd7ed8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1775dc0-0b27-4943-82f1-c0cadf2b8147");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e83e0a9a-28f4-4f8f-9b4b-12ee4f47a64c");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSurvey = table.Column<bool>(type: "bit", nullable: false),
                    SurveyClosureDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58653e52-8c28-4041-bb40-5c3fb134e865", null, "Repairman", "REPAIRMAN" },
                    { "73e2ae89-985c-4635-99f8-bc1daf6c72a6", null, "Resident", "RESIDENT" },
                    { "c93e3ab0-495c-4f39-8082-86ec7287fcd3", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d5e6dc4-a6c1-4681-ac63-ef0ef90a10d8", "AQAAAAIAAYagAAAAEHO/6g0b3IW2L/gkv6HXBDL1jftWfgkzDNfYc0PFHz8sxc2Y+O12O1LxrV/76RvQ0A==", "baf07c77-d46f-4c06-b9f9-d7d549907fd4" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 20, 20, 27, 46, 303, DateTimeKind.Local).AddTicks(8780), "81219c56-6a31-46a6-a2ab-ba8eccacc8c9", new DateTime(2024, 5, 20, 18, 27, 46, 303, DateTimeKind.Local).AddTicks(8730) });

            migrationBuilder.CreateIndex(
                name: "IX_Options_PostId",
                table: "Options",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_OptionId",
                table: "Votes",
                column: "OptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58653e52-8c28-4041-bb40-5c3fb134e865");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e2ae89-985c-4635-99f8-bc1daf6c72a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c93e3ab0-495c-4f39-8082-86ec7287fcd3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9275e636-7dc0-4931-bcf3-f86b63cd7ed8", null, "Repairman", "REPAIRMAN" },
                    { "b1775dc0-0b27-4943-82f1-c0cadf2b8147", null, "Manager", "MANAGER" },
                    { "e83e0a9a-28f4-4f8f-9b4b-12ee4f47a64c", null, "Resident", "RESIDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b329075-7612-42e9-ab79-f9cee558ef8b", "AQAAAAIAAYagAAAAENT9TOu6LX/COgGgEv+8Sg41SDn3emJrBjmamRqvIBDfsHXwQY2JHc3a+wIIDtoydg==", "bcfe5a5f-230b-4d6d-8db0-c3f2dabe91cc" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 14, 3, 48, 19, 713, DateTimeKind.Local).AddTicks(6963), "53c338d1-5f3b-45fd-ac70-9362cdbb792c", new DateTime(2024, 5, 14, 1, 48, 19, 713, DateTimeKind.Local).AddTicks(6900) });
        }
    }
}
