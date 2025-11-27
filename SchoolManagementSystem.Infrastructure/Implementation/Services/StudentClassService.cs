using AutoMapper;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.DTOs.StudentClassDTOs;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class StudentClassService(IUnitOfWork _unitOfWork, IMapper _mapper, IHttpContextAccessor _httpContextAccessor) : IStudentClassService
    {
        public async Task<ServiceResponse> AssignStudentToClassServiceAsync(List<StudentClassRequestDto> studentClassRequestDtos)
        {
           var studentClassModel =  _mapper.Map<List<StudentClass>>(studentClassRequestDtos);
            await _unitOfWork.StudentClassRepository.AddRangeAsync(studentClassModel);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse 
            {
                Data = null,
                StatusCode = 200,
                Message = "Students Was Add Successfully in the classes",
                Success = true
            };
        }

        public async Task<ServiceResponse> ViewEnrolledStudentClassServiceAsync()
        {
            var studentId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var studentClasses = await _unitOfWork.StudentClassRepository.GetAllWithSelectorAsync(
                selector: x=> new StudentClassResponseDto 
                {
                    ClassName =  x.Class!.Name,
                    Username = x.ApplicationUser!.UserName!,
                    EnrollmentDate = x.EnrollmentDate,
                },
                Predecate: x => x.StudentId == studentId);

            return new ServiceResponse 
            {
                Data = studentClasses,
                StatusCode = 200,
                Message = "Student Classes was received Successfully",
                Success = true
            };
        }
    }
}
