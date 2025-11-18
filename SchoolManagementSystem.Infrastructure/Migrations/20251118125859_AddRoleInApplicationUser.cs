using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27863c3e-6f5b-441f-bf6c-d4a96349100f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3bd76-2fb2-4310-b2f0-7087a7e764ac");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "03bc77fa-529d-46f4-98c7-440f3cfd0059", "80c3d2ee-8f77-413c-bd61-7450b4c6fadf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03bc77fa-529d-46f4-98c7-440f3cfd0059");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c3d2ee-8f77-413c-bd61-7450b4c6fadf");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39623ece-af72-458c-a8bb-53504f3aa39f", null, "Student", "STUDENT" },
                    { "46610486-01ae-470e-a587-d827957e22be", null, "Admin", "ADMIN" },
                    { "5ff12561-5f12-47a5-8c14-7c66432ad455", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "27a84d0c-45b2-4d45-bd12-d8eeee9275e7", 0, "fbe14ba8-9278-430d-a9ba-9c4bd9799d19", new DateTime(2025, 11, 18, 14, 58, 57, 775, DateTimeKind.Local).AddTicks(3603), "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAECnOV01WXd5h6VEIQuVdqAUpIhDZ7fAZOTBatup9rza6lcCXgQ5r/ObjAl/qUxiOHA==", null, false, "admin", "4ba53a33-8f2c-4b50-8dd5-8554b5cbfd5b", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46610486-01ae-470e-a587-d827957e22be", "27a84d0c-45b2-4d45-bd12-d8eeee9275e7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39623ece-af72-458c-a8bb-53504f3aa39f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ff12561-5f12-47a5-8c14-7c66432ad455");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46610486-01ae-470e-a587-d827957e22be", "27a84d0c-45b2-4d45-bd12-d8eeee9275e7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46610486-01ae-470e-a587-d827957e22be");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27a84d0c-45b2-4d45-bd12-d8eeee9275e7");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03bc77fa-529d-46f4-98c7-440f3cfd0059", null, "Admin", "ADMIN" },
                    { "27863c3e-6f5b-441f-bf6c-d4a96349100f", null, "Student", "STUDENT" },
                    { "adf3bd76-2fb2-4310-b2f0-7087a7e764ac", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "80c3d2ee-8f77-413c-bd61-7450b4c6fadf", 0, "27aa0e05-b22b-4f1e-9460-4f808b793017", new DateTime(2025, 11, 17, 12, 56, 33, 880, DateTimeKind.Local).AddTicks(5731), "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAEPSjW/Q5Gsfy9F1I7IJ1bOljACIYQUuEV1mtXvSnyts7MWC7iybqDardPjLU1yE5eQ==", null, false, "37753dfb-0bdb-4f5f-8007-04b91054e982", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "03bc77fa-529d-46f4-98c7-440f3cfd0059", "80c3d2ee-8f77-413c-bd61-7450b4c6fadf" });
        }
    }
}
