using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixuserstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_residences_blocks_BlockId1",
                table: "residences");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_residences_ResidenceId1",
                table: "Resident");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_userinfo_UserId1",
                table: "Resident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_residences",
                table: "residences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_managers",
                table: "managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blocks",
                table: "blocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_administrators",
                table: "administrators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userinfo",
                table: "userinfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11f6f668-ee3c-41cd-99e2-b4c8be5d5020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b167f9b2-050f-40f2-8606-f9b62b5d8dd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2ef90c-343d-412e-967a-2618e92cefc4");

            migrationBuilder.RenameTable(
                name: "residences",
                newName: "Residences");

            migrationBuilder.RenameTable(
                name: "managers",
                newName: "Managers");

            migrationBuilder.RenameTable(
                name: "blocks",
                newName: "Blocks");

            migrationBuilder.RenameTable(
                name: "administrators",
                newName: "Administrators");

            migrationBuilder.RenameTable(
                name: "userinfo",
                newName: "Usersinfo");

            migrationBuilder.RenameIndex(
                name: "IX_residences_BlockId1",
                table: "Residences",
                newName: "IX_Residences_BlockId1");

            migrationBuilder.AddColumn<string>(
                name: "BlockId",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residences",
                table: "Residences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blocks",
                table: "Blocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usersinfo",
                table: "Usersinfo",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Usersinfo_UserId1",
                table: "Resident",
                column: "UserId1",
                principalTable: "Usersinfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_Blocks_BlockId1",
                table: "Residences");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Residences_ResidenceId1",
                table: "Resident");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Usersinfo_UserId1",
                table: "Resident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residences",
                table: "Residences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blocks",
                table: "Blocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usersinfo",
                table: "Usersinfo");

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

            migrationBuilder.DropColumn(
                name: "BlockId",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Blocks");

            migrationBuilder.RenameTable(
                name: "Residences",
                newName: "residences");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "managers");

            migrationBuilder.RenameTable(
                name: "Blocks",
                newName: "blocks");

            migrationBuilder.RenameTable(
                name: "Administrators",
                newName: "administrators");

            migrationBuilder.RenameTable(
                name: "Usersinfo",
                newName: "userinfo");

            migrationBuilder.RenameIndex(
                name: "IX_Residences_BlockId1",
                table: "residences",
                newName: "IX_residences_BlockId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_residences",
                table: "residences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_managers",
                table: "managers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blocks",
                table: "blocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_administrators",
                table: "administrators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userinfo",
                table: "userinfo",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11f6f668-ee3c-41cd-99e2-b4c8be5d5020", null, "Manager", "MANAGER" },
                    { "b167f9b2-050f-40f2-8606-f9b62b5d8dd6", null, "Resident", "RESIDENT" },
                    { "cb2ef90c-343d-412e-967a-2618e92cefc4", null, "Repairman", "REPAIRMAN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "730a5be5-ba2d-4eb2-868f-816855a3ef4e", "AQAAAAIAAYagAAAAEBULHiGu04qe2ZgBNwB+jyfMVMnkPeEPodR7ccMwlu0aqO3BS4Xb9lE6raPmkhGHPg==", "c35cbeaa-9d38-44cc-969b-e56e1cb3a9ef" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndTime", "EventPublicId", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 14, 3, 25, 48, 689, DateTimeKind.Local).AddTicks(2867), "f4e0ea05-f25c-4e85-b0df-fe93a3e74058", new DateTime(2024, 5, 14, 1, 25, 48, 689, DateTimeKind.Local).AddTicks(2783) });

            migrationBuilder.AddForeignKey(
                name: "FK_residences_blocks_BlockId1",
                table: "residences",
                column: "BlockId1",
                principalTable: "blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_residences_ResidenceId1",
                table: "Resident",
                column: "ResidenceId1",
                principalTable: "residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_userinfo_UserId1",
                table: "Resident",
                column: "UserId1",
                principalTable: "userinfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
