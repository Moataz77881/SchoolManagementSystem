using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNullColumnsInSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "GradedByTeacherId",
                table: "submissions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<float>(
                name: "Grade",
                table: "submissions",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bb0eb72-ff01-42ef-a2ed-49f24f79b1ae", null, "Student", "STUDENT" },
                    { "7a370e04-c022-4220-b727-3b0b1c9b292e", null, "Teacher", "TEACHER" },
                    { "cbafa0c4-4679-4af4-9aae-c7204754e22b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "1bca70c5-93c8-4a5a-883d-5051e1850975", 0, "6eb2d4d5-82ca-4ade-a21e-c4781911bd1a", new DateTime(2025, 11, 29, 22, 35, 48, 490, DateTimeKind.Local).AddTicks(9979), "admin@test.com", false, false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAEMbzvDhGY4vBAp9+XTTR1xyJFQAbk+rufp6r06PjqeUhFVq5AvTAxzYs70UVrYtn1g==", null, false, "admin", "d4a1f980-acf0-46ea-b423-9b233724af86", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbafa0c4-4679-4af4-9aae-c7204754e22b", "1bca70c5-93c8-4a5a-883d-5051e1850975" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bb0eb72-ff01-42ef-a2ed-49f24f79b1ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a370e04-c022-4220-b727-3b0b1c9b292e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbafa0c4-4679-4af4-9aae-c7204754e22b", "1bca70c5-93c8-4a5a-883d-5051e1850975" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbafa0c4-4679-4af4-9aae-c7204754e22b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bca70c5-93c8-4a5a-883d-5051e1850975");

            migrationBuilder.AlterColumn<string>(
                name: "GradedByTeacherId",
                table: "submissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Grade",
                table: "submissions",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

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
        }
    }
}
