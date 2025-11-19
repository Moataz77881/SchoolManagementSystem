using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Implementation.Repositories;
using SchoolManagementSystem.Infrastructure.Persistence;

namespace SchoolManagementSystem.Infrastructure.Implementation.UOW
{
    public class UnitOfWork(ApplicationDBContext _dbContext) : IUnitOfWork
    {
        public IAssignmentRepository AssignmentRepository => new AssignmentRepository(_dbContext);

        public IAttendanceRepository AttendanceRepository => new AttendanceRepository(_dbContext);

        public IClassRepository ClassRepository => new ClassRepository(_dbContext);

        public ICourseRepository CourseRepository => new CourseRepository(_dbContext);

        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_dbContext);

        public IStudentClassRepository StudentClassRepository => new StudentClassRepository(_dbContext);

        public ISubmissionRepository SubmissionRepository => new SubmissionRepositroy(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
