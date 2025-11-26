using SchoolManagementSystem.Application.DTOs.AttendanceDTOs;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task<ServiceResponse> GetAllAttendanceServiceAsync(int classId);
        Task<ServiceResponse> MarkAttendanceServiceAsync(List<AttendanceRequestDto> attendanceRequestDtos);

    }
}
