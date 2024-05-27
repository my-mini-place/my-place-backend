using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modelsconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Usersinfo_UserId1",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Resident_UserId1",
                table: "Resident");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0604be80-a8b8-4488-94a1-4d09d4e48548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3e255a-c333-4b15-b899-e134c03db16c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "206bf01e-bc92-4649-b090-5e6c6e7531fc");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Resident");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Usersinfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Resident",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Resident",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Administrators",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usersinfo_UserId",
                table: "Usersinfo",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Repairman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartWorkTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndWorkTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairman_Usersinfo_UserId",
                        column: x => x.UserId,
                        principalTable: "Usersinfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64ac29e2-753c-4a05-9ba4-d4d61bad421f", null, "Manager", "MANAGER" },
                    { "8e4829d4-2a36-4332-b19d-4720c4de64fa", null, "Resident", "RESIDENT" },
                    { "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4", null, "Repairman", "REPAIRMAN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50c57990-cc87-468e-9860-c2947886affc", "AQAAAAIAAYagAAAAEIJ4UjHC4NlcVIop7Tkkb8tEK9P22T7pMCC8SPChppn0hbjR1FZmcFEa6PSbgKTANw==", "6ec7015e-863a-4104-996b-c21549ada355" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[,]
                {
                    { "60f8840c-4d51-45df-9abe-1ba4d20fbcdf", 0, "04a32618-4a07-4817-906f-0f11f5cfe265", "Resident123@gmail.com", true, true, null, null, "RESIDENT123@GMAIL.COM", "RESIDENT123@GMAIL.COM", "AQAAAAIAAYagAAAAEFR9BANrbtuLGOA0yWfu06xAXkn6C7cb50csYmANtvRswU37kxFn8KehQ/QafAhyqQ==", null, true, "fcdeca27-7941-4350-8a9c-9dceac1047fe", false, new Guid("00000000-0000-0000-0000-000000000000"), "Resident123@gmail.com" },
                    { "84d26d49-da84-46cc-84af-e03f60eddbc1", 0, "bbf9f7a0-1634-47db-bb27-4e227050cccd", "RepairMan123@gmail.com", true, true, null, null, "REPAIRMAN123@GMAIL.COM", "REPAIRMAN123@GMAIL.COM", "AQAAAAIAAYagAAAAEK/ZnQM0ridIyxSJSTWPlXdSfM5Caomr+ZeE6T+7R1l8F6qVjiCtgjJEU8rnEiDeFA==", null, true, "d0931948-bdc5-4ad1-8745-9f04ec23085a", false, new Guid("00000000-0000-0000-0000-000000000000"), "RepairMan123@gmail.com" },
                    { "921f97ca-b7e2-4b88-8917-d4f2ff820a70", 0, "984da328-4f5d-42de-9b00-c50f9533fa9f", "Manager123@gmail.com", true, true, null, null, "MANAGER123@GMAIL.COM", "MANAGER123@GMAIL.COM", "AQAAAAIAAYagAAAAEEUzyWs8pa3f+CKctqdmc/Gw72KoAaVvdNokJBj9yc6ed/lGCXJK9XkyuhwZKgHaWQ==", null, true, "c118f02f-fe43-4d57-9ba0-3996c3d5e5c2", false, new Guid("00000000-0000-0000-0000-000000000000"), "Manager123@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 48, 23, 394, DateTimeKind.Local).AddTicks(148), "b7606680-2368-4074-ae1a-5ac1e386483d", new DateTime(2024, 5, 27, 0, 48, 23, 394, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8e4829d4-2a36-4332-b19d-4720c4de64fa", "60f8840c-4d51-45df-9abe-1ba4d20fbcdf" },
                    { "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4", "84d26d49-da84-46cc-84af-e03f60eddbc1" },
                    { "64ac29e2-753c-4a05-9ba4-d4d61bad421f", "921f97ca-b7e2-4b88-8917-d4f2ff820a70" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usersinfo_UserId",
                table: "Usersinfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resident_UserId",
                table: "Resident",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairman_UserId",
                table: "Repairman",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_Usersinfo_UserId",
                table: "Administrators",
                column: "UserId",
                principalTable: "Usersinfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Usersinfo_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "Usersinfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Usersinfo_UserId",
                table: "Resident",
                column: "UserId",
                principalTable: "Usersinfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_Usersinfo_UserId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Usersinfo_UserId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Usersinfo_UserId",
                table: "Resident");

            migrationBuilder.DropTable(
                name: "Repairman");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usersinfo_UserId",
                table: "Usersinfo");

            migrationBuilder.DropIndex(
                name: "IX_Usersinfo_UserId",
                table: "Usersinfo");

            migrationBuilder.DropIndex(
                name: "IX_Resident_UserId",
                table: "Resident");

            migrationBuilder.DropIndex(
                name: "IX_Managers_UserId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e4829d4-2a36-4332-b19d-4720c4de64fa", "60f8840c-4d51-45df-9abe-1ba4d20fbcdf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4", "84d26d49-da84-46cc-84af-e03f60eddbc1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64ac29e2-753c-4a05-9ba4-d4d61bad421f", "921f97ca-b7e2-4b88-8917-d4f2ff820a70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64ac29e2-753c-4a05-9ba4-d4d61bad421f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4829d4-2a36-4332-b19d-4720c4de64fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b766b57c-20ce-4aaa-86be-1eabc7fb1ad4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f8840c-4d51-45df-9abe-1ba4d20fbcdf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84d26d49-da84-46cc-84af-e03f60eddbc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "921f97ca-b7e2-4b88-8917-d4f2ff820a70");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Administrators");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Usersinfo",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Resident",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Resident",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0604be80-a8b8-4488-94a1-4d09d4e48548", null, "Repairman", "REPAIRMAN" },
                    { "1c3e255a-c333-4b15-b899-e134c03db16c", null, "Resident", "RESIDENT" },
                    { "206bf01e-bc92-4649-b090-5e6c6e7531fc", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b672f3d-585b-4269-999d-8e147d8e9533", "AQAAAAIAAYagAAAAEKeXoQbV/7bysLRKcLf3D6pytrSlRVhWoGJZxzP626/fSYQ2xjq26t7CjGnZvKqrNw==", "e6dcd45f-5fcc-49ee-8c4c-d885eec908d6" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 24, 22, 39, 50, 539, DateTimeKind.Local).AddTicks(1228), "8da19701-71d7-4a52-a821-7789be8f6285", new DateTime(2024, 5, 24, 20, 39, 50, 539, DateTimeKind.Local).AddTicks(1164) });

            migrationBuilder.CreateIndex(
                name: "IX_Resident_UserId1",
                table: "Resident",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Usersinfo_UserId1",
                table: "Resident",
                column: "UserId1",
                principalTable: "Usersinfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
