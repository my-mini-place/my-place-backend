using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changefloorsname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Floors",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "Blocks",
                keyColumn: "Id",
                keyValue: -1,
                column: "Floors",
                value: 5);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Floors",
                table: "Blocks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "190825f5-a491-48af-a0f0-3a9b95d24347", "AQAAAAIAAYagAAAAEN6FgdzoAaJaVtSv63pzT6wMt/KWKbxH9L2kFnEHnBQIHppq+5ogTb2sw4vyKCysgQ==", "af1bf9ad-028b-4a01-8981-bd8292f5e25e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd0f8426-6670-4ebb-a7cf-6ddc3275ad00", "AQAAAAIAAYagAAAAEBz51y1rG1D4F+ffYppoReYEOVdgMXL8daA2rAwsgDsIqQE4kxZ+x+lCmIQ5oNHSPA==", "8dd27854-161e-4012-80b2-011463c77d3f" });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f6c2fb7-3fbf-4572-9325-232caa3c5f35", "AQAAAAIAAYagAAAAEJ3YDHAcVlZK8pc31tyD5MakifmaZlyyLua0fQ2WYAs5/VO4uU3NR7YXfLDMHQ0UzA==", "e00d09e6-854b-46a0-b526-eef367f69bb2" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 38, 34, 450, DateTimeKind.Local).AddTicks(3464), "8233d480-d217-487c-a3f2-fc262fc6df00", new DateTime(2024, 5, 27, 20, 38, 34, 450, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 20, 38, 34, 446, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 20, 38, 34, 442, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 20, 38, 34, 446, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 20, 38, 34, 442, DateTimeKind.Local).AddTicks(328));
        }
    }
}
