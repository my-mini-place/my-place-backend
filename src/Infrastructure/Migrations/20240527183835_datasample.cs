using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class datasample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_Blocks_BlockId1",
                table: "Residences");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Residences_ResidenceId1",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Resident_ResidenceId1",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Residences_BlockId1",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "ResidenceId1",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "BlockId1",
                table: "Residences");

            migrationBuilder.AlterColumn<string>(
                name: "ResidenceId",
                table: "Resident",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BlockId",
                table: "Residences",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ResidenceId",
                table: "Residences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "BlockId",
                table: "Blocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Residences_ResidenceId",
                table: "Residences",
                column: "ResidenceId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Blocks_BlockId",
                table: "Blocks",
                column: "BlockId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "190825f5-a491-48af-a0f0-3a9b95d24347", "AQAAAAIAAYagAAAAEN6FgdzoAaJaVtSv63pzT6wMt/KWKbxH9L2kFnEHnBQIHppq+5ogTb2sw4vyKCysgQ==", "af1bf9ad-028b-4a01-8981-bd8292f5e25e", "de40243b-e960-425b-a980-5c6e8e1895dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "bd0f8426-6670-4ebb-a7cf-6ddc3275ad00", "AQAAAAIAAYagAAAAEBz51y1rG1D4F+ffYppoReYEOVdgMXL8daA2rAwsgDsIqQE4kxZ+x+lCmIQ5oNHSPA==", "8dd27854-161e-4012-80b2-011463c77d3f", "f805f338-2c36-4e94-a574-6021cc0a2431" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2de48134-c64f-416e-9c9c-0bec8e3f63d9", "AQAAAAIAAYagAAAAEDcVdzgDb3ZhWsiyS8pmGOapUU9i7nvK8KwHzQO8TWKh/aSRKIAmT4bFULEaqoXAeA==", "a8ec9f87-82f8-4d1e-8829-e0798a37bce1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "6f6c2fb7-3fbf-4572-9325-232caa3c5f35", "AQAAAAIAAYagAAAAEJ3YDHAcVlZK8pc31tyD5MakifmaZlyyLua0fQ2WYAs5/VO4uU3NR7YXfLDMHQ0UzA==", "e00d09e6-854b-46a0-b526-eef367f69bb2", "36df4b07-2984-4182-a57c-de26516670cc" });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockId", "Name", "PostalCode" },
                values: new object[] { -1, "1", "BRUDNY", "12-345" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 38, 34, 450, DateTimeKind.Local).AddTicks(3464), "8233d480-d217-487c-a3f2-fc262fc6df00", new DateTime(2024, 5, 27, 20, 38, 34, 450, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 20, 38, 34, 442, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.InsertData(
                table: "Usersinfo",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "Name", "PhoneNumber", "Status", "Surname", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { -4, new DateTime(2024, 5, 27, 20, 38, 34, 446, DateTimeKind.Local).AddTicks(2694), "Resident123@gmail.com", true, "Resident", "123456789", 0, "Cucolkt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "de40243b-e960-425b-a980-5c6e8e1895dc" },
                    { -3, new DateTime(2024, 5, 27, 20, 38, 34, 442, DateTimeKind.Local).AddTicks(655), "RepairMan123@gmail.com", true, "RepairMan", "123456789", 0, "Repairowski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f805f338-2c36-4e94-a574-6021cc0a2431" },
                    { -2, new DateTime(2024, 5, 27, 20, 38, 34, 446, DateTimeKind.Local).AddTicks(2513), "Manager123@gmail.com", true, "Menager", "123456789", 0, "Menadzerski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "36df4b07-2984-4182-a57c-de26516670cc" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "EndWorkTime", "Guid", "StartWorkTime", "UserId" },
                values: new object[] { -1, new TimeSpan(0, 16, 0, 0, 0), "f84ee215-a41f-4e35-bb5a-e8dee5fc7d83\r\n", new TimeSpan(0, 8, 0, 0, 0), "36df4b07-2984-4182-a57c-de26516670cc" });

            migrationBuilder.InsertData(
                table: "Repairman",
                columns: new[] { "Id", "EndWorkTime", "Guid", "StartWorkTime", "UserId" },
                values: new object[] { -1, new TimeSpan(0, 0, 0, 0, 0), "21ee064d-3c9b-4fa0-9cf6-7a5387c3c9fc", new TimeSpan(0, 0, 0, 0, 0), "f805f338-2c36-4e94-a574-6021cc0a2431" });

            migrationBuilder.InsertData(
                table: "Residences",
                columns: new[] { "Id", "ApartmentNumber", "BlockId", "BuildingNumber", "Floor", "ResidenceId", "Street" },
                values: new object[] { -1, "18", "1", "1", 5, "1", "Kwiatowa" });

            migrationBuilder.InsertData(
                table: "Resident",
                columns: new[] { "Id", "Guid", "ResidenceId", "UserId" },
                values: new object[] { -1, "a1748a86-481f-4a39-893a-42c5e6ca980b", "1", "de40243b-e960-425b-a980-5c6e8e1895dc" });

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ResidenceId",
                table: "Resident",
                column: "ResidenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residences_BlockId",
                table: "Residences",
                column: "BlockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_Blocks_BlockId",
                table: "Residences",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "BlockId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Residences_ResidenceId",
                table: "Resident",
                column: "ResidenceId",
                principalTable: "Residences",
                principalColumn: "ResidenceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_Blocks_BlockId",
                table: "Residences");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Residences_ResidenceId",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Resident_ResidenceId",
                table: "Resident");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Residences_ResidenceId",
                table: "Residences");

            migrationBuilder.DropIndex(
                name: "IX_Residences_BlockId",
                table: "Residences");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Blocks_BlockId",
                table: "Blocks");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Repairman",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Resident",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Residences",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Blocks",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "ResidenceId",
                table: "Residences");

            migrationBuilder.AlterColumn<string>(
                name: "ResidenceId",
                table: "Resident",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ResidenceId1",
                table: "Resident",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "BlockId",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BlockId1",
                table: "Residences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "BlockId",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "4e570b5f-a234-4000-a533-9a106282a6f1", "AQAAAAIAAYagAAAAEL6PAigylSjySHQlNfiC6IX81Xm4D/OMTvpgK6eMrcijdQdAjvRfg6UpG2qtFRhjrA==", "ed8580d2-406e-499c-b9f8-d38ad5d59706", "6ae40b13-20a8-462c-9364-a455ef2d3908" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "e22d781f-2875-4099-b472-af2f045ed7f4", "AQAAAAIAAYagAAAAEA0pRRXjj8ltCho6q2CLD9EE7cOT/MGo+hfRbHwyEr8nhVO4u2pirzM1O8evGmGcEg==", "6ebb2077-8067-452a-8c84-ce21b5540e51", "6ae40b13-20a8-462c-9364-a455ef2d3908" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36478a5f-4f6a-438a-a378-847ef285e6a2", "AQAAAAIAAYagAAAAENUmEcrwUwhOMr5Oq+BlBDNvJWluJuLG1KDlGxAXc1WYJlyroQ1F8pYETGN6YVgBtw==", "e208c8f7-3b9d-44eb-aadd-0c149be8267d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "d16e93f8-e928-4414-bf8b-3bf1f96c9e3f", "AQAAAAIAAYagAAAAEHciqKUTcX+0GDYzWoNSrfNvDq3dvOddlyKBtS0fQtnb3hFmptYQlCzBSeEhQ8wH6Q==", "f9d9f94f-4214-451a-9bf8-16316d099c16", "6ae40b13-20a8-462c-9364-a455ef2d3908" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 5, 54, 464, DateTimeKind.Local).AddTicks(1851), "a0dfee85-3ec7-4142-94c2-b78a48d5f5f5", new DateTime(2024, 5, 27, 20, 5, 54, 464, DateTimeKind.Local).AddTicks(1843) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 20, 5, 54, 464, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ResidenceId1",
                table: "Resident",
                column: "ResidenceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Residences_BlockId1",
                table: "Residences",
                column: "BlockId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_Blocks_BlockId1",
                table: "Residences",
                column: "BlockId1",
                principalTable: "Blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Residences_ResidenceId1",
                table: "Resident",
                column: "ResidenceId1",
                principalTable: "Residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
