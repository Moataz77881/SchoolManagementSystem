using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IAssignmentRepository AssignmentRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
        IClassRepository ClassRepository { get; }
        ICourseRepository CourseRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IStudentClassRepository StudentClassRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }
        Task SaveAsync();
    }
}
