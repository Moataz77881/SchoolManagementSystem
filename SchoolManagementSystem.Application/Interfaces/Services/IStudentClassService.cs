using SchoolManagementSystem.Application.DTOs.StudentClassDTOs;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IStudentClassService
    {
        Task<ServiceResponse> AssignStudentToClassServiceAsync(List<StudentClassRequestDto> studentClassRequestDtos);
        Task<ServiceResponse> ViewEnrolledStudentClassServiceAsync();
    }
}
