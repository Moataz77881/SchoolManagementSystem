using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Entities.AuthEntities;
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

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Submission> submissions { get; set; }


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
                RoleName = "Admin".ToLower()
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

            builder.Entity<Class>()
                .HasOne(c => c.ApplicationUser)
                .WithMany()
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // ======= Assignments =======
            builder.Entity<Assignment>()
                .HasOne(a => a.ApplicationUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedByTeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Assignment>()
                .HasOne(a => a.Class)
                .WithMany()
                .HasForeignKey(a => a.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // ======= Attendances =======
            builder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.Teacher)
                .WithMany()
                .HasForeignKey(a => a.MarkedByTeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.Class)
                .WithMany()
                .HasForeignKey(a => a.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // ======= StudentClasses =======
            builder.Entity<StudentClass>()
                .HasOne(sc => sc.ApplicationUser)
                .WithMany()
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentClass>()
                .HasOne(sc => sc.Class)
                .WithMany()
                .HasForeignKey(sc => sc.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // ======= Submissions =======
            builder.Entity<Submission>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Submission>()
                .HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.GradedByTeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Submission>()
                .HasOne(s => s.Assignment)
                .WithMany()
                .HasForeignKey(s => s.AssignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //=======Departnment========//

            builder.Entity<Department>()
                .HasOne(x=>x.ApplicationUser)
                .WithOne()
                .HasForeignKey<Department>(s => s.HeadOfDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
