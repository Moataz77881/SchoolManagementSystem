using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Persistence
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = Guid.NewGuid().ToString();
            var teacherRoleId = Guid.NewGuid().ToString();
            var studentRoleId = Guid.NewGuid().ToString();
            var adminId = Guid.NewGuid().ToString();


            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole 
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = teacherRoleId,
                        Name = "Teacher",
                        NormalizedName = "TEACHER"
                    },
                    new IdentityRole
                    {
                        Id = studentRoleId,
                        Name = "Student",
                        NormalizedName = "STUDENT"
                    }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                CreateDate = DateTime.Now,
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            builder.Entity<ApplicationUser>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminId,
                    RoleId = adminRoleId
                }
            );

        }
    }
}
