using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeDepartmentNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b065c706-6b33-4a54-990f-08eb0bb727ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dec46d68-d7a6-436d-8166-401dbe9904d4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92a69b8d-d9cd-4bda-b676-d372cbe3494c", "5ce2563c-195b-4f98-90e5-ee5762a271dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92a69b8d-d9cd-4bda-b676-d372cbe3494c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ce2563c-195b-4f98-90e5-ee5762a271dd");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                table: "Departments");

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
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92a69b8d-d9cd-4bda-b676-d372cbe3494c", null, "Admin", "ADMIN" },
                    { "b065c706-6b33-4a54-990f-08eb0bb727ae", null, "Teacher", "TEACHER" },
                    { "dec46d68-d7a6-436d-8166-401dbe9904d4", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "5ce2563c-195b-4f98-90e5-ee5762a271dd", 0, "d69a3150-6065-48e6-b504-782a7217e2bf", new DateTime(2025, 11, 20, 13, 46, 37, 746, DateTimeKind.Local).AddTicks(856), "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAEHCO2a1+I48VXfK1x3M9XFps9L4pKM6RjsAibAmRctNEaOj9TXNYc3/695QgUV1HIA==", null, false, "admin", "1da6c7f5-d4b5-4ba8-a6c1-adb2eba86360", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "92a69b8d-d9cd-4bda-b676-d372cbe3494c", "5ce2563c-195b-4f98-90e5-ee5762a271dd" });
        }
    }
}
