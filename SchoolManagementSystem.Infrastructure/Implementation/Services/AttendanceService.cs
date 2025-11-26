using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Application.DTOs.AttendanceDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Entities.AuthEntities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class AttendanceService(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,UserManager<ApplicationUser> _userManager,
        IHttpContextAccessor _httpContextAccessor) : IAttendanceService
    {
        public async Task<ServiceResponse> GetAllAttendanceServiceAsync(int classId)
        {
            var attendance = await _unitOfWork.AttendanceRepository.GetAllWithSelectorAsync(
                Predecate: x => x.ClassId == classId,
                selector: x => new AttendanceResponseDto
                {
                    ClassId = x.ClassId,
                    CreateDate = x.CreateDate,
                    Date = x.Date,
                    Status = x.Status,
                    StudentName = x.Student!.UserName!,
                    TeacherName = x.Teacher!.UserName!
                });

            return new ServiceResponse 
            {
                Data = attendance,
                Message = "Data was Received successfully",
                StatusCode =200,
                Success = true
            };
        }

        public async Task<ServiceResponse> MarkAttendanceServiceAsync(List<AttendanceRequestDto> attendanceRequestDtos)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            foreach (var a in attendanceRequestDtos) 
            {
                var user = await _userManager.FindByIdAsync(a.StudentId);
                if(user is null)
                    return new ServiceResponse
                    {
                        Data = null,
                        Message = $"user id : {a.StudentId} does not exist",
                        StatusCode = 200,
                        Success = true
                    };
                if (user!.RoleName == "Student")
                    return new ServiceResponse
                    {
                        Data = null,
                        Message = $"Student id : {user.Id} must be a student",
                        StatusCode = 200,
                        Success = true
                    };
                var attendace = await _unitOfWork.AttendanceRepository.GetAllWithFilterAsync
                    (Predecate: x=>x.StudentId == a.StudentId && x.ClassId == a.ClassId);

                if(attendace.Count > 0)
                    return new ServiceResponse
                    {
                        Data = null,
                        Message = $"Student id : {user.Id} Already exists in this class",
                        StatusCode = 200,
                        Success = true
                    };
                a.MarkedByTeacherId = userId;
            }
            var AttendanceModels = _mapper.Map<List<Attendance>>(attendanceRequestDtos);
            await _unitOfWork.AttendanceRepository.AddRangeAsync(AttendanceModels);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse
            {
                Data = null,
                Message = "Data was Added successfully",
                StatusCode = 200,
                Success = true
            };

        }
    }
}
