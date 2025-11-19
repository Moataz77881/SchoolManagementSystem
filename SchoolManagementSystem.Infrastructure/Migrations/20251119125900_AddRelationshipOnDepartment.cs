using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipOnDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_ApplicationUserId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ApplicationUserId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "175e1589-dffd-4998-abab-63a6a60e4104");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e176bc-4c64-4ff3-8d66-0b99506bfde9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2178ed2d-0407-4a85-94c1-17bb3b338899", "616fd579-a2ac-4c1c-a6c3-3821ab6ac52b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2178ed2d-0407-4a85-94c1-17bb3b338899");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "616fd579-a2ac-4c1c-a6c3-3821ab6ac52b");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "HeadOfDepartmentId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments");

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

            migrationBuilder.AlterColumn<string>(
                name: "HeadOfDepartmentId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "175e1589-dffd-4998-abab-63a6a60e4104", null, "Teacher", "TEACHER" },
                    { "2178ed2d-0407-4a85-94c1-17bb3b338899", null, "Admin", "ADMIN" },
                    { "61e176bc-4c64-4ff3-8d66-0b99506bfde9", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "616fd579-a2ac-4c1c-a6c3-3821ab6ac52b", 0, "6adc57bb-30dd-42a3-bd00-2a4adb7e2451", new DateTime(2025, 11, 19, 11, 46, 22, 354, DateTimeKind.Local).AddTicks(3597), "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAED/03oToXwZl5kcbpr384yHRbI6ONuBApSnV8giCf/90IRmdU99ntAqGuH7ho/3TLg==", null, false, "admin", "5606af47-886a-40dd-ab5d-01d6173ea56b", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2178ed2d-0407-4a85-94c1-17bb3b338899", "616fd579-a2ac-4c1c-a6c3-3821ab6ac52b" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ApplicationUserId",
                table: "Departments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_ApplicationUserId",
                table: "Departments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
