using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixvote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SurveyClosureDateTime",
                table: "Posts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c118a79-a28f-4de1-bea3-80930278a94f", "AQAAAAIAAYagAAAAEHpxIhFK/zvDh+8CVbwdrtJMxoBMaACU3xD1fyok/rzaHbjNkayNuEC1aeth5ZghTw==", "d5c0b2cd-c0c7-42c8-a8ad-43bfeb77dd79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1454bd48-606c-476d-a708-341886263ac9", "AQAAAAIAAYagAAAAEP76tOlZ5Psum39S2QGp4o0AsxfBgnexLboqgT9cvMdmK5wt1fjqrrpalmm99ebuow==", "827ca056-4d16-4ac1-af34-dbcae026f10f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce4b7cbf-7a2c-4793-84f2-43b184b914af", "AQAAAAIAAYagAAAAEMoYfB6dhnpCxhRF+zBIxQhzNbMUFsImTVJkbhhxNF9Qbcwgzlked5t4zu8kDJ6Jmg==", "0bd3a9b9-34fd-436d-bd31-5924e10d8176" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bcfe8e5-4001-4afd-853c-f0a1935e2ddb", "AQAAAAIAAYagAAAAEIrV/4dkjb3L0TRvK43JKEXB3XRRAL2NXap39XkoMlj/ac0tmIohRA8ElXA0Ge2IyA==", "d59abdd7-49b5-43b0-aa5a-d6a975d7af4c" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 19, 53, 29, 41, DateTimeKind.Local).AddTicks(7258), "a1bb40ec-77f5-4970-8002-dd31d30bd06f", new DateTime(2024, 5, 31, 17, 53, 29, 41, DateTimeKind.Local).AddTicks(7219) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 53, 29, 38, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 53, 29, 34, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 53, 29, 38, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 53, 29, 34, DateTimeKind.Local).AddTicks(5894));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SurveyClosureDateTime",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "305f73a6-4704-44c7-9c3c-39886726f37e", "AQAAAAIAAYagAAAAEDpaV+l0CTyZJRCPvD0nuilR1APtcOhqzdVaa38dXuvismfGan5haUym7WzrV7M7mw==", "5251fbc0-3144-48d6-9637-3e888c7f5c7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f4737a2-c305-4650-bc91-fe00ce3d0880", "AQAAAAIAAYagAAAAEEkvyRgkN7HigbDAY9+EAsME15UkBp2LIhGMr8M1aneHMvGJSvZE91vjFz6QWIJOnw==", "fcd01031-639e-4326-bc0b-28475843c49e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38524a8b-b84f-4fc8-8c8d-8264f459d1ec", "AQAAAAIAAYagAAAAEAh5+vLrePPEHujorbrKuCnsYvqDlIIp6HXpZxAUX+SIK9I5d1egq3bR17EnTnFHQg==", "4a187703-58b9-41e9-8cc5-21dea6aac383" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc6f5340-6d16-4167-a256-a707104f711e", "AQAAAAIAAYagAAAAEC8s+//bXVxO+P8BPAib/CJLr7xWSgWCkoF5zEjXWGb0ZupOk/PnV5zBG9Po0QRvag==", "abff111a-1956-459c-a2ca-640f16887401" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 31, 19, 29, 9, 618, DateTimeKind.Local).AddTicks(426), "a660a7e6-2ed8-4c3f-8bdb-fc6f381f87a9", new DateTime(2024, 5, 31, 17, 29, 9, 618, DateTimeKind.Local).AddTicks(356) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 29, 9, 612, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 29, 9, 606, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 29, 9, 612, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 17, 29, 9, 606, DateTimeKind.Local).AddTicks(9421));
        }
    }
}
