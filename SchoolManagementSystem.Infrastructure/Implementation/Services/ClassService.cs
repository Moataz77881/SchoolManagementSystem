using AutoMapper;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.DTOs.ClassDto;
using SchoolManagementSystem.Application.Interfaces.Services;
using SchoolManagementSystem.Application.Interfaces.UOW;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Services
{
    public class ClassService(IUnitOfWork _unitOfWork, IMapper _mapper, IHttpContextAccessor _httpContextAccessor) : IClassService
    {
        public async Task<ServiceResponse> CreateClassesServiceAsync(List<ClassRequestDto> classrequestDtos)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var dep = await _unitOfWork.DepartmentRepository.GetByIdFirstOrDefaultAsync(Predecate: x => x.HeadOfDepartmentId == teacherId);

            var Classes = _mapper.Map<List<Class>>(classrequestDtos);

            foreach (var c in Classes) 
            {
                var courses = await _unitOfWork.CourseRepository.GetByIdFirstOrDefaultAsync(Predecate: x => x.Id == c.CourseId && x.DepartmentId == dep.Id);
                if (courses is null) 
                {
                    return new ServiceResponse
                    {
                        Data = null,
                        Message = $"Cannot add class in this course id {c.Id}, Teacher is not head of department",
                        StatusCode = 404,
                        Success = false
                    };

                }
            }
            await _unitOfWork.ClassRepository.AddRangeAsync(Classes);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse
            {
                Data = null,
                Message = "Classes was added successfully",
                StatusCode = 200,
                Success = true
            };

        }

        public async Task<ServiceResponse> deactivateClassesServiceAsync(List<int> ids)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var classes =await  _unitOfWork.ClassRepository.GetAllWithFilterAsync(Predecate: x => ids.Contains(x.Id));

            foreach (var c in classes) 
            {
                if (c.TeacherId != teacherId) 
                {
                    return new ServiceResponse
                    {
                        Data = null,
                        Message = $"Teacher isnot exists on this class id {c.Id}",
                        StatusCode = 200,
                        Success = true
                    };
                }
            }
            
            await _unitOfWork.ClassRepository.Deactivate(ids);
            await _unitOfWork.SaveAsync();
            return new ServiceResponse
            {
                Data = null,
                Message = "Classes was Deactivated successfully",
                StatusCode = 200,
                Success = true
            };
        }

        public async Task<ServiceResponse> GetAllClassesServiceAsync(int pageNumber, int pageSize)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var classes = await _unitOfWork.ClassRepository.GetAllWithSelectorAndPaginationAsync(
                Predecate: x => x.IsActive == false && x.TeacherId == teacherId
                , selector:
                s => new ClassResponseDto
                {
                    Course = s.Course!.Name,
                    CreatedDate = s.CreatedDate,
                    EndDate = s.EndDate,
                    IsActive = s.IsActive,
                    Name = s.Name,
                    Semester = s.Semester,
                    StartDate = s.StartDate,
                    TeacherName = s.ApplicationUser!.UserName!,
                    UpdatedDate = s.UpdatedDate
                }, pageNumber: pageNumber, pageSize: pageSize);

            return new ServiceResponse
            {
                Data = classes,
                Message = "Data was Received successfully",
                StatusCode = 200,
                Success = true

            };
        }

        public async Task<ServiceResponse> UpdateClassesServiceAsync(int id, ClassUpdateRequestDtos classRequestDtos)
        {
            var teacherId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var classModel = await _unitOfWork.ClassRepository.GetByIdFirstOrDefaultAsync(x=>x.Id == id && x.TeacherId == teacherId);

            if (classRequestDtos.TeacherId is not null)
                classModel.TeacherId = classRequestDtos.TeacherId;

            if (classRequestDtos.CourseId is not null)
                classModel.CourseId = classRequestDtos.CourseId ?? 0;

            if (classRequestDtos.Semester is not null)
                classModel.Semester = classRequestDtos.Semester ?? 0;

            if (classRequestDtos.Name is not null)
                classModel.Name = classRequestDtos.Name;

            classModel.StartDate = classRequestDtos.StartDate;
            classModel.EndDate = classRequestDtos.EndDate;

            classModel.UpdatedDate = DateTime.Now;

            await _unitOfWork.SaveAsync();

            return new ServiceResponse
            {
                Data = null,
                Message = "Class was updated successfully",
                StatusCode = 200,
                Success = true
            };

        }
    }
}
