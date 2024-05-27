using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "36478a5f-4f6a-438a-a378-847ef285e6a2", "AQAAAAIAAYagAAAAENUmEcrwUwhOMr5Oq+BlBDNvJWluJuLG1KDlGxAXc1WYJlyroQ1F8pYETGN6YVgBtw==", "e208c8f7-3b9d-44eb-aadd-0c149be8267d", "6ae40b13-20a8-462c-9364-a455ef2d3908" });

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

            migrationBuilder.InsertData(
                table: "Usersinfo",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "Name", "PhoneNumber", "Status", "Surname", "UpdatedAt", "UserId" },
                values: new object[] { -1, new DateTime(2024, 5, 27, 20, 5, 54, 464, DateTimeKind.Local).AddTicks(1484), "Admin123@gmail.com", true, "Admin", "123456789", 0, "amin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6ae40b13-20a8-462c-9364-a455ef2d3908" });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "Guid", "UserId" },
                values: new object[] { -1, "e2865b47-dabd-4984-ad52-e42e3e875a44", "6ae40b13-20a8-462c-9364-a455ef2d3908" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Usersinfo",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "04a32618-4a07-4817-906f-0f11f5cfe265", null, "AQAAAAIAAYagAAAAEFR9BANrbtuLGOA0yWfu06xAXkn6C7cb50csYmANtvRswU37kxFn8KehQ/QafAhyqQ==", "fcdeca27-7941-4350-8a9c-9dceac1047fe", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "bbf9f7a0-1634-47db-bb27-4e227050cccd", null, "AQAAAAIAAYagAAAAEK/ZnQM0ridIyxSJSTWPlXdSfM5Caomr+ZeE6T+7R1l8F6qVjiCtgjJEU8rnEiDeFA==", "d0931948-bdc5-4ad1-8745-9f04ec23085a", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "50c57990-cc87-468e-9860-c2947886affc", null, "AQAAAAIAAYagAAAAEIJ4UjHC4NlcVIop7Tkkb8tEK9P22T7pMCC8SPChppn0hbjR1FZmcFEa6PSbgKTANw==", "6ec7015e-863a-4104-996b-c21549ada355", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp", "UserId" },
                values: new object[] { "984da328-4f5d-42de-9b00-c50f9533fa9f", null, "AQAAAAIAAYagAAAAEEUzyWs8pa3f+CKctqdmc/Gw72KoAaVvdNokJBj9yc6ed/lGCXJK9XkyuhwZKgHaWQ==", "c118f02f-fe43-4d57-9ba0-3996c3d5e5c2", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 48, 23, 394, DateTimeKind.Local).AddTicks(148), "b7606680-2368-4074-ae1a-5ac1e386483d", new DateTime(2024, 5, 27, 0, 48, 23, 394, DateTimeKind.Local).AddTicks(40) });
        }
    }
}
