using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectTheNameOfProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c28977-43e7-4caa-94df-62d4a4a1fc56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b982d07c-1ef5-4134-a7a0-f2ed99b8cf05");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "933eef42-f8fd-476d-b8cb-284ac7d828cb", "ab1909ba-25ce-45f5-9b06-f833ba21452d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "933eef42-f8fd-476d-b8cb-284ac7d828cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab1909ba-25ce-45f5-9b06-f833ba21452d");

            migrationBuilder.RenameColumn(
                name: "CreatedDare",
                table: "Departments",
                newName: "CreatedDate");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Departments",
                newName: "CreatedDare");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "933eef42-f8fd-476d-b8cb-284ac7d828cb", null, "Admin", "ADMIN" },
                    { "b1c28977-43e7-4caa-94df-62d4a4a1fc56", null, "Teacher", "TEACHER" },
                    { "b982d07c-1ef5-4134-a7a0-f2ed99b8cf05", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "ab1909ba-25ce-45f5-9b06-f833ba21452d", 0, "211c3848-f1a3-47cb-8380-2f73ad850007", new DateTime(2025, 11, 19, 14, 58, 59, 270, DateTimeKind.Local).AddTicks(2975), "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAEPOI1qJADQPN3EravS/Y+3bJiD2FEfvvAT5nE5WyYqR2I/Dgc0FJXG6Qx3C/g9zqHQ==", null, false, "admin", "df062882-521a-412d-b4b9-f1784554d3b9", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "933eef42-f8fd-476d-b8cb-284ac7d828cb", "ab1909ba-25ce-45f5-9b06-f833ba21452d" });
        }
    }
}
