using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSomepropsInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58bf6a5c-5dc5-4bf4-834e-936fdc68aa03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cfd7bce-f1f8-419b-a1ff-3100c2629006");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "39804bf6-5163-44d4-92a2-b394a0816096", "3224da43-ea7b-43c2-88d3-f652d8b7f37a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39804bf6-5163-44d4-92a2-b394a0816096");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3224da43-ea7b-43c2-88d3-f652d8b7f37a");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bf639da-9979-4c55-aaee-f7f8048016a8", null, "Teacher", "TEACHER" },
                    { "3175d40f-bea7-4924-beb4-4962878ed9aa", null, "Student", "STUDENT" },
                    { "d62f163b-bc67-4733-ae64-d2c04764ce73", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "4914b534-4c0e-4de8-9635-184dffe58c67", 0, "3cf13a09-cb67-4e11-aaad-0c75e8807d62", new DateTime(2025, 11, 20, 16, 20, 39, 252, DateTimeKind.Local).AddTicks(9252), "admin@test.com", false, false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAEOplA5ll+pJ/KkeZ6yvqzhdaGkzqXNna1Eg6DQO1N0slKKtxAmKdwtzGvoUab2EsWg==", null, false, "admin", "243420aa-93e0-4207-a511-465da6d48c01", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d62f163b-bc67-4733-ae64-d2c04764ce73", "4914b534-4c0e-4de8-9635-184dffe58c67" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_code",
                table: "Courses",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_code",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bf639da-9979-4c55-aaee-f7f8048016a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3175d40f-bea7-4924-beb4-4962878ed9aa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d62f163b-bc67-4733-ae64-d2c04764ce73", "4914b534-4c0e-4de8-9635-184dffe58c67" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d62f163b-bc67-4733-ae64-d2c04764ce73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4914b534-4c0e-4de8-9635-184dffe58c67");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39804bf6-5163-44d4-92a2-b394a0816096", null, "Admin", "ADMIN" },
                    { "58bf6a5c-5dc5-4bf4-834e-936fdc68aa03", null, "Teacher", "TEACHER" },
                    { "9cfd7bce-f1f8-419b-a1ff-3100c2629006", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "3224da43-ea7b-43c2-88d3-f652d8b7f37a", 0, "9ee8ca42-fcc9-4e1c-82af-2227887c26bf", new DateTime(2025, 11, 20, 14, 17, 18, 835, DateTimeKind.Local).AddTicks(9466), "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAENGVeS8Koy2hgubxKwMcDrdaV2ddH3nUaLIGS7EOxjXyNt5lML8DGmqmjYBuXHNs+Q==", null, false, "admin", "11006136-0f54-4e56-bb6a-5768fe51fac5", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "39804bf6-5163-44d4-92a2-b394a0816096", "3224da43-ea7b-43c2-88d3-f652d8b7f37a" });
        }
    }
}
