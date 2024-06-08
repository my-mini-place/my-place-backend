using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class resident_foreignkey_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resident_ResidenceId",
                table: "Resident");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bf2939d-1365-4a91-800f-f2604e5e2fc5", "AQAAAAIAAYagAAAAEN3+RHOKs4LV1KGqJdCqIRfa9/fEEiSGT0PONnakWHpnjDPLRGCNGRU7HsUTeipGXA==", "f5d4176b-d9d9-4114-9d1e-cbb926efb94a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f5fcfc-4655-411e-a65f-182fd27a928a", "AQAAAAIAAYagAAAAEGDgPHxsPWIC5zu9xm0HCdNxfsGJAG44dlwgRQexKwIqAky0Ufqa4JpBpGGldMPLGw==", "f44e90c4-a0c3-4152-961b-b861830c7cba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e065ab75-463c-4224-a804-a3572bd603f3", "AQAAAAIAAYagAAAAEO+Hf0rNgbqsGiZg3LT5IypL9OxigV201A3rY2LmRMFhiWZpM5K2sHoaylzLxKhP5w==", "250929dc-1c97-4d2e-b929-57e58c9910c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "704269f2-7d88-4a01-96a5-5383bf10d8ab", "AQAAAAIAAYagAAAAEKbIpznU065/w/LFH+h5yZrVJNKTA0cDwDK4EsThHOTnQ1K3tXRXsNKxKx5rVJdFKA==", "7c2c1434-602b-400f-8d14-a6dc4c09a808" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 9, 2, 37, 24, 245, DateTimeKind.Local).AddTicks(2420), "989ca636-17d2-4636-8274-7f9a26f77590", new DateTime(2024, 6, 9, 0, 37, 24, 245, DateTimeKind.Local).AddTicks(2316) });

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ResidenceId",
                table: "Resident",
                column: "ResidenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resident_ResidenceId",
                table: "Resident");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6ea491f-9aad-42c6-990c-8abd695b1b02", "AQAAAAIAAYagAAAAEJeFXv6V+4tKqejXjQoFXahOrXEwj2Xv5gPiSnXzCs3w4Gzi96sBh2wZRU3uh5lW3w==", "8230e243-16a6-4a71-92ad-afdcb963d36c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93644715-91f4-4474-b4ca-f37408e5d98a", "AQAAAAIAAYagAAAAEFdOm6ZnN7jtAGWzdePsArEtYZDghvoCdkKgEw74pxROX0jm+ISTfqVMXCU4tJ/uSA==", "b34ef5f9-5e13-4a71-85ab-e56aee9c098c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "127dc2ee-29c8-4eb0-bc33-10fa37ec0d53", "AQAAAAIAAYagAAAAEDL/zEdWaYKcmZ54WVvpRo9ewriGz6FeYZx7ttlgC09P6zurY70vI9CqJEwZhu5smQ==", "c803158d-bec0-4c9b-9178-b5ab7eef2319" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "131b6ae5-4f22-4412-b055-305b74fe4ba4", "AQAAAAIAAYagAAAAEH85FEH3E3T6Dq/lSg5pF4AmHWxDyCoysBWwDLWAF22kAY7Ojcs0R+3IllnUOK/hMg==", "5e4f0ea3-50ca-4b98-9b75-b940b7c47d23" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 9, 2, 30, 37, 858, DateTimeKind.Local).AddTicks(6104), "6cd9b735-d78c-4b71-98b9-61ffdea847a1", new DateTime(2024, 6, 9, 0, 30, 37, 858, DateTimeKind.Local).AddTicks(6003) });

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ResidenceId",
                table: "Resident",
                column: "ResidenceId",
                unique: true);
        }
    }
}
