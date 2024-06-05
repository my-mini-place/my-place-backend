using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modificatedpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da671bf0-4525-47f7-a9de-affc56b2ad67", "AQAAAAIAAYagAAAAEEBxy8YIMplKDHkg7A0e8mQIlWLT17hve9SV0Arke0K+2LGrd9s7/BFNILI5RLgbsw==", "3f8d434d-a6df-4268-8c32-e12592bf2ad3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b544d82-8cb2-4609-9879-d3f4999eac69", "AQAAAAIAAYagAAAAEKdRnzWADLba+WZKQo/7wWKTgg9FHgJSiv/1c/zcEJdSCq2ONhPdMxIo4y7rc8lVyg==", "dafaab34-2824-46ba-8b86-179deec75766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea086588-943f-49ac-9cfb-c289d3b623d6", "AQAAAAIAAYagAAAAEDOdlNnAEjNG2WKLysiaz9/UhyGvSSKhua/2UsH6jjnJCLz/gN3hzIFlK/+JVrQlVg==", "54423d84-7af1-4768-8538-dadac059ae1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd451f40-d06c-4a2a-a454-5f290a74ca02", "AQAAAAIAAYagAAAAEGB27Oc8KR3PeUCZ3RF+Wrah+zoSYmYp/WX5bySE5rVrFnQ4HjUMfdfjpRZmCuzTFw==", "8e459a6f-4209-4894-ba99-c8f2defb1f99" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 5, 4, 14, 50, 908, DateTimeKind.Local).AddTicks(8081), "76a93b90-e19f-4f8b-bb41-b72e674ef5d8", new DateTime(2024, 6, 5, 2, 14, 50, 908, DateTimeKind.Local).AddTicks(8035) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 905, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 901, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 905, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 2, 14, 50, 900, DateTimeKind.Local).AddTicks(9903));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71aafd5c-b800-4b2c-9d1e-4f9010e92bac", "AQAAAAIAAYagAAAAEB65ugIpzcHyHqsQ+E4fjfYLrbGgLjiO6rpEN1CRfmTm3NtBpMgQTmha2wnTZblKMQ==", "1b0cba10-e3cd-48d9-9036-93bdd0a475e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95dd3282-2444-4714-afb7-d1fd9be13187", "AQAAAAIAAYagAAAAEI+BNMFEdTX1I5vGmbfr6BftbjoJhEeb6IoTiyLctkwt3xzFwe3qEGsrZzuz+g6O6w==", "1ebc3b32-9cfd-44c3-b2b3-6b2ec193605f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdefe016-9e3e-4f38-97e2-1b30b83db32c", "AQAAAAIAAYagAAAAEDe1hsdH2n2ixob4328vf1XIT9cUEESxGLmKdqHIv6TNPPJSbTZ9r3pJVKl/M8XCvQ==", "d26b2882-830f-45ec-955c-51436403b8fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "856e431e-38f8-43e9-a38d-a2373f08cbb2", "AQAAAAIAAYagAAAAEMH7gC2vjnnIUtxLBjlj/7AuWNmFtwW8mtGDAfoODnvQ1w/ax+Rr8i3aB2TeZs7l0Q==", "9d09fde0-c518-472b-89da-546f5b8c6aa9" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 5, 3, 45, 11, 848, DateTimeKind.Local).AddTicks(6391), "df64b0a9-dbcc-4afb-b517-52c276dd0844", new DateTime(2024, 6, 5, 1, 45, 11, 848, DateTimeKind.Local).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 1, 45, 11, 845, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 1, 45, 11, 841, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 1, 45, 11, 845, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 5, 1, 45, 11, 841, DateTimeKind.Local).AddTicks(6070));
        }
    }
}
