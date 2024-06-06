using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a352331-b770-46ee-b891-39918be5ad99", "AQAAAAIAAYagAAAAEFt+Wr0VrsyeV4Dvhasp09ZK+Gh5dde2QIPcMAPdcRcKWSbvuhrknGBvL1z2HXwWCA==", "544fb1f8-a5e1-43eb-b176-b7234b003e7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80daff34-f162-41d5-bde4-143740539c99", "AQAAAAIAAYagAAAAECx3qyO+HzE4k2wzTNeIbERQtboQr3OhFc7p+CD4S/GIUa6c5dS22ovow47ZUZHxHA==", "3c7ff4dc-5bfd-4059-a6ae-d1316810f03d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "287c9ca9-c6fc-470e-82d3-849e189b5e16", "AQAAAAIAAYagAAAAEFU9cNGcKhhOZVQHfwO3s/olxJU7iZ3jgLx5/WKWkwj5DK4HGOrI48zgGSRMMdiPpQ==", "ef9d0e2c-3646-4c70-b829-93357329c534" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a1652b6-785d-402a-baf9-6930ec1d012f", "AQAAAAIAAYagAAAAEAP2REQ815onfycvSW3n9eURvmKrYfFkj5lLO9APK72fEyoed/tU2L27NLQcSlwlIg==", "d0c2ec96-942e-4220-bd55-1df372b4a144" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 6, 15, 13, 30, 995, DateTimeKind.Local).AddTicks(25), "a707da63-039a-4d68-a64f-7d6da4ac6506", new DateTime(2024, 6, 6, 13, 13, 30, 994, DateTimeKind.Local).AddTicks(9916) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 25, 10, 30, 50, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 10, 30, 50, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 25, 10, 30, 50, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 25, 10, 30, 50, 0, DateTimeKind.Unspecified));

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
    }
}
